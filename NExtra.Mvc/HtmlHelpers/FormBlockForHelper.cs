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
    /// within a tag structure that is identical to the format
    /// that is used when VS auto-generates a model form.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// 
    /// This helper will use metadata to generate label values
    /// and proper validation error messages. Instead of using
    /// attributes to set these values manually, you can setup
    /// the metadata provider in NExtra.Mvc.Localization to do
    /// it automatically as the page is generated. It is based
    /// on conventions and uses resource files.
    /// </remarks>
    public static class FormBlockForHelper
    {
        /// <summary>
        /// Generate a form block with an editor-label,
        /// an editor field (using the provided editor)
        /// that also contains a validation message.
        /// </summary>
        /// <param name="helper">HtmlHelper instance.</param>
        /// <param name="expression">An expression for the property to display, e.g. model => model.Name.</param>
        /// <param name="editor">The editor that should be appended to the editor field, e.g. a TextAreaFor.</param>
        /// <returns>An editor block for the provided property.</returns>
        public static IHtmlString FormBlockFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel,TValue>> expression, MvcHtmlString editor)
        {
            var sb = new StringBuilder();

            sb.Append("<div class=\"editor-label\">");
            sb.Append(helper.LabelFor(expression));
            sb.Append("</div>");
            
            sb.Append("<div class=\"editor-field\">");
            sb.Append(editor);
            sb.Append(helper.ValidationMessageFor(expression));
            sb.Append("</div>");
            
            return helper.Raw(sb.ToString());
        }
    }
}
