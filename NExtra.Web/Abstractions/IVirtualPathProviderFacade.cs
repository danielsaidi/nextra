using System.Web.Hosting;

namespace NExtra.Web.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can work with virtual paths.
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
        VirtualFile GetFile(string fileUrl);

        /// <summary>
        /// Get the size of a certain virtual file.
        /// </summary>
        long GetFileSize(string fileUrl);
    }
}
