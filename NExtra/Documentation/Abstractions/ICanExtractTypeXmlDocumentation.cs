using System;
using System.Xml;

namespace NExtra.Documentation.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that should
    /// be able to locate and extract XML documentation data for
    /// types.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface ICanExtractTypeXmlDocumentation
    {
        /// <summary>
        /// Extract XML documentation data for a certain type.
        /// </summary>
        /// <param name="type">The Type of interest.</param>
        /// <returns>The resulting documentation element.</returns>
        XmlElement ExtractTypeXmlDocumentation(Type type);
    }
}
