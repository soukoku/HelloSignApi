using Newtonsoft.Json;

namespace DropboxSignApi.Common
{
    /// <summary>
    /// Represents a custom field.
    /// </summary>
    public class CustomField
    {
        /// <summary>
        /// The name of the Custom Field.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The type of this Custom Field. Only <see cref="FieldTypes.Text"/> and <see cref="FieldTypes.CheckBox"/> 
        /// are currently supported.
        /// </summary>
        [JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
        /// <summary>
        /// A text string for text fields or true/false for checkbox fields
        /// </summary>
        [JsonProperty("value", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public object Value { get; set; }
        /// <summary>
        /// A boolean value denoting if this field is required.
        /// </summary>
        [JsonProperty("required", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Required { get; set; }
        /// <summary>
        /// The name of the Role that is able to edit this field.
        /// </summary>
        [JsonProperty("editor", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Editor { get; set; }
    }
}
