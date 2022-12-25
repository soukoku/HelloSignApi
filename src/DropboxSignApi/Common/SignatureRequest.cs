﻿using System.Collections.Generic;

namespace DropboxSignApi.Common
{
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
        /// Whether or not the SignatureRequest has been declined by a signer.
        /// </summary>
        public bool IsDeclined { get; set; }
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
        /// File attachment info.
        /// </summary>
        public Attachment[] Attachments { get; set; }
        /// <summary>
        /// Key-value data attached to the signature request. 
        /// </summary>
        public IDictionary<string, string> Metadata { get; set; }
    }
}