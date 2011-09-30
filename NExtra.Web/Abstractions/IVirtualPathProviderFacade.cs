using System.Web.Hosting;

namespace NExtra.Web.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// should be able to work with virtual paths.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface IVirtualPathProviderFacade
    {
        /// <summary>
        /// Retrieve a virtual file.
        /// </summary>
        /// <param name="fileUrl">The URL of the virtual file.</param>
        /// <returns>The resulting virtual file.</returns>
        VirtualFile GetFile(string fileUrl);

        /// <summary>
        /// Get the size of a certain virtual file.
        /// </summary>
        /// <param name="fileUrl">The URL of the virtual file.</param>
        /// <returns>The size of the virtual file.</returns>
        long GetFileSize(string fileUrl);
    }
}
