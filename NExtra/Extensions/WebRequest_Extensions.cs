using System.IO;
using System.Net;

namespace NExtra.Extensions
{
    /// <summary>
    /// Extension methods for System.Net.WebRequest.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class WebRequest_Extensions
    {
        /// <summary>
        /// Adjust content that has been received from a web request.
        /// </summary>
        /// <remarks>
        /// TODO: The method should handle non-absolute, local paths.
        /// </remarks>
        public static string AdjustContent(this WebRequest webRequest, string content)
        {
            content = content.Replace("\r", "");
            content = content.Replace("\n", "");
            content = content.Replace("src=\"/", "src=\"" + webRequest.RequestUri.GetRootUri());
            content = content.Replace("href=\"/", "href=\"" + webRequest.RequestUri.GetRootUri());

            return content;
        }


        /// <summary>
        /// Get the response string (the content) of a web request.
        /// </summary>
        public static string GetResponseString(this WebRequest webRequest)
        {
            var response = webRequest.GetResponse();
            if (response == null)
                return string.Empty;

            var responseStream = response.GetResponseStream();
            if (responseStream == null)
                return string.Empty;

            string result;
            using (var sr = new StreamReader(responseStream))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }

            return result;
        }
    }
}
