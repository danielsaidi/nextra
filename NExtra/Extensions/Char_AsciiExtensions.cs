using System.Globalization;

namespace NExtra.Extensions
{
    /// <summary>
    /// ASCII-related extension methods for System.Char.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// 
    /// The remap method was posted by stackoverflow guru Jeff
    /// Atwood. You find it here:
    /// http://meta.stackoverflow.com/questions/7435/non-us-ascii-characters-dropped-from-full-profile-url
    /// </remarks>
    public static class Char_AsciiExtensions
    {
        public static string RemapInternationalCharToAscii(this char internationalChar)
        {
            var c = internationalChar;
            var s = c.ToString(CultureInfo.InvariantCulture).ToLowerInvariant();

            if ("àåáâäãåą".Contains(s))
            {
                return "a";
            }
            if ("èéêëę".Contains(s))
            {
                return "e";
            }
            if ("ìíîïı".Contains(s))
            {
                return "i";
            }
            if ("òóôõöøőð".Contains(s))
            {
                return "o";
            }
            if ("ùúûüŭů".Contains(s))
            {
                return "u";
            }
            if ("çćčĉ".Contains(s))
            {
                return "c";
            }
            if ("żźž".Contains(s))
            {
                return "z";
            }
            if ("śşšŝ".Contains(s))
            {
                return "s";
            }
            if ("ñń".Contains(s))
            {
                return "n";
            }
            if ("ýÿ".Contains(s))
            {
                return "y";
            }
            if ("ğĝ".Contains(s))
            {
                return "g";
            }
            if (c == 'ř')
            {
                return "r";
            }
            if (c == 'ł')
            {
                return "l";
            }
            if (c == 'đ')
            {
                return "d";
            }
            if (c == 'ß')
            {
                return "ss";
            }
            if (c == 'Þ')
            {
                return "th";
            }
            if (c == 'ĥ')
            {
                return "h";
            }
            if (c == 'ĵ')
            {
                return "j";
            }

            return "";
        }
    }
}
