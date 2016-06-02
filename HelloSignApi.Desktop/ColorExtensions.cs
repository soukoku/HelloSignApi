using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloSignApi
{
    /// <summary>
    /// Contains extension methods for converting colors to and from html hex string values.
    /// This can be used by <see cref="WhiteLabelingOptions"/>.
    /// </summary>
    public static class ColorExtensions
    {

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
            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }

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
            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }
    }
}
