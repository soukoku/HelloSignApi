namespace Soukoku.DropboxSignApi.Requests
{
    public class SubCC
    {
        /// <summary>
        /// Must match an existing CC role in chosen Template(s). 
        /// Multiple CC recipients cannot share the same CC role.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// The email address of the CC recipient.
        /// </summary>
        public string EmailAddress { get; set; }
    }
}