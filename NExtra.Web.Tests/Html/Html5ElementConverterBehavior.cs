using NExtra.Web.Html;
using NUnit.Framework;

namespace NExtra.Web.Tests.Html
{
    [TestFixture]
    public class Html5ElementConverterBehavior
    {
        private Html5ElementConverter converter;


        [SetUp]
        public void SetUp()
        {
            converter = new Html5ElementConverter();
        }


        [Test]
        public void ConvertHtml5Elements_ShouldNotConvertNonHtml5String()
        {
            Assert.That(converter.ConvertHtml("Foo Bar"), Is.EqualTo("Foo Bar"));
        }

        [Test]
        public void ConvertHtml5Elements_ShouldConvertHtml5StringToCssElements()
        {
            Assert.That(converter.ConvertHtml("<address>foo</address>"), Is.EqualTo("<span class=\"address\">foo</span>"));
            Assert.That(converter.ConvertHtml("<time>foo</time>"), Is.EqualTo("<span class=\"time\">foo</span>"));

            Assert.That(converter.ConvertHtml("<nav>foo</nav>"), Is.EqualTo("<div class=\"nav\">foo</div>"));
            Assert.That(converter.ConvertHtml("<section>foo</section>"), Is.EqualTo("<div class=\"section\">foo</div>"));
            Assert.That(converter.ConvertHtml("<header>foo</header>"), Is.EqualTo("<div class=\"header\">foo</div>"));
            Assert.That(converter.ConvertHtml("<aside>foo</aside>"), Is.EqualTo("<div class=\"aside\">foo</div>"));
            Assert.That(converter.ConvertHtml("<footer>foo</footer>"), Is.EqualTo("<div class=\"footer\">foo</div>"));
            Assert.That(converter.ConvertHtml("<article>foo</article>"), Is.EqualTo("<div class=\"article\">foo</div>"));
            Assert.That(converter.ConvertHtml("<article>foo</article>"), Is.EqualTo("<div class=\"article\">foo</div>"));
        }
    }
}
