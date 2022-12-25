using System.Net.Http;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the get file api call with download url.
    /// </summary>
    public class DownloadDataResponse : ApiResponse
    {
        /// <summary>
        /// The download data response.
        /// </summary>
        public HttpResponseMessage FileResponse { get; internal set; }
    }
}
