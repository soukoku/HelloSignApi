using DropboxSignApi.Utils;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace DropboxSignApi.Common
{
    /// <summary>
    /// Contains information about bulk sent signature requests.
    /// </summary>
    public class BulkSendJob
    {
        /// <summary>
        /// The id of the BulkSendJob.
        /// </summary>
        public string BulkSendJobId { get; set; }

        /// <summary>
        /// The total amount of SignatureRequests queued for sending.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// True if you are the owner of this BulkSendJob, false if it's been shared with you by a team member.
        /// </summary>
        public bool IsCreator { get; set; }

        /// <summary>
        /// Time that the BulkSendJob was created.
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.UnixDateTimeConverter))]
        public DateTime? CreatedAt { get; set; }
    }
}
