using System.Windows.Forms;

namespace NExtra.WinForms.Dialogs
{
    /// <summary>
    /// This class can be used as a facade for the
    /// PageSetupDialog class.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
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


        /// <summary>
        /// The page setup dialog that is wrapped by the facade.
        /// </summary>
        public PageSetupDialog PageSetupDialog { get; private set; }
    }
}