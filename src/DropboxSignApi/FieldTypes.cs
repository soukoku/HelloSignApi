namespace Soukoku.DropboxSignApi
{
    /// <summary>
    /// Contains possible values for field types.
    /// </summary>
    public static class FieldTypes
    {
        /// <summary>
        /// A text input field
        /// </summary>
        public const string Text = "text";
        /// <summary>
        /// A yes/no checkbox
        /// </summary>
        public const string CheckBox = "checkbox";
        /// <summary>
        /// A date when a document was signed.
        /// </summary>
        public const string DateSigned = "date_signed";
        /// <summary>
        /// An input field for dropdowns.
        /// </summary>
        public const string Dropdown = "dropdown";
        /// <summary>
        /// An input field for initials
        /// </summary>
        public const string Initials = "initials";
        /// <summary>
        /// An input field for radios
        /// </summary>
        public const string Radio = "radio";
        /// <summary>
        /// A signature input field
        /// </summary>
        public const string Signature = "signature";
        /// <summary>
        /// A text field that has default text set by the api.
        /// </summary>
        public const string TextMerge = "text-merge";
        /// <summary>
        /// A checkbox field that has default value set by the api
        /// </summary>
        public const string CheckBoxMerge = "checkbox-merge";

        /// <summary>
        /// A hyperlink field?
        /// </summary>
        public const string Hyperlink = "hyperlink";

    }
}
