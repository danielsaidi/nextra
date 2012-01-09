using System;

namespace NExtra.Web.Avatar
{
    /// <summary>
    /// This class can be used to retrieve Facebook profile pictures.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class FacebookAvatar : IAvatarService<FacebookAvatarSize>
    {
        /// <summary>
        /// The URL pattern for Facebook profile pictures.
        /// </summary>
        public const string UrlPattern = "http://graph.facebook.com/{0}/picture?type={1}";


        /// <summary>
        /// Get the url of a user avatar.
        /// </summary>
        public string GetAvatarUrl(string userName)
        {
            return GetAvatarUrl(userName, FacebookAvatarSize.Small);
        }

        /// <summary>
        /// Get the url of a user avatar.
        /// </summary>
        public string GetAvatarUrl(string userName, FacebookAvatarSize size)
        {
            return String.Format(UrlPattern, userName, size.ToString().ToLower());
        }
    }
}
