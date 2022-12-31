using Newtonsoft.Json;

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// A merge field in a template.
    /// </summary>
    public class MergeField
    {
        /// <summary>
        /// Name of merge field.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Type of merge field. Can only be <see cref="FieldTypes.Text"/> or <see cref="FieldTypes.CheckBox"/>.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }
}
