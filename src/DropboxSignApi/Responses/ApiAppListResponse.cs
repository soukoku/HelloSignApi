using DropboxSignApi.Common;

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
        public ApiApp[] ApiApps { get; set; }
    }
}
