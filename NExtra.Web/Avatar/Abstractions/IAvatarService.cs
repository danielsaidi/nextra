namespace NExtra.Web.Avatar.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// should be able to provide avatar-related services.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    /// <typeparam name="T">The type of the size attribute.</typeparam>
    public interface IAvatarService<in T>
    {
        /// <summary>
        /// Get the url of a user avatar.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <returns>The resulting url of the user avatar.</returns>
        string GetAvatarUrl(string userName);

        /// <summary>
        /// Get the url of a user avatar.
        /// </summary>
        /// <param name="userName">The user name of interest.</param>
        /// <param name="size">The avatar size.</param>
        /// <returns>The resulting url of the user avatar.</returns>
        string GetAvatarUrl(string userName, T size);
    }
}
