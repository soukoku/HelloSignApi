using Soukoku.DropboxSignApi.Requests;

namespace Soukoku.DropboxSignApi.Responses
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