using Soukoku.DropboxSignApi.Requests;
using Soukoku.DropboxSignApi.Responses;
using Soukoku.DropboxSignApi.Utils;
using System.Threading;
using System.Threading.Tasks;

namespace Soukoku.DropboxSignApi
{
    // this contains report methods

    partial class DropboxSignClient
    {
        const string ReportUrl = "https://api.hellosign.com/v3/report";

        /// <summary>
        /// Returns the status of the BulkSendJob and its SignatureRequests specified by the bulk_send_job_id parameter.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ReportResponseWrap> CreateReportAsync(CreateReportRequest request, CancellationToken cancellationToken = default)
        {
            return PostAsync<ReportResponseWrap>($"{ReportUrl}/create", request.ToJsonContent(_log), cancellationToken);
        }

    }
}
