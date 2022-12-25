using Newtonsoft.Json;

// this file contains reponse wrapper models.

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Error object for an <see cref="ApiResponse"/>.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Error details.
        /// </summary>
        [JsonProperty("error_msg")]
        public string Message { get; set; }

        /// <summary>
        /// Short name for error. See <see cref="ErrorNames"/>.
        /// </summary>
        [JsonProperty("error_name")]
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
