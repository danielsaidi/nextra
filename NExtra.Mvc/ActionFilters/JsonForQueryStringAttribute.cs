using System.Web;
using System.Web.Mvc;

namespace NExtra.Mvc.ActionFilters
{
    /// <summary>
    /// This action filter can be applied to any action. It
    /// is triggered by a custom query variable and returns
    /// the view model as JSON data if the condition is met.
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
        /// Create a filter that requires that a certain
        /// query string variable exists.
        /// </summary>
        public JsonForQueryStringAttribute(string queryVariableName)
            : this(queryVariableName, null)
        {
        }

        /// <summary>
        /// Create a filter that requires that a certain
        /// query string variable exists and that it has
        /// a certain value.
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
