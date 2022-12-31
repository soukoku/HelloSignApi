using Newtonsoft.Json;
using System;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Represents a signature on a document.
    /// </summary>
    public class SignatureRequestResponseSignature
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
        /// The role of the signer.
        /// </summary>
        public string SignerRole { get; set; }
        
        /// <summary>
        /// If signer order is assigned this is the 0-based index for this signer.
        /// </summary>
        public int? Order { get; set; }
        
        /// <summary>
        /// The current status of the signature. <see cref="SignatureStatusCodes"/> values.
        /// </summary>
        public string StatusCode { get; set; }
        
        /// <summary>
        /// The reason provided by the signer for declining the request.
        /// </summary>
        public string DeclineReason { get; set; }

        /// <summary>
        /// Time that the document was signed or null.
        /// </summary>
        public DateTime? SignedAt { get; set; }

        /// <summary>
        /// The time that the document was last viewed by this signer or null.
        /// </summary>
        public DateTime? LastViewedAt { get; set; }

        /// <summary>
        /// The time the last reminder email was sent to the signer or null.
        /// </summary>
        public DateTime? LastRemindedAt { get; set; }

        /// <summary>
        /// Boolean to indicate whether this signature requires a PIN to access.
        /// </summary>
        public bool HasPin { get; set; }

        /// <summary>
        /// Boolean to indicate whether this signature has SMS authentication enabled.
        /// </summary>
        public bool HasSmsAuth { get; set; }

        /// <summary>
        /// Boolean to indicate whether this signature has SMS delivery enabled.
        /// </summary>
        public bool HasSmsDelivery { get; set; }

        /// <summary>
        /// The SMS phone number used for authentication or signature request delivery.
        /// </summary>
        public string SmsPhoneNumber { get; set; }

        /// <summary>
        /// Email address of original signer who reassigned to this signer, or null.
        /// </summary>
        public string ReassignedBy { get; set; }

        /// <summary>
        /// Reason provided by original signer who reassigned to this signer, or null.
        /// </summary>
        public string ReassignmentReason { get; set; }

        /// <summary>
        /// Previous signature identifier.
        /// </summary>
        public string ReassignedFrom { get; set; }

        /// <summary>
        /// Error message pertaining to this signer, or null.
        /// </summary>
        public string Error { get; set; }
    }
}
