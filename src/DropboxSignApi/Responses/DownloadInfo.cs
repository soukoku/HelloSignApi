using DropboxSignApi.Common;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// An object that contains file download info.
    /// </summary>
    public class DownloadInfo : ExpiringObject
    {
        /// <summary>
        /// URL of the download url.
        /// </summary>
        public string FileUrl { get; set; }
    }
}
