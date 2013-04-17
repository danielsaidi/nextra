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
        public static DateTime GetFirstDateOfMonth(this DateTime date)
        {
            return date == DateTime.MinValue ? date : new DateTime(date.Year, date.Month, 1);
        }

		public static DateTime GetLastDateOfMonth(this DateTime date)
		{
			return date == DateTime.MaxValue ? date : new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
		}

        public static bool IsSameDate(this DateTime date, DateTime compareDate)
        {
            return date.Date == compareDate.Date;
        }
    }
}
