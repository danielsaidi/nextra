using System;

namespace NExtra.Week
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can be used to calculate week number for dates.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IWeekParser
    {
        DateTime GetFirstDateOfWeek(DateTime date);

        DateTime GetLastDateOfWeek(DateTime date);

        int GetWeekNumber(DateTime date);
    }
}