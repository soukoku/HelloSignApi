using DropboxSignApi.Internal;
using DropboxSignApi.Responses;
using DropboxSignApi.Utils;
using System;
using System.Net.Http;
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
        public Task<TeamResponse> GetTeamAsync(CancellationToken cancellationToken = default)
        {
            return GetAsync<TeamResponse>(TeamUrl, cancellationToken);
        }

        /// <summary>
        /// Creates a new Team and makes you a member. You must not currently belong to a Team to invoke.
        /// </summary>
        /// <param name="name">The name of your team.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Name is required.</exception>
        public Task<TeamResponse> CreateTeamAsync(string name,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) { throw new ArgumentException("Name is required."); }

            return PostAsync<TeamResponse>($"{TeamUrl}/create", new { name }.ToJsonContent(_log), cancellationToken);
        }

        /// <summary>
        /// Updates the name of your Team.
        /// </summary>
        /// <param name="name">The name of your team.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Name is required.</exception>
        public Task<TeamResponse> UpdateTeamAsync(string name,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) { throw new ArgumentException("Name is required."); }

            return PostAsync<TeamResponse>(TeamUrl, new { name }.ToJsonContent(_log), cancellationToken);
        }

        /// <summary>
        /// Deletes your Team. Can only be invoked when you have a Team with only one member (yourself).
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ApiResponse> DeleteTeamAsync(CancellationToken cancellationToken = default)
        {
            return PostAsync<ApiResponse>($"{TeamUrl}/destroy", null, cancellationToken);
        }

        /// <summary>
        /// Adds or invites a user (specified using the email_address parameter) to your Team.
        /// If the user does not currently have a HelloSign Account, a new one will be created for them.
        /// If the user currently has a paid subscription, they will not automatically join the Team but
        /// instead will be sent an invitation to join. If a user is already a part of another Team,
        /// a <see cref="ErrorNames.TeamInviteFailed" /> error will be returned.
        /// </summary>
        /// <param name="accountId">The account id. Exclusive with emailAddress parameter.</param>
        /// <param name="emailAddress">The email address. Exclusive with accountId parameter.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TeamResponse> AddTeamUserAsync(string accountId, string emailAddress,
            CancellationToken cancellationToken = default)
        {
            var request = new
            {
                accountId,
                emailAddress
            };

            return PostAsync<TeamResponse>($"{TeamUrl}/add_member", request.ToJsonContent(_log), cancellationToken);
        }

        /// <summary>
        /// Removes a user from your Team. If the user had an outstanding invitation to your Team the invitation will be expired.
        /// </summary>
        /// <param name="accountId">The account id. Exclusive with emailAddress parameter.</param>
        /// <param name="emailAddress">The email address. Exclusive with accountId parameter.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TeamResponse> RemoveTeamUserAsync(string accountId, string emailAddress,
            CancellationToken cancellationToken = default)
        {
            var request = new
            {
                accountId,
                emailAddress
            };

            return PostAsync<TeamResponse>($"{TeamUrl}/remove_member", request.ToJsonContent(_log), cancellationToken);
        }
    }
}
