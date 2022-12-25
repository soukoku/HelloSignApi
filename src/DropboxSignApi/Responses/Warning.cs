using Newtonsoft.Json;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Warning object for an <see cref="ApiResponse"/>.
    /// </summary>
    public class Warning
    {
        /// <summary>
        /// Warning details.
        /// </summary>
        [JsonProperty("warning_msg")]
        public string Message { get; set; }

        /// <summary>
        /// Short name for warning. See <see cref="WarningNames"/>.
        /// </summary>
        [JsonProperty("warning_name")]
        public string Name { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Message ?? Name;
        }
    }
}
