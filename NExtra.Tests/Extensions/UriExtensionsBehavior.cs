using System;
using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class UriExtensionsBehavior
    {
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
    }
}