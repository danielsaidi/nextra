using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using NExtra.Web.Html;

namespace NExtra.WebForms.WebControls
{
    /// <summary>
    /// This control inherits CreateUserWizard, but does
    /// not generate any table elements.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public class NoTableCreateUserWizard : CreateUserWizard
    {
        /// <summary>
        /// Override the base Render method.
        /// </summary>
        protected override void Render(HtmlTextWriter writer)
        {
            var htmlTableRemover = HtmlRemover ?? new HtmlRemover();

            var sw = new StringWriter();
            var hw = new HtmlTextWriter(sw);
            base.Render(hw);

            var html = htmlTableRemover.RemoveHtmlTableElements(sw.ToString());

            hw.Close();
            sw.Close();

            writer.Write(html);
        }


        /// <summary>
        /// The ICanRemoveHtml instance that will be used to
        /// remove the HTML code. If no instance is set, the
        /// control will automatically use a new HtmlRemover.
        /// </summary>
        public IHtmlRemover HtmlRemover { get; set; }
    }
}
