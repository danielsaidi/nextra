using System.Web;
using NExtra.Web.Cookies;
using NExtra.Web.Testing;
using NSubstitute;
using NUnit.Framework;

namespace NExtra.Web.Tests.Cookies
{
    [TestFixture]
    public class DomainCookieInvalidatorBehavior
    {
        private ICookieInvalidator _cookieInvalidator;
        private IHttpCookieHandler _cookieHandler;
        private HttpContextBase _httpContext;
        private HttpRequestBase _httpRequest;
        private HttpResponseBase _httpResponse;
        private HttpCookie _customCookie1, _customCookie2;


        [SetUp]
        public void SetUp()
        {
            _customCookie1 = new HttpCookie("foo") { Value = "foo-value", Path = "/" };
            _customCookie2 = new HttpCookie("bar") { Value = "bar-value", Path = "/" };
            var requestCookies = new HttpCookieCollection {_customCookie1, _customCookie2};

            _httpRequest = new FakeHttpRequest("http://foo.bar", true);
            _httpResponse = new FakeHttpResponse();
            _httpContext = new FakeHttpContext(_httpRequest, _httpResponse);

            _cookieHandler = Substitute.For<IHttpCookieHandler>();
            _cookieHandler.GetRequestCookies().Returns(requestCookies);

            _cookieInvalidator = new DomainCookieInvalidator("foo.bar", _httpContext, _cookieHandler);
        }

        public DomainCookieInvalidator GetInvalidatorWithNonMatchingHost()
        {
            _httpRequest = new FakeHttpRequest("http://bar.foo", true);
            _httpContext = new FakeHttpContext(_httpRequest, _httpResponse);
            
            return new DomainCookieInvalidator("foo.bar", _httpContext, _cookieHandler);
        }


        [Test]
        public void InvalidateAllCookies_ShouldNotInvalidateAnyCookieForNonMatchingHost()
        {
            var invalidator = GetInvalidatorWithNonMatchingHost();

            invalidator.InvalidateAllCookies();

            _cookieHandler.DidNotReceive().InvalidateCookie(Arg.Any<string>());
        }

        [Test]
        public void InvalidateAllCookies_ShouldInvalidateAllRequestCookiesForMatchingHost()
        {
            _cookieInvalidator.InvalidateAllCookies();

            _cookieHandler.Received().InvalidateCookie("foo");
            _cookieHandler.Received().InvalidateCookie("bar");
        }

        [Test]
        public void InvalidateCookie_ShouldNotInvalidateCookieForNonMatchingHost()
        {
            var invalidator = GetInvalidatorWithNonMatchingHost();

            invalidator.InvalidateCookie("foo");

            _cookieHandler.DidNotReceive().InvalidateCookie(Arg.Any<string>());
        }

        [Test]
        public void InvalidateCookie_ShouldInvalidateCookieForMatchingHost()
        {
            _cookieInvalidator.InvalidateCookie("foo");

            _cookieHandler.Received().InvalidateCookie("foo");
        }
    }
}