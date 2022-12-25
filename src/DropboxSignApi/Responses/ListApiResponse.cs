// this file contains reponse wrapper models.

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Basic response from calling a list api.
    /// </summary>
    public class ListApiResponse : ApiResponse
    {
        /// <summary>
        /// Gets the paging info for the response.
        /// </summary>
        public ListInfo ListInfo { get; set; }
    }
}
