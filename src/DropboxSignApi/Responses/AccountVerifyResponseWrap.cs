namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the account api calls.
    /// </summary>
    public class AccountVerifyResponseWrap : ResponseWrap
    {
        /// <summary>
        /// The account object.
        /// </summary>
        public AccountVerifyResponse Account { get; set; }
    }
}
