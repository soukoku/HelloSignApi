using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Soukoku.DropboxSignApi.Requests
{
    /// <summary>
    /// Object used to create a new embedded unclaimed draft.
    /// </summary>
    public class CreateEmbeddedUnclaimedDraftRequest : CreateUnclaimedDraftBase
    {
        /// <summary>
        /// The email address of the user that should be designated as the requester of this draft, 
        /// if the draft type is <see cref="UnclaimedDraftTypes.RequestSignature"/>.
        /// </summary>
        public string RequesterEmailAddress { get; set; }

        /// <summary>
        /// This allows the requester to specify whether the user 
        /// is allowed to provide email addresses to CC when claiming the draft.
        /// </summary>
        public bool AllowCcs { get; set; } = true;

        /// <summary>
        /// Allows signers to reassign their signature requests to other signers 
        /// if set to true. Defaults to false.
        /// </summary>
        public bool AllowReassign { get; set; }

        /// <summary>
        /// A list describing the attachments.
        /// </summary>
        public IList<SubAttachment> Attachments { get; } = new List<SubAttachment>();

        /// <summary>
        /// The email addresses that should be CCed.
        /// </summary>
        public IList<string> CcEmailAddresses { get; } = new List<string>();

        /// <summary>
        /// This allows the requester to specify editor options when a preparing a document.
        /// </summary>
        public SubEditorOptions EditorOptions { get; set; }

        /// <summary>
        /// Provide users the ability to review/edit the signers.
        /// </summary>
        public bool ForceSignerPage { get; set; }

        /// <summary>
        /// Provide users the ability to review/edit the subject and message.
        /// </summary>
        public bool ForceSubjectMessage { get; set; }

        /// <summary>
        /// Group information for fields defined in form_fields_per_document. 
        /// String-indexed JSON array with group_label and requirement keys. 
        /// form_fields_per_document must contain fields referencing a group 
        /// defined in form_field_groups.
        /// </summary>
        public IList<SubFormFieldGroup> FormFieldGroups { get; } = new List<SubFormFieldGroup>();

        /// <summary>
        /// Conditional Logic rules for fields defined in form_fields_per_document.
        /// </summary>
        public IList<SubFormFieldRule> FormFieldRules { get; } = new List<SubFormFieldRule>();

        /// <summary>
        /// The fields that should appear on the document.
        /// See <see cref="!:https://faq.hellosign.com/hc/en-us/articles/217115577"/>.
        /// </summary>
        public IList<SubFormFieldsPerDocumentBase> FormFieldsPerDocument { get; set; } = new List<SubFormFieldsPerDocumentBase>();

        /// <summary>
        /// Send with a value of true if you wish to enable automatic 
        /// Text Tag removal. Defaults to false. When using Text Tags 
        /// it is preferred that you set this to false and hide your 
        /// tags with white text or something similar because the automatic 
        /// removal system can cause unwanted clipping.
        /// </summary>
        public bool HideTextTags { get; set; }

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
        /// The URL you want signers redirected to after they successfully request a signature.
        /// </summary>
        public string RequestingRedirectUrl { get; set; }

        /// <summary>
        /// This allows the requester to enable the editor/preview experience.
        /// </summary>
        public bool ShowPreview { get; set; }

        /// <summary>
        /// Add Signers to your Unclaimed Draft Signature Request.
        /// </summary>
        public IList<SubUnclaimedDraftSigner> Signers { get; set; } = new List<SubUnclaimedDraftSigner>();

        /// <summary>
        /// Disables the "Me (Now)" option for the person preparing the document. 
        /// Does not work with type send_document. Defaults to false.
        /// </summary>
        public bool SkipMeNow { get; set; }

        /// <summary>
        /// The type of unclaimed draft to create. Use values from <see cref="UnclaimedDraftTypes"/>.
        /// If the type is <see cref="UnclaimedDraftTypes.RequestSignature"/> then signers name and 
        /// email_address are not optional.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Set use_text_tags to true to enable Text Tags parsing in your document 
        /// (defaults to disabled, or false). Alternatively, if your PDF contains pre-defined fields, 
        /// enable the detection of these fields by setting the use_preexisting_fields to true 
        /// (defaults to disabled, or false). 
        /// Currently we only support use of either use_text_tags or use_preexisting_fields parameter, not both.
        /// </summary>
        public bool UsePreexistingFields { get; set; }

        /// <summary>
        /// Set use_text_tags to true to enable Text Tags parsing in your document 
        /// (defaults to disabled, or false). Alternatively, if your PDF contains pre-defined fields, 
        /// enable the detection of these fields by setting the use_preexisting_fields to true 
        /// (defaults to disabled, or false). 
        /// Currently we only support use of either use_text_tags or use_preexisting_fields parameter, not both.
        /// </summary>
        public bool UseTextTags { get; set; }

        /// <summary>
        /// Controls whether auto fill fields can automatically populate a signer's information during signing.
        /// </summary>
        public bool PopulateAutoFillFields { get; set; }

        /// <summary>
        /// When the signature request will expire. 
        /// Unsigned signatures will be moved to the expired status, and no longer signable.
        /// </summary>
        public DateTime? ExpiresAt { get; set; }

    }
}
