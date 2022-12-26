using DropboxSignApi.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;

namespace DropboxSignApi.Utils
{
    /// <summary>
    /// Easy MultipartFormDataContent with custom handling of 
    /// API request models.
    /// </summary>
    public class ApiMultipartContent : MultipartFormDataContent
    {
        private readonly IApiLog log;

        /// <summary>
        /// Creates a new multipart content with the object data
        /// that's suitable for making API requests.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="log"></param>
        public ApiMultipartContent(object obj, IApiLog log)
        {
            this.log = log ?? NullApiLog.Instance;
            AddObjectProperties(obj, null);
        }

        private void AddObjectProperties(object obj, string arrayPrefix)
        {
            var skipRole = obj is IRoleIndexedSigner;

            foreach (var prop in GetProperties(obj))
            {
                if (skipRole && prop.Name == "role") continue;

                var value = prop.GetValue(obj);
                if (value == null || prop.ShouldIgnore(obj)) continue;

                var name = arrayPrefix == null ?
                    prop.Name :
                    $"{arrayPrefix}[{prop.Name}]";

                if (value is bool bValue)
                {
                    AddParameter(name, bValue ? "1" : "0");
                }
                else if (prop.IsPrimitive)
                {
                    AddParameter(name, value.ToString());
                }
                else if (value is string sValue)
                {
                    AddParameter(name, sValue);
                }
                else if (value is IDictionary<string, string> dValue)
                {
                    foreach (var kv in dValue)
                    {
                        AddParameter($"{name}[{kv.Key}]", kv.Value);
                    }
                }
                else if (value is IEnumerable<PendingFile> files)
                {
                    AddFiles(files);
                }
                else if (value is IEnumerable ieValue)
                {
                    // array format
                    var count = 0;
                    foreach (var subObj in ieValue)
                    {
                        if (subObj is IRoleIndexedSigner roleSigner)
                        {
                            AddObjectProperties(subObj, $"{name}[{roleSigner.Role}]");
                        }
                        else
                        {
                            AddObjectProperties(subObj, $"{name}[{count++}]");
                        }
                    }
                }
                else
                {
                    // TODO: finish this
                    // json-serialize and add the string as value???
                    AddParameter(name, value.ToJson());
                }
            }
        }

        private static IEnumerable<PropertyInfoEx> GetProperties(object obj)
        {
            return obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Select(p => new PropertyInfoEx(p));
        }

        private class PropertyInfoEx
        {
            static readonly NamingStrategy __namer = new SnakeCaseNamingStrategy();

            public PropertyInfoEx(PropertyInfo prop)
            {
                Info = prop;
                JPAttribute = prop.GetCustomAttribute(typeof(JsonPropertyAttribute)) as JsonPropertyAttribute;
                if (JPAttribute != null && !string.IsNullOrEmpty(JPAttribute.PropertyName)) Name = JPAttribute.PropertyName;
                else Name = __namer.GetPropertyName(prop.Name, false);

                hasIgnoreAttr = prop.GetCustomAttribute(typeof(JsonIgnoreAttribute)) != null;
            }

            PropertyInfo Info;

            JsonPropertyAttribute JPAttribute;
            bool hasIgnoreAttr;

            public bool IsPrimitive { get { return Info.PropertyType.IsPrimitive; } }

            /// <summary>
            /// Serialized name.
            /// </summary>
            public string Name { get; set; }

            public bool ShouldIgnore(object obj)
            {
                if (hasIgnoreAttr) return true;

                if (JPAttribute != null)
                {
                    if (JPAttribute.DefaultValueHandling == DefaultValueHandling.Ignore)
                    {
                        var dva = Info.GetCustomAttribute(typeof(DefaultValueAttribute)) as DefaultValueAttribute;
                        if (dva != null) return dva.Value != null && dva.Value.Equals(GetValue(obj));

                        if (Info.PropertyType.IsValueType && Nullable.GetUnderlyingType(Info.PropertyType) == null)
                        {
                            var defaultValue = Activator.CreateInstance(Info.PropertyType);
                            return defaultValue.Equals(GetValue(obj));
                        }
                    }
                }
                return false;
            }

            public object GetValue(object obj)
            {
                var value = Info.GetValue(obj);
                return value;
            }
        }


        /// <summary>
        /// Adds a single parameter value.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="fileName"></param>
        void AddParameter(string name, string value, string fileName = null)
        {
            // empty string is still passed
            if (value != null)
            {
                log.MultipartAdded(name, value);
                var sc = new StringContent(value);
                sc.Headers.ContentType = null;
                if (fileName == null)
                {
                    Add(sc, name);
                }
                else
                {
                    Add(sc, name, fileName);
                }
            }
        }

        /// <summary>
        /// File is special and needs to be handled differently.
        /// </summary>
        /// <param name="files"></param>
        void AddFiles(IEnumerable<PendingFile> files)
        {
            try
            {
                int i = 0;
                foreach (var file in files)
                {
                    if (file.RemotePath != null)
                    {
                        AddParameter($"file_url[{i}]", file.RemotePath.ToString());
                    }
                    else if (file.LocalPath != null)
                    {
                        var fc = new StreamContent(File.Open(file.LocalPath, FileMode.Open, FileAccess.Read, FileShare.Read));
                        fc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                        Add(fc, $"file[{i}]", file.FileName);
                    }
                    else if (file.Data != null)
                    {
                        var fc = new ByteArrayContent(file.Data);
                        fc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                        Add(fc, $"file[{i}]", file.FileName);
                    }
                    else if (file.Stream != null)
                    {
                        var fc = new StreamContent(file.Stream);
                        fc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                        Add(fc, $"file[{i}]", file.FileName);
                    }
                    i++;
                }
            }
            catch
            {
                Dispose();
                throw;
            }
        }
    }
}