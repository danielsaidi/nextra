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


        ///<summary>
        /// Create a default instance of the class, using
        /// http://foo.com as URL and being authenticated.
        ///</summary>
        public FakeHttpRequest()
            : this("http://foo.com", true)
        {
        }

        ///<summary>
        /// Create a custom instance of the class.
        ///</summary>
        ///<param name="url">The fake URL to use.</param>
        ///<param name="isAuthenticated">Whether or not the request is authenticated.</param>
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
        /// <param name="newValue">The new value to set.</param>
        public void SetUrlReferrer(Uri newValue)
        {
            urlReferrer = newValue;
        }
    }
}