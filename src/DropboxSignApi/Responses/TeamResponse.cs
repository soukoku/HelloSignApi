using System.Collections.Generic;

namespace Soukoku.DropboxSignApi.Responses
{
    /// <summary>
    /// Contains information about your team and its members
    /// </summary>
    public class TeamResponse
    {
        /// <summary>
        /// The name of your Team.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A list of all Accounts belonging to your Team.
        /// </summary>
        public IList<AccountResponse> Accounts { get; set; }
        /// <summary>
        /// A list of all Accounts that have an outstanding invitation to join your Team. 
        /// </summary>
        public IList<AccountResponse> InvitedAccounts { get; set; }
    }
}
