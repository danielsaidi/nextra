using System;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace NExtra.Mvc.HtmlHelpers
{
    /// <summary>
    /// This helper can be used to generate a form block
    /// for a model property. It embeds an editor within
    /// a tag structure identical to the one that Visual
    /// Studio uses, when it auto-generates a model form.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// 
    /// This helper can be used to generate a form block
    /// This helper will use metadata to translate label
    /// values and validation error messages. Instead of
    /// using property attributes to set these values, a
    /// better approach is to enable one of the metadata
    /// providers in NExtra.Mvc.Localization.
    /// </remarks>
    public static class FormBlockForHelper
    {
        /// <summary>
        /// Generate a form block. Use this method like this:
        /// @Html.FormBlockFor(x => x.UserName, TextBoxFor(x => x.UserName))
        /// </summary>
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
