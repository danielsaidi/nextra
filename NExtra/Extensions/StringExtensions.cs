using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NExtra.Extensions
{
	/// <summary>
	/// Extension methods for System.String.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public static class StringExtensions
    {
	    /// <summary>
        /// Count how many times a certain pattern appears within a string.
        /// </summary>
        /// <param name="str">The string of interest.</param>
        /// <param name="pattern">The pattern to search for.</param>
        /// <returns>The number of times the pattern appears within the string.</returns>
        public static int CountSubstring(this string str, string pattern)
		{
			return Regex.Matches(str, pattern).Count;
        }

        /// <summary>
        /// Check whether or not a string is empty, without using String.IsNullOrEmpty.
        /// </summary>
        /// <param name="str">The string of interest.</param>
        /// <returns>Whether or not the string is empty.</returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return String.IsNullOrEmpty(str);
        }
        
	    /// <summary>
	    /// Shorten a string to a maximum length, if necessary.
	    /// </summary>
	    /// <param name="str">The string to shorten.</param>
	    /// <param name="maxLength">The max length.</param>
	    /// <param name="overflowReplacement">The string that should replace the overflowing text; default empty.</param>
	    /// <returns>The resulting string.</returns>
	    public static string Shorten(this string str, int maxLength, string overflowReplacement = "")
        {
            //Throw exception if the max length is negative
            if (maxLength < 0)
                throw new ArgumentOutOfRangeException("maxLength", maxLength, "maxLength must be zero or greater");

            //Shorten string if necessary, then return the result
            return str.Length > maxLength ? str.Substring(0, maxLength) + overflowReplacement : str;
        }

		/// <summary>
		/// Split a string by a string rather than by a char. Furthermore,
		/// this function returns a string list instead of a string array.
		/// </summary>
		/// <param name="str">The string to split.</param>
		/// <param name="splitValue">The split value.</param>
		/// <returns>The resulting list.</returns>
		public static IEnumerable<string> Split(this string str, string splitValue)
		{
			var offset = 0;
			var index = 0;
			var offsets = new int[str.Length + 1];

			while (index < str.Length)
			{
				var indexOf = str.IndexOf(splitValue, index);
				if (indexOf != -1)
				{
					offsets[offset++] = indexOf;
					index = (indexOf + splitValue.Length);
				}
				else
				{
					index = str.Length;
				}
			}

			var final = new string[offset + 1];
			if (offset == 0)
			{
				final[0] = str;
			}
			else
			{
				offset--;
				final[0] = str.Substring(0, offsets[0]);
				for (var i = 0; i < offset; i++)
					final[i + 1] = str.Substring(offsets[i] + splitValue.Length, offsets[i + 1] - offsets[i] - splitValue.Length);
				final[offset + 1] = str.Substring(offsets[offset] + splitValue.Length);
			}

			var result = new List<String>();
			result.AddRange(final);
			return result.AsEnumerable();
		}

		/// <summary>
		/// Split a string by a string rather than by a char and convert
		/// each list element to a certain type.
		/// 
		/// The function can be set to throw an exception if any invalid
		/// strings are encountered while parsing the string elements to
		/// the provided type. By default, it adds all the valid strings
		/// to the resulting list and ignores invalid ones.
		/// </summary>
		/// <typeparam name="T">The type to convert the list items to.</typeparam>
		/// <param name="str">The string to split.</param>
		/// <param name="splitValue">The split value.</param>
		/// <param name="throwExceptionOnError">Whether or not to proceed if an invalid value is encountered.</param>
		/// <returns>The resulting list.</returns>
		public static IEnumerable<T> Split<T>(this string str, string splitValue, bool throwExceptionOnError = false)
		{
			var result = new List<T>();
			
			var elements = str.Split(splitValue);
			foreach (var element in elements)
			{
				if (throwExceptionOnError)
				{
					result.Add((T)Convert.ChangeType(element, typeof(T)));
				}
				else
				{
					try { result.Add((T)Convert.ChangeType(element, typeof(T))); }
					catch { }
				}
			}

			return result.AsEnumerable();
		}

		/// <summary>
		/// Try to convert a string to any struct type.
		/// </summary>
		/// <typeparam name="T">The struct type that the string should be converted to.</typeparam>
		/// <param name="str">The string to convert.</param>
		/// <returns>The converted value.</returns>
		public static T? To<T>(this string str) where T : struct
		{
			if (str.IsNullOrEmpty())
				return null;

			try { return (T)Convert.ChangeType(str, typeof(T)); }
			catch { return null; }
		}

		/// <summary>
		/// Try to covnert a string to any enum type.
		/// </summary>
		/// <typeparam name="T">The enum type that the string should be converted to.</typeparam>
		/// <param name="str">The string to convert.</param>
		/// <param name="fallback">Fall back value to return if the parse fails.</param>
		/// <returns>The converted enum.</returns>
		public static T ToEnum<T>(this string str, T fallback)
		{
			try { return (T)Enum.Parse(typeof(T), str, true); }
			catch { return fallback; }
		}
    }
}
