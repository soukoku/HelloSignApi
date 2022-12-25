namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Basic response from calling a list api.
    /// </summary>
    public class ListApiResponse : ApiResponse
    {
        /// <summary>
        /// Contains pagination information about the data returned.
        /// </summary>
        public ListInfo ListInfo { get; set; }
    }
}
