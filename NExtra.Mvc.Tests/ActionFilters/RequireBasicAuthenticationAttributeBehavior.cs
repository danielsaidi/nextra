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
        private RequireBasicAuthenticationAttribute attribute;
        private ActionExecutingContext attributeContext;
        private HttpResponseBase response;
        private IBasicAuthenticationProvider authenticator;


        [SetUp]
        public void Setup()
        {
            response = Substitute.For<HttpResponseBase>();

            var httpContext = Substitute.For<HttpContextBase>();
            httpContext.Response.Returns(response);
            var controller = Substitute.For<ControllerBase>();
            var actionDescriptor = Substitute.For<ActionDescriptor>();
            var controllerContext = new ControllerContext(httpContext, new RouteData(), controller);
            attributeContext = new ActionExecutingContext(controllerContext, actionDescriptor, new Dictionary<string, object>());

            authenticator = Substitute.For<IBasicAuthenticationProvider>();
        }


        [Test]
        public void OnActionExecuting_ShouldAbortForAnyAuthenticatedUserIfNoCredentialsAreSpecified()
        {
            attribute = new RequireBasicAuthenticationAttribute("foo", null, null, authenticator);
            authenticator.IsAuthenticated().Returns(true);
            authenticator.IsAuthenticatedWithCredentials(Arg.Any<BasicAuthenticationCredentials>()).Returns(false);

            attribute.OnActionExecuting(attributeContext);

            AssertDidAbort();
        }

        [Test]
        public void OnActionExecuting_ShouldNotAbortForUnauthenticatedUserIfNoCredentialsAreSpecified()
        {
            attribute = new RequireBasicAuthenticationAttribute("foo", null, null, authenticator);
            authenticator.IsAuthenticated().Returns(false);
            authenticator.IsAuthenticatedWithCredentials(Arg.Any<BasicAuthenticationCredentials>()).Returns(true);

            attribute.OnActionExecuting(attributeContext);

            AssertDidNotAbort();
        }

        [Test]
        public void OnActionExecuting_ShouldAbortForCorrectlyAuthenticatedUserIfCredentialsAreSpecified()
        {
            attribute = new RequireBasicAuthenticationAttribute("foo", "daniel", "saidi", authenticator);
            authenticator.IsAuthenticated().Returns(false);
            authenticator.IsAuthenticatedWithCredentials(Arg.Any<BasicAuthenticationCredentials>()).Returns(true);

            attribute.OnActionExecuting(attributeContext);

            AssertDidAbort();
        }

        [Test]
        public void OnActionExecuting_ShouldNotAbortForIncorrectlyAuthenticatedUserIfCredentialsAreSpecified()
        {
            attribute = new RequireBasicAuthenticationAttribute("foo", "daniel", "saidi", authenticator);
            authenticator.IsAuthenticated().Returns(true);
            authenticator.IsAuthenticatedWithCredentials(Arg.Any<BasicAuthenticationCredentials>()).Returns(false);

            attribute.OnActionExecuting(attributeContext);

            AssertDidNotAbort();
        }

        [Test]
        public void OnActionExecuting_ShouldNotAbortForUnauthenticatedUserIfCredentialsAreSpecified()
        {
            attribute = new RequireBasicAuthenticationAttribute("foo", "daniel", "saidi", authenticator);
            authenticator.IsAuthenticated().Returns(true);
            authenticator.IsAuthenticatedWithCredentials(Arg.Any<BasicAuthenticationCredentials>()).Returns(false);

            attribute.OnActionExecuting(attributeContext);

            AssertDidNotAbort();
        }


        private void AssertDidAbort()
        {
            response.DidNotReceive().StatusCode = 401;
            response.DidNotReceive().AddHeader(Arg.Any<string>(), Arg.Any<string>());
            response.DidNotReceive().End();
        }

        private void AssertDidNotAbort()
        {
            response.Received().StatusCode = 401;
            response.Received().AddHeader("WWW-Authenticate", "Basic realm=\"foo\"");
            response.Received().End();
        }
    }
}
