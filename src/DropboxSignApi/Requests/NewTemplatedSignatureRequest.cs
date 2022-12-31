using System.Collections.Generic;
using DropboxSignApi.Common;

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Object used to create a new signature request from template.
    /// </summary>
    public class NewTemplatedSignatureRequest
    {
        /// <summary>
        /// The client ID of the ApiApp you want to associate with this request.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The template ids to create a SignatureRequest from.
        /// </summary>
        public IList<string> TemplateIds { get; private set; } = new List<string>();

        /// <summary>
        /// The title you want to assign to the SignatureRequest.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The email address of the CC filling the role of RoleName. Required when a CC role exists for the Template.
        /// </summary>
        public IList<SubSignatureRequestSigner> Ccs { get; private set; } = new List<SubSignatureRequestSigner>();
        /// <summary>
        /// Values and options for custom fields. Required when a custom field exists in the Template.
        /// </summary>
        public IList<CustomField> CustomFields { get; private set; } = new List<CustomField>();
    }
}
