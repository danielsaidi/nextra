using System;

namespace NExtra.Week
{
    /// <summary>
    /// This interface can be implemented by classes that can
    /// calculate the week number for a certain date.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IWeekParser
    {
        /// <summary>
        /// Get the first date of the week for a certain date.
        /// </summary>
        /// <param name="date">DateTime instance of interest.</param>
        /// <returns>The first date of the week for the date.</returns>
        DateTime GetFirstDateOfWeek(DateTime date);


        /// <summary>
        /// Get the last date of the week for a certain date.
        /// <param name="date">DateTime instance of interest.</param>
        /// </summary>
        DateTime GetLastDateOfWeek(DateTime date);

        /// <summary>
        /// Get the week number of a certain date.
        /// </summary>
        /// <param name="date">DateTime instance of interest.</param>
        int GetWeekNumber(DateTime date);
    }
}