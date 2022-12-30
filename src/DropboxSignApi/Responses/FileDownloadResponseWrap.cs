using System;
using System.Net.Http;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the file download api call.
    /// </summary>
    public class FileDownloadResponseWrap : ApiResponse, IDisposable
    {
        /// <summary>
        /// The download data response.
        /// </summary>
        public HttpResponseMessage FileResponse { get; internal set; }

        /// <summary>
        /// Dispose this object.
        /// </summary>
        public void Dispose()
        {
            if (FileResponse != null) FileResponse.Dispose();
        }
    }
}
