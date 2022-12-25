// this file contains reponse data models.

namespace DropboxSignApi.Common
{
    /// <summary>
    /// Contains information about your team and its members
    /// </summary>
    public class Team
    {
        /// <summary>
        /// The name of your Team.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A list of all Accounts belonging to your Team.
        /// </summary>
        public Account[] Accounts { get; set; }
        /// <summary>
        /// A list of all Accounts that have an outstanding invitation to join your Team. 
        /// </summary>
        public AccountMin[] InvitedAccounts { get; set; }
    }
}
