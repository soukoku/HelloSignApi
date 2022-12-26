using System.Collections.Generic;
using DropboxSignApi.Common;

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Object used to create a new embedded template draft.
    /// </summary>
    public class NewEmbeddedTemplateDraft : NewUnclaimedDraftBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewEmbeddedTemplateDraft"/> class.
        /// </summary>
        public NewEmbeddedTemplateDraft()
        {
            SignerRoles = new List<SignerRole>();
            CcRoles = new List<string>();
            MergeFields = new List<MergeField>();
            Attachments = new List<SubAttachment>();
        }

        /// <summary>
        /// The title you want to assign to the SignatureRequest.
        /// </summary>
        public string Title { get; set; }

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
        /// Attachment info for new template.
        /// </summary>
        public IList<SubAttachment> Attachments { get; private set; }

    }
}
