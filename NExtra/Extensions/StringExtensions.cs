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
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public static class StringExtensions
    {
	    /// <summary>
        /// Count how many times a certain pattern appears within a string.
        /// </summary>
        public static int CountSubstring(this string str, string pattern)
		{
			return Regex.Matches(str, pattern).Count;
        }

        /// <summary>
        /// Check whether or not a string is empty, using String.IsNullOrEmpty.
        /// </summary>
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
		/// Split a string by a string rather than by a char.
		/// </summary>
		public static IEnumerable<string> Split(this string str, string separator)
        {
		    int offset;
		    var offsets = Split_CalculateOffsets(str, separator, out offset);
		    var result = Split_CalculateResult(str, separator, offset, offsets);

		    return new List<String>(result.AsEnumerable());
		}

	    /// <summary>
	    /// Calculate split offset data.
	    /// </summary>
	    private static int[] Split_CalculateOffsets(string str, string separator, out int offset)
	    {
	        offset = 0;

	        var index = 0;
	        var offsets = new int[str.Length + 1];

	        while (index < str.Length)
	        {
	            var indexOf = str.IndexOf(separator, index);
	            if (indexOf != -1)
	            {
	                offsets[offset++] = indexOf;
	                index = (indexOf + separator.Length);
	            }
	            else
	            {
	                index = str.Length;
	            }
	        }

	        return offsets;
	    }

	    /// <summary>
        /// Calculate the final split result, using
        /// previously calculated offset data.
        /// </summary>
	    private static IEnumerable<string> Split_CalculateResult(string str, string separator, int offset, IList<int> offsets)
	    {
            //Init default result for zero offset
            var result = new string[offset + 1];
            result[0] = str;

            //Calculate result for non-zero offset
	        if (offset != 0)
	        {
	            offset--;
	            result[0] = str.Substring(0, offsets[0]);
	            for (var i = 0; i < offset; i++)
	                result[i + 1] = str.Substring(offsets[i] + separator.Length, offsets[i + 1] - offsets[i] - separator.Length);
	            result[offset + 1] = str.Substring(offsets[offset] + separator.Length);
	        }

	        return result;
	    }

	    /// <summary>
		/// Split a string by a string rather than by a char,
		/// then convert each list element to a certain type.
		/// </summary>
		public static IEnumerable<T> Split<T>(this string str, string separator, bool throwExceptionOnError = false)
		{
			var result = new List<T>();
			
			foreach (var element in str.Split(separator))
			{
                try { result.Add((T)Convert.ChangeType(element, typeof(T))); }
                catch (Exception) { if (throwExceptionOnError) throw; }
			}

			return result.AsEnumerable();
		}

		/// <summary>
		/// Try to convert a string to any struct type.
		/// </summary>
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
		public static T ToEnum<T>(this string str, T fallback)
		{
			try { return (T)Enum.Parse(typeof(T), str, true); }
			catch { return fallback; }
		}
    }
}
