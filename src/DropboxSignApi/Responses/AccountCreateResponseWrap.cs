namespace Soukoku.DropboxSignApi.Responses
{
    /// <summary>
    /// Extended account api response with oauth token data.
    /// </summary>
    public class AccountCreateResponseWrap : AccountResponseWrap
    {
        /// <summary>
        /// OAuth token for new account.
        /// </summary>
        public OAuthToken OAuthData { get; set; }
    }
}
