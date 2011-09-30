using System;
using System.Linq;
using System.Xml;
using NExtra.Documentation.Abstractions;

namespace NExtra.Documentation.Extractors
{
    ///<summary>
    /// This class can be used to extract documentation elements for
    /// any type, constructor, member, method etc. It is intended to
    /// be used indirectly by the various default extractors in this
    /// namespace, but can naturally be used directly as well.
    /// </summary>
    /// <remarks>
    /// Author:         Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:           http://www.saidi.se/nextra
    /// </remarks>
    public class XmlDocumentationElementExtractor : ICanExtractXmlDocumentationElement
    {
        private readonly ICanExtractAssemblyXmlDocumentation assemblyXmlDocumentationExtractor;


        /// <summary>
        /// Create an instance of the class.
        /// </summary>
        /// <param name="assemblyXmlDocumentationExtractor">ICanExtractAssemblyXmlDocumentation implementation.</param>
        public XmlDocumentationElementExtractor(ICanExtractAssemblyXmlDocumentation assemblyXmlDocumentationExtractor)
        {
            this.assemblyXmlDocumentationExtractor = assemblyXmlDocumentationExtractor;
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
            var fullName = String.IsNullOrEmpty(subElementName) ?
                prefix + ":" + type.FullName :
                prefix + ":" + type.FullName + "." + subElementName;

            fullName.Replace("..", ".");

            var xmlDocument = assemblyXmlDocumentationExtractor.ExtractAssemblyXmlDocumentation(type.Assembly);
            
            var xmlElement = xmlDocument["doc"];
            if (xmlElement == null)
                throw new XmlException("Invalid XML document. The XML document is missing a <doc> tag.");

            var membersElement = xmlElement["members"];
            if (membersElement == null)
                throw new XmlException("Invalid XML document. The <doc> tag is missing a <members> tag.");
            
            XmlElement matchedElement = null;
            foreach (var memberElement in membersElement.Cast<XmlElement>().Where(memberElement => memberElement.Attributes["name"].Value.Equals(fullName)))
            {
                if (matchedElement != null)
                    throw new XmlException("Invalid XML document. Multiple elements matched the name value", null);
                matchedElement = memberElement;
            }

            if (matchedElement == null)
                throw new ArgumentException("Could not find documentation for specified element");

            return matchedElement;
        }
    }
}
