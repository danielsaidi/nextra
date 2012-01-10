using System;
using System.Xml;

namespace NExtra.Extensions
{
    /// <summary>
    /// Extension methods for System.Xml.XmlElement.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public static class XmlElementExtensions
    {
        /// <summary>
        /// Get the inner text of any tag, or an empty string if the tag is not found.
        /// </summary>
        public static string GetElementInnerText(this XmlElement xmlElement, string elementName)
        {
            return xmlElement.GetElementsByTagName(elementName).Count == 0 ? String.Empty : xmlElement[elementName].InnerText.Trim();
        }
    }
}