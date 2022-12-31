namespace Soukoku.DropboxSignApi.Requests
{
    public class SubMergeField
    {
        /// <summary>
        /// The name of the merge field. Must be unique.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of merge field. "text" and "checkbox".
        /// </summary>
        public string Type { get; set; }
    }
}
