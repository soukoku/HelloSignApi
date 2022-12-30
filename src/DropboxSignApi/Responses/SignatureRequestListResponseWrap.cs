using System.Collections.Generic;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the signature request list api call.
    /// </summary>
    public class SignatureRequestListResponseWrap : ListApiResponse
    {
        /// <summary>
        /// Contains information about signature requests.
        /// </summary>
        public IList<SignatureRequestResponse> SignatureRequests { get; set; }
    }
}
