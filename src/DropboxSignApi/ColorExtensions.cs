using DropboxSignApi.Common;

namespace DropboxSignApi
{
    /// <summary>
    /// Contains extension methods for converting colors to and from html hex string values.
    /// This can be used by <see cref="WhiteLabelingOptions"/>.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Converts color to html hex string.
        /// </summary>
        /// <param name="red">The red color component value.</param>
        /// <param name="green">The green color component value.</param>
        /// <param name="blue">The blue color component value.</param>
        /// <returns></returns>
        public static string ToHtmlColor(byte red, byte green, byte blue)
        {
            return "#" + red.ToString("X2") + green.ToString("X2") + blue.ToString("X2");
        }


#if NET40_OR_GREATER || NET5_0_OR_GREATER

        /// <summary>
        /// Converts html color string to color.
        /// </summary>
        /// <param name="htmlColor">HTML hex color string.</param>
        /// <returns></returns>
        public static System.Drawing.Color ToColor(this string htmlColor)
        {
            return System.Drawing.ColorTranslator.FromHtml(htmlColor);
        }
        /// <summary>
        /// Converts color to html hex string.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string ToHtmlColor(this System.Drawing.Color color)
        {
            //return System.Drawing.ColorTranslator.ToHtml(color); // doesn't convert known colors
            return ToHtmlColor(color.R, color.G, color.B);
        }
#endif

#if NET40_OR_GREATER || WINDOWS

        /// <summary>
        /// Converts html color string to WPF color.
        /// </summary>
        /// <param name="htmlColor">HTML hex color string.</param>
        /// <returns></returns>
        public static System.Windows.Media.Color ToColorWpf(this string htmlColor)
        {
            return (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(htmlColor);
        }
        /// <summary>
        /// Converts color to html hex string.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string ToHtmlColor(this System.Windows.Media.Color color)
        {
            return ToHtmlColor(color.R, color.G, color.B);
        }

#endif
    }
}