using System;
using System.Collections.Generic;
using System.Linq;

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
        public static Uri SetQueryParameter(this Uri uri, string key, string value)
        {
            var parameters = uri.GetQueryParameters();
            parameters[key] = value;

            var pairs = parameters.Select(x => string.Format("{0}={1}", x.Key, x.Value));
            var query = string.Join("&", pairs);
            var result = new UriBuilder(uri) { Query = query }.Uri;

            return result;
        }

        public static IDictionary<string, string> GetQueryParameters(this Uri uri)
        {
            var result = new Dictionary<string, string>();

            var rawQuery = uri.Query.Replace("?", "");
            if (string.IsNullOrWhiteSpace(rawQuery))
                return result;

            result = rawQuery.Split('&')
               .Select(part => part.Split('='))
               .ToDictionary(split => split[0], split => split.Length > 1 ? split[1] : String.Empty);

            return result;
        }

        public static Uri GetRootUri(this Uri uri)
        {
            var port = (uri.IsDefaultPort) ? "" : ":" + uri.Port;
            var root = new Uri(string.Format("{0}://{1}{2}", uri.Scheme, uri.Host, port));

            return root;
        }
    }
}
