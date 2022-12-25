using DropboxSignApi.Common;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the account api calls.
    /// </summary>
    public class AccountVerifyResponse : ApiResponse
    {
        /// <summary>
        /// The account object.
        /// </summary>
        public AccountVerifyResponseAccount Account { get; set; }
    }

    /// <summary>
    /// Account data for <see cref="AccountVerifyResponse"/>.
    /// </summary>
    public class AccountVerifyResponseAccount
    {
        /// <summary>
        /// The email address associated with the Account.
        /// </summary>
        public string EmailAddress { get; set; }
    }
}
