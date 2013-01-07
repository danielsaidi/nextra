using System.Collections.Generic;

namespace NExtra.Web.Html
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can remove HTML code from strings.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IHtmlRemover
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
