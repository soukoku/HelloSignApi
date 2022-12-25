﻿using DropboxSignApi.Common;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the unclaimed draft api calls.
    /// </summary>
    public class UnclaimedDraftResponse : ApiResponse
    {
        /// <summary>
        /// The unclaimed draft object.
        /// </summary>
        public UnclaimedDraft UnclaimedDraft { get; set; }
    }
}