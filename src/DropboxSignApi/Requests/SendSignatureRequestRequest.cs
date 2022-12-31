using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Object used to create a new signature request.
    /// </summary>
    public class SendSignatureRequestRequest  : FileRequestBase
    {
        /// <summary>
        /// The signers to request signatures.
        /// </summary>
        public IList<SubSignatureRequestSigner> Signers { get; } = new List<SubSignatureRequestSigner>();

        /// <summary>
        /// Allows signers to decline to sign a document if set to true. Defaults to false.
        /// </summary>
        public bool AllowDecline { get; set; }

        /// <summary>
        /// Allows signers to reassign their signature requests to other signers if set to true. Defaults to false.
        /// </summary>
        public bool AllowReassign { get; set; }

        /// <summary>
        /// A list describing the attachments.
        /// </summary>
        public IList<SubAttachment> Attachments { get; set; } = new List<SubAttachment>();

        /// <summary>
        /// The email addresses that should be CCed.
        /// </summary>
        public IList<string> CcEmailAddresses { get; set; } = new List<string>();

        /// <summary>
        /// The client id of the API App you want to associate with this request. 
        /// Used to apply the branding and callback url defined for the app.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// <para>When used together with merge fields, custom_fields allows users to add pre-filled data to their signature requests.</para>
        /// <para>
        /// Pre-filled data can be used with "send-once" signature requests by adding merge fields with form_fields_per_document or 
        /// Text Tags while passing values back with custom_fields together in one API call.
        /// </para>
        /// <para>
        /// For using pre-filled on repeatable signature requests, merge fields are added to templates in the Dropbox Sign UI 
        /// or by calling /template/create_embedded_draft and then passing custom_fields on subsequent signature requests referencing that template.
        /// </para>
        /// </summary>
        public IList<SubCustomField> CustomFields { get; set; } = new List<SubCustomField>();

        /// <summary>
        /// This allows the requester to specify field options for a signature request.
        /// </summary>
        public SubFieldOptions FieldOptions { get; set; }


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
        public IList<SubFormFieldBase> FormFieldsPerDocument { get; set; } = new List<SubFormFieldBase>();

        /// <summary>
        /// Enables automatic Text Tag removal when set to true.
        /// </summary>
        public bool HideTextTags { get; set; }

        /// <summary>
        /// Send with a value of true if you wish to enable Qualified Electronic Signatures (QES), 
        /// which requires a face-to-face call to verify the signer's identity.
        /// </summary>
        public bool IsQualifiedSignature { get; set; }

        /// <summary>
        /// The custom message in the email that will be sent to the signers.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Key-value data that should be attached to the signature request. 
        /// This metadata is included in all API responses and events involving the signature request. 
        /// For example, use the metadata field to store a signer's order number for look up when 
        /// receiving events for the signature request.
        /// Each request can include up to 10 metadata keys (or 50 nested metadata keys), 
        /// with key names up to 40 characters long and values up to 1000 characters long.
        /// </summary>
        public IDictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// This allows the requester to specify the types allowed for creating a signature.
        /// </summary>
        public SubSigningOptions SigningOptions { get; set; }

        /// <summary>
        /// The URL you want signers redirected to after they successfully sign.
        /// </summary>
        public string SigningRedirectUrl { get; set; }

        /// <summary>
        /// The subject in the email that will be sent to the signers.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Whether this is a test, the signature request will not be legally binding 
        /// if set to <code>true</code>.
        /// </summary>
        public bool TestMode { get; set; }

        /// <summary>
        /// The title you want to assign to the SignatureRequest.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Send with a value of true if you wish to enable Text Tags parsing in your document. 
        /// Defaults to disabled, or false.
        /// </summary>
        public bool UseTextTags { get; set; }

        /// <summary>
        /// When the signature request will expire. 
        /// Unsigned signatures will be moved to the expired status, and no longer signable.
        /// </summary>
        public DateTime? ExpiresAt { get; set; }
    }
}
