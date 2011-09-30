using System;
using System.Text.RegularExpressions;
using System.Web;
using NExtra.Documentation;
using NExtra.Extensions;

namespace NExtra.Demo.Models
{
    /// <summary>
    /// This class is used as view model by the DemoController
    /// and documented since it is used in a demo.
    /// </summary>
    /// <remarks>
    /// Additional details can be placed within the remarks tag.
    /// </remarks>
    /// <example>
    /// Examples can be placed within the example tag, like this.
    /// </example>
    public class DemoModel : ModelBase
    {
        private readonly XmlDocumentationHandler xmlDocumentationHandler;


        /// <summary>
        /// Create an instance of the class.
        /// </summary>
        public DemoModel()
        {
            xmlDocumentationHandler = new XmlDocumentationHandler();
        }


        /// <summary>
        /// The name of the currently executing action.
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// The name of the currently executing action.
        /// </summary>
        public string ControllerName { get; set; }
        
        /// <summary>
        /// This propety is documented so that its documentation can be loaded in one of the demos.
        /// </summary>
        public string DocumentedProperty { get; set; }

        /// <summary>
        /// The base URL, to which demo forms should be posted.
        /// </summary>
        public string PostUrl
        {
            get { return HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path); }
        }


        /// <summary>
        /// This method is documented so that its documentation can be loaded in one of the demos.
        /// </summary>
        public void DocumentedMethod() {}

        /// <summary>
        /// Extract the documentation summary for a certain type.
        /// </summary>
        /// <param name="type">The type of interest.</param>
        /// <returns>The documentation summary, if any.</returns>
        public IHtmlString GetTypeSummary(Type type)
        {
            var summary = String.Format("<p class=\"ingress\">{0}</p>", xmlDocumentationHandler.ExtractTypeXmlDocumentation(type).GetElementInnerText("summary"));
            summary = new Regex(@"[ ]{2,}").Replace(summary, @" ");
            summary = summary.Replace(Environment.NewLine + " ", Environment.NewLine);
            summary = summary.Replace(Environment.NewLine + Environment.NewLine, "</p><p>");
            summary = summary.Replace(Environment.NewLine, " ");
            summary = summary.Replace("<p></p>", String.Empty);

            return new HtmlString(summary);
        }
    }
}