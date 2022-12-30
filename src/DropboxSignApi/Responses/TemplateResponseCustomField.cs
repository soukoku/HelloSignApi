﻿namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Custom field of a template.
    /// </summary>
    public class TemplateResponseCustomField
    {
        /// <summary>
        /// The name of the custom field.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The type of this Custom Field. Only text and checkbox are currently supported.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The horizontal offset in pixels for this form field.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The vertical offset in pixels for this form field.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// The width in pixels of this form field.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The height in pixels of this form field.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Boolean showing whether or not this field is required.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// A unique id for the form field.
        /// </summary>
        public string ApiId { get; set; }

        /// <summary>
        /// The name of the group this field is in. If this field is not a group, this defaults to null.
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Average text length in this field.
        /// </summary>
        public TemplateResponseFieldAvgTextLength AvgTextLength { get; set; }

        /// <summary>
        /// Whether this form field is multiline text.
        /// </summary>
        public bool IsMultiline { get; set; }

        /// <summary>
        /// Original font size used in this form field's text.
        /// </summary>
        public int OriginalFontSize { get; set; }

        /// <summary>
        /// Font family used in this form field's text.
        /// </summary>
        public string FontFamily { get; set; }
    }
}