using System;
using System.Linq;
using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class Uri_ExtensionsBehavior
    {
        [Test]
        public void GetQueryParameter_ShouldReturnNullForNoParameters()
        {
            var uri = new Uri("http://www.foo.bar/index.htm");
            var result = uri.GetQueryParameter("foo");

            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void GetQueryParameter_ShouldReturnMatchForSingleParameter()
        {
            var uri = new Uri("http://www.foo.bar/index.htm?foo=bar");
            var result = uri.GetQueryParameter("foo");

            Assert.That(result, Is.EqualTo("bar"));
        }

        [Test]
        public void GetQueryParameter_ShouldReturnMatchForMultipleParameters()
        {
            var uri = new Uri("http://www.foo.bar/index.htm?foo=bar&bar=foo");
            var result = uri.GetQueryParameter("foo");

            Assert.That(result, Is.EqualTo("bar"));
        }

        [Test]
        public void GetQueryParameter_ShouldHandleBrokenParameter()
        {
            var uri = new Uri("http://www.foo.bar/index.htm?foo");
            var result = uri.GetQueryParameter("foo");

            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void GetQueryParameters_ShouldReturnEmptyDictionaryForNoParameters()
        {
            var uri = new Uri("http://www.foo.bar/index.htm");
            var result = uri.GetQueryParameters();

            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetQueryParameters_ShouldReturnOneElementDictionaryForSingleParameter()
        {
            var uri = new Uri("http://www.foo.bar/index.htm?foo=bar");
            var result = uri.GetQueryParameters();

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().Key, Is.EqualTo("foo"));
            Assert.That(result.First().Value, Is.EqualTo("bar"));
        }

        [Test]
        public void GetQueryParameters_ShouldReturnMultipleElementDictionaryForMultipleParameters()
        {
            var uri = new Uri("http://www.foo.bar/index.htm?foo=bar&bar=foo");
            var result = uri.GetQueryParameters().ToList();

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().Key, Is.EqualTo("foo"));
            Assert.That(result.First().Value, Is.EqualTo("bar"));
            Assert.That(result.Last().Key, Is.EqualTo("bar"));
            Assert.That(result.Last().Value, Is.EqualTo("foo"));
        }

        [Test]
        public void GetQueryParameters_ShouldHandleBrokenParameter()
        {
            var uri = new Uri("http://www.foo.bar/index.htm?foo=bar&bar=foo&broken");
            var result = uri.GetQueryParameters();

            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result.First().Key, Is.EqualTo("foo"));
            Assert.That(result.First().Value, Is.EqualTo("bar"));
            Assert.That(result.ElementAt(1).Key, Is.EqualTo("bar"));
            Assert.That(result.ElementAt(1).Value, Is.EqualTo("foo"));
            Assert.That(result.Last().Key, Is.EqualTo("broken"));
            Assert.That(result.Last().Value, Is.EqualTo(""));
        }


        [Test, ExpectedException(typeof(UriFormatException))]
        public void GetRootUri_ShouldFailForMissingScheme()
        {
            Assert.That(new Uri("www.google.com").GetRootUri(), Is.EqualTo("www.google.com"));
        }

        [Test]
        public void GetRootUri_ShouldHandleWebUrls()
        {
            Assert.That(new Uri("ftp://www.google.com").GetRootUri().ToString(), Is.EqualTo("ftp://www.google.com/"));
            Assert.That(new Uri("http://www.google.com").GetRootUri().ToString(), Is.EqualTo("http://www.google.com/"));
            Assert.That(new Uri("https://www.google.com").GetRootUri().ToString(), Is.EqualTo("https://www.google.com/"));
            Assert.That(new Uri("http://www.google.com/").GetRootUri().ToString(), Is.EqualTo("http://www.google.com/"));
            Assert.That(new Uri("http://www.google.com/foo/bar?foo=bar").GetRootUri().ToString(), Is.EqualTo("http://www.google.com/"));
            Assert.That(new Uri("http://www.google.com/foo/bar:8080?foo=bar").GetRootUri().ToString(), Is.EqualTo("http://www.google.com/"));
        }

        [Test]
        public void SetQueryParameter_ShouldAddQueryStringToQuerylessUri()
        {
            var uri = new Uri("http://www.foo.bar/index.htm");
            var result = uri.SetQueryParameter("key", "value");

            Assert.That(result.ToString(), Is.EqualTo("http://www.foo.bar/index.htm?key=value"));
        }

        [Test]
        public void SetQueryParameter_ShouldAddQueryStringToUriWithQueryParameters()
        {
            var uri = new Uri("http://www.foo.bar/index.htm?foo=bar");
            var result = uri.SetQueryParameter("key", "value");

            Assert.That(result.ToString(), Is.EqualTo("http://www.foo.bar/index.htm?foo=bar&key=value"));
        }

        [Test]
        public void SetQueryParameter_ShouldReplaceExistingQueryParameter()
        {
            var uri = new Uri("http://www.foo.bar/index.htm?key=value1");
            var result = uri.SetQueryParameter("key", "value2");

            Assert.That(result.ToString(), Is.EqualTo("http://www.foo.bar/index.htm?key=value2"));
        }
    }
}