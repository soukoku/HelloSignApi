using DropboxSignApi.Internal;
using DropboxSignApi.Requests;
using DropboxSignApi.Responses;
using DropboxSignApi.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DropboxSignApi
{
    // this contains api app methods

    partial class DropboxSignClient
    {
        const string ApiAppUrl = "https://api.hellosign.com/v3/api_app";

        /// <summary>
        /// Returns an object with information about an API App.
        /// </summary>
        /// <param name="clientId">The client ID of the ApiApp to retrieve.</param>
        /// <param name="cancellationToken"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Client id required.</exception>
        public Task<ApiAppResponse> GetApiAppAsync(string clientId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(clientId)) { throw new ArgumentException("Client id required."); }

            return GetAsync<ApiAppResponse>($"{ApiAppUrl}/{Uri.EscapeDataString(clientId)}", cancellationToken);
        }

        /// <summary>
        /// Returns a list of API Apps that are accessible by you. If you are on a team with an
        /// Admin or Developer role, this list will include apps owned by teammates.
        /// </summary>
        /// <param name="page">Which page number of the ApiApp List to return. Defaults to 1.</param>
        /// <param name="pageSize">Number of objects to be returned per page. Must be between 1 and 100. Default is 20.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ApiAppListResponse> GetApiAppListAsync(int page = 1, int pageSize = 20,
            CancellationToken cancellationToken = default)
        {
            page = Math.Max(1, page);
            pageSize = Math.Min(100, Math.Max(1, pageSize));

            return GetAsync<ApiAppListResponse>($"{ApiAppUrl}/list?page={page}&page_size={pageSize}", cancellationToken);
        }

        /// <summary>
        /// Creates a new API App.
        /// </summary>
        /// <param name="request">The application to add.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ApiAppResponse> CreateApiAppAsync(ApiAppRequest request,
            CancellationToken cancellationToken = default)
        {
            return PostAsync<ApiAppResponse>(ApiAppUrl, request.ToJsonContent(_log), cancellationToken);
        }

        /// <summary>
        /// Updates an existing API App. Can only be invoked for apps you own.
        /// Only the fields you provide will be updated. If you wish to clear an existing optional field,
        /// provide an empty string.
        /// </summary>
        /// <param name="clientId">The client id of the API App to update.</param>
        /// <param name="request">The application to update.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">app</exception>
        public Task<ApiAppResponse> UpdateApiAppAsync(string clientId, ApiAppRequest request,
            CancellationToken cancellationToken = default)
        {
            return PutAsync<ApiAppResponse>($"{ApiAppUrl}/{Uri.EscapeDataString(clientId)}", request.ToJsonContent(_log), cancellationToken);
        }

        /// <summary>
        /// Removes a user from your Team. If the user had an outstanding invitation to your Team the invitation will be expired.
        /// </summary>
        /// <param name="clientId">The client id of the ApiApp to delete.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Client id is required.</exception>
        public Task<ApiResponse> DeleteApiAppAsync(string clientId,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(clientId)) { throw new ArgumentException("Client id is required."); }

            return PostAsync<ApiResponse>($"{ApiAppUrl}/{Uri.EscapeDataString(clientId)}", null, cancellationToken);
        }
    }
}
