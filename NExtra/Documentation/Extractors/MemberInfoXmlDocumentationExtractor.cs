using System.Reflection;
using System.Xml;

namespace NExtra.Documentation.Extractors
{
    ///<summary>
    /// This class can be used to extract XML documentation
    /// data for MemberInfo instances.
    ///</summary>
    /// <remarks>
    /// Author:         Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:           http://www.saidi.se/nextra
    /// </remarks>
    public class MemberInfoXmlDocumentationExtractor : ICanExtractMemberInfoXmlDocumentation
    {
        private readonly ICanExtractXmlDocumentationElement xmlDocumentationElementExtractor;


        /// <param name="xmlDocumentationElementExtractor">The element documentation extractor to use.</param>
        public MemberInfoXmlDocumentationExtractor(ICanExtractXmlDocumentationElement xmlDocumentationElementExtractor)
        {
            this.xmlDocumentationElementExtractor = xmlDocumentationElementExtractor;
        }


        public XmlElement ExtractMemberInfoXmlDocumentation(MemberInfo memberInfo)
        {
            return xmlDocumentationElementExtractor.ExtractXmlDocumentationElement(memberInfo.DeclaringType, memberInfo.MemberType.ToString()[0], memberInfo.Name);
        }
    }
}
