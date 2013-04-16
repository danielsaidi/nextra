using System;

namespace NExtra.Extensions
{
	/// <summary>
	/// Extension methods for System.IComparable.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class IComparable_Extensions
    {
        /// <summary>
        /// Limit a value to a certain min/max interval.
        /// </summary>
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
