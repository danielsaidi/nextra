using System;

namespace NExtra.Extensions
{
	/// <summary>
	/// Extension methods for System.IComparable.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public static class IComparableExtensions
    {
        /// <summary>
        /// Limit value to a certain min/max interval.
        /// </summary>
        /// <param name="value">The original value.</param>
        /// <param name="minValue">The minimum allowed value.</param>
        /// <param name="maxValue">The maximum allowed value.</param>
        /// <returns>The resulting value.</returns>
        public static T Limit<T>(this T value, T minValue, T maxValue)
		where T : IComparable
        {
        	if (value.CompareTo(minValue) == -1)
				return minValue;
			if (value.CompareTo(maxValue) == 1)
				return maxValue;
        	return value;
        }
    }
}
