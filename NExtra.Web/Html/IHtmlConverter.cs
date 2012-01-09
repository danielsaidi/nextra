namespace NExtra.Web.Html
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can convert HTML code in various ways.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface IHtmlConverter
    {
        /// <summary>
        /// Convert the HTML code that exists within a certain string.
        /// </summary>
        string ConvertHtml(string str);
    }
}
