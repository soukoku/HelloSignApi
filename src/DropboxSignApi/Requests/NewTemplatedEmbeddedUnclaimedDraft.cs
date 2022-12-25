using System.Collections.Generic;
using DropboxSignApi.Common;

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Object used to create a new embedded unclaimed draft with template.
    /// </summary>
    public class NewTemplatedEmbeddedUnclaimedDraft : NewRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewTemplatedEmbeddedUnclaimedDraft"/> class.
        /// </summary>
        public NewTemplatedEmbeddedUnclaimedDraft()
        {
            TemplateIds = new List<string>();
            Ccs = new List<Signer>();
            CustomFields = new List<CustomField>();
        }

        /// <summary>
        /// The client ID of the ApiApp you want to associate with this request.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The templates to create a request from. The order of the template is significant.
        /// </summary>
        public IList<string> TemplateIds { get; private set; }

        /// <summary>
        /// The title you want to assign to the SignatureRequest.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The URL you want signers redirected to after they successfully request a signature.
        /// </summary>
        public string RequestingRedirectUrl { get; set; }

        /// <summary>
        /// The email address of the CC filling the role of RoleName. Required when a CC role exists for the Template.
        /// </summary>
        public IList<Signer> Ccs { get; private set; }

        /// <summary>
        /// Values and options for custom fields. Required when a custom field exists in the Template.
        /// </summary>
        public IList<CustomField> CustomFields { get; private set; }

        /// <summary>
        /// The request created from this draft will also be signable in embedded mode if set to <code>true</code>.
        /// </summary>
        public bool IsForEmbeddedSigning { get; set; }
    }
}
