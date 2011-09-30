using System.Text.RegularExpressions;
using NExtra.Web.Abstractions;

namespace NExtra.Web
{
    /// <summary>
    /// This class can convert HTML5 elements to div and span
    /// elements. The original HTML5 element name is added as
    /// a class name for each converted element.
    /// 
    /// The class needs improvement. It now adds the class to
    /// the end tag of the replaced element as well, and also
    /// ignores any additional classes that the tag may have.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    /// <todo>
    /// Improve the class as described in the class summary.
    /// </todo>
    public class Html5ElementConverter : ICanConvertHtml
    {
        private const string HTML5_INLINE_ELEMENTS = @"<(\/)?(address|time)(( )class=""(.*)"")?";
        private const string HTML5_INLINE_ELEMENTS_REPLACEMENT = @"<$1span class=""$2$4$5""";
        private const string HTML5_BLOCK_ELEMENTS = @"<(\/)?(nav|section|header|aside|footer|article|hgroup|figure|figcaption|dialog|meter|progress|video|audio|details|datagrid|menu|command)(( )class=""(.*)"")?";
        private const string HTML5_BLOCK_ELEMENTS_REPLACEMENT = @"<$1div class=""$2$4$5""";


        /// <summary>
        /// Convert all HTML5 elements in a string to div and span elements.
        /// </summary>
        /// <param name="str">The original HTML5 string.</param>
        /// <returns>The resulting HTML5 free string.</returns>
        public string ConvertHtml(string str)
        {
            str = Regex.Replace(str, HTML5_BLOCK_ELEMENTS, HTML5_BLOCK_ELEMENTS_REPLACEMENT);
            str = Regex.Replace(str, HTML5_INLINE_ELEMENTS, HTML5_INLINE_ELEMENTS_REPLACEMENT);

            return str;
        }
    }
}
