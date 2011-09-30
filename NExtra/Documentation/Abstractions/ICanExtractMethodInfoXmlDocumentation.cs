using System.Reflection;
using System.Xml;

namespace NExtra.Documentation.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that should
    /// be able to locate and extract XML documentation data for
    /// MethodInfo instances.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface ICanExtractMethodInfoXmlDocumentation
    {
        /// <summary>
        /// Extract XML documentation data for a certain MemberInfo instance.
        /// </summary>
        /// <param name="methodInfo">The MethodInfo instance of interest.</param>
        /// <returns>The resulting documentation element.</returns>
        XmlElement ExtractMethodInfoXmlDocumentation(MethodInfo methodInfo);
    }
}
