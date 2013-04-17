namespace NExtra.Web.Avatar
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// provides user avatars, like Gravatar and Facebook.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IAvatarService<in SizeType>
    {
        string GetAvatarUrl(string userName, SizeType size);
    }
}
