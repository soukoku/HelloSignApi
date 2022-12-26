using System.Collections.Generic;

namespace DropboxSignApi.Responses
{

    /// <summary>
    /// Response for the api app list api call.
    /// </summary>
    public class ApiAppListResponseWrap : ListApiResponse
    {
        /// <summary>
        /// The api app objects.
        /// </summary>
        public IList<ApiAppResponse> ApiApps { get; set; }
    }
}
