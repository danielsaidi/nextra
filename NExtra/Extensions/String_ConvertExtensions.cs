using System;

namespace NExtra.Extensions
{
	/// <summary>
	/// Convert extension methods for System.String.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class String_ConvertExtensions
    {
        public static T? ConvertTo<T>(this string str)
            where T : struct
        {
            if (str.IsNullOrEmpty())
                return null;

            try { return (T)Convert.ChangeType(str, typeof(T)); }
            catch { return null; }
        }

        public static T ConvertTo<T>(this string str, T fallback)
            where T : struct
        {
            if (str.IsNullOrEmpty())
                return fallback;

            try { return (T)Convert.ChangeType(str, typeof(T)); }
            catch { return fallback; }
        }

		public static T ConvertToEnum<T>(this string str, T fallback)
		{
			try { return (T)Enum.Parse(typeof(T), str, true); }
			catch { return fallback; }
		}
    }
}
