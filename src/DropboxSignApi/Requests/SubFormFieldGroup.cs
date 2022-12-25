namespace DropboxSignApi.Requests
{
    public class SubFormFieldGroup
    {
        /// <summary>
        /// ID of group. Use this to reference a specific group from the 
        /// group value in form_fields_per_document.
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// Name of the group
        /// </summary>
        public string GroupLabel { get; set; }

        public string Requirement { get; set; }
    }
}