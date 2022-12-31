using Newtonsoft.Json;

namespace Soukoku.DropboxSignApi.Responses
{
    public class TemplateResponseAccount
    {
        /// <summary>
        /// The ID of the Account.
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// The email address associated with the Account.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Returns <code>true</code> if the user has been locked out of their account by a team admin.
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// Returns <code>true</code> if the user has a paid Dropbox Sign account.
        /// </summary>
        [JsonProperty("is_paid_hs")]
        public bool IsPaidHelloSign { get; set; }

        /// <summary>
        /// Returns <code>true</code> if the user has a paid HelloFax account.
        /// </summary>
        [JsonProperty("is_paid_hf")]
        public bool IsPaidHelloFax { get; set; }

        /// <summary>
        /// Details concerning remaining monthly quotas.
        /// </summary>
        public TemplateResponseAccountQuota Quotas { get; set; }
    }
}