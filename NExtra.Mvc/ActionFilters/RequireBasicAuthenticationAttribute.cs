using System.Web.Mvc;
using NExtra.Web.Security;

namespace NExtra.Mvc.ActionFilters
{
    /// <summary>
    /// This attribute can be added to controller actions
    /// and will ensure that users provide required basic
    /// authentication credentials. It can either require
    /// that the user is simply logged in, or that he/she
    /// is logged in with certain credentials.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class RequireBasicAuthenticationAttribute : ActionFilterAttribute
    {
        private readonly IBasicAuthenticationProvider authenticator;
        private readonly string basicRealm;
        private readonly BasicAuthenticationCredentials requiredCredentials;


        public RequireBasicAuthenticationAttribute(string basicRealm)
            : this(basicRealm, null, null, new BasicAuthenticationProvider())
        {
        }

        public RequireBasicAuthenticationAttribute(string basicRealm, string requiredUserName, string requiredPassword)
            : this(basicRealm, requiredUserName, requiredPassword, new BasicAuthenticationProvider())
        {
        }

        public RequireBasicAuthenticationAttribute(string basicRealm, string requiredUserName, string requiredPassword, IBasicAuthenticationProvider authenticator)
        {
            this.basicRealm = basicRealm;
            if (requiredUserName != null || requiredPassword != null)
                requiredCredentials = new BasicAuthenticationCredentials(requiredUserName, requiredPassword);
            this.authenticator = authenticator;
        }


        private bool IsAuthenticated()
        {
            return requiredCredentials == null
                       ? authenticator.IsAuthenticated()
                       : authenticator.IsAuthenticatedWithCredentials(requiredCredentials);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (IsAuthenticated())
                return;

            var response = filterContext.HttpContext.Response;
            response.StatusCode = 401;
            response.AddHeader("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", basicRealm));
            response.End();
        }
    }
}