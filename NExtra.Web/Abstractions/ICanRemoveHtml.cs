using System.Collections.Generic;

namespace NExtra.Web.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can remove HTML code from strings.
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
        string RemoveHtml(string str);

        /// <summary>
        /// Remove all occurances of a certain elements within a string.
        /// </summary>
        string RemoveHtmlElement(string str, string elementName);

        /// <summary>
        /// Remove all occurances of certain HTML elements within a string.
        /// </summary>
        string RemoveHtmlElements(string str, IEnumerable<string> elementNames);

        /// <summary>
        /// Remove all HTML table elements within a string.
        /// </summary>
        string RemoveHtmlTableElements(string str);
    }
}
