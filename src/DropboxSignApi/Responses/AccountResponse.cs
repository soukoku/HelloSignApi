using DropboxSignApi.Common;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the account api calls.
    /// </summary>
    public class AccountResponse : ApiResponse
    {
        /// <summary>
        /// The account object.
        /// </summary>
        public Account Account { get; set; }
    }
}
