using System.Collections.Generic;
using DropboxSignApi.Common;

// this file contains objects for creating new things.

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Object used to create a new unclaimed draft.
    /// </summary>
    public class NewUnclaimedDraft : NewRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewUnclaimedDraft"/> class.
        /// </summary>
        public NewUnclaimedDraft()
        {
            Files = new PendingFileCollection();
            CcEmailAddresses = new List<string>();
            FormFieldsPerDocument = new List<RequestFormField>();
        }

        /// <summary>
        /// Gets the files to be uploaded.
        /// </summary>
        public PendingFileCollection Files { get; private set; }

        /// <summary>
        /// The type of unclaimed draft to create. Use values from <see cref="UnclaimedDraftTypes"/>.
        /// If the type is <see cref="UnclaimedDraftTypes.RequestSignature"/> then signers name and 
        /// email_address are not optional.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// If your PDF contains pre-defined fields, enable the detection of these fields by setting this to <code>true</code>.
        /// This is exclusive with <see cref="UseTextTags"/>.
        /// </summary>
        public bool UsePreexistingFields { get; set; }

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
        public IList<RequestFormField> FormFieldsPerDocument { get; set; }
    }
}
