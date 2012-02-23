using System;
using System.Web;
using NExtra.Web.Cookies;
using NExtra.Web.Testing;
using NUnit.Framework;

namespace NExtra.Web.Tests.Cookies
{
    [TestFixture]
    public class HttpContextCookieHandlerBehavior
    {
        private IHttpCookieHandler cookieHandler;
        private HttpContextBase httpContext;
        private HttpRequestBase httpRequest;
        private HttpResponseBase httpResponse;
        private HttpCookie customCookie1, customCookie2;


        [SetUp]
        public void SetUp()
        {
            customCookie1 = new HttpCookie("foo") { Value = "bar", Path = "/" };
            customCookie2 = new HttpCookie("foo") { Value = "bar2", Path = "/" };

            httpRequest = new FakeHttpRequest("http://foo.bar", true);
            httpResponse = new FakeHttpResponse();
            httpContext = new FakeHttpContext(httpRequest, httpResponse);

            cookieHandler = new HttpContextCookieHandler(httpContext);
        }


        [Test]
        public void Constructor_ShouldSupportCustomContext()
        {
            cookieHandler = new HttpContextCookieHandler(httpContext);
            
            Assert.That(cookieHandler, Is.Not.Null);
        }


        [Test]
        public void AddCookie_ShouldMakeCookieInstantlyAvailable()
        {
            cookieHandler.AddCookie(customCookie1);

            Assert.That(cookieHandler.GetCookie("foo"), Is.EqualTo(customCookie1));
        }

        [Test]
        public void AddCookie_ShouldOverwriteExistingCookie()
        {
            cookieHandler.AddCookie(customCookie1);
            cookieHandler.AddCookie(customCookie2);

            Assert.That(cookieHandler.GetCookie("foo"), Is.EqualTo(customCookie2));
        }

        [Test]
        public void CookieExists_ShouldReturnFalseForNonExistingCookie()
        {
            Assert.That(cookieHandler.CookieExists("foo"), Is.False);
        }

        [Test]
        public void CookieExists_ShouldReturnTrueForExistingCookie()
        {
            cookieHandler.SetCookieValue("foo", "bar");

            Assert.That(cookieHandler.CookieExists("foo"), Is.True);
        }

        [Test]
        public void GetCookie_ShouldReturnCookieAddedWithAddCookie()
        {
            cookieHandler.AddCookie(customCookie1);

            var cookie = cookieHandler.GetCookie("foo");

            Assert.That(cookie, Is.EqualTo(customCookie1));
        }

        [Test]
        public void GetCookie_ShouldReturnCookieAddedWithSetCookieValue()
        {
            cookieHandler.SetCookieValue("foo", "bar");

            var cookie = cookieHandler.GetCookie("foo");

            Assert.That(cookie.Value, Is.EqualTo("\"bar\""));
        }

        [Test]
        public void GetCookieValue_ShouldReturnNulForNonExistingCookie()
        {
            var value = cookieHandler.GetCookieValue("foo");

            Assert.That(value, Is.Null);
        }

        [Test]
        public void GetCookieValue_ShouldReturnStringValue()
        {
            cookieHandler.SetCookieValue("foo", "bar");

            var value = cookieHandler.GetCookieValue("foo");

            Assert.That(value, Is.EqualTo("bar"));
        }

        [Test]
        public void GetCookieValue_ShouldReturnComplexValue()
        {
            var value = new ComplexCookieValue("foo", true, 15);
            cookieHandler.SetCookieValue("foo", value);

            var result = cookieHandler.GetCookieValue<ComplexCookieValue>("foo");

            Assert.That(result.name, Is.EqualTo("foo"));
            Assert.That(result.valid, Is.EqualTo(true));
            Assert.That(result.length, Is.EqualTo(15));
        }

        [Test]
        public void GetRequestCookies_ShouldReturnEmptyCollectionForNoExistingCookies()
        {
            var cookies = cookieHandler.GetRequestCookies();

            Assert.That(cookies.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetRequestCookies_ShouldReturnCollectionAllExistingCookies()
        {
            cookieHandler.SetCookieValue("foo", "1");
            cookieHandler.SetCookieValue("bar", "2");

            var cookies = cookieHandler.GetRequestCookies();

            Assert.That(cookies.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetResponseCookies_ShouldReturnEmptyCollectionForNoExistingCookies()
        {
            var cookies = cookieHandler.GetResponseCookies();

            Assert.That(cookies.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetResponseCookies_ShouldReturnCollectionAllExistingCookies()
        {
            cookieHandler.SetCookieValue("foo", "1");
            cookieHandler.SetCookieValue("bar", "2");

            var cookies = cookieHandler.GetResponseCookies();

            Assert.That(cookies.Count, Is.EqualTo(2));
        }

        [Test]
        public void RemoveCookie_ShouldResetCookieValue()
        {
            cookieHandler.SetCookieValue("foo", "bar");
            cookieHandler.InvalidateCookie("foo");

            var value = cookieHandler.GetCookieValue("foo");

            Assert.That(value, Is.EqualTo(string.Empty));
        }

        [Test]
        public void RemoveCookie_ShouldSetCookieToExpired()
        {
            cookieHandler.SetCookieValue("foo", "bar");
            cookieHandler.InvalidateCookie("foo");

            var cookie = cookieHandler.GetCookie("foo");

            Assert.That(cookie.Expires, Is.EqualTo(DateTime.MinValue));
        }

        [Test]
        public void SetCookieValue_ShouldSetStringValue()
        {
            cookieHandler.SetCookieValue("foo", "bar");

            var value = cookieHandler.GetCookieValue("foo");

            Assert.That(value, Is.EqualTo("bar"));
        }

        [Test]
        public void SetCookieValue_ShouldSetStringValueWithTimeout()
        {
            cookieHandler.SetCookieValue("foo", "bar", DateTime.Now.AddDays(-1));

            var value = cookieHandler.GetCookie("foo");

            Assert.That(value.Expires.Date, Is.EqualTo(DateTime.Now.Date.AddDays(-1)));
        }

        [Test]
        public void SetCookieValue_ShouldSetComplexValue()
        {
            var value = new ComplexCookieValue("foo", true, 15);
            cookieHandler.SetCookieValue("foo", value);

            var result = cookieHandler.GetCookieValue<ComplexCookieValue>("foo");

            Assert.That(result.name, Is.EqualTo("foo"));
            Assert.That(result.valid, Is.EqualTo(true));
            Assert.That(result.length, Is.EqualTo(15));
        }

        [Test]
        public void SetCookieValue_ShouldSetComplexValueWithTimeout()
        {
            var value = new ComplexCookieValue("foo", true, 15);
            cookieHandler.SetCookieValue("foo", value, DateTime.Now.AddDays(-1));

            var cookie = cookieHandler.GetCookie("foo");

            Assert.That(cookie.Expires.Date, Is.EqualTo(DateTime.Now.Date.AddDays(-1)));
        }
    }


    internal class ComplexCookieValue
    {
        public readonly string name;
        public readonly bool valid;
        public readonly int length;

        public ComplexCookieValue() {}

        public ComplexCookieValue(string name, bool valid, int length)
        {
            this.name = name;
            this.valid = valid;
            this.length = length;
        }
    }
}