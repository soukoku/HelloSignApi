namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Response for the team api calls.
    /// </summary>
    public class TeamResponseWrap : ApiResponse
    {
        /// <summary>
        /// Contains information about your team and its members
        /// </summary>
        public TeamResponse Team { get; set; }
    }
}
