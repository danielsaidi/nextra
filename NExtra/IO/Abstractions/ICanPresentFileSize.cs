namespace NExtra.IO.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes
    /// that can present file sizes textually.
    /// </summary>
    public interface ICanPresentFileSize
    {
        /// <summary>
        /// Present the size (in bytes) of a file.
        /// </summary>
        string PresentFileSize(double fileSize, string numberFormat);
    }
}
