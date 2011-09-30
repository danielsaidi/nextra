namespace NExtra.IO.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// should be able to present file sizes in a textual
    /// way.
    /// </summary>
    public interface ICanPresentFileSize
    {
        /// <summary>
        /// Present the size of a file.
        /// </summary>
        /// <param name="fileSize">The file size in bytes.</param>
        /// <param name="numberFormat">The number format to use; e.g. {0:F2}.</param>
        /// <returns>The textual representation of the file size.</returns>
        string PresentFileSize(double fileSize, string numberFormat);
    }
}
