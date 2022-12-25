using Newtonsoft.Json;
using System;
using System.ComponentModel;

// this file contains reponse data models.

namespace DropboxSignApi.Common
{
    /// <summary>
    /// Attachment info for a request.
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// Attachment id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The 1-based (?) signer index in the request.
        /// </summary>
        public int Signer { get; set; }

        /// <summary>
        /// The name of attachment.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The instructions for uploading the attachment.
        /// </summary>
        public string Instructions { get; set; }

        /// <summary>
        /// Determines if the attachment must be uploaded.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// Actual value of <see cref="UploadedAt"/>.
        /// </summary>
        [JsonProperty("uploaded_at"), EditorBrowsable(EditorBrowsableState.Never)]
        public long? UploadedAtRaw { get; set; }

        /// <summary>
        /// Time that the attachment was uploaded.
        /// </summary>
        [JsonIgnore]
        public DateTime? UploadedAt { get { return UploadedAtRaw?.FromUnixTime(); } }

    }
}
