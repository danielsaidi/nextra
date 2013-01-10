namespace NExtra.Web.Avatar
{
    /// <summary>
    /// This interface can be implemented by classes that can
    /// provide avatars for users accounts, e.g. Gravatar.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IAvatarService<in SizeType>
    {
        /// <summary>
        /// Get the url of a user avatar with default size.
        /// </summary>
        string GetAvatarUrl(string userName);

        /// <summary>
        /// Get the url of a user avatar with a given size.
        /// </summary>
        string GetAvatarUrl(string userName, SizeType size);
    }
}
