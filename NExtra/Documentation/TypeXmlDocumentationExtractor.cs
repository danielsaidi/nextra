using System;
using System.Xml;

namespace NExtra.Documentation
{
    ///<summary>
    /// This class can be used to extract XML documentation for Type instances.
    ///</summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class TypeXmlDocumentationExtractor : ITypeDocumentationExtractor
    {
        private readonly IDocumentationElementExtractor _xmlDocumentationElementExtractor;
        

        public TypeXmlDocumentationExtractor(IDocumentationElementExtractor xmlDocumentationElementExtractor)
        {
            _xmlDocumentationElementExtractor = xmlDocumentationElementExtractor;
        }


        public XmlElement ExtractDocumentation(Type type)
        {
            return _xmlDocumentationElementExtractor.ExtractDocumentationElement(type, 'T', "");
        }
    }
}
