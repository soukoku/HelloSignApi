using System.Collections.Generic;

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Object used to create a new embedded template draft.
    /// </summary>
    public class CreateEmbeddedTemplateDraftRequest : FileRequestBase
    {
        /// <summary>
        /// Client id of the app used to create the draft. 
        /// Used to apply the branding and callback url defined for the app.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// This allows the requester to specify whether the user is 
        /// allowed to provide email addresses to CC when creating a template.
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
        public IList<SubAttachment> Attachments { get; private set; } = new List<SubAttachment>();

        /// <summary>
        /// The CC roles that must be assigned when using the template to send a signature request.
        /// </summary>
        public IList<string> CCRoles { get; set; }

        /// <summary>
        /// This allows the requester to specify editor options when a preparing a document.
        /// </summary>
        public SubEditorOptions EditorOptions { get; set; }

        /// <summary>
        /// This allows the requester to specify field options for a signature request.
        /// </summary>
        public SubFieldOptions FieldOptions { get; set; }

        /// <summary>
        /// Provide users the ability to review/edit the template signer roles.
        /// </summary>
        public bool ForceSignerRoles { get; set; }

        /// <summary>
        /// Provide users the ability to review/edit the template subject and message.
        /// </summary>
        public bool ForceSubjectMessage { get; set; }

        /// <summary>
        /// Group information for fields defined in form_fields_per_document. 
        /// String-indexed JSON array with group_label and requirement keys. 
        /// form_fields_per_document must contain fields referencing a group 
        /// defined in form_field_groups.
        /// </summary>
        public IList<SubFormFieldGroup> FormFieldGroups { get; private set; } = new List<SubFormFieldGroup>();

        /// <summary>
        /// Conditional Logic rules for fields defined in form_fields_per_document.
        /// </summary>
        public IList<SubFormFieldRule> FormFieldRules { get; private set; } = new List<SubFormFieldRule>();

        /// <summary>
        /// The fields that should appear on the document.
        /// See <see cref="!:https://faq.hellosign.com/hc/en-us/articles/217115577"/>.
        /// </summary>
        public IList<SubFormFieldBase> FormFieldsPerDocument { get; set; } = new List<SubFormFieldBase>();

        /// <summary>
        /// Add merge fields to the template. Merge fields are placed by the user creating the template 
        /// and used to pre-fill data by passing values into signature requests with the custom_fields parameter. 
        /// If the signature request using that template does not pass a value into a merge field, 
        /// then an empty field remains in the document.
        /// </summary>
        public IList<SubMergeField> MergeFields { get; private set; }

        /// <summary>
        /// The default template email message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// <para>Key-value data that should be attached to the signature request. 
        /// This metadata is included in all API responses and events involving the signature request. 
        /// For example, use the metadata field to store a signer's order number for look up when 
        /// receiving events for the signature request.
        /// </para>
        /// <para>
        /// Each request can include up to 10 metadata keys (or 50 nested metadata keys), 
        /// with key names up to 40 characters long and values up to 1000 characters long.
        /// </para>
        /// </summary>
        public IDictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// This allows the requester to enable the editor/preview experience.
        /// </summary>
        public bool ShowPreview { get; set; }

        /// <summary>
        /// When only one step remains in the signature request process and 
        /// this parameter is set to false then the progress stepper will be hidden.
        /// </summary>
        public bool ShowProgressStepper { get; set; } = true;

        /// <summary>
        /// An array of the designated signer roles that must be specified when sending 
        /// a SignatureRequest using this Template.
        /// </summary>
        public IList<SubTemplateRole> SignerRoles { get; set; }

        /// <summary>
        /// Disables the "Me (Now)" option for the person preparing the document. 
        /// Does not work with type send_document. Defaults to false.
        /// </summary>
        public bool SkipMeNow { get; set; }

        /// <summary>
        /// The template title (alias).
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Whether this is a test, the signature request created from this draft 
        /// will not be legally binding if <code>true</code>.
        /// </summary>
        public bool TestMode { get; set; }

        /// <summary>
        /// The title you want to assign to the SignatureRequest.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Enable the detection of predefined PDF fields 
        /// </summary>
        public bool UsePreexistingFields { get; set; }
    }
}
