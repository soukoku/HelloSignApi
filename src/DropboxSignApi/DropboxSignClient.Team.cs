using DropboxSignApi.Responses;
using DropboxSignApi.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DropboxSignApi
{
    // this contains team api methods

    partial class DropboxSignClient
    {
        const string TeamUrl = "https://api.hellosign.com/v3/team";

        /// <summary>
        /// Returns information about your Team as well as a list of its members. If you do not belong to a Team,
        /// a 404 error with an error name of <see cref="ErrorNames.NotFound" /> will be returned.
        /// </summary>
        /// <returns></returns>
        public Task<TeamResponseWrap> GetTeamAsync(CancellationToken cancellationToken = default)
        {
            return GetAsync<TeamResponseWrap>(TeamUrl, cancellationToken);
        }

        /// <summary>
        /// Creates a new Team and makes you a member. You must not currently belong to a Team to invoke.
        /// </summary>
        /// <param name="name">The name of your team.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Name is required.</exception>
        public Task<TeamResponseWrap> CreateTeamAsync(string name,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) { throw new ArgumentException("Name is required."); }

            return PostAsync<TeamResponseWrap>($"{TeamUrl}/create", new { name }.ToJsonContent(_log), cancellationToken);
        }

        /// <summary>
        /// Updates the name of your Team.
        /// </summary>
        /// <param name="name">The name of your team.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Name is required.</exception>
        public Task<TeamResponseWrap> UpdateTeamAsync(string name,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) { throw new ArgumentException("Name is required."); }

            return PutAsync<TeamResponseWrap>(TeamUrl, new { name }.ToJsonContent(_log), cancellationToken);
        }

        /// <summary>
        /// Deletes your Team. Can only be invoked when you have a Team with only one member (yourself).
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ResponseWrap> DeleteTeamAsync(CancellationToken cancellationToken = default)
        {
            return DeleteAsync<ResponseWrap>($"{TeamUrl}/destroy", cancellationToken);
        }

        /// <summary>
        /// Invites a user (specified using the email_address parameter) to your Team. 
        /// If the user does not currently have a Dropbox Sign Account, 
        /// a new one will be created for them. If a user is already a part of another Team, 
        /// a team_invite_failed error will be returned.
        /// </summary>
        /// <param name="accountId">Account id of the user to invite to your Team. Exclusive with emailAddress parameter.</param>
        /// <param name="emailAddress">Email address of the user to invite to your Team. Exclusive with accountId parameter.</param>
        /// <param name="teamId">The id of the team.</param>
        /// <param name="role">A role member will take in a new Team. This parameter is used only if team_id is provided.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TeamResponseWrap> AddTeamUserAsync(string accountId, string emailAddress,
            string role = null, string teamId = null,
            CancellationToken cancellationToken = default)
        {
            var request = new
            {
                accountId,
                emailAddress,
                role
            };
            var url = $"{TeamUrl}/add_member";
            if (!string.IsNullOrEmpty(teamId)) url += $"?team_id={Uri.EscapeDataString(teamId)}";

            return PutAsync<TeamResponseWrap>(url, request.ToJsonContent(_log), cancellationToken);
        }

        /// <summary>
        /// Removes the provided user Account from your Team. If the Account had an outstanding 
        /// invitation to your Team, the invitation will be expired. If you choose to transfer documents 
        /// from the removed Account to an Account provided in the new_owner_email_address parameter 
        /// (available only for Enterprise plans), the response status code will be 201, which 
        /// indicates that your request has been queued but not fully executed.
        /// </summary>
        /// <param name="accountId">Account id to remove from your Team. Exclusive with emailAddress parameter.</param>
        /// <param name="emailAddress">Email address of the Account to remove from your Team. Exclusive with accountId parameter.</param>
        /// <param name="newOwnerEmailAddress">The email address of an Account on this Team to receive all documents, templates, 
        /// and API apps (if applicable) from the removed Account. 
        /// If not provided, and on an Enterprise plan, this data will remain with the removed Account.</param>
        /// <param name="newTeamId">Id of the new Team.</param>
        /// <param name="newRole">A new role member will take in a new Team.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TeamResponseWrap> RemoveTeamUserAsync(string accountId, string emailAddress,
            string newOwnerEmailAddress, string newTeamId = null, string newRole = null,
            CancellationToken cancellationToken = default)
        {
            var request = new
            {
                accountId,
                emailAddress,
                newOwnerEmailAddress,
                newTeamId,
                newRole
            };

            return PostAsync<TeamResponseWrap>($"{TeamUrl}/remove_member", request.ToJsonContent(_log), cancellationToken);
        }
    }
}
