using System.Security.Principal;
using System.Web;

namespace NExtra.Web.Testing
{
    ///<summary>
    /// This class can be used as a fake HTTP context.
    ///</summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class FakeHttpContext : HttpContextBase
    {
        private readonly HttpRequestBase request;
        private readonly HttpResponseBase response;
        private readonly IPrincipal user;


        public FakeHttpContext(HttpRequestBase request, HttpResponseBase response)
            : this(request, response, new GenericPrincipal(new GenericIdentity("someUser"), null /* roles */))
        {
        }

        public FakeHttpContext(HttpRequestBase request, HttpResponseBase response, IPrincipal user)
        {
            this.request = request;
            this.response = response;
            this.user = user;
        }


        public override HttpRequestBase Request
        {
            get { return request; }
        }

        public override HttpResponseBase Response
        {
            get { return response; }
        }

        public override IPrincipal User
        {
            get { return user; }
            set { base.User = value; }
        }
    }
}