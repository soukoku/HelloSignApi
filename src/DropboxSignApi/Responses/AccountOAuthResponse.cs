namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Extended account api response with oauth token data.
    /// </summary>
    public class AccountOAuthResponse : AccountResponse
    {
        public OAuthToken OAuthData { get; set; }
    }
}
