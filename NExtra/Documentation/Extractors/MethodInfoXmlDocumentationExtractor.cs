using System.Reflection;
using System.Xml;
using NExtra.Documentation.Abstractions;

namespace NExtra.Documentation.Extractors
{
    ///<summary>
    /// This class can be used to extract XML documentation for type methods.
    ///</summary>
    /// <remarks>
    /// Author:         Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:           http://www.saidi.se/nextra
    /// </remarks>
    public class MethodInfoXmlDocumentationExtractor : ICanExtractMethodInfoXmlDocumentation
    {
        private readonly ICanExtractXmlDocumentationElement xmlDocumentationElementExtractor;


        /// <summary>
        /// Create an instance of the class.
        /// </summary>
        /// <param name="xmlDocumentationElementExtractor">ICanExtractXmlDocumentationElement implementation.</param>
        public MethodInfoXmlDocumentationExtractor(ICanExtractXmlDocumentationElement xmlDocumentationElementExtractor)
        {
            this.xmlDocumentationElementExtractor = xmlDocumentationElementExtractor;
        }


        /// <summary>
        /// Extract XML documentation for a MethodInfo instance.
        /// </summary>
        /// <param name="methodInfo">The MethodInfo instance of interest.</param>
        /// <returns>XML documentation element.</returns>
        public XmlElement ExtractMethodInfoXmlDocumentation(MethodInfo methodInfo)
        {
            var parametersString = "";
            foreach (var parameterInfo in methodInfo.GetParameters())
            {
                if (parametersString.Length > 0)
                    parametersString += ",";
                parametersString += parameterInfo.ParameterType.FullName;
            }

            return parametersString.Length > 0 ?
                xmlDocumentationElementExtractor.ExtractXmlDocumentationElement(methodInfo.DeclaringType, 'M', methodInfo.Name + "(" + parametersString + ")") :
                xmlDocumentationElementExtractor.ExtractXmlDocumentationElement(methodInfo.DeclaringType, 'M', methodInfo.Name);
        }
    }
}
