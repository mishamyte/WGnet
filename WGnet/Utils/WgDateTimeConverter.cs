using System;

namespace WGnet.Utils
{
    /// <summary>
    /// Класс для конвертаций Unix Timestamp и DateTime
    /// </summary>
    public static class WgDateTimeConverter
    {
        /// <summary>
        /// Конвертирует Unix Timestamp в DateTime
        /// </summary>
        /// <param name="timestamp">Unix Timestamp</param>
        /// <returns>Значение в формате DateTime</returns>
        public static DateTime DateFromTimestamp(this long timestamp)
        {
            var unixStartDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return unixStartDate.AddSeconds(timestamp);
        }

        /// <summary>
        /// Конвертирует DateTime в Unix Timestamp 
        /// </summary>
        /// <param name="date">DateTime</param>
        /// <returns>Значение в Unix Timestamp</returns>
        public static long DateToTimesptamp(this DateTime date)
        {
            var unixStartDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date - unixStartDate).TotalSeconds);
        }
    }
}
