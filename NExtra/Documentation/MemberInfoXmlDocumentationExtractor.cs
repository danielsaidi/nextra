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
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class MemberInfoXmlDocumentationExtractor : IMemberInfoDocumentationExtractor
    {
        private readonly IDocumentationElementExtractor _xmlDocumentationElementExtractor;


        public MemberInfoXmlDocumentationExtractor(IDocumentationElementExtractor xmlDocumentationElementExtractor)
        {
            _xmlDocumentationElementExtractor = xmlDocumentationElementExtractor;
        }


        public XmlElement ExtractDocumentation(MemberInfo memberInfo)
        {
            return _xmlDocumentationElementExtractor.ExtractDocumentationElement(memberInfo.DeclaringType, memberInfo.MemberType.ToString()[0], memberInfo.Name);
        }
    }
}
