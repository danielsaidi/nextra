using System.Text.RegularExpressions;
using NExtra.Web.Abstractions;

namespace NExtra.Web
{
    /// <summary>
    /// This class can replace HTML elements with another
    /// element type.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class HtmlReplacer : ICanReplaceHtml
    {
        /// <summary>
        /// Replace one element type with another.
        /// </summary>
        public string ReplaceHtmlElement(string str, string originalElementName, string replacementElementName)
        {
            str = Regex.Replace(str, @"<" + originalElementName, @"<" + replacementElementName);
            str = Regex.Replace(str, @"</" + originalElementName, @"</" + replacementElementName);
            return str;
        }
    }
}
