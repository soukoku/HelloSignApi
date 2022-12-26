using DropboxSignApi.Requests;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for <see cref="DropboxSignClient.CreateReportAsync(Requests.CreateReportRequest, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class ApiReportResponse : ApiResponse
    {
        /// <summary>
        /// Contains information about the report request.
        /// </summary>
        public ReportResponse Report { get; set; }
    }

    /// <summary>
    /// Main data for <see cref="ApiReportResponse"/>.
    /// </summary>
    public class ReportResponse : CreateReportRequest
    {
        /// <summary>
        /// A message indicating the requested operation's success.
        /// </summary>
        public string Success { get; set; }
    }
}