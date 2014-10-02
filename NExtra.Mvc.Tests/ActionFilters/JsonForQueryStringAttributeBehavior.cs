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
        private ViewResult _defaultActionResult;
        private ActionExecutedContext _filterContext;
        private HttpRequestBase _httpRequestBase;
        private JsonForQueryStringAttribute _jsonForQueryStringAttribute;


        [SetUp]
        public void SetUp()
        {
            _defaultActionResult = new ViewResult();

            _filterContext = new ActionExecutedContext {
                Result = _defaultActionResult,
                Controller = new TempController { ViewData = new ViewDataDictionary(true) }
            };

            _httpRequestBase = Substitute.For<HttpRequestBase>();
            _httpRequestBase.QueryString.Returns(new NameValueCollection {{"foo", "bar"}});
            
            _jsonForQueryStringAttribute = new JsonForQueryStringAttribute("foo", "bar");
        }


        [Test]
        public void OnActionExecuted_ShouldNotAffectDefaultResultForMissingQueryStringVariable()
        {
            _httpRequestBase.QueryString.Returns(new NameValueCollection());

            _jsonForQueryStringAttribute.OnActionExecuted(_filterContext, _httpRequestBase);

            Assert.That(_filterContext.Result, Is.EqualTo(_defaultActionResult));
        }

        [Test]
        public void OnActionExecuted_ShouldNotAffectDefaultResultForInvalidQueryStringVariableValue()
        {
            _httpRequestBase.QueryString.Returns(new NameValueCollection { { "foo", "bar2" } });

            _jsonForQueryStringAttribute.OnActionExecuted(_filterContext, _httpRequestBase);

            Assert.That(_filterContext.Result, Is.EqualTo(_defaultActionResult));
        }

        [Test]
        public void OnActionExecuted_ShouldAffectResultForNullQueryStringVariableValue()
        {
            _jsonForQueryStringAttribute = new JsonForQueryStringAttribute("foo", null);

            _jsonForQueryStringAttribute.OnActionExecuted(_filterContext, _httpRequestBase);

            Assert.That(((JsonResult)_filterContext.Result).Data, Is.True);
        }

        [Test]
        public void OnActionExecuted_ShouldAffectResultForValidQueryStringVariableValue()
        {
            _jsonForQueryStringAttribute.OnActionExecuted(_filterContext, _httpRequestBase);

            Assert.That(((JsonResult)_filterContext.Result).Data, Is.True);
        }
    }
}