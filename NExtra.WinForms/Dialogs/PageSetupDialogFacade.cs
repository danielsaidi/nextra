using System.Windows.Forms;

namespace NExtra.WinForms.Dialogs
{
    /// <summary>
    /// This class can be used to wrap a PageSetupDialog instance.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class PageSetupDialogFacade : IPageSetupDialogFacade
    {
        public PageSetupDialogFacade(PageSetupDialog pageSetupDialog)
        {
            PageSetupDialog = pageSetupDialog;
        }


        public PageSetupDialog PageSetupDialog { get; private set; }
    }
}