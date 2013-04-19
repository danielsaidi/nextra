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
        string RemoveHtml(string str);
        string RemoveHtmlElement(string str, string elementName);
        string RemoveHtmlElements(string str, IEnumerable<string> elementNames);
        string RemoveHtmlTableElements(string str);
    }
}
