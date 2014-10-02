using System;
using System.Reflection;
using System.Xml;

namespace NExtra.Documentation
{
    /// <summary>
    /// This class can be used to extract documentation for assemblies that
    /// are shipped with a corresponding XML documentation file, as well as
    /// types, members and methods within such assemblies.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// 
    /// This class wraps the various XML extractor classes that are defined
    /// in this namespace.
    /// </remarks>
    public class XmlDocumentationHandler : IAssemblyDocumentationExtractor, IMemberInfoDocumentationExtractor, IMethodInfoDocumentationExtractor, ITypeDocumentationExtractor, IDocumentationElementExtractor
    {
        private readonly IAssemblyDocumentationExtractor _assemblyExtractor;
        private readonly IDocumentationElementExtractor _elementExtractor;
        private readonly IMemberInfoDocumentationExtractor _memberExtractor;
        private readonly IMethodInfoDocumentationExtractor _methodExtractor;
        private readonly ITypeDocumentationExtractor _typeExtractor;


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
        public XmlDocumentationHandler(IAssemblyDocumentationExtractor assemblyExtractor)
            : this(assemblyExtractor, new XmlDocumentationElementExtractor(assemblyExtractor))
        {
        }

        /// <summary>
        /// Create a custom instance of the class.
        /// </summary>
        /// <param name="assemblyExtractor">Custom ICanExtractAssemblyXmlDocumentation implementation.</param>
        /// <param name="elementExtractor">Custom ICanExtractXmlDocumentationElement implementation.</param>
        public XmlDocumentationHandler(IAssemblyDocumentationExtractor assemblyExtractor, IDocumentationElementExtractor elementExtractor)
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
            IAssemblyDocumentationExtractor assemblyExtractor,
            IDocumentationElementExtractor elementExtractor,
            IMemberInfoDocumentationExtractor memberExtractor,
            IMethodInfoDocumentationExtractor methodExtractor,
            ITypeDocumentationExtractor typeExtractor)
        {
            _assemblyExtractor = assemblyExtractor;
            _elementExtractor = elementExtractor;
            _memberExtractor = memberExtractor;
            _methodExtractor = methodExtractor;
            _typeExtractor = typeExtractor;
        }


        /// <summary>
        /// Extract XML documentation for an assembly.
        /// </summary>
        /// <param name="assembly">The assembly of interest.</param>
        /// <returns>XML documentation document.</returns>
        public XmlDocument ExtractDocumentation(Assembly assembly)
        {
            return _assemblyExtractor.ExtractDocumentation(assembly);
        }

        /// <summary>
        /// Extract XML documentation for an assembly.
        /// </summary>
        /// <param name="assembly">The assembly of interest.</param>
        /// <param name="xmlFilePath">The path to the XML documentation file.</param>
        /// <returns>XML documentation document.</returns>
        public XmlDocument ExtractDocumentation(Assembly assembly, string xmlFilePath)
        {
            return _assemblyExtractor.ExtractDocumentation(assembly, xmlFilePath);
        }

        /// <summary>
        /// Extract XML documentation for a MemberInfo instance.
        /// </summary>
        /// <param name="memberInfo">The MemberInfo instance of interest.</param>
        /// <returns>XML documentation element.</returns>
        public XmlElement ExtractDocumentation(MemberInfo memberInfo)
        {
            return _memberExtractor.ExtractDocumentation(memberInfo);
        }

        /// <summary>
        /// Extract XML documentation for a MethodInfo instance.
        /// </summary>
        /// <param name="methodInfo">The MethodInfo instance of interest.</param>
        /// <returns>XML documentation element.</returns>
        public XmlElement ExtractDocumentation(MethodInfo methodInfo)
        {
            return _methodExtractor.ExtractDocumentation(methodInfo);
        }

        /// <summary>
        /// Extract XML documentation for a Type.
        /// </summary>
        /// <param name="type">The Type of interest.</param>
        /// <returns>XML documentation element.</returns>
        public XmlElement ExtractDocumentation(Type type)
        {
            return _typeExtractor.ExtractDocumentation(type);
        }

        /// <summary>
        /// Extract an XML documentation element.
        /// </summary>
        /// <param name="type">The type of interest.</param>
        /// <param name="prefix">The type's documentation prefix.</param>
        /// <param name="subElementName">The sub element name, if any.</param>
        /// <returns>XML documentation element.</returns>
        public XmlElement ExtractDocumentationElement(Type type, char prefix, string subElementName)
        {
            return _elementExtractor.ExtractDocumentationElement(type, prefix, subElementName);
        }
    }
}
