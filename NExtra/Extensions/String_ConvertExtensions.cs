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
        /// <summary>
        /// Try to convert a string to any struct type.
        /// </summary>
        /// <remarks>
        /// Returns null if the conversion fails.
        /// </remarks>
        public static T? ConvertTo<T>(this string str)
            where T : struct
        {
            if (str.IsNullOrEmpty())
                return null;

            try { return (T)Convert.ChangeType(str, typeof(T)); }
            catch { return null; }
        }

        /// <summary>
        /// Try to convert a string to any struct type.
        /// </summary>
        /// <remarks>
        /// Returns fallback if the conversion fails.
        /// </remarks>
        public static T ConvertTo<T>(this string str, T fallback)
            where T : struct
        {
            if (str.IsNullOrEmpty())
                return fallback;

            try { return (T)Convert.ChangeType(str, typeof(T)); }
            catch { return fallback; }
        }

		/// <summary>
		/// Try to convert a string to any enum type.
		/// </summary>
		/// <remarks>
		/// Returns fallback if the conversion fails.
		/// </remarks>
		public static T ConvertToEnum<T>(this string str, T fallback)
		{
			try { return (T)Enum.Parse(typeof(T), str, true); }
			catch { return fallback; }
		}
    }
}
