using System.Collections.Generic;

namespace Soukoku.DropboxSignApi.Requests
{
    /// <summary>
    /// Object used to create a new embedded unclaimed draft with template.
    /// </summary>
    public class CreateTemplatedEmbeddedUnclaimedDraftRequest : CreateUnclaimedDraftBase
    {
        /// <summary>
        /// The email address of the user that should be designated as the requester of this draft.
        /// </summary>
        public string RequesterEmailAddress { get; set; }

        /// <summary>
        /// Use template_ids to create a SignatureRequest from one or more templates, 
        /// in the order in which the templates will be used.
        /// </summary>
        public IList<string> TemplateIds { get; } = new List<string>();

        /// <summary>
        /// Allows signers to reassign their signature requests to other signers if set to true. Defaults to false.
        /// </summary>
        public bool AllowReassign { get; set; }

        /// <summary>
        /// Add CC email recipients. Required when a CC role exists for the Template.
        /// </summary>
        public IList<SubCC> CCs { get; } = new List<SubCC>();

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
        /// The request from this draft will not automatically send to signers 
        /// post-claim if set to true. Requester must release the request 
        /// from hold when ready to send. Defaults to false.
        /// </summary>
        public bool HoldRequest { get; set; }

        /// <summary>
        /// The request created from this draft will also be signable in 
        /// embedded mode if set to <code>true</code>.
        /// </summary>
        public bool IsForEmbeddedSigning { get; set; }

        /// <summary>
        /// This allows the requester to enable the preview experience 
        /// (i.e. does not allow the requester's end user to add any additional fields via the editor).
        /// </summary>
        public bool PreviewOnly { get; set; }

        /// <summary>
        /// The URL you want signers redirected to after they successfully request a signature.
        /// </summary>
        public string RequestingRedirectUrl { get; set; }

        /// <summary>
        /// This allows the requester to enable the editor/preview experience.
        /// </summary>
        public bool ShowPreview { get; set; }

        /// <summary>
        /// Add Signers to your Templated-based Signature Request.
        /// </summary>
        public IList<SubUnclaimedDraftTemplateSigner> Signers { get; set; } = new List<SubUnclaimedDraftTemplateSigner>();

        /// <summary>
        /// Disables the "Me (Now)" option for the person preparing the document. 
        /// Does not work with type send_document. Defaults to false.
        /// </summary>
        public bool SkipMeNow { get; set; }

        /// <summary>
        /// The title you want to assign to the SignatureRequest.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Controls whether auto fill fields can automatically populate a signer's information during signing.
        /// </summary>
        public bool PopulateAutoFillFields { get; set; }
    }
}
