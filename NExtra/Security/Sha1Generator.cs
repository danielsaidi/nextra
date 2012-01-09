using System;
using System.Security.Cryptography;
using System.Text;

namespace NExtra.Security
{
    /// <summary>
    /// This class can be used to generate SHA1 hash values.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class Sha1Generator : ICanGenerateHashValue
    {
        /// <summary>
        /// Generate an SHA1 hash value.
        /// </summary>
        public string GenerateHashValue(object value)
        {
            var md5 = new SHA1CryptoServiceProvider();
            var hashedBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(value.ToString()));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}
