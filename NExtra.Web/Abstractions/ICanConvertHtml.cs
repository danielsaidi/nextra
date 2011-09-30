namespace NExtra.Web.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// should be able to convert HTML code in various ways.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface ICanConvertHtml
    {
        /// <summary>
        /// Convert the HTML code that exists within a certain string.
        /// </summary>
        /// <param name="str">The string of interest.</param>
        /// <returns>The converted string.</returns>
        string ConvertHtml(string str);
    }
}
