using System;

namespace NExtra.Web.Avatar
{
    /// <summary>
    /// This class can be used to load Facebook avatars.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class FacebookAvatarService : IAvatarService<FacebookAvatarSize>
    {
        private const string UrlPattern = "http://graph.facebook.com/{0}/picture?type={1}";


        public string GetAvatarUrl(string userName, FacebookAvatarSize size)
        {
            return String.Format(UrlPattern, userName, size.ToString().ToLower());
        }
    }
}
