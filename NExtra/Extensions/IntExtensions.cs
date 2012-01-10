namespace NExtra.Extensions
{
	/// <summary>
	/// Extension methods for System.Int32.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public static class IntExtensions
    {
        /// <summary>
        /// Check whether or not a value is even.
        /// </summary>
        public static bool IsEven(this int value)
		{
			return value % 2 == 0;
        }

		/// <summary>
		/// Check whether or not a value is odd.
		/// </summary>
        public static bool IsOdd(this int value)
        {
            return !IsEven(value);
        }
	}
}
