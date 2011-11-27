namespace NExtra.IO.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// should be able to textually present file sizes.
    /// </summary>
    public interface ICanPresentFileSize
    {
        /// <summary>
        /// Present the size (in bytes) of a file.
        /// </summary>
        string PresentFileSize(double fileSize, string numberFormat);
    }
}
