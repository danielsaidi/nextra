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
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class NoTableCreateUserWizard : CreateUserWizard
    {
        /// <summary>
        /// Override the base Render method.
        /// </summary>
        protected override void Render(HtmlTextWriter writer)
        {
            if (HtmlRemover == null)
                HtmlRemover = new HtmlRemover();

            var sw = new StringWriter();
            var hw = new HtmlTextWriter(sw);
            base.Render(hw);

            var html = HtmlRemover.RemoveHtmlTableElements(sw.ToString());

            hw.Close();
            sw.Close();

            writer.Write(html);
        }


        /// <summary>
        /// The component that will be used to remove HTML
        /// code for the control. If no instance is set, a
        /// new HtmlRemover instance is used by default.
        /// </summary>
        public IHtmlRemover HtmlRemover { get; set; }
    }
}
