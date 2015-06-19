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
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp);
        }

        /// <summary>
        /// Конвертирует nullable Unix Timestamp в nullable DateTime
        /// </summary>
        /// <param name="timestamp">Nullable Unix Timestamp</param>
        /// <returns>Значение в формате nullable DateTime</returns>
        public static DateTime? DateFromTimestamp(this long? timestamp)
        {
            return timestamp == null
                ? (DateTime?) null
                : new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds((double) timestamp);
        }

        /// <summary>
        /// Конвертирует nullable DateTime в nullable Unix Timestamp 
        /// </summary>
        /// <param name="date">Nullable DateTime</param>
        /// <returns>Значение в nullable Unix Timestamp</returns>
        public static long? DateToTimestamp(this DateTime? date)
        {
            return date == null ? (long?) null : Convert.ToInt64((date - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Value.TotalSeconds);
        }

        /// <summary>
        /// Конвертирует DateTime в Unix Timestamp 
        /// </summary>
        /// <param name="date">DateTime</param>
        /// <returns>Значение в Unix Timestamp</returns>
        public static long DateToTimestamp(this DateTime date)
        {
            return Convert.ToInt64((date - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
        }
    }
}
