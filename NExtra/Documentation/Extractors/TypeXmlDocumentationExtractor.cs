using System;
using System.Xml;
using NExtra.Documentation.Abstractions;

namespace NExtra.Documentation.Extractors
{
    ///<summary>
    /// This class can be used to extract XML documentation for types.
    ///</summary>
    /// <remarks>
    /// Author:         Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:           http://www.saidi.se/nextra
    /// </remarks>
    public class TypeXmlDocumentationExtractor : ICanExtractTypeXmlDocumentation
    {
        private readonly ICanExtractXmlDocumentationElement xmlDocumentationElementExtractor;

        /// <summary>
        /// Create an instance of the class.
        /// </summary>
        /// <param name="xmlDocumentationElementExtractor">ICanExtractXmlDocumentationElement implementation.</param>
        public TypeXmlDocumentationExtractor(ICanExtractXmlDocumentationElement xmlDocumentationElementExtractor)
        {
            this.xmlDocumentationElementExtractor = xmlDocumentationElementExtractor;
        }


        /// <summary>
        /// Extract XML documentation for a Type.
        /// </summary>
        /// <param name="type">The Type of interest.</param>
        /// <returns>XML documentation element.</returns>
        public XmlElement ExtractTypeXmlDocumentation(Type type)
        {
            return xmlDocumentationElementExtractor.ExtractXmlDocumentationElement(type, 'T', "");
        }
    }
}
