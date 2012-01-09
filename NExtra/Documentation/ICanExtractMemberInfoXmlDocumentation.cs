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
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface ICanExtractMemberInfoXmlDocumentation
    {
        /// <summary>
        /// Extract XML documentation for a certain MemberInfo instance.
        /// </summary>
        XmlElement ExtractMemberInfoXmlDocumentation(MemberInfo memberInfo);
    }
}
