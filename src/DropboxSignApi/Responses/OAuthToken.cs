namespace Soukoku.DropboxSignApi.Responses
{
    public class OAuthToken
    {
        public string AccessToken { get; set; }

        public string TokenType { get; set; }

        public string RefreshToken { get; set; }

        /// <summary>
        /// Number of seconds until the access_token expires. Uses epoch time.
        /// </summary>
        public int ExpiresIn { get; set; }

        public string State { get; set; }
    }
}