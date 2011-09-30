using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using NExtra.Documentation.Abstractions;

namespace NExtra.Documentation.Extractors
{
    ///<summary>
    /// This class can be used to extract documentation for assemblies
    /// that are shipped together with an XML documentation file.
    ///</summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class AssemblyXmlDocumentationExtractor : ICanExtractAssemblyXmlDocumentation
    {
        private static Dictionary<Assembly, XmlDocument> cache;


        /// <summary>
        /// Create an instance of the class.
        /// </summary>
        public AssemblyXmlDocumentationExtractor()
        {
            cache = new Dictionary<Assembly, XmlDocument>();
        }


        /// <summary>
        /// Extract XML documentation for an assembly.
        /// </summary>
        /// <param name="assembly">The assembly of interest.</param>
        /// <returns>XML documentation document.</returns>
        public XmlDocument ExtractAssemblyXmlDocumentation(Assembly assembly)
        {
            if (cache.ContainsKey(assembly))
                return cache[assembly];

            const string filePrefix = "file:///";
            var xmlDocumentationFile = Path.ChangeExtension(assembly.CodeBase.Substring(filePrefix.Length), ".xml");

            return ExtractAssemblyXmlDocumentation(assembly, xmlDocumentationFile);
        }

        /// <summary>
        /// Extract XML documentation for an assembly.
        /// </summary>
        /// <param name="assembly">The assembly of interest.</param>
        /// <param name="xmlDocumentationFile">The path to the XML documentation file.</param>
        /// <returns>XML documentation document.</returns>
        public XmlDocument ExtractAssemblyXmlDocumentation(Assembly assembly, string xmlDocumentationFile)
        {
            if (!File.Exists(xmlDocumentationFile))
                throw new FileNotFoundException(String.Format("The XML documentation file {0} does not exist. Make sure that the file is generated when building the assembly.", xmlDocumentationFile));

            var streamReader = new StreamReader(xmlDocumentationFile);
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(streamReader);
            streamReader.Close();

            cache.Add(assembly, xmlDocument);

            return xmlDocument;
        }
    }
}
