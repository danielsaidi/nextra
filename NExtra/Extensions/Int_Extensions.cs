namespace NExtra.Extensions
{
	/// <summary>
	/// Extension methods for System.Int32.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class Int_Extensions
    {
        public static bool IsEven(this int value)
		{
			return value % 2 == 0;
        }

		public static bool IsOdd(this int value)
        {
            return !IsEven(value);
        }
	}
}
