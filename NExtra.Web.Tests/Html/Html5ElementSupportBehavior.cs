using System;
using NExtra.Web.Html;
using NUnit.Framework;

namespace NExtra.Web.Tests.Html
{
    [TestFixture]
    public class Html5ElementSupportBehavior
    {
        private Html5ElementSupportEvaluator htmlElementSupportEvaluator;


        [SetUp]
        public void SetUp()
        {
            htmlElementSupportEvaluator = new Html5ElementSupportEvaluator();
        }


        [Test]
        public void DetermineBrowserHtml5Support_ShouldReturnFalseForUnsupportedIE()
        {
            Assert.That(htmlElementSupportEvaluator.HasHtml5ElementSupport("IE", new Version(8, 9, 9, 9)), Is.False);
            Assert.That(htmlElementSupportEvaluator.HasHtml5ElementSupport("IE", new Version(8, 0, 0, 0)), Is.False);
        }

        [Test]
        public void DetermineBrowserHtml5Support_ShouldReturnTrueForSupportedIE()
        {
            Assert.That(htmlElementSupportEvaluator.HasHtml5ElementSupport("IE", new Version(9, 0, 0, 0)), Is.True);
        }

        [Test]
        public void DetermineBrowserHtml5Support_ShouldReturnTrueForAllOtherBrowsers__TODO()
        {
            Assert.That(htmlElementSupportEvaluator.HasHtml5ElementSupport("Firefox", new Version(9, 0, 0, 0)), Is.True);
            Assert.That(htmlElementSupportEvaluator.HasHtml5ElementSupport("Opera", new Version(1, 0, 0, 0)), Is.True);
            Assert.That(htmlElementSupportEvaluator.HasHtml5ElementSupport("Chrome", new Version(24, 0, 0, 0)), Is.True);
        }
    }
}
