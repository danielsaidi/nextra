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
        private IHttpCookieHandler _cookieHandler;
        private HttpContextBase _httpContext;
        private HttpRequestBase _httpRequest;
        private HttpResponseBase _httpResponse;
        private HttpCookie _customCookie1, _customCookie2;


        [SetUp]
        public void SetUp()
        {
            _customCookie1 = new HttpCookie("foo") { Value = "bar", Path = "/" };
            _customCookie2 = new HttpCookie("foo") { Value = "bar2", Path = "/" };

            _httpRequest = new FakeHttpRequest("http://foo.bar", true);
            _httpResponse = new FakeHttpResponse();
            _httpContext = new FakeHttpContext(_httpRequest, _httpResponse);

            _cookieHandler = new HttpContextCookieHandler(_httpContext);
        }


        [Test]
        public void Constructor_ShouldSupportCustomContext()
        {
            _cookieHandler = new HttpContextCookieHandler(_httpContext);
            
            Assert.That(_cookieHandler, Is.Not.Null);
        }


        [Test]
        public void AddCookie_ShouldMakeCookieInstantlyAvailable()
        {
            _cookieHandler.AddCookie(_customCookie1);

            Assert.That(_cookieHandler.GetCookie("foo"), Is.EqualTo(_customCookie1));
        }

        [Test]
        public void AddCookie_ShouldOverwriteExistingCookie()
        {
            _cookieHandler.AddCookie(_customCookie1);
            _cookieHandler.AddCookie(_customCookie2);

            Assert.That(_cookieHandler.GetCookie("foo"), Is.EqualTo(_customCookie2));
        }

        [Test]
        public void CookieExists_ShouldReturnFalseForNonExistingCookie()
        {
            Assert.That(_cookieHandler.CookieExists("foo"), Is.False);
        }

        [Test]
        public void CookieExists_ShouldReturnTrueForExistingCookie()
        {
            _cookieHandler.SetCookieValue("foo", "bar");

            Assert.That(_cookieHandler.CookieExists("foo"), Is.True);
        }

        [Test]
        public void GetCookie_ShouldReturnCookieAddedWithAddCookie()
        {
            _cookieHandler.AddCookie(_customCookie1);

            var cookie = _cookieHandler.GetCookie("foo");

            Assert.That(cookie, Is.EqualTo(_customCookie1));
        }

        [Test]
        public void GetCookie_ShouldReturnCookieAddedWithSetCookieValue()
        {
            _cookieHandler.SetCookieValue("foo", "bar");

            var cookie = _cookieHandler.GetCookie("foo");

            Assert.That(cookie.Value, Is.EqualTo("\"bar\""));
        }

        [Test]
        public void GetCookieValue_ShouldReturnNulForNonExistingCookie()
        {
            var value = _cookieHandler.GetCookieValue("foo");

            Assert.That(value, Is.Null);
        }

        [Test]
        public void GetCookieValue_ShouldReturnStringValue()
        {
            _cookieHandler.SetCookieValue("foo", "bar");

            var value = _cookieHandler.GetCookieValue("foo");

            Assert.That(value, Is.EqualTo("bar"));
        }

        [Test]
        public void GetCookieValue_ShouldReturnComplexValue()
        {
            var value = new ComplexCookieValue("foo", true, 15);
            _cookieHandler.SetCookieValue("foo", value);

            var result = _cookieHandler.GetCookieValue<ComplexCookieValue>("foo");

            Assert.That(result.Name, Is.EqualTo("foo"));
            Assert.That(result.Valid, Is.EqualTo(true));
            Assert.That(result.Length, Is.EqualTo(15));
        }

        [Test]
        public void GetRequestCookies_ShouldReturnEmptyCollectionForNoExistingCookies()
        {
            var cookies = _cookieHandler.GetRequestCookies();

            Assert.That(cookies.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetRequestCookies_ShouldReturnCollectionAllExistingCookies()
        {
            _cookieHandler.SetCookieValue("foo", "1");
            _cookieHandler.SetCookieValue("bar", "2");

            var cookies = _cookieHandler.GetRequestCookies();

            Assert.That(cookies.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetResponseCookies_ShouldReturnEmptyCollectionForNoExistingCookies()
        {
            var cookies = _cookieHandler.GetResponseCookies();

            Assert.That(cookies.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetResponseCookies_ShouldReturnCollectionAllExistingCookies()
        {
            _cookieHandler.SetCookieValue("foo", "1");
            _cookieHandler.SetCookieValue("bar", "2");

            var cookies = _cookieHandler.GetResponseCookies();

            Assert.That(cookies.Count, Is.EqualTo(2));
        }

        [Test]
        public void RemoveCookie_ShouldResetCookieValue()
        {
            _cookieHandler.SetCookieValue("foo", "bar");
            _cookieHandler.InvalidateCookie("foo");

            var value = _cookieHandler.GetCookieValue("foo");

            Assert.That(value, Is.EqualTo(string.Empty));
        }

        [Test]
        public void RemoveCookie_ShouldSetCookieToExpired()
        {
            _cookieHandler.SetCookieValue("foo", "bar");
            _cookieHandler.InvalidateCookie("foo");

            var cookie = _cookieHandler.GetCookie("foo");

            Assert.That(cookie.Expires, Is.EqualTo(DateTime.MinValue));
        }

        [Test]
        public void SetCookieValue_ShouldSetStringValue()
        {
            _cookieHandler.SetCookieValue("foo", "bar");

            var value = _cookieHandler.GetCookieValue("foo");

            Assert.That(value, Is.EqualTo("bar"));
        }

        [Test]
        public void SetCookieValue_ShouldSetStringValueWithTimeout()
        {
            _cookieHandler.SetCookieValue("foo", "bar", DateTime.Now.AddDays(-1));

            var value = _cookieHandler.GetCookie("foo");

            Assert.That(value.Expires.Date, Is.EqualTo(DateTime.Now.Date.AddDays(-1)));
        }

        [Test]
        public void SetCookieValue_ShouldSetComplexValue()
        {
            var value = new ComplexCookieValue("foo", true, 15);
            _cookieHandler.SetCookieValue("foo", value);

            var result = _cookieHandler.GetCookieValue<ComplexCookieValue>("foo");

            Assert.That(result.Name, Is.EqualTo("foo"));
            Assert.That(result.Valid, Is.EqualTo(true));
            Assert.That(result.Length, Is.EqualTo(15));
        }

        [Test]
        public void SetCookieValue_ShouldSetComplexValueWithTimeout()
        {
            var value = new ComplexCookieValue("foo", true, 15);
            _cookieHandler.SetCookieValue("foo", value, DateTime.Now.AddDays(-1));

            var cookie = _cookieHandler.GetCookie("foo");

            Assert.That(cookie.Expires.Date, Is.EqualTo(DateTime.Now.Date.AddDays(-1)));
        }
    }


    internal class ComplexCookieValue
    {
        public readonly string Name;
        public readonly bool Valid;
        public readonly int Length;

        public ComplexCookieValue() {}

        public ComplexCookieValue(string name, bool valid, int length)
        {
            Name = name;
            Valid = valid;
            Length = length;
        }
    }
}