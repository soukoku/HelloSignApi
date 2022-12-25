﻿using DropboxSignApi.Common;

// this file contains reponse wrapper models.

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the template list api call.
    /// </summary>
    public class TemplateListResponse : ListApiResponse
    {
        /// <summary>
        /// The template objects.
        /// </summary>
        public Template[] Templates { get; set; }
    }
}
