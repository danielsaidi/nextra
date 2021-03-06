﻿using System;
using System.Globalization;

namespace NExtra.Date
{
    /// <summary>
    /// This class can be used to calculate week numbers
    /// for ISO8601 dates.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class Iso8601WeekResolver : WeekResolver
    {
        const int January = 1;
        const int JanuaryFirstDay = 1;
        const int December = 12;
        const int DecemberLastDay = 31;
        const int Thursday = 4;


        public Iso8601WeekResolver()
            : base(CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
        {
        }


        public override int GetWeekNumber(DateTime date)
        {
            //Get the day number since the beginning of the year
            var dayOfYear = date.DayOfYear;

            //Get the first and last weekday of the year
            var startWeekDayOfYear = (int)(new DateTime(date.Year, January, JanuaryFirstDay)).DayOfWeek;
            var endWeekDayOfYear = (int)(new DateTime(date.Year, December, DecemberLastDay)).DayOfWeek;

            //Compensate for using monday as the first day of the week
            if (startWeekDayOfYear == 0)
                startWeekDayOfYear = 7;
            if (endWeekDayOfYear == 0)
                endWeekDayOfYear = 7;

            //Calculate the number of days in the first week
            var daysInFirstWeek = 8 - (startWeekDayOfYear);

            //Year starting and ending on a thursday will have 53 weeks
            var thursdayFlag = (startWeekDayOfYear == Thursday || endWeekDayOfYear == Thursday);

            //We begin by calculating the rounded up number of FULL weeks between the year start and our date.
            var resultWeekNumber = (int)Math.Ceiling((dayOfYear - (daysInFirstWeek)) / 7.0);

            //If the first week of the year has at least four days, the week number can be incremented by one.
            if (daysInFirstWeek >= Thursday)
                resultWeekNumber = resultWeekNumber + 1;

            //If the week number is larger than 52 (and the year doesn't start/end on a thursday), the week number is 1.
            if (resultWeekNumber > 52 && !thursdayFlag)
                resultWeekNumber = 1;

            //If the week number is still 0, it we are trying to evaluate the week number for a week that belongs to the
            //previous year (since it has 3 days or less in this year). We therefore execute this function recursively.
            if (resultWeekNumber == 0)
                resultWeekNumber = GetWeekNumber(new DateTime(date.Year - 1, December, DecemberLastDay));
            return resultWeekNumber;
        }
    }
}