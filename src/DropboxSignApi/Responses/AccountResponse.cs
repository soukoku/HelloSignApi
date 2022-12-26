using DropboxSignApi.Common;
using Newtonsoft.Json;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Represents a HelloSign account.
    /// </summary>
    public class AccountResponse
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
        public AccountResponseQuotas Quotas { get; set; }

        /// <summary>
        /// The URL that Dropbox Sign events will POST to.
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// The membership role for the team. a = Admin, m = Member.
        /// </summary>
        public string RoleCode { get; set; }

        /// <summary>
        /// The id of the team account belongs to.
        /// </summary>
        public string TeamId { get; set; }

        /// <summary>
        /// The locale used in this Account. Check out the <see cref="SupportedLocales"/> to learn more about the possible values.
        /// </summary>
        public string Locale { get; set; }
    }

}
