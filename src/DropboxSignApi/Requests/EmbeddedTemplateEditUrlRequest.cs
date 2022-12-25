using System.Collections.Generic;

namespace DropboxSignApi.Requests
{
    public class EmbeddedTemplateEditUrlRequest
    {
        /// <summary>
        /// This allows the requester to enable/disable to add or change CC roles when editing the template.
        /// </summary>
        public bool AllowEditCCs { get; set; }

        /// <summary>
        /// The CC roles that must be assigned when using the template to send a signature request. 
        /// To remove all CC roles, pass in a single role with no name. 
        /// </summary>
        public IList<string> CCRoles { get; set; }

        /// <summary>
        /// This allows the requester to specify editor options when a preparing a document.
        /// </summary>
        public SubEditorOptions EditorOptions { get; set; }

        /// <summary>
        /// Provide users the ability to review/edit the template signer roles.
        /// </summary>
        public bool ForceSignerRoles { get; set; }

        /// <summary>
        /// Provide users the ability to review/edit the template subject and message.
        /// </summary>
        public bool ForceSubjectMessage { get; set; }

        /// <summary>
        /// Add additional merge fields to the template, which can be used used to 
        /// pre-fill data by passing values into signature requests made with that template.
        /// Remove all merge fields on the template by passing an empty array.
        /// </summary>
        public IList<SubMergeField> MergeFields { get; set; }

        /// <summary>
        /// This allows the requester to enable the preview experience 
        /// (i.e. does not allow the requester's end user to add any additional fields via the editor).
        /// </summary>
        public bool PreviewOnly { get; set; }

        /// <summary>
        /// This allows the requester to enable the editor/preview experience.
        /// </summary>
        public bool ShowPreview { get; set; }

        /// <summary>
        /// When only one step remains in the signature request process and this parameter 
        /// is set to false then the progress stepper will be hidden.
        /// </summary>
        public bool ShowProgressStepper { get; set; } = true;

        /// <summary>
        /// Whether this is a test, locked templates will only be available for editing 
        /// if this is set to true. Defaults to false.
        /// </summary>
        public bool TestMode { get; set; }
    }
}
