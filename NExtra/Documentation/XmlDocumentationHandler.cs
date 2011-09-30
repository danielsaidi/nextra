using System;
using System.Reflection;
using System.Xml;
using NExtra.Documentation.Abstractions;
using NExtra.Documentation.Extractors;

namespace NExtra.Documentation
{
    /// <summary>
    /// This class can be used to extract documentation for assemblies that
    /// are shipped with a corresponding XML documentation file, as well as
    /// types, members and methods within such assemblies.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// 
    /// This class wraps the various XML extractor classes that are defined
    /// in the Extractors sub namespace. It makes it easier to work with an
    /// XML documented assembly and its components, since all functionality
    /// is gathered in one class.
    /// </remarks>
    public class XmlDocumentationHandler : ICanExtractAssemblyXmlDocumentation, ICanExtractMemberInfoXmlDocumentation, ICanExtractMethodInfoXmlDocumentation, ICanExtractTypeXmlDocumentation, ICanExtractXmlDocumentationElement
    {
        private readonly ICanExtractAssemblyXmlDocumentation assemblyXmlDocumentationExtractor;
        private readonly ICanExtractXmlDocumentationElement xmlDocumentationElementExtractor;
        private readonly ICanExtractMemberInfoXmlDocumentation memberInfoXmlDocumentationExtractor;
        private readonly ICanExtractMethodInfoXmlDocumentation methodInfoXmlDocumentationExtractor;
        private readonly ICanExtractTypeXmlDocumentation typeXmlDocumentationExtractor;


        /// <summary>
        /// Create a default instance of the class.
        /// </summary>
        public XmlDocumentationHandler()
            : this(new AssemblyXmlDocumentationExtractor())
        {
        }

        /// <summary>
        /// Create a custom instance of the class.
        /// </summary>
        /// <param name="assemblyXmlDocumentationExtractor">Custom ICanExtractAssemblyXmlDocumentation implementation.</param>
        public XmlDocumentationHandler(ICanExtractAssemblyXmlDocumentation assemblyXmlDocumentationExtractor)
            : this(assemblyXmlDocumentationExtractor, new XmlDocumentationElementExtractor(assemblyXmlDocumentationExtractor))
        {
        }

        /// <summary>
        /// Create a custom instance of the class.
        /// </summary>
        /// <param name="assemblyXmlDocumentationExtractor">Custom ICanExtractAssemblyXmlDocumentation implementation.</param>
        /// <param name="xmlDocumentationElementExtractor">Custom ICanExtractXmlDocumentationElement implementation.</param>
        public XmlDocumentationHandler(ICanExtractAssemblyXmlDocumentation assemblyXmlDocumentationExtractor, ICanExtractXmlDocumentationElement xmlDocumentationElementExtractor)
            : this(assemblyXmlDocumentationExtractor, xmlDocumentationElementExtractor, new MemberInfoXmlDocumentationExtractor(xmlDocumentationElementExtractor), new MethodInfoXmlDocumentationExtractor(xmlDocumentationElementExtractor), new TypeXmlDocumentationExtractor(xmlDocumentationElementExtractor))
        {   
        }

        /// <summary>
        /// Create a custom instance of the class.
        /// </summary>
        /// <param name="assemblyXmlDocumentationExtractor">Custom ICanExtractAssemblyXmlDocumentation implementation.</param>
        /// <param name="xmlDocumentationElementExtractor">Custom ICanExtractXmlDocumentationElement implementation.</param>
        /// <param name="memberInfoXmlDocumentationExtractor">Custom ICanExtractMemberInfoXmlDocumentation implementation.</param>
        /// <param name="methodInfoXmlDocumentationExtractor">Custom ICanExtractMethodInfoXmlDocumentation implementation.</param>
        /// <param name="typeXmlDocumentationExtractor">Custom ICanExtractTypeXmlDocumentation implementation.</param>
        public XmlDocumentationHandler(
            ICanExtractAssemblyXmlDocumentation assemblyXmlDocumentationExtractor,
            ICanExtractXmlDocumentationElement xmlDocumentationElementExtractor,
            ICanExtractMemberInfoXmlDocumentation memberInfoXmlDocumentationExtractor,
            ICanExtractMethodInfoXmlDocumentation methodInfoXmlDocumentationExtractor,
            ICanExtractTypeXmlDocumentation typeXmlDocumentationExtractor)
        {
            this.assemblyXmlDocumentationExtractor = assemblyXmlDocumentationExtractor;
            this.xmlDocumentationElementExtractor = xmlDocumentationElementExtractor;
            this.memberInfoXmlDocumentationExtractor = memberInfoXmlDocumentationExtractor;
            this.methodInfoXmlDocumentationExtractor = methodInfoXmlDocumentationExtractor;
            this.typeXmlDocumentationExtractor = typeXmlDocumentationExtractor;
        }


        /// <summary>
        /// Extract XML documentation for an assembly.
        /// </summary>
        /// <param name="assembly">The assembly of interest.</param>
        /// <returns>XML documentation document.</returns>
        public XmlDocument ExtractAssemblyXmlDocumentation(Assembly assembly)
        {
            return assemblyXmlDocumentationExtractor.ExtractAssemblyXmlDocumentation(assembly);
        }

        /// <summary>
        /// Extract XML documentation for an assembly.
        /// </summary>
        /// <param name="assembly">The assembly of interest.</param>
        /// <param name="xmlDocumentationFile">The path to the XML documentation file.</param>
        /// <returns>XML documentation document.</returns>
        public XmlDocument ExtractAssemblyXmlDocumentation(Assembly assembly, string xmlDocumentationFile)
        {
            return assemblyXmlDocumentationExtractor.ExtractAssemblyXmlDocumentation(assembly, xmlDocumentationFile);
        }

        /// <summary>
        /// Extract XML documentation for a MemberInfo instance.
        /// </summary>
        /// <param name="memberInfo">The MemberInfo instance of interest.</param>
        /// <returns>XML documentation element.</returns>
        public XmlElement ExtractMemberInfoXmlDocumentation(MemberInfo memberInfo)
        {
            return memberInfoXmlDocumentationExtractor.ExtractMemberInfoXmlDocumentation(memberInfo);
        }

        /// <summary>
        /// Extract XML documentation for a MethodInfo instance.
        /// </summary>
        /// <param name="methodInfo">The MethodInfo instance of interest.</param>
        /// <returns>XML documentation element.</returns>
        public XmlElement ExtractMethodInfoXmlDocumentation(MethodInfo methodInfo)
        {
            return methodInfoXmlDocumentationExtractor.ExtractMethodInfoXmlDocumentation(methodInfo);
        }

        /// <summary>
        /// Extract XML documentation for a Type.
        /// </summary>
        /// <param name="type">The Type of interest.</param>
        /// <returns>XML documentation element.</returns>
        public XmlElement ExtractTypeXmlDocumentation(Type type)
        {
            return typeXmlDocumentationExtractor.ExtractTypeXmlDocumentation(type);
        }

        /// <summary>
        /// Extract an XML documentation element.
        /// </summary>
        /// <param name="type">The type of interest.</param>
        /// <param name="prefix">The type's documentation prefix.</param>
        /// <param name="subElementName">The sub element name, if any.</param>
        /// <returns>XML documentation element.</returns>
        public XmlElement ExtractXmlDocumentationElement(Type type, char prefix, string subElementName)
        {
            return xmlDocumentationElementExtractor.ExtractXmlDocumentationElement(type, prefix, subElementName);
        }
    }
}
