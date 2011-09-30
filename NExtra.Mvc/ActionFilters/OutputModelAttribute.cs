using System.Web;
using System.Web.Mvc;

namespace NExtra.Mvc.ActionFilters
{
    /// <summary>
    /// This action filter can be applied to any action. It
    /// is triggered by a custom query variable and returns
    /// the view model as a JSON data.
    /// 
    /// This attribute can be applied to actions where JSON
    /// data can help analyzing invalid view models.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class OutputModelAttribute : ActionFilterAttribute
    {
        private readonly string queryVariableName;
        private readonly string queryVariableValue;


        /// <summary>
        /// Create a filter instance that only requires that a
        /// query string variable with the given name exists.
        /// </summary>
        /// <param name="queryVariableName">The query string variable name.</param>
        public OutputModelAttribute(string queryVariableName)
            : this(queryVariableName, null)
        {
        }

        /// <summary>
        /// Create a filter instance that requires that a query
        /// string variable with a certain value exists.
        /// </summary>
        /// <param name="queryVariableName">The query string variable name.</param>
        /// <param name="queryVariableValue">The required query string variable value.</param>
        public OutputModelAttribute(string queryVariableName, string queryVariableValue)
        {
            this.queryVariableName = queryVariableName;
            this.queryVariableValue = queryVariableValue;
        }


        /// <summary>
        /// Override the OnActionExecuted event.
        /// </summary>
        /// <param name="filterContext">The current filter context.</param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            OnActionExecuted(filterContext, filterContext.HttpContext.Request);
        }

        /// <summary>
        /// Override the OnActionExecuted event, using a custom HTTP request.
        /// </summary>
        /// <param name="filterContext">The current filter context.</param>
        /// <param name="httpRequest">Custom HTTP request.</param>
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
