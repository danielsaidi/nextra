using System;

namespace NExtra.Extensions
{
    /// <summary>
    /// Extension methods for System.Uri.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class Uri_Extensions
    {
        /// <summary>
        /// Get the root url for an Uri, including scheme,
        /// host and port.
        /// </summary>
        public static Uri GetRootUri(this Uri uri)
        {
            var port = (uri.IsDefaultPort) ? "" : ":" + uri.Port;
            var root = new Uri(string.Format("{0}://{1}{2}", uri.Scheme, uri.Host, port));

            return root;
        }
    }
}
