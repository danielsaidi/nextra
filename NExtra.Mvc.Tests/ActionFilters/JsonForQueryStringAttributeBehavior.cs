using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;
using NExtra.Mvc.ActionFilters;
using NSubstitute;
using NUnit.Framework;

namespace NExtra.Mvc.Tests.ActionFilters
{
    class TempController : Controller {}


    [TestFixture]
    public class JsonForQueryStringAttributeBehavior
    {
        private ViewResult defaultActionResult;
        private ActionExecutedContext filterContext;
        private HttpRequestBase httpRequestBase;
        private JsonForQueryStringAttribute jsonForQueryStringAttribute;


        [SetUp]
        public void SetUp()
        {
            defaultActionResult = new ViewResult();

            filterContext = new ActionExecutedContext {
                Result = defaultActionResult,
                Controller = new TempController { ViewData = new ViewDataDictionary(true) }
            };

            httpRequestBase = Substitute.For<HttpRequestBase>();
            httpRequestBase.QueryString.Returns(new NameValueCollection {{"foo", "bar"}});
            
            jsonForQueryStringAttribute = new JsonForQueryStringAttribute("foo", "bar");
        }


        [Test]
        public void OnActionExecuted_ShouldNotAffectDefaultResultForMissingQueryStringVariable()
        {
            httpRequestBase.QueryString.Returns(new NameValueCollection());

            jsonForQueryStringAttribute.OnActionExecuted(filterContext, httpRequestBase);

            Assert.That(filterContext.Result, Is.EqualTo(defaultActionResult));
        }

        [Test]
        public void OnActionExecuted_ShouldNotAffectDefaultResultForInvalidQueryStringVariableValue()
        {
            httpRequestBase.QueryString.Returns(new NameValueCollection { { "foo", "bar2" } });

            jsonForQueryStringAttribute.OnActionExecuted(filterContext, httpRequestBase);

            Assert.That(filterContext.Result, Is.EqualTo(defaultActionResult));
        }

        [Test]
        public void OnActionExecuted_ShouldAffectResultForNullQueryStringVariableValue()
        {
            jsonForQueryStringAttribute = new JsonForQueryStringAttribute("foo", null);

            jsonForQueryStringAttribute.OnActionExecuted(filterContext, httpRequestBase);

            Assert.That(((JsonResult)filterContext.Result).Data, Is.True);
        }

        [Test]
        public void OnActionExecuted_ShouldAffectResultForValidQueryStringVariableValue()
        {
            jsonForQueryStringAttribute.OnActionExecuted(filterContext, httpRequestBase);

            Assert.That(((JsonResult)filterContext.Result).Data, Is.True);
        }
    }
}