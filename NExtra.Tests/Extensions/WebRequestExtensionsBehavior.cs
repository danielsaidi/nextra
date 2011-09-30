using System.Net;
using NUnit.Framework;
using NExtra.Extensions;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class WebRequestExtensionsBehavior
    {
        private WebRequest obj;


        [SetUp]
        public void SetUp()
        {
            obj = WebRequest.Create("http://www.foo.bar/test");
        }


        [Test]
        public void AdjustContent_ShouldRemoveLineFeeds()
        {
            const string content = "foo\rbar\nfoo";

            Assert.That(obj.AdjustContent(content), Is.EqualTo("foobarfoo"));
        }


        [Test]
        public void AdjustContent_ShouldAdjustAbsoluteSrc()
        {
            const string content = "<img src=\"/img/foo.bar\" />";

            Assert.That(obj.AdjustContent(content), Is.EqualTo("<img src=\"http://www.foo.bar/img/foo.bar\" />"));
        }

        [Test]
        public void AdjustContent_ShouldAdjustAbsoluteHref()
        {
            const string content = "<a href=\"/img/foo.bar\" />";

            Assert.That(obj.AdjustContent(content), Is.EqualTo("<a href=\"http://www.foo.bar/img/foo.bar\" />"));
        }
    }
}