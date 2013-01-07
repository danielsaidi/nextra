namespace NExtra.Web.Avatar
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can provide avatar-related services.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IAvatarService<in T>
    {
        /// <summary>
        /// Get the url of a user avatar.
        /// </summary>
        string GetAvatarUrl(string userName);

        /// <summary>
        /// Get the url of a user avatar.
        /// </summary>
        string GetAvatarUrl(string userName, T size);
    }
}
