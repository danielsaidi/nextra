using System;
using System.Globalization;

namespace NExtra.Week
{
    /// <summary>
    /// This IDateTimeWeekParser implementation can be used to
    /// calculate the week number for a certain date. It makes
    /// use of the native Calendar.GetWeekOfYear method, which
    /// is not always correct for boundary dates.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// 
    /// Make sure to configure the class properly according to
    /// which calendar week rule and first day of week rule it
    /// should use. In Sweden, for instance, the first week of
    /// the year is the one with four days in it (as such, use
    /// CalendarWeekRule.FirstFourDayWeek) and the week starts
    /// on a Monday (DayOfWeek.Monday). Since I am proud to be
    /// a Swede (and needed a default constructor), I took the
    /// bold decision to make that the default behavior.
    /// </remarks>
    public class WeekParser : IWeekParser
    {
        public WeekParser()
            : this(CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
        {
        }

        public WeekParser(CalendarWeekRule weekRule, DayOfWeek firstDayOfWeek)
        {
            WeekRule = weekRule;
            FirstDayOfWeek = firstDayOfWeek;
        }


        private DayOfWeek FirstDayOfWeek { get; set; }

        private CalendarWeekRule WeekRule { get; set; }


        public DateTime GetFirstDateOfWeek(DateTime date)
        {
            if (date == DateTime.MinValue)
                return date;

            var week = GetWeekNumber(date);
            while (week == GetWeekNumber(date))
                date = date.AddDays(-1);
            return date.AddDays(1);
        }

        public DateTime GetLastDateOfWeek(DateTime date)
        {
            if (date == DateTime.MaxValue)
                return date;

            var week = GetWeekNumber(date);
            while (week == GetWeekNumber(date))
                date = date.AddDays(1);
            return date.AddDays(-1);
        }

        public virtual int GetWeekNumber(DateTime date)
        {
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, WeekRule, FirstDayOfWeek);
        }
    }
}
