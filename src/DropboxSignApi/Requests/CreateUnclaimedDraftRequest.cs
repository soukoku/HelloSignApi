using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Soukoku.DropboxSignApi.Requests
{
    /// <summary>
    /// Object used to create a new unclaimed draft.
    /// </summary>
    public class CreateUnclaimedDraftRequest : CreateUnclaimedDraftBase
    {
        /// <summary>
        /// The type of unclaimed draft to create. Use values from <see cref="UnclaimedDraftTypes"/>.
        /// If the type is <see cref="UnclaimedDraftTypes.RequestSignature"/> then signers name and 
        /// email_address are not optional.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// A list describing the attachments.
        /// </summary>
        public IList<SubAttachment> Attachments { get; } = new List<SubAttachment>();

        /// <summary>
        /// The email addresses that should be CCed.
        /// </summary>
        public IList<string> CcEmailAddresses { get; } = new List<string>();

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
        /// Add Signers to your Unclaimed Draft Signature Request.
        /// </summary>
        public IList<SubUnclaimedDraftSigner> Signers { get; set; } = new List<SubUnclaimedDraftSigner>();

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
        /// When the signature request will expire. 
        /// Unsigned signatures will be moved to the expired status, and no longer signable.
        /// </summary>
        public DateTime? ExpiresAt { get; set; }
    }
}
