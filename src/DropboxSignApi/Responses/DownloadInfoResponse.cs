using Newtonsoft.Json;
using System;

namespace Soukoku.DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the get file api call download url.
    /// </summary>
    public class FileUrlResponseWrap : ResponseWrap
    {
        /// <summary>
        /// URL of the download url.
        /// </summary>
        public string FileUrl { get; set; }

        /// <summary>
        /// When the link expires.
        /// </summary>
        public DateTime ExpiresAt { get; set; }
    }
}
