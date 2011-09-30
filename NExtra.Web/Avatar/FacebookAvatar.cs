using System;
using NExtra.Web.Avatar.Abstractions;

namespace NExtra.Web.Avatar
{
    /// <summary>
    /// This class can be used to retrieve user avatars
    /// from Facebook.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class FacebookAvatar : IAvatarService<FacebookAvatarSize>
    {
        /// <summary>
        /// The pattern of Facebook avatar URLs.
        /// </summary>
        public const string BaseUrl = "http://graph.facebook.com/{0}/picture?type={1}";


        /// <summary>
        /// Get the url of a user avatar.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <returns>The resulting url of the user avatar.</returns>
        public string GetAvatarUrl(string userName)
        {
            return GetAvatarUrl(userName, FacebookAvatarSize.Small);
        }

        /// <summary>
        /// Get the url of a user avatar.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <param name="size">The avatar size.</param>
        /// <returns>The resulting url of the user avatar.</returns>
        public string GetAvatarUrl(string userName, FacebookAvatarSize size)
        {
            return String.Format(BaseUrl, userName, size.ToString().ToLower());
        }
    }
}
