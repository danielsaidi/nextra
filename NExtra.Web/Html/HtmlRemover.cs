using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NExtra.Web.Html
{
    /// <summary>
    /// This class can remove HTML elements in various ways,
    /// leaving only their content.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public class HtmlRemover : IHtmlRemover
    {
        /// <summary>
        /// Remove all HTML within a certain string.
        /// </summary>
        public string RemoveHtml(string str)
        {
            return str == null ? string.Empty : Regex.Replace(str, "<.*?>", "");
        }

        /// <summary>
        /// Remove a certain HTML element from a certain string.
        /// </summary>
        public string RemoveHtmlElement(string str, string elementName)
        {
            return str == null ? string.Empty : Regex.Replace(str, "</?" + elementName + "[^>]*>", String.Empty);
        }

        /// <summary>
        /// Remove a set of HTML elements from a certain string.
        /// </summary>
        public string RemoveHtmlElements(string str, IEnumerable<string> elementNames)
        {
            return elementNames.Aggregate(str, RemoveHtmlElement);
        }

        /// <summary>
        /// Remove all HTML table elements from a certain string.
        /// </summary>
        public string RemoveHtmlTableElements(string str)
        {
            return RemoveHtmlElements(str, new[] { "table", "tr", "td", "thead", "tbody" });
        }
    }
}
