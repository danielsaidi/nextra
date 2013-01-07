namespace NExtra.IO
{
    /// <summary>
    /// This interface can be implemented by classes
    /// that can present file sizes textually.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IFileSizePresenter
    {
        /// <summary>
        /// Present the size (in bytes) of a file.
        /// </summary>
        string PresentFileSize(double fileSize, string numberFormat);
    }
}
