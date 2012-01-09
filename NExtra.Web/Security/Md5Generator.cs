using System.Web.Security;
using NExtra.Security;

namespace NExtra.Web.Security
{
    /// <summary>
    /// This class can be used to generate MD5 hash values.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class Md5Generator : ICanGenerateHashValue
    {
        /// <summary>
        /// Generate an MD5 hash value for an object.
        /// </summary>
        public string GenerateHashValue(object value)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(value.ToString(), "md5");
        }
    }
}
