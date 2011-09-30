using System;
using System.Xml;

namespace NExtra.Documentation.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that should
    /// be able to locate and extract specific XML documentation
    /// elements.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface ICanExtractXmlDocumentationElement
    {
        /// <summary>
        /// Extract an XML documentation element.
        /// </summary>
        /// <param name="type">The type of interest.</param>
        /// <param name="prefix">The type's documentation prefix.</param>
        /// <param name="subElementName">The sub element name, if any.</param>
        /// <returns>XML documentation element.</returns>
        XmlElement ExtractXmlDocumentationElement(Type type, char prefix, string subElementName);
    }
}
