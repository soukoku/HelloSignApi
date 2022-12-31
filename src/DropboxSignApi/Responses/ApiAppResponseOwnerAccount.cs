namespace Soukoku.DropboxSignApi.Responses
{
    /// <summary>
    /// Min amount of account object.
    /// </summary>
    public class ApiAppResponseOwnerAccount
    {
        /// <summary>
        /// The ID of the Account.
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// The email address associated with the Account.
        /// </summary>
        public string EmailAddress { get; set; }
    }
}
