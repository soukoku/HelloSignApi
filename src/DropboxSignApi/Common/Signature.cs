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
