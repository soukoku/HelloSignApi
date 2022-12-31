using Newtonsoft.Json;
using System;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Attachment info for a request.
    /// </summary>
    public class SignatureRequestResponseAttachment
    {
        /// <summary>
        /// The unique ID for this attachment.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The Signer this attachment is assigned to.
        /// </summary>
        public string Signer { get; set; }

        /// <summary>
        /// The name of attachment.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A boolean value denoting if this attachment is required.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// Instructions for Signer.
        /// </summary>
        public string Instructions { get; set; }

        /// <summary>
        /// Timestamp when attachment was uploaded by Signer.
        /// </summary>
        public DateTime? UploadedAt { get; set; }

    }
}
