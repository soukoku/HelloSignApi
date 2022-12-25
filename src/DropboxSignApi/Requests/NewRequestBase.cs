using System.Collections.Generic;

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Base class for making new signature type requests.
    /// </summary>
    public abstract class NewRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewRequestBase"/> class.
        /// </summary>
        protected NewRequestBase()
        {
            Metadata = new Dictionary<string, string>();
            Signers = new List<Signer>();
            Attachments = new List<NewAttachment>();
        }

        /// <summary>
        /// Whether this is a test, the signature request created from this draft will not be legally binding if <code>true</code>.
        /// </summary>
        public bool TestMode { get; set; }

        /// <summary>
        /// Allows signers to decline to sign a document if set to true. Defaults to false.
        /// </summary>
        public bool AllowDecline { get; set; }

        /// <summary>
        /// The subject in the email that will be sent to the signers.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// The custom message in the email that will be sent to the signers.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The URL you want signers redirected to after they successfully sign.
        /// </summary>
        public string SigningRedirectUrl { get; set; }

        /// <summary>
        /// The signers to request signatures.
        /// </summary>
        public IList<Signer> Signers { get; private set; }

        /// <summary>
        /// Key-value data that should be attached to the signature request. 
        /// This metadata is included in all API responses and events involving the signature request. 
        /// For example, use the metadata field to store a signer's order number for look up when 
        /// receiving events for the signature request.
        /// Each request can include up to 10 metadata keys, with key names up to 40 characters long and 
        /// values up to 500 characters long.
        /// </summary>
        public IDictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Attachment info for new request.
        /// </summary>
        public IList<NewAttachment> Attachments { get; private set; }
    }
}
