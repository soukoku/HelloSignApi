using DropboxSignApi.Requests;
using DropboxSignApi.Responses;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DropboxSignApi
{
    // this contains team api methods

    partial class DropboxSignClient
    {
        const string ApiAppUrl = "https://api.hellosign.com/v3/api_app";

        /// <summary>
        /// Returns an object with information about an API App.
        /// </summary>
        /// <param name="clientId">The client ID of the ApiApp to retrieve.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Client id required.</exception>
        public Task<ApiAppResponse> GetApiAppAsync(string clientId)
        {
            if (string.IsNullOrEmpty(clientId)) { throw new ArgumentException("Client id required."); }

            return GetAsync<ApiAppResponse>($"{ApiAppUrl}/{clientId}");
        }

        /// <summary>
        /// Returns a list of API Apps that are accessible by you. If you are on a team with an
        /// Admin or Developer role, this list will include apps owned by teammates.
        /// </summary>
        /// <param name="page">Which page number of the ApiApp List to return. Defaults to 1.</param>
        /// <param name="pageSize">Number of objects to be returned per page. Must be between 1 and 100. Default is 20.</param>
        /// <returns></returns>
        public Task<ApiAppListResponse> GetApiAppListAsync(int page = 1, int pageSize = 20)
        {
            page = Math.Max(1, page);
            pageSize = Math.Min(100, Math.Max(1, pageSize));

            return GetAsync<ApiAppListResponse>($"{ApiAppUrl}/list?page={page}&page_size={pageSize}");
        }

        /// <summary>
        /// Creates a new API App.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">app</exception>
        public Task<ApiAppResponse> CreateApiAppAsync(NewApiApp app)
        {
            if (app == null) { throw new ArgumentNullException(nameof(app)); }

            var content = new MultipartFormDataContent();
            content.AddApiApp(_log, app);

            return PostAsync<ApiAppResponse>(ApiAppUrl, content);
        }

        /// <summary>
        /// Updates an existing API App. Can only be invoked for apps you own.
        /// Only the fields you provide will be updated. If you wish to clear an existing optional field,
        /// provide an empty string.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="app">The application.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">app</exception>
        public Task<ApiAppResponse> UpdateApiAppAsync(string clientId, NewApiApp app)
        {
            if (string.IsNullOrEmpty(clientId)) { throw new ArgumentException("Client id is required."); }
            if (app == null) { throw new ArgumentNullException(nameof(app)); }

            var content = new MultipartFormDataContent();
            content.AddApiApp(_log, app);

            return PostAsync<ApiAppResponse>($"{ApiAppUrl}/{clientId}", content);
        }

        /// <summary>
        /// Removes a user from your Team. If the user had an outstanding invitation to your Team the invitation will be expired.
        /// </summary>
        /// <param name="clientId">The client id of the ApiApp to delete.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Client id is required.</exception>
        public Task<ApiResponse> DeleteApiAppAsync(string clientId)
        {
            if (string.IsNullOrEmpty(clientId)) { throw new ArgumentException("Client id is required."); }

            return PostAsync<ApiResponse>($"{ApiAppUrl}/{clientId}", null);
        }
    }
}
