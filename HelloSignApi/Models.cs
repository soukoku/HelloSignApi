using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

// this file contains non-reponse object models.

namespace HelloSignApi
{
    /// <summary>
    /// Represents a HelloSign account.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// The id of the Account.
        /// </summary>
        public string AccountId { get; set; }
        /// <summary>
        /// The email address associated with the Account.
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// The URL that HelloSign events will be POSTed to.
        /// </summary>
        public string CallbackUrl { get; set; }
        /// <summary>
        /// Whether the user has a paid HelloSign account.
        /// </summary>
        [JsonProperty("is_paid_hs")]
        public bool? IsPaidHelloSign { get; set; }
        /// <summary>
        /// Whether the user has a paid HelloFax account.
        /// </summary>
        [JsonProperty("is_paid_hf")]
        public bool? IsPaidHelloFax { get; set; }
        /// <summary>
        /// An object detailing remaining monthly quotas.
        /// </summary>
        public Quota Quotas { get; set; }
        /// <summary>
        /// The membership role for the team. a = Admin, m = Member.
        /// </summary>
        public string RoleCode { get; set; }
    }

    /// <summary>
    /// Quota for an <see cref="Account"/>.
    /// </summary>
    public class Quota
    {
        /// <summary>
        /// API templates remaining.
        /// </summary>
        public int? TemplatesLeft { get; set; }
        /// <summary>
        /// API signature requests remaining.
        /// </summary>
        public int? ApiSignatureRequestsLeft { get; set; }
        /// <summary>
        /// Signature requests remaining.
        /// </summary>
        public int? DocumentsLeft { get; set; }
    }

    /// <summary>
    /// Contains information regarding documents that need to be signed.
    /// </summary>
    public class SignatureRequest
    {
        /// <summary>
        /// Whether this is a test signature request. Test requests have no legal value. 
        /// </summary>
        public bool TestMode { get; set; }
        /// <summary>
        /// The id of the SignatureRequest.
        /// </summary>
        public string SignatureRequestId { get; set; }
        /// <summary>
        /// The email address of the initiator of the SignatureRequest.
        /// </summary>
        public string RequesterEmailAddress { get; set; }
        /// <summary>
        /// The title the specified Account uses for the SignatureRequest.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The subject in the email that was initially sent to the signers.
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// The custom message in the email that was initially sent to the signers.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Whether or not the SignatureRequest has been fully executed by all signers.
        /// </summary>
        public bool IsComplete { get; set; }
        /// <summary>
        /// Whether or not an error occurred (either during the creation of the SignatureRequest or during one of the signings).
        /// </summary>
        public bool HasError { get; set; }
        /// <summary>
        /// The URL where a copy of the request's documents can be downloaded.
        /// </summary>
        public string FilesUrl { get; set; }
        /// <summary>
        /// The URL where a signer, after authenticating, can sign the documents. This should only be used by users with existing HelloSign accounts as they will be required to log in before signing.
        /// </summary>
        public string SigningUrl { get; set; }
        /// <summary>
        /// The URL where the requester and the signers can view the current status of the SignatureRequest.
        /// </summary>
        public string DetailsUrl { get; set; }
        /// <summary>
        /// A list of email addresses that were CCed on the SignatureRequest. They will receive a copy of the final PDF once all the signers have signed.
        /// </summary>
        public string[] CcEmailAddresses { get; set; }
        /// <summary>
        /// The URL you want the signer redirected to after they successfully sign.
        /// </summary>
        public string SigningRedirectUrl { get; set; }
        /// <summary>
        /// An array of Custom Field objects containing the name and type of each custom field.
        /// </summary>
        public CustomField[] CustomFields { get; set; }
        /// <summary>
        /// An array of form field objects containing the name, value, and type of each textbox or checkmark field filled in by the signers.
        /// </summary>
        public FieldResponse[] ResponseData { get; set; }
        /// <summary>
        /// An array of signature obects, 1 for each signer.
        /// </summary>
        public Signature[] Signatures { get; set; }
        /// <summary>
        /// Key-value data attached to the signature request. 
        /// </summary>
        public IDictionary<string, string> Metadata { get; set; }
    }

    /// <summary>
    /// Represents a custom field.
    /// </summary>
    public class CustomField
    {
        /// <summary>
        /// The name of the Custom Field.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The type of this Custom Field. Only <see cref="FieldTypes.Text"/> and <see cref="FieldTypes.CheckBox"/> 
        /// are currently supported.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// A text string for text fields or true/false for checkbox fields
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// A boolean value denoting if this field is required.
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// The name of the Role that is able to edit this field.
        /// </summary>
        public string Editor { get; set; }
    }

    /// <summary>
    /// Represents a field data.
    /// </summary>
    public class FieldResponse
    {
        /// <summary>
        /// The unique ID for this field.
        /// </summary>
        public string ApiId { get; set; }
        /// <summary>
        /// The ID of the signature to which this response is linked.
        /// </summary>
        public string SignatureId { get; set; }
        /// <summary>
        /// The name of the form field.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The value of the form field.
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// A boolean value denoting if this field is required.
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// The type of this form field. See <see cref="FieldTypes"/> values.
        /// </summary>
        public string Type { get; set; } // TODO: Change to an enum, custom setter
    }

    /// <summary>
    /// Represents a signature on a document.
    /// </summary>
    public class Signature
    {
        /// <summary>
        /// Signature identifier.
        /// </summary>
        public string SignatureId { get; set; }
        /// <summary>
        /// The email address of the signer.
        /// </summary>
        public string SignerEmailAddress { get; set; }
        /// <summary>
        /// The name of the signer.
        /// </summary>
        public string SignerName { get; set; }
        /// <summary>
        /// If signer order is assigned this is the 0-based index for this signer.
        /// </summary>
        public int? Order { get; set; }
        /// <summary>
        /// The current status of the signature. <see cref="SignatureStatusCodes"/> values.
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// Actual value of <see cref="SignedAt"/>.
        /// </summary>
        [JsonProperty("signed_at"), EditorBrowsable(EditorBrowsableState.Never)]
        public long? SignedAtRaw { get; set; }
        /// <summary>
        /// Actual value of <see cref="LastViewedAt"/>.
        /// </summary>
        [JsonProperty("signed_at"), EditorBrowsable(EditorBrowsableState.Never)]
        public long? LastViewedAtRaw { get; set; }
        /// <summary>
        /// Actual value of <see cref="LastRemindedAt"/>.
        /// </summary>
        [JsonProperty("signed_at"), EditorBrowsable(EditorBrowsableState.Never)]
        public long? LastRemindedAtRaw { get; set; }

        /// <summary>
        /// Time that the document was signed or null.
        /// </summary>
        [JsonIgnore]
        public DateTime? SignedAt { get { return SignedAtRaw?.ToUnixTime(); } }
        /// <summary>
        /// The time that the document was last viewed by this signer or null.
        /// </summary>
        [JsonIgnore]
        public DateTime? LastViewedAt { get { return LastViewedAtRaw?.ToUnixTime(); } }
        /// <summary>
        /// The time the last reminder email was sent to the signer or null.
        /// </summary>
        [JsonIgnore]
        public DateTime? LastRemindedAt { get { return LastRemindedAtRaw?.ToUnixTime(); } }

        /// <summary>
        /// Indicate whether this signature requires a PIN to access.
        /// </summary>
        public bool HasPin { get; set; }
    }

    /// <summary>
    /// An object with an expiration date.
    /// </summary>
    public class ExpiringObject
    {
        /// <summary>
        /// Actual value for <see cref="ExpiresAt"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty("expires_at")]
        public long ExpiresAtRaw { get; set; }

        /// <summary>
        /// Gets when the link expires.
        /// </summary>
        [JsonIgnore]
        public DateTime ExpiresAt { get { return ExpiresAtRaw.ToUnixTime(); } }
    }

    /// <summary>
    /// Represents a group of documents that a user can take ownership of via the claim URL.
    /// </summary>
    public class UnclaimedDraft : ExpiringObject
    {
        /// <summary>
        /// The URL to be used to claim this UnclaimedDraft.
        /// </summary>
        public string ClaimUrl { get; set; }
        /// <summary>
        /// The URL you want signers redirected to after they successfully sign.
        /// </summary>
        public string SigningRedirectUrl { get; set; }
        /// <summary>
        /// Whether this is a test draft. Signature requests made from test drafts have no legal value.
        /// </summary>
        public bool TestMode { get; set; }
    }

    /// <summary>
    /// An object that contains necessary information to set up embedded signing.
    /// </summary>
    public class EmbeddedSign : ExpiringObject
    {
        /// <summary>
        /// URL of the signature page to display in the embedded iFrame.
        /// </summary>
        public string SignUrl { get; set; }
    }

    /// <summary>
    /// An object that contains necessary information to set up embedded template editing.
    /// </summary>
    public class EmbeddedTemplate : ExpiringObject
    {
        /// <summary>
        /// URL of the template page to display in the embedded iFrame.
        /// </summary>
        public string EditUrl { get; set; }
    }

    /// <summary>
    /// An object that contains file download info.
    /// </summary>
    public class DownloadInfo : ExpiringObject
    {
        /// <summary>
        /// URL of the download url.
        /// </summary>
        public string FileUrl { get; set; }
    }
}
