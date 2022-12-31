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
using System.Xml.Linq;

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
            AddProperties(obj, null);
        }

        /// <summary>
        /// Add all properties of the object as parts in the multipart data.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="arrayPrefix"></param>
        void AddProperties(object obj, string arrayPrefix)
        {
            if (obj is Uri uriValue)
            {
                AddParameter(arrayPrefix, uriValue.ToString());
                return;
            }


            var skipRole = obj is IRoleIndexedSigner;
            var properties = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Select(p => new PropertyInfoEx(p));

            foreach (var prop in properties)
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
                    AddFiles(name, files);
                }
                else if (value is IEnumerable ieValue)
                {
                    // array format
                    var count = 0;
                    foreach (var subObj in ieValue)
                    {
                        if (subObj is IRoleIndexedSigner roleSigner)
                        {
                            AddProperties(subObj, $"{name}[{roleSigner.Role}]");
                        }
                        else
                        {
                            AddProperties(subObj, $"{name}[{count++}]");
                        }
                    }
                }
                else
                {
                    // TODO: verify this
                    // json-serialize and add the string as value???
                    AddParameter(name, value.ToJson());
                }
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
            // empty string is still added, only null is excluded.
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

        void AddFiles(string propName, IEnumerable<PendingFile> files)
        {
            try
            {
                int i = 0;
                foreach (var file in files)
                {
                    var fc = new StreamContent(file.Stream);
                    fc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                    Add(fc, $"file[{i}]", file.FileName);
                    i++;
                }
            }
            catch
            {
                Dispose();
                throw;
            }
        }


        private class PropertyInfoEx
        {
            static readonly NamingStrategy __namer = new SnakeCaseNamingStrategy();

            public PropertyInfoEx(PropertyInfo prop)
            {
                _prop = prop;
                _jpAttr = prop.GetCustomAttribute(typeof(JsonPropertyAttribute)) as JsonPropertyAttribute;
                if (_jpAttr != null && !string.IsNullOrEmpty(_jpAttr.PropertyName)) Name = _jpAttr.PropertyName;
                else Name = __namer.GetPropertyName(prop.Name, false);

                _hasIgnoreAttr = prop.GetCustomAttribute(typeof(JsonIgnoreAttribute)) != null;
            }

            PropertyInfo _prop;
            JsonPropertyAttribute _jpAttr;
            bool _hasIgnoreAttr;

            public bool IsPrimitive { get { return _prop.PropertyType.IsPrimitive; } }

            /// <summary>
            /// Serialized name.
            /// </summary>
            public string Name { get; set; }

            public bool ShouldIgnore(object obj)
            {
                if (_hasIgnoreAttr) return true;

                if (_jpAttr != null)
                {
                    if (_jpAttr.DefaultValueHandling == DefaultValueHandling.Ignore)
                    {
                        var dva = _prop.GetCustomAttribute(typeof(DefaultValueAttribute)) as DefaultValueAttribute;
                        if (dva != null) return dva.Value != null && dva.Value.Equals(GetValue(obj));

                        if (_prop.PropertyType.IsValueType && Nullable.GetUnderlyingType(_prop.PropertyType) == null)
                        {
                            var defaultValue = Activator.CreateInstance(_prop.PropertyType);
                            return defaultValue.Equals(GetValue(obj));
                        }
                    }
                }
                return false;
            }

            public object GetValue(object obj)
            {
                var value = _prop.GetValue(obj);
                return value;
            }
        }
    }
}