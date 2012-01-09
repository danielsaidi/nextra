using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

namespace NExtra.Documentation.Extractors
{
    ///<summary>
    /// This class can be used to extract documentation for
    /// assemblies that have an XML documentation file.
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
        /// Extract XML documentation for an assembly, using
        /// the default documentation file location (next to
        /// the assembly, but with an .xml file type).
        /// </summary>
        public XmlDocument ExtractAssemblyXmlDocumentation(Assembly assembly)
        {
            if (cache.ContainsKey(assembly))
                return cache[assembly];

            const string filePrefix = "file:///";
            var xmlDocumentationFile = Path.ChangeExtension(assembly.CodeBase.Substring(filePrefix.Length), ".xml");

            return ExtractAssemblyXmlDocumentation(assembly, xmlDocumentationFile);
        }


        /// <summary>
        /// Extract XML documentation for an assembly using
        /// a custom documentation file location.
        /// </summary>
        public XmlDocument ExtractAssemblyXmlDocumentation(Assembly assembly, string xmlFilePath)
        {
            if (!File.Exists(xmlFilePath))
                throw new FileNotFoundException(String.Format("The XML documentation file {0} does not exist. Make sure that the file is generated when building the assembly.", xmlFilePath));

            var streamReader = new StreamReader(xmlFilePath);
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(streamReader);
            streamReader.Close();

            cache.Add(assembly, xmlDocument);

            return xmlDocument;
        }
    }
}
