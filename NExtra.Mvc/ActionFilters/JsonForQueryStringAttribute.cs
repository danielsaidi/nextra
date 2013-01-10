using System.Web;
using System.Web.Mvc;

namespace NExtra.Mvc.ActionFilters
{
    /// <summary>
    /// This attribute can be applied to any controller action.
    /// It is triggered by a certain query variable, either if
    /// the variable just exists, or if it has a certain value.
    /// If the condition is met, the attribute will return the
    /// current view model to JSON data.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class JsonForQueryStringAttribute : ActionFilterAttribute
    {
        private readonly string queryVariableName;
        private readonly string queryVariableValue;


        /// <summary>
        /// Create an attribute that requires that a certain
        /// query string key exists.
        /// </summary>
        public JsonForQueryStringAttribute(string queryVariableName)
            : this(queryVariableName, null)
        {
        }

        /// <summary>
        /// Create an attribute that requires that a certain
        /// query string key with a certain value exists.
        /// </summary>
        public JsonForQueryStringAttribute(string queryVariableName, string queryVariableValue)
        {
            this.queryVariableName = queryVariableName;
            this.queryVariableValue = queryVariableValue;
        }


        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            OnActionExecuted(filterContext, filterContext.HttpContext.Request);
        }

        /// <summary>
        /// This method is called by the overridden base method. It
        /// has a HTTP request parameter as well, so that it can be
        /// easily tested. The test class calls this method.
        /// </summary>
        public void OnActionExecuted(ActionExecutedContext filterContext, HttpRequestBase httpRequest)
        {
            var queryString = httpRequest.QueryString[queryVariableName];

            if (queryString != null)
            {
                if (queryVariableValue == null || queryVariableValue == queryString)
                {
                    var result = new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = filterContext.Controller.ViewData.Model
                    };

                    filterContext.Result = result;
                }
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
