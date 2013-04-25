using System.Text;
using NExtra.Extensions;

namespace NExtra.Url
{
    /// <summary>
    /// This class can be used to urlify strings. It uses
    /// Char_AsciiExtensions to remove invalid characters.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// 
    /// Original implementation by John Gietzen (otac0n).
    /// http://stackoverflow.com/questions/25259/how-does-stackoverflow-generate-its-seo-friendly-urls
    /// 
    /// Original implementation has been adjusted so that
    /// it has no max length.
    /// </remarks>
    public class StringUrlifier : IUrlifier<string>
    {
        public string Urlify(string str)
        {
            if (str == null)
                return "";

            char c;
            var len = str.Length;
            var prevdash = false;
            var sb = new StringBuilder(len);

            for (var i = 0; i < len; i++)
            {
                c = str[i];
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                {
                    sb.Append(c);
                    prevdash = false;
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    // tricky way to convert to lowercase
                    sb.Append((char)(c | 32));
                    prevdash = false;
                }
                else if (c == ' ' || c == ',' || c == '.' || c == '/' ||
                         c == '\\' || c == '-' || c == '_' || c == '=')
                {
                    if (!prevdash && sb.Length > 0)
                    {
                        sb.Append('-');
                        prevdash = true;
                    }
                }
                else if (c >= 128)
                {
                    var prevlen = sb.Length;
                    sb.Append(c.RemapInternationalCharToAscii());
                    if (prevlen != sb.Length) prevdash = false;
                }
                //if (sb.Length == maxLength) break;
            }

            var result = prevdash ? sb.ToString().Substring(0, sb.Length - 1) : sb.ToString();
            //if (result.Length > maxLength)
              //  result = result.Substring(0, maxLength);

            return result;
        }
    }
}