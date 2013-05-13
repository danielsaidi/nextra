using System;
using System.IO;
using System.Reflection;

namespace NExtra.Extensions
{
	/// <summary>
	/// Extension methods for System.Reflection.Assembly.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
	public static class Assembly_FileExtensions
    {
        public static string GetFilePath(this Assembly assembly)
        {
            var codeBase = assembly.GetName().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);

            return path;
        }

        public static string GetFolderPath(this Assembly assembly)
        {
            var codeBase = assembly.GetName().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);

            return Path.GetDirectoryName(path);
        }
	}
}
