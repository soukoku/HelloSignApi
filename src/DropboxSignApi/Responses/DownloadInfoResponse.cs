using Newtonsoft.Json;
using System;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the get file api call download url.
    /// </summary>
    public class FileUrlResponseWrap : ApiResponse
    {
        /// <summary>
        /// URL of the download url.
        /// </summary>
        public string FileUrl { get; set; }

        /// <summary>
        /// When the link expires.
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.UnixDateTimeConverter))]
        public DateTime ExpiresAt { get; set; }
    }
}
