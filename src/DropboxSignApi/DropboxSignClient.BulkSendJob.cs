using DropboxSignApi.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DropboxSignApi
{
    // this contains bulk send job methods

    partial class DropboxSignClient
    {
        const string BulkSendUrl = "https://api.hellosign.com/v3/bulk_send_job";

        /// <summary>
        /// Returns the status of the BulkSendJob and its SignatureRequests specified by the bulk_send_job_id parameter.
        /// </summary>
        /// <param name="bulkSendJobId">The id of the BulkSendJob to retrieve.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Id required.</exception>
        public Task<BulkSendJobResponse> GetBulkSendJobAsync(string bulkSendJobId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(bulkSendJobId)) { throw new ArgumentException("Id required."); }

            return GetAsync<BulkSendJobResponse>($"{BulkSendUrl}/{Uri.EscapeDataString(bulkSendJobId)}", cancellationToken);
        }

        /// <summary>
        /// Returns a list of BulkSendJob that you can access.
        /// </summary>
        /// <param name="page">Which page number of the BulkSendJob List to return. Defaults to 1.</param>
        /// <param name="pageSize">Number of objects to be returned per page. Must be between 1 and 100. Default is 20.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<BulkSendJobListResponse> GetBulkSendJobListAsync(int page = 1, int pageSize = 20,
            CancellationToken cancellationToken = default)
        {
            page = Math.Max(1, page);
            pageSize = Math.Min(100, Math.Max(1, pageSize));

            return GetAsync<BulkSendJobListResponse>($"{BulkSendUrl}/list?page={page}&page_size={pageSize}", cancellationToken);
        }
    }
}
