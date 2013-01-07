using System;
using System.Xml;

namespace NExtra.Documentation
{
    /// <summary>
    /// This interface can be implemented by classes can
    /// locate and extract XML documentation elements.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IDocumentationElementExtractor
    {
        /// <summary>
        /// Extract documentation for an XML element.
        /// </summary>
        /// <param name="type">The type of interest.</param>
        /// <param name="prefix">The type's documentation prefix.</param>
        /// <param name="subElementName">The sub element name, if any.</param>
        /// <returns>XML documentation element.</returns>
        XmlElement ExtractDocumentationElement(Type type, char prefix, string subElementName);
    }
}
