using Newtonsoft.Json;

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Object used to update account.
    /// </summary>
    public class UpdateAccountRequest
    {
        /// <summary>
        /// The ID of the Account.
        /// </summary>
        [JsonProperty(DefaultValueHandling= DefaultValueHandling.Ignore)]
        public string AccountId { get; set; }

        /// <summary>
        /// The URL that Dropbox Sign should POST events to.
        /// </summary>
        [JsonProperty(DefaultValueHandling= DefaultValueHandling.Ignore)]
        public string CallbackUrl { get; set; }

        /// <summary>
        /// The locale used in this Account. Check out the <see cref="DropboxSignApi.SupportedLocales"/> to learn more about the possible values.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Locale { get; set; }
    }
}
