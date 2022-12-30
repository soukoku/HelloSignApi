using System.Collections.Generic;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the template list api call.
    /// </summary>
    public class TemplateListResponseWrap : ListApiResponse
    {
        /// <summary>
        /// List of templates that the API caller has access to.
        /// </summary>
        public IList<TemplateResponse> Templates { get; set; }
    }
}
