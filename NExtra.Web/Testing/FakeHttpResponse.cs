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
        private readonly HttpCookieCollection _cookies;


        public FakeHttpResponse()
        {
            _cookies = new HttpCookieCollection();
        }
        

        public override HttpCookieCollection Cookies
        {
            get { return _cookies; }
        }
    }
}