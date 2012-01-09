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
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface ICanExtractXmlDocumentationElement
    {
        /// <summary>
        /// Extract documentation for an XML element.
        /// </summary>
        XmlElement ExtractXmlDocumentationElement(Type type, char prefix, string subElementName);
    }
}
