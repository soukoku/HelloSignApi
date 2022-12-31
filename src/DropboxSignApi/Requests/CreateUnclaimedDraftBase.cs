using System.Collections.Generic;

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Shared request properties for creating new unclaimed drafts.
    /// </summary>
    public abstract class CreateUnclaimedDraftBase : FileRequestBase
    {
        /// <summary>
        /// Allows signers to decline to sign a document if set to true. Defaults to false.
        /// </summary>
        public bool AllowDecline { get; set; }

        /// <summary>
        /// Client id of the app used to create the draft. 
        /// Used to apply the branding and callback url defined for the app.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// <para>
        /// When used together with merge fields, custom_fields allows users to add pre-filled data to their signature requests.
        /// </para>
        /// <para>
        /// Pre-filled data can be used with "send-once" signature requests by adding merge fields with 
        /// form_fields_per_document or Text Tags while passing values back with custom_fields together in one API call.
        /// </para>
        /// <para>
        /// For using pre-filled on repeatable signature requests, merge fields are added to templates in the 
        /// Dropbox Sign UI or by calling /template/create_embedded_draft and then passing custom_fields on 
        /// subsequent signature requests referencing that template.
        /// </para>
        /// </summary>
        public IList<SubCustomField> CustomFields { get; set; }

        /// <summary>
        /// This allows the requester to specify field options for a signature request.
        /// </summary>
        public SubFieldOptions FieldOptions { get; set; }

        /// <summary>
        /// The custom message in the email that will be sent to the signers.
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
        /// When only one step remains in the signature request process and 
        /// this parameter is set to false then the progress stepper will be hidden.
        /// </summary>
        public bool ShowProgressStepper { get; set; } = true;

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
        /// Whether this is a test, the signature request created from this draft 
        /// will not be legally binding if <code>true</code>.
        /// </summary>
        public bool TestMode { get; set; }
    }
}