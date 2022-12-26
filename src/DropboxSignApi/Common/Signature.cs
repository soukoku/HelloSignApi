using DropboxSignApi.Utils;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace DropboxSignApi.Common
{
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.UnixDateTimeConverter))]
        public DateTime? SignedAt { get; set; }
        /// <summary>
        /// The time that the document was last viewed by this signer or null.
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.UnixDateTimeConverter))]
        public DateTime? LastViewedAt { get; set; }
        /// <summary>
        /// The time the last reminder email was sent to the signer or null.
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.UnixDateTimeConverter))]
        public DateTime? LastRemindedAt { get; set; }

        /// <summary>
        /// Indicate whether this signature requires a PIN to access.
        /// </summary>
        public bool HasPin { get; set; }

        /// <summary>
        /// Email address of original signer who reassigned to this signer, or null.
        /// </summary>
        public string ReassignedBy { get; set; }

        /// <summary>
        /// Reason provided by original signer who reassigned to this signer, or null.
        /// </summary>
        public string ReassignmentReason { get; set; }

        /// <summary>
        /// Error message pertaining to this signer, or null.
        /// </summary>
        public string Error { get; set; }
    }
}
