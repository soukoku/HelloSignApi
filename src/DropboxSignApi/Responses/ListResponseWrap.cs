namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Basic response from calling a list API.
    /// </summary>
    public class ListResponseWrap : ResponseWrap
    {
        /// <summary>
        /// Contains pagination information about the data returned.
        /// </summary>
        public ListInfoResponse ListInfo { get; set; }
    }
}
