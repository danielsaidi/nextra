using System.Collections.Generic;

namespace NExtra.Web.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// should be able to remove HTML code from strings.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface ICanRemoveHtml
    {
        /// <summary>
        /// Remove all HTML code within a string.
        /// </summary>
        /// <param name="str">The string of interest.</param>
        /// <returns>The resulting, HTML-free string.</returns>
        string RemoveHtml(string str);

        /// <summary>
        /// Remove all occurances of a certain elements within a string.
        /// </summary>
        /// <param name="str">The string of interest.</param>
        /// <param name="elementName">The name of the element to remove.</param>
        /// <returns>The resulting, element-free string.</returns>
        string RemoveHtmlElement(string str, string elementName);

        /// <summary>
        /// Remove all occurances of certain HTML elements within a string.
        /// </summary>
        /// <param name="str">The string of interest.</param>
        /// <param name="elementNames">The name of the elements to remove.</param>
        /// <returns>The resulting, element-free string.</returns>
        string RemoveHtmlElements(string str, IEnumerable<string> elementNames);

        /// <summary>
        /// Remove all HTML table elements within a string.
        /// </summary>
        /// <param name="str">The string of interest.</param>
        /// <returns>The resulting table-free string.</returns>
        string RemoveHtmlTableElements(string str);
    }
}
