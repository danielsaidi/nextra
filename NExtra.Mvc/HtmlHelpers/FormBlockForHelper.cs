using System;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace NExtra.Mvc.HtmlHelpers
{
    /// <summary>
    /// This helper can be used to generate a form block for a
    /// model property. It embeds an editor, e.g. an EditorFor,
    /// in a div structure that is identical to that generated
    /// piece of code that is created when Visual Studio takes
    /// a model and auto-generates a form.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public static class FormBlockForHelper
    {
        /// <summary>
        /// Generate a form block.
        /// </summary>
        /// <param name="helper">HtmlHelper instance.</param>
        /// <param name="expression">An expression for the property to display, e.g. model => model.Name.</param>
        /// <param name="editorBlock">The editor that should be appended to the editor field, e.g. a TextAreaFor.</param>
        /// <returns>An editor block for the provided property.</returns>
        public static IHtmlString FormBlockFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel,TValue>> expression, MvcHtmlString editorBlock)
        {
            var sb = new StringBuilder();

            sb.Append("<div class=\"editor-label\">");
            sb.Append(helper.LabelFor(expression));
            sb.Append("</div>");
            
            sb.Append("<div class=\"editor-field\">");
            sb.Append(editorBlock);
            sb.Append(helper.ValidationMessageFor(expression));
            sb.Append("</div>");
            
            return helper.Raw(sb.ToString());
        }
    }
}
