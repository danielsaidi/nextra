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
        private readonly HttpRequestBase _request;
        private readonly HttpResponseBase _response;
        private readonly IPrincipal _user;


        public FakeHttpContext(HttpRequestBase request, HttpResponseBase response)
            : this(request, response, new GenericPrincipal(new GenericIdentity("someUser"), null /* roles */))
        {
        }

        public FakeHttpContext(HttpRequestBase request, HttpResponseBase response, IPrincipal user)
        {
            _request = request;
            _response = response;
            _user = user;
        }


        public override HttpRequestBase Request
        {
            get { return _request; }
        }

        public override HttpResponseBase Response
        {
            get { return _response; }
        }

        public override IPrincipal User
        {
            get { return _user; }
            set { base.User = value; }
        }
    }
}