using HelloSignApi.BaseObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

// this file contains reponse data models.

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
        public object Value { get; set; }
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
        public bool? Required { get; set; }
        /// <summary>
        /// The type of this form field. See <see cref="FieldTypes"/> values.
        /// </summary>
        public string Type { get; set; }
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
        [JsonProperty("last_viewed_at"), EditorBrowsable(EditorBrowsableState.Never)]
        public long? LastViewedAtRaw { get; set; }
        /// <summary>
        /// Actual value of <see cref="LastRemindedAt"/>.
        /// </summary>
        [JsonProperty("last_reminded_at"), EditorBrowsable(EditorBrowsableState.Never)]
        public long? LastRemindedAtRaw { get; set; }

        /// <summary>
        /// Time that the document was signed or null.
        /// </summary>
        [JsonIgnore]
        public DateTime? SignedAt { get { return SignedAtRaw?.FromUnixTime(); } }
        /// <summary>
        /// The time that the document was last viewed by this signer or null.
        /// </summary>
        [JsonIgnore]
        public DateTime? LastViewedAt { get { return LastViewedAtRaw?.FromUnixTime(); } }
        /// <summary>
        /// The time the last reminder email was sent to the signer or null.
        /// </summary>
        [JsonIgnore]
        public DateTime? LastRemindedAt { get { return LastRemindedAtRaw?.FromUnixTime(); } }

        /// <summary>
        /// Indicate whether this signature requires a PIN to access.
        /// </summary>
        public bool HasPin { get; set; }
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

    /// <summary>
    /// Represents a document template.
    /// </summary>
    public class Template
    {
        /// <summary>
        /// The id of the Template.
        /// </summary>
        public string TemplateId { get; set; }
        /// <summary>
        /// The title of the Template. This will also be the default subject of the message sent to signers when using this Template to send a SignatureRequest. This can be overriden when sending the SignatureRequest.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The default message that will be sent to signers when using this Template to send a SignatureRequest. This can be overriden when sending the SignatureRequest.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// An array of the designated signer roles that must be specified when sending a SignatureRequest using this Template.
        /// </summary>
        public SignerRole[] SignerRoles { get; set; }
        /// <summary>
        /// An array of the designated CC roles that must be specified when sending a SignatureRequest using this Template.
        /// </summary>
        public SignerRole[] CcRoles { get; set; }
        /// <summary>
        /// An array describing each document associated with this Template. Includes form field data for each document.
        /// </summary>
        public Document[] Documents { get; set; }
        /// <summary>
        /// An array of the Accounts that can use this Template.
        /// </summary>
        public Account[] Accounts { get; set; }
        /// <summary>
        /// True if you are the owner of this template, false if it's been shared with you by a team member.
        /// </summary>
        public bool IsCreator { get; set; }
        /// <summary>
        /// Indicates whether edit rights have been granted to you by the owner (always true if that's you).
        /// </summary>
        public bool CanEdit { get; set; }
        /// <summary>
        /// True if you exceed Template quota; these can only be used in test mode. False if the template is included with the Template quota; these can be used at any time.
        /// </summary>
        public bool IsLocked { get; set; }
    }

    /// <summary>
    /// Represents a signer role in a template.
    /// </summary>
    public class SignerRole
    {
        /// <summary>
        /// The name of the role.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// If signer order is assigned this is the 0-based index for this role.
        /// </summary>
        public int? Order { get; set; }
    }

    /// <summary>
    /// Document object in a template.
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Name of the associated file
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Document ordering, the lowest index is diplayed first and the highest last.
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// An array of Form Field objects containing the name and type of each named textbox and checkmark field.
        /// </summary>
        public FormField[] FormFields { get; set; }
        /// <summary>
        /// An array of Custom Field objects containing the name and type of each custom field.
        /// </summary>
        public CustomField[] CustomFields { get; set; }
    }

    /// <summary>
    /// Field object for a template <see cref="Document"/>.
    /// </summary>
    public class FormField
    {
        /// <summary>
        /// A unique id for the form field.
        /// </summary>
        public string ApiId { get; set; }
        /// <summary>
        /// The name of the form field.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The type of this form field. See <see cref="FieldTypes"/> values.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// The horizontal offset in pixels for this form field.
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// The vertical offset in pixels for this form field.
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// The width in pixels of this form field.
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// The height in pixels of this form field.
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Boolean showing whether or not this field is required.
        /// </summary>
        public bool Required { get; set; }
    }

    /// <summary>
    /// Contains information about your team and its members
    /// </summary>
    public class Team
    {
        /// <summary>
        /// The name of your Team.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A list of all Accounts belonging to your Team.
        /// </summary>
        public Account[] Accounts { get; set; }
        /// <summary>
        /// A list of all Accounts that have an outstanding invitation to join your Team. 
        /// </summary>
        public Account[] InvitedAccounts { get; set; }
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
    /// Contains information about an API App.
    /// </summary>
    public class ApiApp
    {
        /// <summary>
        /// The app's client ID.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Actual value of <see cref="CreatedAt"/>.
        /// </summary>
        [JsonProperty("created_at"), EditorBrowsable(EditorBrowsableState.Never)]
        public long CreatedAtRaw { get; set; }

        /// <summary>
        /// The time that the app was created.
        /// </summary>
        [JsonIgnore]
        public DateTime CreatedAt { get { return CreatedAtRaw.FromUnixTime(); } }

        /// <summary>
        /// The name of the app.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The domain name associated with the app.
        /// </summary>
        public string Domain { get; set; }
        /// <summary>
        /// The app's callback URL (for events).
        /// </summary>
        public string CallbackUrl { get; set; }
        /// <summary>
        /// Boolean to indicate if the app has been approved.
        /// </summary>
        public bool? IsApproved { get; set; }
        /// <summary>
        /// An object describing the app's owner.
        /// </summary>
        public Account OwnerAccount { get; set; }

        /// <summary>
        /// An object describing the app's OAuth properties, or null if OAuth is not configured for the app.
        /// </summary>
        [JsonProperty("oauth")]
        public OAuth OAuth { get; set; }

        /// <summary>
        /// Serialized <see cref="WhiteLabelingOptions"/>, to be used to customize the app's signer page. (Only applies to some API plans)
        /// </summary>
        public string WhiteLabelingOptions { get; set; }
    }

    /// <summary>
    /// Contains OAuth info.
    /// </summary>
    public class OAuth
    {
        /// <summary>
        /// The app's OAuth callback URL.
        /// </summary>
        public string CallbackUrl { get; set; }
        /// <summary>
        /// The app's OAuth secret.
        /// </summary>
        public string Secret { get; set; }
        /// <summary>
        /// Array of OAuth scopes used by the app.
        /// </summary>
        public string[] Scopes { get; set; }
    }

    /// <summary>
    /// Represents an event from callback.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Actual value of <see cref="EventTime"/>.
        /// </summary>
        [JsonProperty("event_time"), EditorBrowsable(EditorBrowsableState.Never)]
        public long? EventTimeRaw { get; set; }

        /// <summary>
        /// When the event was created.
        /// </summary>
        [JsonIgnore]
        public DateTime? EventTime { get { return EventTimeRaw?.FromUnixTime(); } }

        /// <summary>
        /// Type of event being reported. See <see cref="EventTypes"/> values.
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        /// Unique hash of this event.
        /// </summary>
        public string EventHash { get; set; }

        /// <summary>
        /// A map of values containing data related to this event.
        /// </summary>
        public EventMetadata EventMetadata { get; set; }

        /// <summary>
        /// Attached signature request if applicable.
        /// </summary>
        public SignatureRequest SignatureRequest { get; set; }

        /// <summary>
        /// Attached template info if applicable.
        /// </summary>
        public Template Template { get; set; }

        /// <summary>
        /// Attached account info if applicable.
        /// </summary>
        public Account Account { get; set; }
    }

    /// <summary>
    /// Metadata in an event callback.
    /// </summary>
    public class EventMetadata
    {
        /// <summary>
        /// Signature associated with this event. Only set when <see cref="Event.EventType"/> 
        /// is <see cref="EventTypes.SignatureRequestSigned"/> or 
        /// <see cref="EventTypes.SignatureRequestViewed"/>.
        /// </summary>
        public string RelatedSignatureId { get; set; }

        /// <summary>
        /// Id of the account this event is reported for.
        /// </summary>
        public string ReportedForAccountId { get; set; }

        /// <summary>
        /// Client id of the app this event is reported for.
        /// </summary>
        public string ReportedForAppId { get; set; }
    }

    /// <summary>
    /// Represents the white labeling options for the document view.
    /// </summary>
    public class WhiteLabelingOptions
    {
        /// <summary>
        /// Deserializes the serialized data into a <see cref="WhiteLabelingOptions"/>.
        /// </summary>
        /// <param name="serializedData">The serialized data.</param>
        /// <returns></returns>
        public static WhiteLabelingOptions Deserialize(string serializedData)
        {
            return JsonConvert.DeserializeObject<WhiteLabelingOptions>(serializedData ?? string.Empty, HttpResponseExtensions.JsonSettings);
        }

        /// <summary>
        /// Serializes this instance for use with the api.
        /// </summary>
        /// <returns></returns>
        public string Serialize()
        {
            return JsonConvert.SerializeObject(this, HttpResponseExtensions.JsonSettings);
        }

        /// <summary>
        /// 
        /// </summary>
        public string PageBackgroundColor { get; set; } = "#F7F8F9";
        /// <summary>
        /// 
        /// </summary>
        public string HeaderBackgroundColor { get; set; } = "#1A1A1A";
        /// <summary>
        /// 
        /// </summary>
        public string TextColor1 { get; set; } = "#808080";
        /// <summary>
        /// 
        /// </summary>
        public string TextColor2 { get; set; } = "#FFFFFF";
        /// <summary>
        /// 
        /// </summary>
        public string LinkColor { get; set; } = "#00B3E6";
        /// <summary>
        /// 
        /// </summary>
        public string PrimaryButtonColor { get; set; } = "#00B3E6";
        /// <summary>
        /// 
        /// </summary>
        public string PrimaryButtonTextColor { get; set; } = "#FFFFFF";
        /// <summary>
        /// 
        /// </summary>
        public string PrimaryButtonColorHover { get; set; } = "#00B3E6";
        /// <summary>
        /// 
        /// </summary>
        public string PrimaryButtonTextColorHover { get; set; } = "#FFFFFF";
        /// <summary>
        /// 
        /// </summary>
        public string SecondaryButtonColor { get; set; } = "#FFFFFF";
        /// <summary>
        /// 
        /// </summary>
        public string SecondaryButtonTextColor { get; set; } = "#00B3E6";
        /// <summary>
        /// 
        /// </summary>
        public string SecondaryButtonColorHover { get; set; } = "#FFFFFF";
        /// <summary>
        /// 
        /// </summary>
        public string SecondaryButtonTextColorHover { get; set; } = "#00B3E6";
        /// <summary>
        /// Terms of service to display (terms1 or terms2).
        /// </summary>
        public string LegalVersion { get; set; } = "terms1";

    }
}
