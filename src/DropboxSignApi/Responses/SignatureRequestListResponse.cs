﻿using DropboxSignApi.Common;

// this file contains reponse wrapper models.

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the signature request list api call.
    /// </summary>
    public class SignatureRequestListResponse : ListApiResponse
    {
        /// <summary>
        /// The signature request objects.
        /// </summary>
        public SignatureRequest[] SignatureRequests { get; set; }
    }
}
