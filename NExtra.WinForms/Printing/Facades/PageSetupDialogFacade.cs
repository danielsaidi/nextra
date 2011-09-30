using System.Windows.Forms;
using NExtra.WinForms.Printing.Abstractions;

namespace NExtra.WinForms.Printing.Facades
{
    /// <summary>
    /// This class can be used as facade for the PageSetupDialog
    /// class, to simplify unit testing.
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
        /// <param name="pageSetupDialog">The base instance to wrap.</param>
        public PageSetupDialogFacade(PageSetupDialog pageSetupDialog)
        {
            PageSetupDialog = pageSetupDialog;
        }


        /// <summary>
        /// The base instance that is wrapped within the facade.
        /// </summary>
        public PageSetupDialog PageSetupDialog { get; private set; }
    }
}