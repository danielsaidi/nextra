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
        public static string GetResponseString(this WebRequest webRequest)
        {
            var response = webRequest.GetResponse();
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
