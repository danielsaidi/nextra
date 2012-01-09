using NExtra.Web.Html;
using NUnit.Framework;

namespace NExtra.Web.Tests.Html
{
    [TestFixture]
    public class HtmlReplacerBehavior
    {
        private HtmlReplacer replacer;


        [SetUp]
        public void SetUp()
        {
            replacer = new HtmlReplacer();
        }


        [Test]
        public void ReplaceHtmlElement_ShoulNotAffectNonHtmlString()
        {
            const string str = "foo bar";

            Assert.That(replacer.ReplaceHtmlElement(str, "p", "div"), Is.EqualTo(str));
        }

        [Test]
        public void ReplaceHtmlElement_ShoulNotAffectIrrelevantElements()
        {
            const string str = "f<div class=\"foo\">oo ba</div>r";

            Assert.That(replacer.ReplaceHtmlElement(str, "p", "div"), Is.EqualTo(str));
        }

        [Test]
        public void ReplaceHtmlElement_ShoulAffectRelevantElement()
        {
            const string str = "f<p class=\"foo\">oo ba</p>r";

            Assert.That(replacer.ReplaceHtmlElement(str, "p", "div"), Is.EqualTo("f<div class=\"foo\">oo ba</div>r"));
        }
    }
}
