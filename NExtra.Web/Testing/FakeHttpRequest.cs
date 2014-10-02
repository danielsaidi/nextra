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
        private readonly HttpCookieCollection _cookies;
        private readonly bool _isAuthenticated;
        private readonly Uri _url;
        private Uri _urlReferrer;


        public FakeHttpRequest(string url, bool isAuthenticated)
        {
            _url = new Uri(url);
            _isAuthenticated = isAuthenticated;

            _cookies = new HttpCookieCollection();
        }


        public override HttpCookieCollection Cookies
        {
            get { return _cookies; }
        }

        public override bool IsAuthenticated
        {
            get { return _isAuthenticated; }
        }

        public override Uri Url
        {
            get { return _url; }
        }

        public override Uri UrlReferrer
        {
            get { return _urlReferrer; }
        }

        public void SetUrlReferrer(Uri newValue)
        {
            _urlReferrer = newValue;
        }
    }
}