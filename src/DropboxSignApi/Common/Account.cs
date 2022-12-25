using Newtonsoft.Json;

// this file contains reponse data models.

namespace DropboxSignApi.Common
{
    /// <summary>
    /// Represents a HelloSign account.
    /// </summary>
    public class Account : AccountMin
    {
        /// <summary>
        /// The URL that HelloSign events will be POSTed to.
        /// </summary>
        public string CallbackUrl { get; set; }
        /// <summary>
        /// Returns true if the user has been locked out of their account by a team admin.
        /// </summary>
        public bool IsLocked { get; set; }
        /// <summary>
        /// Whether the user has a paid HelloSign account.
        /// </summary>
        [JsonProperty("is_paid_hs")]
        public bool IsPaidHelloSign { get; set; }
        /// <summary>
        /// Whether the user has a paid HelloFax account.
        /// </summary>
        [JsonProperty("is_paid_hf")]
        public bool IsPaidHelloFax { get; set; }
        /// <summary>
        /// An object detailing remaining monthly quotas.
        /// </summary>
        public Quota Quotas { get; set; }
        /// <summary>
        /// The membership role for the team. a = Admin, m = Member.
        /// </summary>
        public string RoleCode { get; set; }
    }
}
