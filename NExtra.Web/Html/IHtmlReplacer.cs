namespace NExtra.Web.Html
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can replace an HTML element with another.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IHtmlReplacer
    {
        /// <summary>
        /// Replace one HTML element with another one.
        /// </summary>
        string ReplaceHtmlElement(string str, string originalElementName, string replacementElementName);
    }
}
