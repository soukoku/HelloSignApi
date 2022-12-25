using System.Collections.Generic;
using DropboxSignApi.Common;

// this file contains objects for creating new things.

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Object used to create a new signature request from template.
    /// </summary>
    public class NewTemplatedSignatureRequest : NewRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewTemplatedSignatureRequest"/> class.
        /// </summary>
        public NewTemplatedSignatureRequest()
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
        /// The template ids to create a SignatureRequest from.
        /// </summary>
        public IList<string> TemplateIds { get; private set; }

        /// <summary>
        /// The title you want to assign to the SignatureRequest.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The email address of the CC filling the role of RoleName. Required when a CC role exists for the Template.
        /// </summary>
        public IList<Signer> Ccs { get; private set; }
        /// <summary>
        /// Values and options for custom fields. Required when a custom field exists in the Template.
        /// </summary>
        public IList<CustomField> CustomFields { get; private set; }
    }
}
