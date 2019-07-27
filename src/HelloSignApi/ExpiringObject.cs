using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace HelloSignApi
{
    /// <summary>
    /// An object with an expiration time.
    /// </summary>
    public class ExpiringObject
    {
        /// <summary>
        /// Actual value for <see cref="ExpiresAt"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty("expires_at")]
        public long ExpiresAtRaw { get; set; }

        /// <summary>
        /// Gets when the link expires.
        /// </summary>
        [JsonIgnore]
        public DateTime ExpiresAt { get { return ExpiresAtRaw.FromUnixTime(); } }
    }
}
