﻿namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the embedded sign api call.
    /// </summary>
    public class EmbeddedSignUrlResponseWrap : ApiResponse
    {
        /// <summary>
        /// An object that contains necessary information to set up embedded signing.
        /// </summary>
        public EmbeddedSignUrlResponse Embedded { get; set; }
    }
}
