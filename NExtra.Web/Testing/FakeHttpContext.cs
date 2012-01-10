using System.Security.Principal;
using System.Web;

namespace NExtra.Web.Testing
{
    ///<summary>
    /// This class can be used as a fake HTTP context.
    ///</summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public class FakeHttpContext : HttpContextBase
    {
        private readonly HttpRequestBase request = new FakeHttpRequest();
        private readonly IPrincipal user = new GenericPrincipal(new GenericIdentity("someUser"), null /* roles */);


        /// <summary>
        /// The HTTP request being used.
        /// </summary>
        public override HttpRequestBase Request
        {
            get
            {
                return request;
            }
        }

        /// <summary>
        /// The principal being used.
        /// </summary>
        public override IPrincipal User
        {
            get
            {
                return user;
            }
            set
            {
                base.User = value;
            }
        }
    }
}