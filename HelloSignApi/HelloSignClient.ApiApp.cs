using HelloSignApi.Requests;
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

            var resp = _client.GetAsync($"{ApiAppUrl}/{clientId}")
                .ContinueWith(t => t.Result.ParseApiResponseAsync<ApiAppResponse>());
            return resp.Unwrap();
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

            var resp = _client.GetAsync($"{ApiAppUrl}/list?page={page}&page_size={pageSize}")
                .ContinueWith(t => t.Result.ParseApiResponseAsync<ApiAppListResponse>());
            return resp.Unwrap();
        }

        /// <summary>
        /// Creates a new API App.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">app</exception>
        public Task<ApiAppResponse> CreateApiAppAsync(NewApiApp app)
        {
            if (app == null) { throw new ArgumentNullException("app"); }

            var content = new MultipartFormDataContent();
            content.AddApiApp(app);

            var resp = _client.PostAsync(ApiAppUrl, content)
                .ContinueWith(t => t.Result.ParseApiResponseAsync<ApiAppResponse>());
            return resp.Unwrap();
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
            if (app == null) { throw new ArgumentNullException("app"); }

            var content = new MultipartFormDataContent();
            content.AddApiApp(app);

            var resp = _client.PostAsync($"{ApiAppUrl}/{clientId}", content)
                .ContinueWith(t => t.Result.ParseApiResponseAsync<ApiAppResponse>());
            return resp.Unwrap();
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

            var resp = _client.PostAsync($"{ApiAppUrl}/{clientId}", null)
                .ContinueWith(t => t.Result.ParseApiResponseAsync<ApiResponse>());
            return resp.Unwrap();
        }
    }
}
