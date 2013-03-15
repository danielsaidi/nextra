using System;
using System.Web;

namespace NExtra.Web.Testing
{
    ///<summary>
    /// This class can be used as a fake HTTP request.
    ///</summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class FakeHttpRequest : HttpRequestBase
    {
        private readonly HttpCookieCollection cookies;
        private readonly bool isAuthenticated;
        private readonly Uri url;
        private Uri urlReferrer;


        /// <summary>
        /// Create a fake HTTP request with a certain url and authentication state.
        /// </summary>
        public FakeHttpRequest(string url, bool isAuthenticated)
        {
            this.url = new Uri(url);
            this.isAuthenticated = isAuthenticated;

            cookies = new HttpCookieCollection();
        }


        /// <summary>
        /// Get a fake cookie collection for the request.
        /// </summary>
        public override HttpCookieCollection Cookies
        {
            get { return cookies; }
        }

        /// <summary>
        /// Get the fake, manually set authentication status for the request.
        /// </summary>
        public override bool IsAuthenticated
        {
            get { return isAuthenticated; }
        }

        /// <summary>
        /// Get the fake, manually set url for the request.
        /// </summary>
        public override Uri Url
        {
            get { return url; }
        }

        /// <summary>
        /// Get the manually set url referrer for the request.
        /// </summary>
        public override Uri UrlReferrer
        {
            get { return urlReferrer; }
        }

        /// <summary>
        /// Set the url referrer for the request.
        /// </summary>
        public void SetUrlReferrer(Uri newValue)
        {
            urlReferrer = newValue;
        }
    }
}