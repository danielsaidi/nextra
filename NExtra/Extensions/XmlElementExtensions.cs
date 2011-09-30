using System;
using System.Xml;

namespace NExtra.Extensions
{
    /// <summary>
    /// Extension methods for System.Xml.XmlElement.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public static class XmlElementExtensions
    {
        /// <summary>
        /// Get the inner text of any tag; empty string if tag not found.
        /// </summary>
        /// <param name="xmlElement">The XmlElement instance of interest.</param>
        /// <param name="elementName">The name of the element of interest.</param>
        /// <returns>The value of the tag, if any.</returns>
        public static string GetElementInnerText(this XmlElement xmlElement, string elementName)
        {
            return xmlElement.GetElementsByTagName(elementName).Count == 0 ? String.Empty : xmlElement[elementName].InnerText.Trim();
        }
    }
}
