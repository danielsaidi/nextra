using System.Reflection;
using System.Xml;

namespace NExtra.Documentation.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that should
    /// be able to locate and extract XML documentation data for
    /// MemberInfo instances.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface ICanExtractMemberInfoXmlDocumentation
    {
        /// <summary>
        /// Extract XML documentation data for a certain MemberInfo instance.
        /// </summary>
        /// <param name="memberInfo">The MemberInfo instance of interest.</param>
        /// <returns>The resulting documentation element.</returns>
        XmlElement ExtractMemberInfoXmlDocumentation(MemberInfo memberInfo);
    }
}
