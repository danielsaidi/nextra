using System;
using System.Security.Cryptography;
using System.Text;

namespace NExtra.Security
{
    /// <summary>
    /// This class can be used to generate MD5 hash values.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class Md5Generator : IHashValueGenerator
    {
        /// <summary>
        /// Generate an MD5 hash value for an object.
        /// </summary>
        public string GenerateHashValue(object value)
        {
            var md5 = new MD5CryptoServiceProvider();
            var hashedBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(value.ToString()));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}
