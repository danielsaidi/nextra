using System.Reflection;
using System.Xml;

namespace NExtra.Documentation
{
    ///<summary>
    /// This class can be used to extract XML documentation
    /// data for MemberInfo instances.
    ///</summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public class MemberInfoXmlDocumentationExtractor : IMemberInfoDocumentationExtractor
    {
        private readonly IDocumentationElementExtractor xmlDocumentationElementExtractor;


        /// <param name="xmlDocumentationElementExtractor">The element documentation extractor to use.</param>
        public MemberInfoXmlDocumentationExtractor(IDocumentationElementExtractor xmlDocumentationElementExtractor)
        {
            this.xmlDocumentationElementExtractor = xmlDocumentationElementExtractor;
        }


        public XmlElement ExtractDocumentation(MemberInfo memberInfo)
        {
            return xmlDocumentationElementExtractor.ExtractDocumentationElement(memberInfo.DeclaringType, memberInfo.MemberType.ToString()[0], memberInfo.Name);
        }
    }
}
