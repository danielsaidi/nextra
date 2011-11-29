using System.Text.RegularExpressions;
using NExtra.Web.Abstractions;

namespace NExtra.Web
{
    /// <summary>
    /// This class can convert HTML5 elements to div and span
    /// elements. The original HTML5 element name is added as
    /// a class name for each converted element.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class Html5ElementConverter : ICanConvertHtml
    {
        protected const string HTML5_INLINE_ELEMENTS = @"<(\/)?(address|time)(( )class=""(.*)"")?";
        protected const string HTML5_INLINE_ELEMENTS_REPLACEMENT = @"<$1span class=""$2$4$5""";
        protected const string HTML5_BLOCK_ELEMENTS = @"<(\/)?(nav|section|header|aside|footer|article|hgroup|figure|figcaption|dialog|meter|progress|video|audio|details|datagrid|menu|command)((\s)class=""(.*)"")?";
        protected const string HTML5_BLOCK_ELEMENTS_REPLACEMENT = @"<$1div class=""$2$4$5""";
        protected const string HTML5_ELEMENTS_ENDTAG = @"(<\/[a-zA-Z]+)(\sclass="".+"")(>)";
        protected const string HTML5_ELEMENTS_ENDTAG_REPLACEMENT = @"$1$3";


        /// <summary>
        /// Convert all HTML5 elements in a string to div and span elements.
        /// </summary>
        public string ConvertHtml(string htmlString)
        {
            htmlString = Regex.Replace(htmlString, HTML5_BLOCK_ELEMENTS, HTML5_BLOCK_ELEMENTS_REPLACEMENT);
            htmlString = Regex.Replace(htmlString, HTML5_INLINE_ELEMENTS, HTML5_INLINE_ELEMENTS_REPLACEMENT);
            htmlString = Regex.Replace(htmlString, HTML5_ELEMENTS_ENDTAG, HTML5_ELEMENTS_ENDTAG_REPLACEMENT);

            return htmlString;
        }
    }
}
