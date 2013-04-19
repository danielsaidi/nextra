using System.Text.RegularExpressions;

namespace NExtra.Web.Html
{
    /// <summary>
    /// This class can replace HTML elements with another
    /// element type.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class HtmlReplacer : IHtmlReplacer
    {
        public string ReplaceHtmlElement(string str, string fromElementName, string toElementName)
        {
            str = Regex.Replace(str, "<" + fromElementName, "<" + toElementName);
            str = Regex.Replace(str, "</" + fromElementName, "</" + toElementName);
            return str;
        }
    }
}
