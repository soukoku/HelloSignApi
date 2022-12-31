namespace Soukoku.DropboxSignApi.Requests
{
    public class SubEditorOptions
    {
        /// <summary>
        /// Allows requesters to edit the list of signers.
        /// </summary>
        public bool AllowEditSigners { get; set; }

        /// <summary>
        /// Allows requesters to edit documents, including delete and add.
        /// </summary>
        public bool AllowEditDocuments { get; set; }
    }
}
