using System.Collections.Generic;

namespace Soukoku.DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the signature request list api call.
    /// </summary>
    public class SignatureRequestListResponseWrap : ListResponseWrap
    {
        /// <summary>
        /// Contains information about signature requests.
        /// </summary>
        public IList<SignatureRequestResponse> SignatureRequests { get; set; }
    }
}
