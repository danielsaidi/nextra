using System;

namespace NExtra.IO
{
    /// <summary>
    /// This class can be used to present a file size in a
    /// readable fashion, e.g. "100 kB". It handles string
    /// formatting for file sizes up to TB.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class FileSizePresenter : IFileSizePresenter
    {
        /// <summary>
        /// Present the size (in bytes) of a file, e.g. 10000 => 10kB.
        /// </summary>
        public string PresentFileSize(double fileSize, string numberFormat = "{0:F2}")
        {
            if (fileSize < 1000)
                return fileSize + " B";

            if (fileSize >= 1000 && fileSize < 1000000)
                return String.Format(numberFormat + " kB", fileSize / 1000);

            if (fileSize >= 1000000 && fileSize < 1000000000)
                return String.Format(numberFormat + " MB", fileSize / 1000000);

            if (fileSize >= 1000000000 && fileSize < 1000000000000)
                return String.Format(numberFormat + " GB", fileSize / 1000000000);

            return String.Format(numberFormat + " TB", fileSize / 1000000000000);
        }
    }
}
