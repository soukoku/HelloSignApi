namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the get file api call with download url.
    /// </summary>
    public class DownloadInfoResponse : ApiResponse
    {
        /// <summary>
        /// The download info object.
        /// </summary>
        public DownloadInfo DownloadInfo { get; internal set; }
    }
}
