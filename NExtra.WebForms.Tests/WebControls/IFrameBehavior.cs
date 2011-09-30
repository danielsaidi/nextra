using System.IO;
using System.Web.UI;
using NExtra.WebForms.WebControls;
using NUnit.Framework;

namespace NExtra.WebForms.Tests.WebControls
{
    [TestFixture]
    public class IFrameControlBehavior
    {
        private IFrameTestClass iframe;


        [SetUp]
        public void SetUp()
        {
            iframe = new IFrameTestClass();
        }


        [Test]
        public void FrameBorder_ShouldGetSetValue()
        {
            Assert.That(iframe.FrameBorder, Is.Null);
            iframe.FrameBorder = null;
            Assert.That(iframe.FrameBorder, Is.Null);
            iframe.FrameBorder = 5;
            Assert.That(iframe.FrameBorder, Is.EqualTo(5));
        }

        [Test]
        public void Html_ShouldGetSetValue()
        {
            Assert.That(iframe.Html, Is.EqualTo(""));
            iframe.Html = "<html></html>";
            Assert.That(iframe.Html, Is.EqualTo("<html></html>"));
        }

        [Test]
        public void MarginHeight_ShouldGetSetValue()
        {
            Assert.That(iframe.MarginHeight, Is.Null);
            iframe.MarginHeight = null;
            Assert.That(iframe.MarginHeight, Is.Null);
            iframe.MarginHeight = 5;
            Assert.That(iframe.MarginHeight, Is.EqualTo(5));
        }

        [Test]
        public void MarginWidth_ShouldGetSetValue()
        {
            Assert.That(iframe.MarginWidth, Is.Null);
            iframe.MarginWidth = null;
            Assert.That(iframe.MarginWidth, Is.Null);
            iframe.MarginWidth = 5;
            Assert.That(iframe.MarginWidth, Is.EqualTo(5));
        }

        [Test]
        public void Scrolling_ShouldGetSetValue()
        {
            Assert.That(iframe.Scrolling, Is.Null);
            iframe.Scrolling = null;
            Assert.That(iframe.Scrolling, Is.Null);
            iframe.Scrolling = true;
            Assert.That(iframe.Scrolling, Is.True);
        }

        [Test]
        public void Src_ShouldGetSetValue()
        {
            Assert.That(iframe.Src, Is.EqualTo(""));
            iframe.Src = "http://www.saidi.se";
            Assert.That(iframe.Src, Is.EqualTo("http://www.saidi.se"));
        }

        [Test]
        public void Style_ShouldGetSetValue()
        {
            Assert.That(iframe.Style, Is.EqualTo(""));
            iframe.Style = "width: 100%";
            Assert.That(iframe.Style, Is.EqualTo("width: 100%"));
        }

        [Test]
        public void Transparent_ShouldGetSetValue()
        {
            Assert.That(iframe.Transparent, Is.Null);
            iframe.Transparent = null;
            Assert.That(iframe.Transparent, Is.Null);
            iframe.Transparent = true;
            Assert.That(iframe.Transparent, Is.True);
        }


        [Test]
        public void GetHtml_ShouldGenerateStringWithoutProperties()
        {
            const string expectedValue = "<iframe frameborder=\"0\"></iframe>";

            Assert.That(iframe.TestGetHtml(), Is.EqualTo(expectedValue));
        }

        [Test]
        public void GetHtml_ShouldGenerateStringWithProperties()
        {
            iframe.ID = "foo";
            iframe.Src = "http://www.saidi.se";
            iframe.CssClass = "bar";
            iframe.Style = "background: red";
            iframe.Width = 1;
            iframe.Height = 2;
            iframe.MarginWidth = 3;
            iframe.MarginHeight = 4;
            iframe.Scrolling = true;
            iframe.FrameBorder = 5;
            iframe.Transparent = true;

            iframe.Html = "<html></html>";

            const string expectedValue = "<iframe id=\"foo\" src=\"http://www.saidi.se\" class=\"bar\" style=\"background: red\" width=\"1\" height=\"2\" marginWidth=\"3\" marginHeight=\"4\" scrolling=\"yes\" allowtransparency=\"true\" frameborder=\"5\"></iframe>";

            Assert.That(iframe.TestGetHtml(), Is.EqualTo(expectedValue));
        }

        [Test]
        public void GetHtmlScript_ShouldReturnEmptyStringForNoHtml()
        {
            const string expectedValue = "";

            Assert.That(iframe.TestGetHtmlScript(), Is.EqualTo(expectedValue));
        }

        [Test]
        public void GetHtmlScript_ShouldReturnNonEmptyStringForHtml()
        {
            iframe.Html = "foo bar";
            var result = iframe.TestGetHtmlScript();

            Assert.That(result.Contains("var tmpObj"), Is.True);
            Assert.That(result.Contains("doc.open();"), Is.True);
            Assert.That(result.Contains("doc.write"), Is.True);
            Assert.That(result.Contains("doc.close();"), Is.True);
        }

        [Test]
        public void GetHtmlScriptHtml_ShouldReturnEmptyStringForNoHtml()
        {
            const string expectedValue = "";

            Assert.That(iframe.TestGetHtmlScriptHtml(), Is.EqualTo(expectedValue));
        }

        [Test]
        public void GetHtmlScriptHtml_ShouldAddBodyTagIfMissing()
        {
            const string html = "<div>foo bar</div>";
            iframe.Html = html;

            Assert.That(iframe.TestGetHtmlScriptHtml(), Is.EqualTo("<body>" + html + "</body>"));
        }

        [Test]
        public void GetHtmlScriptHtml_ShouldNotAddBodyTagIfExisting()
        {
            const string html = "<body><div>foo bar</div></body>";
            iframe.Html = html;

            Assert.That(iframe.TestGetHtmlScriptHtml(), Is.EqualTo(html));
        }

        [Test]
        public void GetHtmlScriptHtml_ShouldAddScriptTagForTransparentIfram()
        {
            const string html = "<div>foo bar</div>";
            iframe.Html = html;
            iframe.Transparent = true;

            Assert.That(iframe.TestGetHtmlScriptHtml().Contains("<style type=\"text/css\">body { background: transparent; }</style>"), Is.True);
        }

        [Test]
        public void Render_ShouldSwallowSpan()
        {
            var stringWriter = new StringWriter();
            var htmlTextWriter = new HtmlTextWriter(stringWriter);

            iframe.TestRender(htmlTextWriter);
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
