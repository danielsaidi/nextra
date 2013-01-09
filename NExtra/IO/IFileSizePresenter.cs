namespace NExtra.IO
{
    /// <summary>
    /// This interface can be implemented by classes that can
    /// present file sizes textually.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IFileSizePresenter
    {
        /// <summary>
        /// Present the textual representation of a file size (in bytes).
        /// </summary>
        string PresentFileSize(double fileSize, string numberFormat);
    }
}
