using System;
using System.Xml;

namespace NExtra.Documentation
{
    ///<summary>
    /// This class can be used to extract XML documentation for types.
    ///</summary>
    /// <remarks>
    /// Author:         Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:           http://www.saidi.se/nextra
    /// </remarks>
    public class TypeXmlDocumentationExtractor : ITypeDocumentationExtractor
    {
        private readonly IDocumentationElementExtractor xmlDocumentationElementExtractor;
        

        public TypeXmlDocumentationExtractor(IDocumentationElementExtractor xmlDocumentationElementExtractor)
        {
            this.xmlDocumentationElementExtractor = xmlDocumentationElementExtractor;
        }


        public XmlElement ExtractDocumentation(Type type)
        {
            return xmlDocumentationElementExtractor.ExtractDocumentationElement(type, 'T', "");
        }
    }
}
