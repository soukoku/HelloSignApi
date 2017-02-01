using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

// this file contains objects for creating new things.

namespace HelloSignApi.Requests
{
    /// <summary>
    /// Base class for making new signature type requests.
    /// </summary>
    public abstract class NewRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewRequestBase"/> class.
        /// </summary>
        protected NewRequestBase()
        {
            Metadata = new Dictionary<string, string>();
            Signers = new List<Signer>();
        }

        /// <summary>
        /// Whether this is a test, the signature request created from this draft will not be legally binding if <code>true</code>.
        /// </summary>
        public bool TestMode { get; set; }

        /// <summary>
        /// Allows signers to decline to sign a document if set to true. Defaults to false.
        /// </summary>
        public bool AllowDecline { get; set; }

        /// <summary>
        /// The subject in the email that will be sent to the signers.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// The custom message in the email that will be sent to the signers.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The URL you want signers redirected to after they successfully sign.
        /// </summary>
        public string SigningRedirectUrl { get; set; }

        /// <summary>
        /// The signers to request signatures.
        /// </summary>
        public IList<Signer> Signers { get; private set; }

        /// <summary>
        /// Key-value data that should be attached to the signature request. 
        /// This metadata is included in all API responses and events involving the signature request. 
        /// For example, use the metadata field to store a signer's order number for look up when 
        /// receiving events for the signature request.
        /// Each request can include up to 10 metadata keys, with key names up to 40 characters long and 
        /// values up to 500 characters long.
        /// </summary>
        public IDictionary<string, string> Metadata { get; private set; }
    }

    /// <summary>
    /// Object used to create a new signature request.
    /// </summary>
    public class NewSignatureRequest : NewRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewSignatureRequest"/> class.
        /// </summary>
        public NewSignatureRequest()
        {
            Files = new PendingFileCollection();
            CcEmailAddresses = new List<string>();
            FormFieldsPerDocument = new List<IList<RequestFormField>>();
        }

        /// <summary>
        /// The client ID of the ApiApp you want to associate with this request.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets the files to be uploaded.
        /// </summary>
        public PendingFileCollection Files { get; private set; }

        /// <summary>
        /// The title you want to assign to the SignatureRequest.
        /// </summary>
        public string Title { get; set; }

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
        public IList<IList<RequestFormField>> FormFieldsPerDocument { get; set; }
    }

    /// <summary>
    /// Object used to create a new signature request from template.
    /// </summary>
    public class NewTemplatedSignatureRequest : NewRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewTemplatedSignatureRequest"/> class.
        /// </summary>
        public NewTemplatedSignatureRequest()
        {
            TemplateIds = new List<string>();
            Ccs = new List<Signer>();
            CustomFields = new List<CustomField>();
        }
        /// <summary>
        /// The client ID of the ApiApp you want to associate with this request.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The template ids to create a SignatureRequest from.
        /// </summary>
        public IList<string> TemplateIds { get; private set; }

        /// <summary>
        /// The title you want to assign to the SignatureRequest.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The email address of the CC filling the role of RoleName. Required when a CC role exists for the Template.
        /// </summary>
        public IList<Signer> Ccs { get; private set; }
        /// <summary>
        /// Values and options for custom fields. Required when a custom field exists in the Template.
        /// </summary>
        public IList<CustomField> CustomFields { get; private set; }
    }


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

    /// <summary>
    /// Object used to create a new embedded unclaimed draft.
    /// </summary>
    public class NewEmbeddedUnclaimedDraft : NewUnclaimedDraft
    {
        /// <summary>
        /// Client id of the app you're using to create this draft. 
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The email address of the user that should be designated as the requester of this draft, 
        /// if the draft type is <see cref="UnclaimedDraftTypes.RequestSignature"/>.
        /// </summary>
        public string RequesterEmailAddress { get; set; }

        /// <summary>
        /// The request created from this draft will also be signable in embedded mode if set to <code>true</code>.
        /// </summary>
        public bool IsForEmbeddedSigning { get; set; }
    }


    /// <summary>
    /// Object used to create a new embedded unclaimed draft with template.
    /// </summary>
    public class NewTemplatedEmbeddedUnclaimedDraft : NewRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewTemplatedEmbeddedUnclaimedDraft"/> class.
        /// </summary>
        public NewTemplatedEmbeddedUnclaimedDraft()
        {
            TemplateIds = new List<string>();
            Ccs = new List<Signer>();
            CustomFields = new List<CustomField>();
        }

        /// <summary>
        /// The client ID of the ApiApp you want to associate with this request.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The templates to create a request from. The order of the template is significant.
        /// </summary>
        public IList<string> TemplateIds { get; private set; }

        /// <summary>
        /// The title you want to assign to the SignatureRequest.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The URL you want signers redirected to after they successfully request a signature.
        /// </summary>
        public string RequestingRedirectUrl { get; set; }

        /// <summary>
        /// The email address of the CC filling the role of RoleName. Required when a CC role exists for the Template.
        /// </summary>
        public IList<Signer> Ccs { get; private set; }

        /// <summary>
        /// Values and options for custom fields. Required when a custom field exists in the Template.
        /// </summary>
        public IList<CustomField> CustomFields { get; private set; }

        /// <summary>
        /// The request created from this draft will also be signable in embedded mode if set to <code>true</code>.
        /// </summary>
        public bool IsForEmbeddedSigning { get; set; }
    }

    /// <summary>
    /// Object used to create a new embedded template draft.
    /// </summary>
    public class NewEmbeddedTemplateDraft
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewEmbeddedTemplateDraft"/> class.
        /// </summary>
        public NewEmbeddedTemplateDraft()
        {
            Files = new PendingFileCollection();
            SignerRoles = new List<SignerRole>();
            CcRoles = new List<string>();
            MergeFields = new List<MergeField>();
        }

        /// <summary>
        /// Whether this is a test, the signature request created from this draft will not be legally binding if <code>true</code>.
        /// </summary>
        public bool TestMode { get; set; }

        /// <summary>
        /// Gets the files to be uploaded.
        /// </summary>
        public PendingFileCollection Files { get; private set; }
        /// <summary>
        /// The title you want to assign to the SignatureRequest.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The subject in the email that will be sent to the signers.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// The custom message in the email that will be sent to the signers.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The roles when the template is used to create a signature request.
        /// </summary>
        public IList<SignerRole> SignerRoles { get; private set; }

        /// <summary>
        /// The CC roles that must be assigned when using the template to send a signature request.
        /// </summary>
        public IList<string> CcRoles { get; private set; }

        /// <summary>
        /// The merge fields that can be placed on the template's document(s) by the user claiming the template draft. These are typically fields that can be pre-populated by your application when using the resulting template to send a signature request. Each merge field object must have two parameters: name and type. Names must be unique and type can only be "text" or "checkbox".
        /// </summary>
        public IList<MergeField> MergeFields { get; private set; }

        /// <summary>
        /// Enable the detection of predefined PDF fields 
        /// </summary>
        public bool UsePreexistingFields { get; set; }

        /// <summary>
        /// Key-value data that should be attached to the signature request. 
        /// This metadata is included in all API responses and events involving the signature request. 
        /// For example, use the metadata field to store a signer's order number for look up when 
        /// receiving events for the signature request.
        /// Each request can include up to 10 metadata keys, with key names up to 40 characters long and 
        /// values up to 500 characters long.
        /// </summary>
        public IDictionary<string, string> Metadata { get; private set; }

        /// <summary>
        /// The client ID of the ApiApp you want to associate with this request.
        /// </summary>
        public string ClientId { get; set; }

    }

    /// <summary>
    /// Data for creating or modifying a new api app.
    /// </summary>
    public class NewApiApp
    {
        /// <summary>
        /// The name you want to assign to the ApiApp.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The domain name the ApiApp will be associated with.
        /// </summary>
        public string Domain { get; set; }
        /// <summary>
        /// The URL at which the ApiApp should receive event callbacks.
        /// </summary>
        public string CallbackUrl { get; set; }
        /// <summary>
        /// An image file to use as a custom logo in embedded contexts. (Only applies to some API plans)
        /// </summary>
        public string CustomLogoFile { get; set; }

        /// <summary>
        /// The callback URL to be used for OAuth flows. (Required if <see cref="OAuthScopes"/> is provided)
        /// </summary>
        public string OAuthCallbackUrl { get; set; }
        /// <summary>
        /// A comma-separated list of OAuth scopes to be granted to the app. (Required if <see cref="OAuthCallbackUrl"/> is provided)
        /// </summary>
        public string OAuthScopes { get; set; }

        /// <summary>
        /// Serialized <see cref="WhiteLabelingOptions"/>, to be used to customize the app's signer page. (Only applies to some API plans)
        /// </summary>
        public string WhiteLabelingOptions { get; set; }
    }
}
