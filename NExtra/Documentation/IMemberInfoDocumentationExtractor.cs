using System.Reflection;
using System.Xml;

namespace NExtra.Documentation
{
    /// <summary>
    /// This interface can be implemented by classes that can
    /// extract XML documentation data for MemberInfo instances.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IMemberInfoDocumentationExtractor
    {
        /// <summary>
        /// Extract XML documentation for a certain MemberInfo instance.
        /// </summary>
        XmlElement ExtractDocumentation(MemberInfo memberInfo);
    }
}
