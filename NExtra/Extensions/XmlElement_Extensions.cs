using System;
using System.Xml;

namespace NExtra.Extensions
{
    /// <summary>
    /// Extension methods for System.Xml.XmlElement.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class XmlElement_Extensions
    {
        /// <summary>
        /// Get the inner text of any tag, or an empty string if the tag is not found.
        /// </summary>
        public static string GetElementInnerText(this XmlElement xmlElement, string elementName)
        {
            var innerElement = xmlElement[elementName];
            if (innerElement == null)
                return string.Empty;

            return xmlElement.GetElementsByTagName(elementName).Count == 0 ? String.Empty : innerElement.InnerText.Trim();
        }
    }
}