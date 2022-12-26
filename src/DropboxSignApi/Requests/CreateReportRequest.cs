using System.Collections.Generic;

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Request for <see cref="DropboxSignClient.CreateReportAsync(CreateReportRequest, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class CreateReportRequest
    {
        /// <summary>
        /// The (inclusive) start date for the report data in MM/DD/YYYY format.
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// The (inclusive) end date for the report data in MM/DD/YYYY format.
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// The type(s) of the report you are requesting. Allowed values are 
        /// user_activity and document_status. User activity reports contain list of all 
        /// users and their activity during the specified date range. Document status 
        /// report contain a list of signature requests created in the specified time range (and their status).
        /// </summary>
        public IList<string> ReportType { get; } = new List<string>();
    }
}