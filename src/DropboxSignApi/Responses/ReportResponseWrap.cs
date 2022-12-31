using Soukoku.DropboxSignApi.Requests;

namespace Soukoku.DropboxSignApi.Responses
{
    /// <summary>
    /// Response for <see cref="DropboxSignClient.CreateReportAsync(Requests.CreateReportRequest, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class ReportResponseWrap : ResponseWrap
    {
        /// <summary>
        /// Contains information about the report request.
        /// </summary>
        public ReportResponse Report { get; set; }
    }
}