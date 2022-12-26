using Newtonsoft.Json;

namespace DropboxSignApi.Common
{
    /// <summary>
    /// Represents a custom field.
    /// </summary>
    public class CustomField : SubCustomField
    {
        /// <summary>
        /// The type of this Custom Field. Only <see cref="FieldTypes.Text"/> and <see cref="FieldTypes.CheckBox"/> 
        /// are currently supported.
        /// </summary>
        [JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
     }
}
