using Soukoku.DropboxSignApi.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Security.Cryptography;

namespace Soukoku.DropboxSignApi.Internal
{
    internal class SubFormFieldConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var jObj = JObject.Load(reader);
            var type = jObj["type"].ToObject<string>();

            switch (type)
            {
                case FieldTypes.Text:
                    return jObj.ToObject<SubFormFieldText>();
                case FieldTypes.CheckBox:
                    return jObj.ToObject<SubFormFieldCheckbox>();
                case FieldTypes.DateSigned:
                    return jObj.ToObject<SubFormFieldDateSigned>();
                case FieldTypes.Dropdown:
                    return jObj.ToObject<SubFormFieldDropdown>();
                case FieldTypes.Initials:
                    return jObj.ToObject<SubFormFieldInitials>();
                case FieldTypes.Radio:
                    return jObj.ToObject<SubFormFieldRadio>();
                case FieldTypes.Signature:
                    return jObj.ToObject<SubFormFieldSignature>();
                case FieldTypes.TextMerge:
                    return jObj.ToObject<SubFormFieldTextMerge>();
                case FieldTypes.CheckBoxMerge:
                    return jObj.ToObject<SubFormFieldCheckboxMerge>();
                case FieldTypes.Hyperlink:
                    return jObj.ToObject<SubFormFieldHyperlink>();
            }

            throw new NotSupportedException($"Unknown form field type {type}.");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}