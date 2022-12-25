// this file contains objects for creating new things.

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Config for file attachment in new requests.
    /// </summary>
    public class NewAttachment
    {
        /// <summary>
        /// The name of attachment.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The instructions for uploading the attachment.
        /// </summary>
        public string Instructions { get; set; }

        /// <summary>
        /// The signer's unique number.
        /// </summary>
        public int SignerIndex { get; set; }

        /// <summary>
        /// Determines if the attachment must be uploaded.
        /// </summary>
        public bool Required { get; set; }
    }
}
