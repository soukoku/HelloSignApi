using HelloSignApi.Responses;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelloSignApi
{
    // this contains team api methods

    partial class HelloSignClient
    {
        const string TeamUrl = "https://api.hellosign.com/v3/team";

        /// <summary>
        /// Returns information about your Team as well as a list of its members. If you do not belong to a Team,
        /// a 404 error with an error name of <see cref="ErrorNames.NotFound" /> will be returned.
        /// </summary>
        /// <returns></returns>
        public Task<TeamResponse> GetTeamAsync()
        {
            var resp = _client.GetAsync(TeamUrl)
                .ContinueWith(t => t.Result.ParseApiResponseAsync<TeamResponse>());
            return resp.Unwrap();
        }

        /// <summary>
        /// Creates a new Team and makes you a member. You must not currently belong to a Team to invoke.
        /// </summary>
        /// <param name="name">The name of your team.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Name is required.</exception>
        public Task<TeamResponse> CreateTeamAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) { throw new ArgumentException("Name is required."); }

            var content = new MultipartFormDataContent();
            content.AddParameter("name", name);

            var resp = _client.PostAsync($"{TeamUrl}/create", content)
                .ContinueWith(t => t.Result.ParseApiResponseAsync<TeamResponse>());
            return resp.Unwrap();
        }

        /// <summary>
        /// Updates the name of your Team.
        /// </summary>
        /// <param name="name">The name of your team.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Name is required.</exception>
        public Task<TeamResponse> UpdateTeamAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) { throw new ArgumentException("Name is required."); }

            var content = new MultipartFormDataContent();
            content.AddParameter("name", name);

            var resp = _client.PostAsync(TeamUrl, content)
                .ContinueWith(t => t.Result.ParseApiResponseAsync<TeamResponse>());
            return resp.Unwrap();
        }

        /// <summary>
        /// Deletes your Team. Can only be invoked when you have a Team with only one member (yourself).
        /// </summary>
        /// <returns></returns>
        public Task<ApiResponse> DeleteTeamAsync()
        {
            var resp = _client.PostAsync($"{TeamUrl}/destroy", null)
                .ContinueWith(t => t.Result.ParseApiResponseAsync<ApiResponse>());
            return resp.Unwrap();
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
        /// <returns></returns>
        public Task<TeamResponse> AddTeamUserAsync(string accountId, string emailAddress)
        {
            var content = new MultipartFormDataContent();
            content.AddParameter("account_id", accountId);
            content.AddParameter("email_address", emailAddress);

            var resp = _client.PostAsync($"{TeamUrl}/add_member", content)
                .ContinueWith(t => t.Result.ParseApiResponseAsync<TeamResponse>());
            return resp.Unwrap();
        }

        /// <summary>
        /// Removes a user from your Team. If the user had an outstanding invitation to your Team the invitation will be expired.
        /// </summary>
        /// <param name="accountId">The account id. Exclusive with emailAddress parameter.</param>
        /// <param name="emailAddress">The email address. Exclusive with accountId parameter.</param>
        /// <returns></returns>
        public Task<TeamResponse> RemoveTeamUserAsync(string accountId, string emailAddress)
        {
            var content = new MultipartFormDataContent();
            content.AddParameter("account_id", accountId);
            content.AddParameter("email_address", emailAddress);

            var resp = _client.PostAsync($"{TeamUrl}/remove_member", content)
                .ContinueWith(t => t.Result.ParseApiResponseAsync<TeamResponse>());
            return resp.Unwrap();
        }
    }
}
