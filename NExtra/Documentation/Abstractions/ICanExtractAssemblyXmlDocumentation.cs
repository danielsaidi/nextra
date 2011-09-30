using System.Reflection;
using System.Xml;

namespace NExtra.Documentation.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that should
    /// be able to extract XML documentation data from assemblies.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface ICanExtractAssemblyXmlDocumentation
    {
        /// <summary>
        /// Extract XML documentation data from an assembly,
        /// using its name to locate the documentation data.
        /// </summary>
        /// <param name="assembly">The assembly of interest.</param>
        /// <returns>The resulting XML document.</returns>
        XmlDocument ExtractAssemblyXmlDocumentation(Assembly assembly);

        /// <summary>
        /// Extract XML documentation data from an assembly,
        /// using a custom path to the XML documentation file.
        /// </summary>
        /// <param name="assembly">The assembly of interest.</param>
        /// <param name="xmlDocumentationFile">The path to the XML documentation file.</param>
        /// <returns>The resulting XML document.</returns>
        XmlDocument ExtractAssemblyXmlDocumentation(Assembly assembly, string xmlDocumentationFile);
    }
}
