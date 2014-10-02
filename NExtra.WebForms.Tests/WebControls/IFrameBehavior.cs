using System.IO;
using System.Web.UI;
using NExtra.WebForms.WebControls;
using NUnit.Framework;

namespace NExtra.WebForms.Tests.WebControls
{
    [TestFixture]
    public class IFrameControlBehavior
    {
        private IFrameTestClass _iframe;


        [SetUp]
        public void SetUp()
        {
            _iframe = new IFrameTestClass();
        }


        [Test]
        public void FrameBorder_ShouldGetSetValue()
        {
            Assert.That(_iframe.FrameBorder, Is.Null);
            _iframe.FrameBorder = null;
            Assert.That(_iframe.FrameBorder, Is.Null);
            _iframe.FrameBorder = 5;
            Assert.That(_iframe.FrameBorder, Is.EqualTo(5));
        }

        [Test]
        public void Html_ShouldGetSetValue()
        {
            Assert.That(_iframe.Html, Is.EqualTo(""));
            _iframe.Html = "<html></html>";
            Assert.That(_iframe.Html, Is.EqualTo("<html></html>"));
        }

        [Test]
        public void MarginHeight_ShouldGetSetValue()
        {
            Assert.That(_iframe.MarginHeight, Is.Null);
            _iframe.MarginHeight = null;
            Assert.That(_iframe.MarginHeight, Is.Null);
            _iframe.MarginHeight = 5;
            Assert.That(_iframe.MarginHeight, Is.EqualTo(5));
        }

        [Test]
        public void MarginWidth_ShouldGetSetValue()
        {
            Assert.That(_iframe.MarginWidth, Is.Null);
            _iframe.MarginWidth = null;
            Assert.That(_iframe.MarginWidth, Is.Null);
            _iframe.MarginWidth = 5;
            Assert.That(_iframe.MarginWidth, Is.EqualTo(5));
        }

        [Test]
        public void Scrolling_ShouldGetSetValue()
        {
            Assert.That(_iframe.Scrolling, Is.Null);
            _iframe.Scrolling = null;
            Assert.That(_iframe.Scrolling, Is.Null);
            _iframe.Scrolling = true;
            Assert.That(_iframe.Scrolling, Is.True);
        }

        [Test]
        public void Src_ShouldGetSetValue()
        {
            Assert.That(_iframe.Src, Is.EqualTo(""));
            _iframe.Src = "http://www.saidi.se";
            Assert.That(_iframe.Src, Is.EqualTo("http://www.saidi.se"));
        }

        [Test]
        public void Style_ShouldGetSetValue()
        {
            Assert.That(_iframe.Style, Is.EqualTo(""));
            _iframe.Style = "width: 100%";
            Assert.That(_iframe.Style, Is.EqualTo("width: 100%"));
        }

        [Test]
        public void Transparent_ShouldGetSetValue()
        {
            Assert.That(_iframe.Transparent, Is.Null);
            _iframe.Transparent = null;
            Assert.That(_iframe.Transparent, Is.Null);
            _iframe.Transparent = true;
            Assert.That(_iframe.Transparent, Is.True);
        }


        [Test]
        public void GetHtml_ShouldGenerateStringWithoutProperties()
        {
            const string expectedValue = "<iframe frameborder=\"0\"></iframe>";

            Assert.That(_iframe.TestGetHtml(), Is.EqualTo(expectedValue));
        }

        [Test]
        public void GetHtml_ShouldGenerateStringWithProperties()
        {
            _iframe.ID = "foo";
            _iframe.Src = "http://www.saidi.se";
            _iframe.CssClass = "bar";
            _iframe.Style = "background: red";
            _iframe.Width = 1;
            _iframe.Height = 2;
            _iframe.MarginWidth = 3;
            _iframe.MarginHeight = 4;
            _iframe.Scrolling = true;
            _iframe.FrameBorder = 5;
            _iframe.Transparent = true;

            _iframe.Html = "<html></html>";

            const string expectedValue = "<iframe id=\"foo\" src=\"http://www.saidi.se\" class=\"bar\" style=\"background: red\" width=\"1\" height=\"2\" marginWidth=\"3\" marginHeight=\"4\" scrolling=\"yes\" allowtransparency=\"true\" frameborder=\"5\"></iframe>";

            Assert.That(_iframe.TestGetHtml(), Is.EqualTo(expectedValue));
        }

        [Test]
        public void GetHtmlScript_ShouldReturnEmptyStringForNoHtml()
        {
            const string expectedValue = "";

            Assert.That(_iframe.TestGetHtmlScript(), Is.EqualTo(expectedValue));
        }

        [Test]
        public void GetHtmlScript_ShouldReturnNonEmptyStringForHtml()
        {
            _iframe.Html = "foo bar";
            var result = _iframe.TestGetHtmlScript();

            Assert.That(result.Contains("var tmpObj"), Is.True);
            Assert.That(result.Contains("doc.open();"), Is.True);
            Assert.That(result.Contains("doc.write"), Is.True);
            Assert.That(result.Contains("doc.close();"), Is.True);
        }

        [Test]
        public void GetHtmlScriptHtml_ShouldReturnEmptyStringForNoHtml()
        {
            const string expectedValue = "";

            Assert.That(_iframe.TestGetHtmlScriptHtml(), Is.EqualTo(expectedValue));
        }

        [Test]
        public void GetHtmlScriptHtml_ShouldAddBodyTagIfMissing()
        {
            const string html = "<div>foo bar</div>";
            _iframe.Html = html;

            Assert.That(_iframe.TestGetHtmlScriptHtml(), Is.EqualTo("<body>" + html + "</body>"));
        }

        [Test]
        public void GetHtmlScriptHtml_ShouldNotAddBodyTagIfExisting()
        {
            const string html = "<body><div>foo bar</div></body>";
            _iframe.Html = html;

            Assert.That(_iframe.TestGetHtmlScriptHtml(), Is.EqualTo(html));
        }

        [Test]
        public void GetHtmlScriptHtml_ShouldAddScriptTagForTransparentIfram()
        {
            const string html = "<div>foo bar</div>";
            _iframe.Html = html;
            _iframe.Transparent = true;

            Assert.That(_iframe.TestGetHtmlScriptHtml().Contains("<style type=\"text/css\">body { background: transparent; }</style>"), Is.True);
        }

        [Test]
        public void Render_ShouldSwallowSpan()
        {
            var stringWriter = new StringWriter();
            var htmlTextWriter = new HtmlTextWriter(stringWriter);

            _iframe.TestRender(htmlTextWriter);
        }
    }

    class IFrameTestClass : IFrame
    {
        public string TestGetHtml() { return GetHtml(); }
        public string TestGetHtmlScript() { return GetHtmlScript(); }
        public string TestGetHtmlScriptHtml() { return GetHtmlScriptHtml(); }
        public void TestRender(HtmlTextWriter writer) { Render(writer); }
    }
}
