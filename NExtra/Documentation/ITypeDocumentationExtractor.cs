using System;
using System.Xml;

namespace NExtra.Documentation
{
    /// <summary>
    /// This interface can be implemented by classes that should
    /// be able to locate and extract XML documentation data for
    /// Type instances.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public interface ITypeDocumentationExtractor
    {
        /// <summary>
        /// Extract XML documentation for a certain type.
        /// </summary>
        XmlElement ExtractDocumentation(Type type);
    }
}
