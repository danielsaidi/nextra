using System;

namespace NExtra.Web.Avatar
{
    /// <summary>
    /// This class can be used to retrieve Facebook profile pictures.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class FacebookAvatar : IAvatarService<FacebookAvatarSize>
    {
        private const string urlPattern = "http://graph.facebook.com/{0}/picture?type={1}";


        ///<summary>
        /// Create an instance of the class, using a default avatar size.
        ///</summary>
        public FacebookAvatar(FacebookAvatarSize defaultSize)
        {
            DefaultSize = defaultSize;
        }


        /// <summary>
        /// The default size of the avatars returned by this class.
        /// </summary>
        public FacebookAvatarSize DefaultSize { get; private set; }
        
        
        public string GetAvatarUrl(string userName)
        {
            return GetAvatarUrl(userName, DefaultSize);
        }

        public string GetAvatarUrl(string userName, FacebookAvatarSize size)
        {
            return String.Format(urlPattern, userName, size.ToString().ToLower());
        }
    }
}
