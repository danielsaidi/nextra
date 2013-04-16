using System.Globalization;
using System.Text.RegularExpressions;

namespace NExtra.Extensions
{
    /// <summary>
    /// Extract extension methods for System.String.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class String_ExtractExtensions
    {
        public static double ExtractDouble(this string str)
        {
            var result = Regex.Match(str, @"[0-9]+\.[0-9]+").Value;
            try
            {
                return double.Parse(result, CultureInfo.InvariantCulture);
            }
            catch
            {
                return str.ExtractInt();
            }
        }

        public static int ExtractInt(this string str)
        {
            var result = Regex.Match(str, @"\d+").Value;
            int outVal;
            var parsed = int.TryParse(result, out outVal);

            return !parsed ? 0 : outVal;
        }
    }
}
