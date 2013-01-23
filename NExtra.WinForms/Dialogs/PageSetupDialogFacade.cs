using System.Windows.Forms;

namespace NExtra.WinForms.Dialogs
{
    /// <summary>
    /// This class can be used to wrap PageSetupDialog instances.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class PageSetupDialogFacade : IPageSetupDialogFacade
    {
        /// <summary>
        /// Create an instance of the class.
        /// </summary>
        public PageSetupDialogFacade(PageSetupDialog pageSetupDialog)
        {
            PageSetupDialog = pageSetupDialog;
        }


        public PageSetupDialog PageSetupDialog { get; private set; }
    }
}