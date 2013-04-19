using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NExtra.Web.Html
{
    /// <summary>
    /// This class can be used to remove HTML elements in
    /// various ways, leaving only their content.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class HtmlRemover : IHtmlRemover
    {
        public string RemoveHtml(string str)
        {
            return str == null ? string.Empty : Regex.Replace(str, "<.*?>", "");
        }

        public string RemoveHtmlElement(string str, string elementName)
        {
            return str == null ? string.Empty : Regex.Replace(str, "</?" + elementName + "[^>]*>", String.Empty);
        }

        public string RemoveHtmlElements(string str, IEnumerable<string> elementNames)
        {
            return elementNames.Aggregate(str, RemoveHtmlElement);
        }

        public string RemoveHtmlTableElements(string str)
        {
            return RemoveHtmlElements(str, new[] { "table", "tr", "td", "thead", "tbody" });
        }
    }
}
