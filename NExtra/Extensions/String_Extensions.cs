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
        public static int CountSubstring(this string str, string pattern)
		{
			return Regex.Matches(str, pattern).Count;
        }

        public static bool HasContent(this string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return String.IsNullOrEmpty(str);
        }

        public static bool IsNullOrWhiteSpace(this string str)
        {
            return String.IsNullOrWhiteSpace(str);
        }
        
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
