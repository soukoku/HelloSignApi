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
        public DateTime ExpiresAt { get; set; }
    }
}
