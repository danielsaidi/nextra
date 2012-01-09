using System;
using System.Xml;

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
        

        /// <param name="xmlDocumentationElementExtractor">The element documentation extractor to use.</param>
        public TypeXmlDocumentationExtractor(ICanExtractXmlDocumentationElement xmlDocumentationElementExtractor)
        {
            this.xmlDocumentationElementExtractor = xmlDocumentationElementExtractor;
        }


        public XmlElement ExtractTypeXmlDocumentation(Type type)
        {
            return xmlDocumentationElementExtractor.ExtractXmlDocumentationElement(type, 'T', "");
        }
    }
}
