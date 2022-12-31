namespace Soukoku.DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the get file api call with data uri or download url.
    /// </summary>
    public class FileDataUriResponseWrap : ResponseWrap
    {
        /// <summary>
        /// The data uri string.
        /// </summary>
        public string DataUri { get; internal set; }
    }
}
