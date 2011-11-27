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
        /// Get the inner text of any tag, or an empty string if the tag is not found.
        /// </summary>
        [Obsolete("This is useless (oh, come on...sure it is!) and will be removed in .NExtra 2.6.0.0")]
        public static string GetElementInnerText(this XmlElement xmlElement, string elementName)
        {
            return xmlElement.GetElementsByTagName(elementName).Count == 0 ? String.Empty : xmlElement[elementName].InnerText.Trim();
        }
    }
}
