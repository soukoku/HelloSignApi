using DropboxSignApi.Common;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the team api calls.
    /// </summary>
    public class TeamResponse : ApiResponse
    {
        /// <summary>
        /// The team object.
        /// </summary>
        public Team Team { get; set; }
    }
}
