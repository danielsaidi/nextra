using NExtra.Url;
using NUnit.Framework;

namespace NExtra.Tests.Url
{
    [TestFixture]
    public class StringUrlifierBehavior
    {
        private IUrlifier<string> _urlifier;


        [SetUp]
        public void Setup()
        {
            _urlifier = new StringUrlifier();
        }


        [Test]
        [TestCase("foo")]
        [TestCase("bar")]
        public void Urlify_ShouldNotAffectValidString(string url)
        {
            Assert.That(_urlifier.Urlify(url), Is.EqualTo(url));
        }

        [Test]
        [TestCase("FOO")]
        [TestCase("BaR")]
        public void Urlify_ShouldAffectUpperCaseString(string url)
        {
            Assert.That(_urlifier.Urlify(url), Is.EqualTo(url.ToLower()));
        }

        [Test]
        [TestCase("foo")]
        [TestCase("bar")]
        public void Urlify_ShouldAffectInternationalString(string url)
        {
            Assert.That(_urlifier.Urlify(url), Is.EqualTo(url));
        }

        [Test]
        [TestCase("foo bar", "foo-bar")]
        public void Urlify_ShouldReplaceSpaceWithDash(string url, string expected)
        {
            Assert.That(_urlifier.Urlify(url), Is.EqualTo(expected));
        }
    }
}
