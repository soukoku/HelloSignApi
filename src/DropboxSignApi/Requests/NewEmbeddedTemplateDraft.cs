using System.Collections.Generic;
using DropboxSignApi.Common;

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Object used to create a new embedded template draft.
    /// </summary>
    public class NewEmbeddedTemplateDraft
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewEmbeddedTemplateDraft"/> class.
        /// </summary>
        public NewEmbeddedTemplateDraft()
        {
            Files = new PendingFileCollection();
            SignerRoles = new List<SignerRole>();
            CcRoles = new List<string>();
            MergeFields = new List<MergeField>();
            Metadata = new Dictionary<string, string>();
            Attachments = new List<NewAttachment>();
        }

        /// <summary>
        /// Whether this is a test, the signature request created from this draft will not be legally binding if <code>true</code>.
        /// </summary>
        public bool TestMode { get; set; }

        /// <summary>
        /// Gets the files to be uploaded.
        /// </summary>
        public PendingFileCollection Files { get; private set; }
        /// <summary>
        /// The title you want to assign to the SignatureRequest.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The subject in the email that will be sent to the signers.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// The custom message in the email that will be sent to the signers.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The roles when the template is used to create a signature request.
        /// </summary>
        public IList<SignerRole> SignerRoles { get; private set; }

        /// <summary>
        /// The CC roles that must be assigned when using the template to send a signature request.
        /// </summary>
        public IList<string> CcRoles { get; private set; }

        /// <summary>
        /// The merge fields that can be placed on the template's document(s) by the user claiming the template draft. These are typically fields that can be pre-populated by your application when using the resulting template to send a signature request. Each merge field object must have two parameters: name and type. Names must be unique and type can only be "text" or "checkbox".
        /// </summary>
        public IList<MergeField> MergeFields { get; private set; }

        /// <summary>
        /// Enable the detection of predefined PDF fields 
        /// </summary>
        public bool UsePreexistingFields { get; set; }

        /// <summary>
        /// Key-value data that should be attached to the signature request. 
        /// This metadata is included in all API responses and events involving the signature request. 
        /// For example, use the metadata field to store a signer's order number for look up when 
        /// receiving events for the signature request.
        /// Each request can include up to 10 metadata keys, with key names up to 40 characters long and 
        /// values up to 500 characters long.
        /// </summary>
        public IDictionary<string, string> Metadata { get; private set; }

        /// <summary>
        /// The client ID of the ApiApp you want to associate with this request.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Attachment info for new template.
        /// </summary>
        public IList<NewAttachment> Attachments { get; private set; }

    }
}
