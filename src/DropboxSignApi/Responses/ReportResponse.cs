using DropboxSignApi.Requests;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Main data for <see cref="ReportResponseWrap"/>.
    /// </summary>
    public class ReportResponse : CreateReportRequest
    {
        /// <summary>
        /// A message indicating the requested operation's success.
        /// </summary>
        public string Success { get; set; }
    }
}