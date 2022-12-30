namespace DropboxSignApi.Responses
{
    /// <summary>
    /// For use in a <see cref="TemplateResponseCustomField"/>.
    /// </summary>
    public class TemplateResponseFieldAvgTextLength
    {
        /// <summary>
        /// Number of lines.
        /// </summary>
        public int NumLines { get; set; }

        /// <summary>
        /// Number of character per line.
        /// </summary>
        public int NumCharsPerLine { get; set; }
    }
}