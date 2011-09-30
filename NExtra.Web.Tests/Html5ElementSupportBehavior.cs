using System;
using NUnit.Framework;

namespace NExtra.Web.Tests
{
    [TestFixture]
    public class Html5ElementSupportBehavior
    {
        private Html5ElementSupport htmlElementSupport;


        [SetUp]
        public void SetUp()
        {
            htmlElementSupport = new Html5ElementSupport();
        }


        [Test]
        public void DetermineBrowserHtml5Support_ShouldReturnFalseForUnsupportedIE()
        {
            Assert.That(htmlElementSupport.HasHtml5ElementSupport("IE", new Version(8, 9, 9, 9)), Is.False);
            Assert.That(htmlElementSupport.HasHtml5ElementSupport("IE", new Version(8, 0, 0, 0)), Is.False);
        }

        [Test]
        public void DetermineBrowserHtml5Support_ShouldReturnTrueForSupportedIE()
        {
            Assert.That(htmlElementSupport.HasHtml5ElementSupport("IE", new Version(9, 0, 0, 0)), Is.True);
        }

        [Test]
        public void DetermineBrowserHtml5Support_ShouldReturnTrueForAllOtherBrowsers__TODO()
        {
            Assert.That(htmlElementSupport.HasHtml5ElementSupport("Firefox", new Version(9, 0, 0, 0)), Is.True);
            Assert.That(htmlElementSupport.HasHtml5ElementSupport("Opera", new Version(1, 0, 0, 0)), Is.True);
            Assert.That(htmlElementSupport.HasHtml5ElementSupport("Chrome", new Version(24, 0, 0, 0)), Is.True);
        }
    }
}
