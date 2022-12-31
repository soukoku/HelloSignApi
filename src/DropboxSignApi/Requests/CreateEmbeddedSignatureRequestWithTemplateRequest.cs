﻿using System.Collections.Generic;

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Object used by <see cref="DropboxSignClient.CreateEmbeddedSignatureRequestWithTemplateAsync"/>.
    /// </summary>
    public class CreateEmbeddedSignatureRequestWithTemplateRequest : FileRequestBase
    {
        /// <summary>
        /// Client id of the app you're using to create this embedded signature request. Used for security purposes.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Used to create a SignatureRequest from one or more templates, in the order in which the template will be used.
        /// </summary>
        public IList<string> TemplateIds { get; } = new List<string>();

        /// <summary>
        /// The signers to request signatures.
        /// </summary>
        public IList<SubSignatureRequestTemplateSigner> Signers { get; } = new List<SubSignatureRequestTemplateSigner>();

        /// <summary>
        /// Allows signers to decline to sign a document if set to true. Defaults to false.
        /// </summary>
        public bool AllowDecline { get; set; }

        /// <summary>
        /// Add CC email recipients. Required when a CC role exists for the Template.
        /// </summary>
        public IList<SubCC> Ccs { get; } = new List<SubCC>();

        /// <summary>
        /// An list defining values and options for custom fields. Required when a custom field exists in the Template.
        /// </summary>
        public IList<SubCustomField> CustomFields { get; set; } = new List<SubCustomField>();

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
        /// Controls whether auto fill fields can automatically populate a signer's information during signing.
        /// </summary>
        public bool PopulateAutoFillFields { get; set; }
    }
}