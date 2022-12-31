namespace Soukoku.DropboxSignApi.Requests
{
    /// <summary>
    /// Represents a signer role in a template.
    /// </summary>
    public class SubTemplateRole
    {
        /// <summary>
        /// The role name of the signer that will be displayed when the template is used to create a signature request.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The order in which this signer role is required to sign.
        /// </summary>
        public int? Order { get; set; }
    }
}
