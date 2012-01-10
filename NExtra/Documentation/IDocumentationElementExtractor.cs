using System;
using System.Xml;

namespace NExtra.Documentation
{
    /// <summary>
    /// This interface can be implemented by classes that should
    /// be able to locate and extract XML documentation elements.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public interface IDocumentationElementExtractor
    {
        /// <summary>
        /// Extract documentation for an XML element.
        /// </summary>
        XmlElement ExtractDocumentationElement(Type type, char prefix, string subElementName);
    }
}
