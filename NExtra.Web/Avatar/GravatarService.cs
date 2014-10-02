using System;
using NExtra.Web.Security;

namespace NExtra.Web.Avatar
{
    /// <summary>
    /// This class can be used to load Gravatar avatars.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class GravatarService : IAvatarService<int>
    {
        private const string UrlPattern = "http://www.gravatar.com/avatar/{0}?s={1}";

        public string GetAvatarUrl(string emailAddress, int size)
        {
            var hashCreator = new FormsAuthenticationBasedMd5Generator();

            return String.Format(UrlPattern, hashCreator.GenerateHashValue(emailAddress).ToLower(), size);
        }
    }
}
