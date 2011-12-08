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
        private readonly ICanExtractAssemblyXmlDocumentation assemblyExtractor;
        private readonly ICanExtractXmlDocumentationElement elementExtractor;
        private readonly ICanExtractMemberInfoXmlDocumentation memberExtractor;
        private readonly ICanExtractMethodInfoXmlDocumentation methodExtractor;
        private readonly ICanExtractTypeXmlDocumentation typeExtractor;


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
        /// <param name="assemblyExtractor">Custom ICanExtractAssemblyXmlDocumentation implementation.</param>
        public XmlDocumentationHandler(ICanExtractAssemblyXmlDocumentation assemblyExtractor)
            : this(assemblyExtractor, new XmlDocumentationElementExtractor(assemblyExtractor))
        {
        }

        /// <summary>
        /// Create a custom instance of the class.
        /// </summary>
        /// <param name="assemblyExtractor">Custom ICanExtractAssemblyXmlDocumentation implementation.</param>
        /// <param name="elementExtractor">Custom ICanExtractXmlDocumentationElement implementation.</param>
        public XmlDocumentationHandler(ICanExtractAssemblyXmlDocumentation assemblyExtractor, ICanExtractXmlDocumentationElement elementExtractor)
            : this(assemblyExtractor, elementExtractor, new MemberInfoXmlDocumentationExtractor(elementExtractor), new MethodInfoXmlDocumentationExtractor(elementExtractor), new TypeXmlDocumentationExtractor(elementExtractor))
        {   
        }

        /// <summary>
        /// Create a custom instance of the class.
        /// </summary>
        /// <param name="assemblyExtractor">Custom ICanExtractAssemblyXmlDocumentation implementation.</param>
        /// <param name="elementExtractor">Custom ICanExtractXmlDocumentationElement implementation.</param>
        /// <param name="memberExtractor">Custom ICanExtractMemberInfoXmlDocumentation implementation.</param>
        /// <param name="methodExtractor">Custom ICanExtractMethodInfoXmlDocumentation implementation.</param>
        /// <param name="typeExtractor">Custom ICanExtractTypeXmlDocumentation implementation.</param>
        public XmlDocumentationHandler(
            ICanExtractAssemblyXmlDocumentation assemblyExtractor,
            ICanExtractXmlDocumentationElement elementExtractor,
            ICanExtractMemberInfoXmlDocumentation memberExtractor,
            ICanExtractMethodInfoXmlDocumentation methodExtractor,
            ICanExtractTypeXmlDocumentation typeExtractor)
        {
            this.assemblyExtractor = assemblyExtractor;
            this.elementExtractor = elementExtractor;
            this.memberExtractor = memberExtractor;
            this.methodExtractor = methodExtractor;
            this.typeExtractor = typeExtractor;
        }


        /// <summary>
        /// Extract XML documentation for an assembly.
        /// </summary>
        /// <param name="assembly">The assembly of interest.</param>
        /// <returns>XML documentation document.</returns>
        public XmlDocument ExtractAssemblyXmlDocumentation(Assembly assembly)
        {
            return assemblyExtractor.ExtractAssemblyXmlDocumentation(assembly);
        }

        /// <summary>
        /// Extract XML documentation for an assembly.
        /// </summary>
        /// <param name="assembly">The assembly of interest.</param>
        /// <param name="xmlFilePath">The path to the XML documentation file.</param>
        /// <returns>XML documentation document.</returns>
        public XmlDocument ExtractAssemblyXmlDocumentation(Assembly assembly, string xmlFilePath)
        {
            return assemblyExtractor.ExtractAssemblyXmlDocumentation(assembly, xmlFilePath);
        }

        /// <summary>
        /// Extract XML documentation for a MemberInfo instance.
        /// </summary>
        /// <param name="memberInfo">The MemberInfo instance of interest.</param>
        /// <returns>XML documentation element.</returns>
        public XmlElement ExtractMemberInfoXmlDocumentation(MemberInfo memberInfo)
        {
            return memberExtractor.ExtractMemberInfoXmlDocumentation(memberInfo);
        }

        /// <summary>
        /// Extract XML documentation for a MethodInfo instance.
        /// </summary>
        /// <param name="methodInfo">The MethodInfo instance of interest.</param>
        /// <returns>XML documentation element.</returns>
        public XmlElement ExtractMethodInfoXmlDocumentation(MethodInfo methodInfo)
        {
            return methodExtractor.ExtractMethodInfoXmlDocumentation(methodInfo);
        }

        /// <summary>
        /// Extract XML documentation for a Type.
        /// </summary>
        /// <param name="type">The Type of interest.</param>
        /// <returns>XML documentation element.</returns>
        public XmlElement ExtractTypeXmlDocumentation(Type type)
        {
            return typeExtractor.ExtractTypeXmlDocumentation(type);
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
            return elementExtractor.ExtractXmlDocumentationElement(type, prefix, subElementName);
        }
    }
}
