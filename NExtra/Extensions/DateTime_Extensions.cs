using System;

namespace NExtra.Extensions
{
    /// <summary>
    /// Extension methods for System.DateTime.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class DateTime_Extensions
    {
        /// <summary>
        /// Get the first date of the month for a certain date.
        /// </summary>
        public static DateTime GetFirstDateOfMonth(this DateTime date)
        {
            return date == DateTime.MinValue ? date : new DateTime(date.Year, date.Month, 1);
        }

		/// <summary>
		/// Get the last date of the month for a certain date.
		/// </summary>
		public static DateTime GetLastDateOfMonth(this DateTime date)
		{
			return date == DateTime.MaxValue ? date : new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
		}

        /// <summary>
        /// Check if two DateTime instances represent the same date, regardless of the time.
        /// </summary>
        public static bool IsSameDate(this DateTime date, DateTime compareDate)
        {
            return date.Date == compareDate.Date;
        }
    }
}
