namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Config for file attachment in new requests.
    /// </summary>
    public class SubAttachment
    {
        /// <summary>
        /// The name of attachment.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The signer's index in the signers parameter (0-based indexing).
        /// </summary>
        public int SignerIndex { get; set; }

        /// <summary>
        /// The instructions for uploading the attachment.
        /// </summary>
        public string Instructions { get; set; }

        /// <summary>
        /// Determines if the attachment must be uploaded.
        /// </summary>
        public bool Required { get; set; }
    }
}
