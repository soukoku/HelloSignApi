using System;

namespace Soukoku.DropboxSignApi.Utils
{
    /// <summary>
    /// Converts to/from unix epoch time.
    /// </summary>
    public static class UnixTimeExtensions
    {
        static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Converts froms the unix time stamp to <see cref="DateTime"/> in UTC.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DateTime FromUnixTime(this long value)
        {
            return Epoch.AddSeconds(value);
        }

        /// <summary>
        /// Converts to unix time stamp value from a UTC time.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToUnixTime(this DateTime value)
        {
            return (long)value.Subtract(Epoch).TotalSeconds;
        }
    }
}
