using System;

namespace DropboxSignApi
{
    static class UnixTimeExtensions
    {
        static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        ///// <summary>
        ///// Converts froms the unix time stamp to <see cref="DateTime"/> in UTc.
        ///// </summary>
        ///// <param name="value">The value.</param>
        ///// <returns></returns>
        //public static DateTime FromUnixTime(this int value)
        //{
        //    return Epoch.AddSeconds(value);
        //}

        /// <summary>
        /// Converts froms the unix time stamp to <see cref="DateTime"/> in UTc.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DateTime FromUnixTime(this long value)
        {
            return Epoch.AddSeconds(value);
        }
    }
}
