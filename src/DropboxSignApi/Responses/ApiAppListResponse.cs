using DropboxSignApi.Common;
using System.Collections.Generic;

namespace DropboxSignApi.Responses
{

    /// <summary>
    /// Response for the api app list api call.
    /// </summary>
    public class ApiAppListResponse : ListApiResponse
    {
        /// <summary>
        /// The api app objects.
        /// </summary>
        public IList<ApiApp> ApiApps { get; set; }
    }
}
