using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using NExtra.Extensions;
using NExtra.Web.Extensions;

namespace NExtra.WebForms.WebControls
{
    /// <summary>
    /// This class can be used to add an iframe to a page.
    /// It does not support auto scaling, but that can be
    /// set client-side.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class IFrame : WebControl
    {
        public int? FrameBorder
        {
            get { return ViewState.Get<int?>("FrameBorder"); }
            set { ViewState.Set("FrameBorder", value); }
        }

        public String Html
        {
            get { return ViewState.Get("Html", ""); }
            set { ViewState.Set("Html", value); }
        }

        public int? MarginWidth
        {
            get { return ViewState.Get<int?>("MarginWidth"); }
            set { ViewState.Set("MarginWidth", value); }
        }

        public int? MarginHeight
        {
            get { return ViewState.Get<int?>("MarginHeight"); }
            set { ViewState.Set("MarginHeight", value); }
        }

        public bool? Scrolling
        {
            get { return ViewState.Get<bool?>("Scrolling"); }
            set { ViewState.Set("Scrolling", value); }
        }

        public String Src
        {
            get { return ViewState.Get("Src", ""); }
            set { ViewState.Set("Src", value); }
        }

        new public String Style
        {
            get { return ViewState.Get("Style", ""); }
            set { ViewState.Set("Style", value); }
        }

        public bool? Transparent
        {
            get { return ViewState.Get<bool?>("Transparent"); }
            set { ViewState.Set("Transparent", value); }
        }


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

        protected string GetHtmlScriptHtml()
        {
            if (String.IsNullOrEmpty(Html))
                return "";

            var html = (Html.IndexOf("<body") < 0) ? String.Format("<body>{0}</body>", Html) : Html;
            if (Transparent.HasValue && Transparent.Value)
                html += "<style type=\"text/css\">body { background: transparent; }</style>";
            return html;
        }

        protected override void OnPreRender(EventArgs e)
        {
            Controls.Add(new Literal { Text = GetHtml() });
            ScriptManager.RegisterStartupScript(this, typeof(Literal), ClientID + "_text", GetHtmlScript(), true);
            base.OnPreRender(e);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            RenderContents(writer);
        }


        private static void AppendAttribute(StringBuilder sb, string format, double value)
        {
            sb.Append(value > 0 ? String.Format(format, value) : null);
        }

        private static void AppendAttribute(StringBuilder sb, string format, int? value)
        {
            sb.Append(value.HasValue ? String.Format(format, value) : null);
        }

        private static void AppendAttribute(StringBuilder sb, string format, string value)
        {
            sb.Append(!value.IsNullOrEmpty() ? String.Format(format, value) : null);
        }

        private static void AppendScrollingAttribute(StringBuilder sb, bool? value)
        {
            sb.Append(value.HasValue ? String.Format("scrolling=\"{0}\" ", value.Value ? "yes" : "no") : null);
        }

        private static void AppendTransparencyAttribute(StringBuilder sb, bool? value)
        {
            sb.Append(value.HasValue ? String.Format("allowtransparency=\"{0}\" ", value.Value).ToLower() : null);
        }
    }
}
