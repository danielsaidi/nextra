using System;
using System.Web;

namespace NExtra.Web.Testing
{
    ///<summary>
    /// This class can be used as a fake HTTP request.
    ///</summary>
    public class FakeHttpRequest : HttpRequestBase
    {
        private readonly bool isAuthenticated;
        private readonly Uri url;
        private Uri urlReferrer;


        [Obsolete("This default constructor will be removed in 2.6.0.0")]
        public FakeHttpRequest()
            : this("http://foo.com", true)
        {
        }

        ///<summary>
        /// Create a custom instance of the class.
        ///</summary>
        public FakeHttpRequest(string url, bool isAuthenticated)
        {
            this.url = new Uri(url);
            this.isAuthenticated = isAuthenticated;
        }


        /// <summary>
        /// Whether or not the request is authenticated.
        /// </summary>
        public override bool IsAuthenticated
        {
            get { return isAuthenticated; }
        }

        /// <summary>
        /// The URL of the request.
        /// </summary>
        public override Uri Url
        {
            get { return url; }
        }

        /// <summary>
        /// The URL of the request.
        /// </summary>
        public override Uri UrlReferrer
        {
            get { return urlReferrer; }
        }



        /// <summary>
        /// Set a new value for the UrlReferrer property.
        /// </summary>
        public void SetUrlReferrer(Uri newValue)
        {
            urlReferrer = newValue;
        }
    }
}