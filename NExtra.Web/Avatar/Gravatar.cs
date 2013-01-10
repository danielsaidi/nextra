using System;
using NExtra.Web.Security;

namespace NExtra.Web.Avatar
{
    /// <summary>
    /// This class can be used to retrieve Gravatar avatars.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class Gravatar : IAvatarService<int>
    {
        private const string urlPattern = "http://www.gravatar.com/avatar/{0}?s={1}";


        ///<summary>
        /// Create an instance of the class, using a default avatar size.
        ///</summary>
        public Gravatar(int defaultSize)
        {
            DefaultSize = defaultSize;
        }


        /// <summary>
        /// The default size of the avatars returned by this class.
        /// </summary>
        public int DefaultSize { get; private set; }

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
            var hashCreator = new FormsAuthenticationBasedMd5Generator();

            return String.Format(urlPattern, hashCreator.GenerateHashValue(emailAddress).ToLower(), size);
        }
    }
}
