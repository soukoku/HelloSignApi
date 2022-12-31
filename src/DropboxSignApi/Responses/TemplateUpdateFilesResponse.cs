using System.Collections.Generic;

namespace Soukoku.DropboxSignApi.Responses
{
    /// <summary>
    /// Data of <see cref="TemplateUpdateFilesResponseWrap"/>.
    /// </summary>
    public class TemplateUpdateFilesResponse
    {
        /// <summary>
        /// The id of the Template.
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        /// A list of warnings.
        /// </summary>
        public IList<WarningResponse> Warnings { get; set; }
    }
}