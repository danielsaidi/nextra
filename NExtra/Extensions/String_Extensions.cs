using System;
using System.Text.RegularExpressions;

namespace NExtra.Extensions
{
	/// <summary>
	/// Extension methods for System.String.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class String_Extensions
    {
	    /// <summary>
        /// Count how many times a certain pattern appears within a string.
        /// </summary>
        public static int CountSubstring(this string str, string pattern)
		{
			return Regex.Matches(str, pattern).Count;
        }

        /// <summary>
        /// Check if a string consists of more than just whitespace. 
        /// </summary>
        public static bool HasContent(this string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Check if a string is null or contains no text at all.
        /// </summary>
        public static bool IsNullOrEmpty(this string str)
        {
            return String.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Check if a string is null or contains of just whitespace.
        /// </summary>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return String.IsNullOrWhiteSpace(str);
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
    }
}
