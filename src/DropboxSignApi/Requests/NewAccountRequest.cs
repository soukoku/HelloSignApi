using Newtonsoft.Json;

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Object used to create a new account.
    /// </summary>
    public class NewAccountRequest
    {
        /// <summary>
        /// The email address which will be associated with the new Account.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Used when creating a new account with OAuth authorization.
        /// </summary>
        [JsonProperty(DefaultValueHandling= DefaultValueHandling.Ignore)]
        public string ClientId { get; set; }

        /// <summary>
        /// Used when creating a new account with OAuth authorization.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ClientSecret { get; set; }

        /// <summary>
        /// The locale used in this Account. Check out the <see cref="DropboxSignApi.SupportedLocales"/> to learn more about the possible values.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Locale { get; set; }
    }
}
