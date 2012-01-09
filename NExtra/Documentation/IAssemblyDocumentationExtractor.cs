using System.Reflection;
using System.Xml;

namespace NExtra.Documentation
{
    /// <summary>
    /// This interface can be implemented by classes that can
    /// be used to extract XML documentation from assemblies.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface IAssemblyDocumentationExtractor
    {
        /// <summary>
        /// Extract XML documentation for an assembly, using
        /// a default documentation file location.
        /// </summary>
        XmlDocument ExtractDocumentation(Assembly assembly);

        /// <summary>
        /// Extract XML documentation for an assembly, using
        /// a custom documentation file location.
        /// </summary>
        XmlDocument ExtractDocumentation(Assembly assembly, string xmlFilePath);
    }
}
