using NUnit.Framework;

namespace NExtra.Mvc.Tests.HtmlHelpers
{
    [TestFixture]
    public class ResourceStringHtmlHelperBehavior
    {
        //private HtmlHelper htmlHelper;

        
        [SetUp]
        public void Setup()
        {
            //htmlHelper = new HtmlHelper(new ViewContext(), Substitute.For<IViewDataContainer>());
        }


        [Test]
        public void HtmlString_ShouldNotAffectNonAffectableString()
        {
            //Assert.That(htmlHelper.ToHtml("foo bar").ToHtmlString(), Is.EqualTo("foo bar"));
        }

        [Test]
        public void HtmlString_ShouldReplaceNewLineWithBrTag()
        {
            //Assert.That(htmlHelper.ToHtml("foo" + Environment.NewLine + "bar").ToHtmlString(), Is.EqualTo("foo<br/>bar"));
        }
    }
}