using Newtonsoft.Json;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Contains paging info for a <see cref="ListApiResponse"/>.
    /// </summary>
    public class ListInfoResponse
    {
        /// <summary>
        /// Total number of pages available.
        /// </summary>
        [JsonProperty("num_pages")]
        public int TotalPages { get; set; }

        /// <summary>
        /// Total number of objects available.
        /// </summary>
        [JsonProperty("num_results")]
        public int TotalCount { get; set; }

        /// <summary>
        /// Number of the page being returned.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Objects returned per page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"Page {Page}/{TotalPages}";
        }
    }
}
