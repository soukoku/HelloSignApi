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
}
