using System.Web;

namespace NExtra.Web.Testing
{
    ///<summary>
    /// This class can be used as a fake HTTP response in
    /// test scenarios.
    ///</summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class FakeHttpResponse : HttpResponseBase
    {
        private readonly HttpCookieCollection cookies;


        /// <summary>
        /// Create a fake HTTP response.
        /// </summary>
        public FakeHttpResponse()
        {
            cookies = new HttpCookieCollection();
        }
        

        /// <summary>
        /// Get a fake cookie collection for the fake response.
        /// </summary>
        public override HttpCookieCollection Cookies
        {
            get { return cookies; }
        }
    }
}