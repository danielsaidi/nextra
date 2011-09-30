using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NExtra.Web.Abstractions;

namespace NExtra.Web
{
    /// <summary>
    /// This class can remove HTML elements in various ways,
    /// leaving only their content.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class HtmlRemover : ICanRemoveHtml
    {
        /// <summary>
        /// Remove all HTML within a certain string.
        /// </summary>
        /// <param name="str">The HTML string.</param>
        /// <returns>The resulting string.</returns>
        public string RemoveHtml(string str)
        {
            return str == null ? string.Empty : Regex.Replace(str, "<.*?>", "");
        }

        /// <summary>
        /// Remove a certain HTML element from a certain string.
        /// </summary>
        /// <param name="str">The HTML string.</param>
        /// <param name="elementName">The name of the HTML element.</param>
        /// <returns>The resulting string.</returns>
        public string RemoveHtmlElement(string str, string elementName)
        {
            return str == null ? string.Empty : Regex.Replace(str, "</?" + elementName + "[^>]*>", String.Empty);
        }

        /// <summary>
        /// Remove a set of HTML elements from a certain string.
        /// </summary>
        /// <param name="str">The HTML string.</param>
        /// <param name="elementNames">The a list of HTML element names.</param>
        /// <returns>The resulting string.</returns>
        public string RemoveHtmlElements(string str, IEnumerable<string> elementNames)
        {
            return elementNames.Aggregate(str, RemoveHtmlElement);
        }

        /// <summary>
        /// Remove all HTML table elements from a certain string.
        /// </summary>
        /// <param name="str">The HTML string.</param>
        /// <returns>The resulting string.</returns>
        public string RemoveHtmlTableElements(string str)
        {
            return RemoveHtmlElements(str, new[] { "table", "tr", "td", "thead", "tbody" });
        }
    }
}
