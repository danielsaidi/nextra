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
        /// <summary>
        /// The URL pattern for Gravatar avatars.
        /// </summary>
        public const string BaseUrl = "http://www.gravatar.com/avatar/{0}?s={1}";


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

            return String.Format(BaseUrl, hashCreator.GenerateHashValue(emailAddress).ToLower(), size);
        }
    }
}
