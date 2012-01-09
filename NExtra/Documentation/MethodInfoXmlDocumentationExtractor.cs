using System.Reflection;
using System.Xml;

namespace NExtra.Documentation
{
    ///<summary>
    /// This class can be used to extract XML documentation
    /// data for MethodInfo instances.
    ///</summary>
    /// <remarks>
    /// Author:         Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:           http://www.saidi.se/nextra
    /// </remarks>
    public class MethodInfoXmlDocumentationExtractor : ICanExtractMethodInfoXmlDocumentation
    {
        private readonly ICanExtractXmlDocumentationElement xmlDocumentationElementExtractor;


        /// <param name="xmlDocumentationElementExtractor">The element documentation extractor to use.</param>
        public MethodInfoXmlDocumentationExtractor(ICanExtractXmlDocumentationElement xmlDocumentationElementExtractor)
        {
            this.xmlDocumentationElementExtractor = xmlDocumentationElementExtractor;
        }


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
