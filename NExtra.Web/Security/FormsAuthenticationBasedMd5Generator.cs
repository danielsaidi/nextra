using System.Web.Security;
using NExtra.Security;

namespace NExtra.Web.Security
{
    /// <summary>
    /// This class can be used to generate MD5 hash values,
    /// using FormsAuthentication functionality.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class FormsAuthenticationBasedMd5Generator : IHashValueGenerator
    {
        public string GenerateHashValue(object value)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(value.ToString(), "md5");
        }
    }
}
