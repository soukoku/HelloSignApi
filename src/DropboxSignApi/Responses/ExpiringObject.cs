using Newtonsoft.Json;
using System;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// An object with an expiration time.
    /// </summary>
    public class ExpiringObject
    {
        /// <summary>
        /// Gets when the link expires.
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.UnixDateTimeConverter))]
        public DateTime ExpiresAt { get; set; }
    }
}
