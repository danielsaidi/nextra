namespace NExtra.Web.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that should
    /// be able to replace HTML element with another in a string.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface ICanReplaceHtml
    {
        /// <summary>
        /// Replace one HTML element with another one.
        /// </summary>
        /// <param name="str">The string of interest.</param>
        /// <param name="originalElementName">The original element name.</param>
        /// <param name="replacementElementName">The name of the replacing element.</param>
        /// <returns>The resulting string.</returns>
        string ReplaceHtmlElement(string str, string originalElementName, string replacementElementName);
    }
}
