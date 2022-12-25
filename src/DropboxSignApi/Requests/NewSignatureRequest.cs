using System.Collections.Generic;

// this file contains objects for creating new things.

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Object used to create a new signature request.
    /// </summary>
    public class NewSignatureRequest : NewRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewSignatureRequest"/> class.
        /// </summary>
        public NewSignatureRequest()
        {
            Files = new PendingFileCollection();
            CcEmailAddresses = new List<string>();
            FormFieldsPerDocument = new List<IList<RequestFormField>>();
        }

        /// <summary>
        /// The client ID of the ApiApp you want to associate with this request.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets the files to be uploaded.
        /// </summary>
        public PendingFileCollection Files { get; private set; }

        /// <summary>
        /// The title you want to assign to the SignatureRequest.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The email addresses that should be CCed.
        /// </summary>
        public IList<string> CcEmailAddresses { get; private set; }

        /// <summary>
        /// Set to <code>true</code> if you wish to enable Text Tags parsing in your document.
        /// </summary>
        public bool UseTextTags { get; set; }
        /// <summary>
        /// Set to <code>true</code> if you wish to enable automatic Text Tag removal. 
        /// When using Text Tags it is preferred that you set this to <code>false</code> 
        /// and hide your tags with white text or something similar because the automatic 
        /// removal system can cause unwanted clipping.
        /// </summary>
        public bool HideTextTags { get; set; }

        /// <summary>
        /// The fields that should appear on the document.
        /// See <see cref="!:https://faq.hellosign.com/hc/en-us/articles/217115577"/>.
        /// </summary>
        public IList<IList<RequestFormField>> FormFieldsPerDocument { get; set; }
    }
}
