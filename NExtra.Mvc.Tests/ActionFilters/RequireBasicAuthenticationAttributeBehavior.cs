using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NExtra.Mvc.ActionFilters;
using NExtra.Web.Security;
using NSubstitute;
using NUnit.Framework;

namespace NExtra.Mvc.Tests.ActionFilters
{
    [TestFixture]
    public class RequireBasicAuthenticationAttributeBehavior
    {
        private RequireBasicAuthenticationAttribute _attribute;
        private ActionExecutingContext _attributeContext;
        private HttpResponseBase _response;
        private IBasicAuthenticationProvider _authenticator;


        [SetUp]
        public void Setup()
        {
            _response = Substitute.For<HttpResponseBase>();

            var httpContext = Substitute.For<HttpContextBase>();
            httpContext.Response.Returns(_response);
            var controller = Substitute.For<ControllerBase>();
            var actionDescriptor = Substitute.For<ActionDescriptor>();
            var controllerContext = new ControllerContext(httpContext, new RouteData(), controller);
            _attributeContext = new ActionExecutingContext(controllerContext, actionDescriptor, new Dictionary<string, object>());

            _authenticator = Substitute.For<IBasicAuthenticationProvider>();
        }


        [Test]
        public void OnActionExecuting_ShouldAbortForAnyAuthenticatedUserIfNoCredentialsAreSpecified()
        {
            _attribute = new RequireBasicAuthenticationAttribute("foo", null, null, _authenticator);
            _authenticator.IsAuthenticated().Returns(true);
            _authenticator.IsAuthenticatedWithCredentials(Arg.Any<BasicAuthenticationCredentials>()).Returns(false);

            _attribute.OnActionExecuting(_attributeContext);

            AssertDidAbort();
        }

        [Test]
        public void OnActionExecuting_ShouldNotAbortForUnauthenticatedUserIfNoCredentialsAreSpecified()
        {
            _attribute = new RequireBasicAuthenticationAttribute("foo", null, null, _authenticator);
            _authenticator.IsAuthenticated().Returns(false);
            _authenticator.IsAuthenticatedWithCredentials(Arg.Any<BasicAuthenticationCredentials>()).Returns(true);

            _attribute.OnActionExecuting(_attributeContext);

            AssertDidNotAbort();
        }

        [Test]
        public void OnActionExecuting_ShouldAbortForCorrectlyAuthenticatedUserIfCredentialsAreSpecified()
        {
            _attribute = new RequireBasicAuthenticationAttribute("foo", "daniel", "saidi", _authenticator);
            _authenticator.IsAuthenticated().Returns(false);
            _authenticator.IsAuthenticatedWithCredentials(Arg.Any<BasicAuthenticationCredentials>()).Returns(true);

            _attribute.OnActionExecuting(_attributeContext);

            AssertDidAbort();
        }

        [Test]
        public void OnActionExecuting_ShouldNotAbortForIncorrectlyAuthenticatedUserIfCredentialsAreSpecified()
        {
            _attribute = new RequireBasicAuthenticationAttribute("foo", "daniel", "saidi", _authenticator);
            _authenticator.IsAuthenticated().Returns(true);
            _authenticator.IsAuthenticatedWithCredentials(Arg.Any<BasicAuthenticationCredentials>()).Returns(false);

            _attribute.OnActionExecuting(_attributeContext);

            AssertDidNotAbort();
        }

        [Test]
        public void OnActionExecuting_ShouldNotAbortForUnauthenticatedUserIfCredentialsAreSpecified()
        {
            _attribute = new RequireBasicAuthenticationAttribute("foo", "daniel", "saidi", _authenticator);
            _authenticator.IsAuthenticated().Returns(true);
            _authenticator.IsAuthenticatedWithCredentials(Arg.Any<BasicAuthenticationCredentials>()).Returns(false);

            _attribute.OnActionExecuting(_attributeContext);

            AssertDidNotAbort();
        }


        private void AssertDidAbort()
        {
            _response.DidNotReceive().StatusCode = 401;
            _response.DidNotReceive().AddHeader(Arg.Any<string>(), Arg.Any<string>());
            _response.DidNotReceive().End();
        }

        private void AssertDidNotAbort()
        {
            _response.Received().StatusCode = 401;
            _response.Received().AddHeader("WWW-Authenticate", "Basic realm=\"foo\"");
            _response.Received().End();
        }
    }
}
