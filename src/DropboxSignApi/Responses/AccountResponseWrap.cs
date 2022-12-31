namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the account api calls.
    /// </summary>
    public class AccountResponseWrap : ResponseWrap
    {
        /// <summary>
        /// The account object.
        /// </summary>
        public AccountResponse Account { get; set; }
    }
}
