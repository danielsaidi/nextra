using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using NExtra.Extensions;
using NExtra.Web.Extensions;

namespace NExtra.WebForms.WebControls
{
    /// <summary>
    /// This class can be used to embed an iframe to the page.
    /// It does not support auto scaling, but that can be set
    /// client-side. Also, adding HTML to the iframe requires
    /// JavaScript as well.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class IFrame : WebControl
    {
        /// <summary>
        /// This overriden method will add a Literal to the
        /// control collection and register a startup script.
        /// </summary>
        protected override void OnPreRender(EventArgs e)
        {
            Controls.Add(new Literal { Text = GetHtml() });
            ScriptManager.RegisterStartupScript(this, typeof(Literal), ClientID + "_text", GetHtmlScript(), true);
            base.OnPreRender(e);
        }


        /// <summary>
        /// Get/set the frame border size of the iFrame, if any.
        /// </summary>
        public int? FrameBorder
        {
            get { return ViewState.Get<int?>("FrameBorder"); }
            set { ViewState.Set("FrameBorder", value); }
        }

        /// <summary>
        /// Get or set the HTML content to load into the iFrame, if any.
        /// This property is applied with JavaScript, unlike Src, which
        /// is applied directly within the markup.
        /// </summary>
        public String Html
        {
            get { return ViewState.Get("Html", ""); }
            set { ViewState.Set("Html", value); }
        }

        /// <summary>
        /// Get/set the horizontal margin of the iFrame content.
        /// </summary>
        public int? MarginWidth
        {
            get { return ViewState.Get<int?>("MarginWidth"); }
            set { ViewState.Set("MarginWidth", value); }
        }

        /// <summary>
        /// Get/set the vertical margin of the iFrame content.
        /// </summary>
        public int? MarginHeight
        {
            get { return ViewState.Get<int?>("MarginHeight"); }
            set { ViewState.Set("MarginHeight", value); }
        }

        /// <summary>
        /// Get/set if the iFrame schould scroll if the content
        /// size exceeds the iFrame size.
        /// </summary>
        public bool? Scrolling
        {
            get { return ViewState.Get<bool?>("Scrolling"); }
            set { ViewState.Set("Scrolling", value); }
        }

        /// <summary>
        /// Get/set the path of the page to load into the iFrame, if any.
        /// </summary>
        public String Src
        {
            get { return ViewState.Get("Src", ""); }
            set { ViewState.Set("Src", value); }
        }

        /// <summary>
        /// Get/set the style to apply to the iFrame.
        /// </summary>
        new public String Style
        {
            get { return ViewState.Get("Style", ""); }
            set { ViewState.Set("Style", value); }
        }

        /// <summary>
        /// Get/set if the iFrame background should be transparent.
        /// </summary>
        public bool? Transparent
        {
            get { return ViewState.Get<bool?>("Transparent"); }
            set { ViewState.Set("Transparent", value); }
        }

        /// <summary>
        /// Append a double attribute, which is only appended if the value is greater than zero.
        /// </summary>
        private static void AppendAttribute(StringBuilder sb, string format, double value)
        {
            sb.Append(value > 0 ? String.Format(format, value) : null);
        }

        /// <summary>
        /// Append a int? attribute, which is only appended if the value has a value.
        /// </summary>
        private static void AppendAttribute(StringBuilder sb, string format, int? value)
        {
            sb.Append(value.HasValue ? String.Format(format, value) : null);
        }

        /// <summary>
        /// Append a string attribute, which is only appended if the value is not null or empty.
        /// </summary>
        private static void AppendAttribute(StringBuilder sb, string format, string value)
        {
            sb.Append(!value.IsNullOrEmpty() ? String.Format(format, value) : null);
        }

        /// <summary>
        /// Append a scrolling attribute, which is either "yes" or "no".
        /// </summary>
        private static void AppendScrollingAttribute(StringBuilder sb, bool? value)
        {
            sb.Append(value.HasValue ? String.Format("scrolling=\"{0}\" ", value.Value ? "yes" : "no") : null);
        }

        /// <summary>
        /// Append an allowtransparency attribute.
        /// </summary>
        private static void AppendTransparencyAttribute(StringBuilder sb, bool? value)
        {
            sb.Append(value.HasValue ? String.Format("allowtransparency=\"{0}\" ", value.Value).ToLower() : null);
        }

        /// <summary>
        /// Get the resulting HTML code for the control.
        /// </summary>
        protected string GetHtml()
        {
            var sb = new StringBuilder();

            sb.Append("<iframe ");
            AppendAttribute(sb, "id=\"{0}\" ", ClientID);
            AppendAttribute(sb, "src=\"{0}\" ", Src);
            AppendAttribute(sb, "class=\"{0}\" ", CssClass);
            AppendAttribute(sb, "style=\"{0}\" ", Style);
            AppendAttribute(sb, "width=\"{0}\" ", Width.Value);
            AppendAttribute(sb, "height=\"{0}\" ", Height.Value);
            AppendAttribute(sb, "marginWidth=\"{0}\" ", MarginWidth);
            AppendAttribute(sb, "marginHeight=\"{0}\" ", MarginHeight);
            AppendScrollingAttribute(sb, Scrolling);
            AppendTransparencyAttribute(sb, Transparent);
            AppendAttribute(sb, "frameborder=\"{0}\">", FrameBorder.HasValue ? FrameBorder : 0);
            sb.Append("</iframe>");

            return sb.ToString();
        }

        /// <summary>
        /// Get the JavaScript code that is responsible for adding
        /// any custom Html property value into the iFrame control.
        /// </summary>
        protected string GetHtmlScript()
        {
            if (String.IsNullOrEmpty(Html))
                return "";

            var script = new StringBuilder();
            script.AppendFormat("var tmpObj = document.getElementById('{0}');", ClientID);
            script.Append("var doc = tmpObj.contentDocument;");
            script.Append("if (doc == undefined || doc == null) doc = tmpObj.contentWindow.document;");
            script.Append("doc.open();");
            script.AppendFormat("doc.write('{0}');", GetHtmlScriptHtml());
            script.Append("doc.close();");

            return script.ToString();
        }

        /// <summary>
        /// Get the adjusted HTML code that is to be added to the iFrame.
        /// </summary>
        protected string GetHtmlScriptHtml()
        {
            if (String.IsNullOrEmpty(Html))
                return "";

            var html = (Html.IndexOf("<body") < 0) ? String.Format("<body>{0}</body>", Html) : Html;
            if (Transparent.HasValue && Transparent.Value)
                html += "<style type=\"text/css\">body { background: transparent; }</style>";
            return html;
        }

        /// <summary>
        /// Override the Render function in order to remove the outer span tag.
        /// </summary>
        protected override void Render(HtmlTextWriter writer)
        {
            RenderContents(writer);
        }
    }
}
