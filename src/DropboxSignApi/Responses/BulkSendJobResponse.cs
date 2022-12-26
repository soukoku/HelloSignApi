using DropboxSignApi.Common;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for <see cref="DropboxSignClient.GetBulkSendJobAsync(string, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class BulkSendJobResponse : ApiResponse
    {
        /// <summary>
        /// Contains information about the BulkSendJob such as when it was created and how many signature requests are queued.
        /// </summary>
        public BulkSendJob BulkSendJob { get; set; }
    }
}