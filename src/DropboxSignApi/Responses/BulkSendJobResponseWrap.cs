using System.Collections.Generic;

namespace Soukoku.DropboxSignApi.Responses
{
    /// <summary>
    /// Response for bulk send jobs.
    /// </summary>
    public class BulkSendJobResponseWrap : ResponseWrap
    {
        /// <summary>
        /// Contains information about the BulkSendJob such as when it was created and how many signature requests are queued.
        /// </summary>
        public BulkSendJobResponse BulkSendJob { get; set; }

        /// <summary>
        /// Contains information about the Signature Requests sent in bulk.
        /// </summary>
        public IList<SignatureRequestResponse> SignatureRequests { get; set; }
    }
}