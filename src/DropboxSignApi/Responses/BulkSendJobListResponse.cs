﻿using DropboxSignApi.Common;
using System.Collections.Generic;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for <see cref="DropboxSignClient.GetBulkSendJobListAsync(int, int, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class BulkSendJobListResponse : ListApiResponse
    {
        /// <summary>
        /// Contains a list of BulkSendJobs that the API caller has access to.
        /// </summary>
        public IList<BulkSendJob> BulkSendJobs { get; set; }
    }
}