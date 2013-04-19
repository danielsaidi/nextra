using NExtra.Web.Html;
using NUnit.Framework;

namespace NExtra.Web.Tests.Html
{
    [TestFixture]
    public class HtmlRemoverBehavior
    {
        private HtmlRemover remover;


        [SetUp]
        public void SetUp()
        {
            remover = new HtmlRemover();
        }


        [Test]
        public void RemoveHtml_ShouldNotAffectNonHtmlString()
        {
            const string str = "foo bar";

            Assert.That(remover.RemoveHtml(str), Is.EqualTo(str));
        }

        [Test]
        public void RemoveHtml_ShoulAffectHtmlString()
        {
            const string str = "foo<html><body><div>bar</div></body></html>foo";

            Assert.That(remover.RemoveHtml(str), Is.EqualTo("foobarfoo"));
        }

        [Test]
        public void RemoveHtmlElement_ShouldNotAffectNonHtmlString()
        {
            const string str = "foo bar";

            Assert.That(remover.RemoveHtmlElement(str, "div"), Is.EqualTo(str));
        }

        [Test]
        public void RemoveHtmlElement_ShoulNotAffectIrrelevantElements()
        {
            const string str = "f<div class=\"foo\">oo ba</div>r<span></span>";

            Assert.That(remover.RemoveHtmlElement(str, "p"), Is.EqualTo(str));
        }

        [Test]
        public void RemoveHtmlElement_ShoulAffectHtmlString()
        {
            const string str = "f<div class=\"foo\">oo ba</div>r<span></span>";

            Assert.That(remover.RemoveHtmlElement(str, "div"), Is.EqualTo("foo bar<span></span>"));
        }

        [Test]
        public void RemoveHtmlElements_ShouldNotAffectNonHtmlString()
        {
            const string str = "foo bar";

            Assert.That(remover.RemoveHtmlElements(str, new[] { "div", "span" }), Is.EqualTo(str));
        }

        [Test]
        public void RemoveHtmlElements_ShoulNotAffectIrrelevantElements()
        {
            const string str = "f<div class=\"foo\">oo ba</div>r<span></span>";

            Assert.That(remover.RemoveHtmlElements(str, new[] { "div", "span" }), Is.EqualTo("foo bar"));
        }

        [Test]
        public void RemoveHtmlTableElements_ShouldNotAffectNonHtmlString()
        {
            const string str = "foo bar";

            Assert.That(remover.RemoveHtmlTableElements(str), Is.EqualTo(str));
        }

        [Test]
        public void RemoveHtmlTableElements_ShoulAffectHtmlString()
        {
            const string str = "f<table><tr><thead></thead><tbody></tbody><td>oo</td><td class=\"foo\">ba</td></tr></table>r";

            Assert.That(remover.RemoveHtmlTableElements(str), Is.EqualTo("foobar"));
        }
    }
}
