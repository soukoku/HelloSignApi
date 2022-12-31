﻿namespace Soukoku.DropboxSignApi.Responses
{
    /// <summary>
    /// An object that contains necessary information to set up embedded template editing.
    /// </summary>
    public class EmbeddedTemplateUrl : ExpiringObject
    {
        /// <summary>
        /// The template id if applicable.
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        /// A template url that can be opened in an iFrame.
        /// </summary>
        public string EditUrl { get; set; }
    }
}
