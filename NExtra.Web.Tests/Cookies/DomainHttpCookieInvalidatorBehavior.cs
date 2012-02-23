using System.Web;
using NExtra.Web.Cookies;
using NExtra.Web.Testing;
using NSubstitute;
using NUnit.Framework;

namespace NExtra.Web.Tests.Cookies
{
    [TestFixture]
    public class DomainHttpCookieInvalidatorBehavior
    {
        private IHttpCookieInvalidator cookieInvalidator;
        private IHttpCookieHandler cookieHandler;
        private HttpContextBase httpContext;
        private HttpRequestBase httpRequest;
        private HttpResponseBase httpResponse;
        private HttpCookie customCookie1, customCookie2;


        [SetUp]
        public void SetUp()
        {
            customCookie1 = new HttpCookie("foo") { Value = "foo-value", Path = "/" };
            customCookie2 = new HttpCookie("bar") { Value = "bar-value", Path = "/" };
            var requestCookies = new HttpCookieCollection {customCookie1, customCookie2};

            httpRequest = new FakeHttpRequest("http://foo.bar", true);
            httpResponse = new FakeHttpResponse();
            httpContext = new FakeHttpContext(httpRequest, httpResponse);

            cookieHandler = Substitute.For<IHttpCookieHandler>();
            cookieHandler.GetRequestCookies().Returns(requestCookies);

            cookieInvalidator = new DomainHttpCookieInvalidator("foo.bar", httpContext, cookieHandler);
        }

        public DomainHttpCookieInvalidator GetInvalidatorWithNonMatchingHost()
        {
            httpRequest = new FakeHttpRequest("http://bar.foo", true);
            httpContext = new FakeHttpContext(httpRequest, httpResponse);
            
            return new DomainHttpCookieInvalidator("foo.bar", httpContext, cookieHandler);
        }


        [Test]
        public void InvalidateAllCookies_ShouldNotInvalidateAnyCookieForNonMatchingHost()
        {
            var invalidator = GetInvalidatorWithNonMatchingHost();

            invalidator.InvalidateAllCookies();

            cookieHandler.DidNotReceive().InvalidateCookie(Arg.Any<string>());
        }

        [Test]
        public void InvalidateAllCookies_ShouldInvalidateAllRequestCookiesForMatchingHost()
        {
            cookieInvalidator.InvalidateAllCookies();

            cookieHandler.Received().InvalidateCookie("foo");
            cookieHandler.Received().InvalidateCookie("bar");
        }

        [Test]
        public void InvalidateCookie_ShouldNotInvalidateCookieForNonMatchingHost()
        {
            var invalidator = GetInvalidatorWithNonMatchingHost();

            invalidator.InvalidateCookie("foo");

            cookieHandler.DidNotReceive().InvalidateCookie(Arg.Any<string>());
        }

        [Test]
        public void InvalidateCookie_ShouldInvalidateCookieForMatchingHost()
        {
            cookieInvalidator.InvalidateCookie("foo");

            cookieHandler.Received().InvalidateCookie("foo");
        }


        [Test]
        public void IsValidContext_ShouldReturnFalseForNullContext()
        {
            Assert.That(DomainHttpCookieInvalidator.IsValidContext(null, "foo.bar"), Is.False);
        }

        [Test]
        public void IsValidContext_ShouldReturnFalseForNullRequest()
        {
            httpContext = new FakeHttpContext(null, httpResponse);

            Assert.That(DomainHttpCookieInvalidator.IsValidContext(httpContext, "foo.bar"), Is.False);
        }

        [Test]
        public void IsValidContext_ShouldReturnFalseForNonMatchingHost()
        {
            httpRequest = new FakeHttpRequest("http://bar.foo", true);
            httpContext = new FakeHttpContext(httpRequest, httpResponse);

            Assert.That(DomainHttpCookieInvalidator.IsValidContext(httpContext, "foo.bar"), Is.False);
        }

        [Test]
        public void IsValidContext_ShouldReturnTrueForMatchingHost()
        {
            Assert.That(DomainHttpCookieInvalidator.IsValidContext(httpContext, "foo.bar"), Is.False);
        }
    }
}