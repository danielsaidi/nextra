using System;
using NExtra.Web.Avatar.Abstractions;
using NExtra.Web.Security;

namespace NExtra.Web.Avatar
{
    /// <summary>
    /// This class can be used to retrieve Gravatar avatars.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class Gravatar : IAvatarService<int>
    {
        [Obsolete("This constant is obsolete. Use UrlPattern instead.")]
        public const string BaseUrl = UrlPattern;



        /// <summary>
        /// The URL pattern for Gravatar avatars.
        /// </summary>
        public const string UrlPattern = "http://www.gravatar.com/avatar/{0}?s={1}";


        /// <summary>
        /// Get the url of a user avatar.
        /// </summary>
        public string GetAvatarUrl(string emailAddress)
        {
            return GetAvatarUrl(emailAddress, 80);
        }

        /// <summary>
        /// Get the url of a user avatar.
        /// </summary>
        public string GetAvatarUrl(string emailAddress, int size)
        {
            var hashCreator = new Md5Generator();

            return String.Format(UrlPattern, hashCreator.GenerateHashValue(emailAddress).ToLower(), size);
        }
    }
}
