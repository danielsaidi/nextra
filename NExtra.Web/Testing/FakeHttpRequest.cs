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


        public FakeHttpRequest(string url, bool isAuthenticated)
        {
            this.url = new Uri(url);
            this.isAuthenticated = isAuthenticated;

            cookies = new HttpCookieCollection();
        }


        public override HttpCookieCollection Cookies
        {
            get { return cookies; }
        }

        public override bool IsAuthenticated
        {
            get { return isAuthenticated; }
        }

        public override Uri Url
        {
            get { return url; }
        }

        public override Uri UrlReferrer
        {
            get { return urlReferrer; }
        }



        public void SetUrlReferrer(Uri newValue)
        {
            urlReferrer = newValue;
        }
    }
}