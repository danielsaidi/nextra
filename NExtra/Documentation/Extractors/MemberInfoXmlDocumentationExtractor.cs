using System.Reflection;
using System.Xml;
using NExtra.Documentation.Abstractions;

namespace NExtra.Documentation.Extractors
{
    ///<summary>
    /// This class can be used to extract XML documentation for type members.
    ///</summary>
    /// <remarks>
    /// Author:         Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:           http://www.saidi.se/nextra
    /// </remarks>
    public class MemberInfoXmlDocumentationExtractor : ICanExtractMemberInfoXmlDocumentation
    {
        private readonly ICanExtractXmlDocumentationElement xmlDocumentationElementExtractor;


        /// <summary>
        /// Create an instance of the class.
        /// </summary>
        /// <param name="xmlDocumentationElementExtractor">ICanExtractXmlDocumentationElement implementation.</param>
        public MemberInfoXmlDocumentationExtractor(ICanExtractXmlDocumentationElement xmlDocumentationElementExtractor)
        {
            this.xmlDocumentationElementExtractor = xmlDocumentationElementExtractor;
        }


        /// <summary>
        /// Extract XML documentation for a MemberInfo instance.
        /// </summary>
        /// <param name="memberInfo">The MemberInfo instance of interest.</param>
        /// <returns>XML documentation element.</returns>
        public XmlElement ExtractMemberInfoXmlDocumentation(MemberInfo memberInfo)
        {
            return xmlDocumentationElementExtractor.ExtractXmlDocumentationElement(memberInfo.DeclaringType, memberInfo.MemberType.ToString()[0], memberInfo.Name);
        }
    }
}
