using System.Windows.Forms;
using NExtra.WinForms.Printing.Abstractions;

namespace NExtra.WinForms.Printing.Facades
{
    /// <summary>
    /// This class can be used as facade for the PrintPreviewDialog
    /// class, to simplify unit testing.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class PrintPreviewDialogFacade : IPrintPreviewDialogFacade
    {
        /// <summary>
        /// Create an instance of the class.
        /// </summary>
        /// <param name="printPreviewDialog">The base instance to wrap.</param>
        public PrintPreviewDialogFacade(PrintPreviewDialog printPreviewDialog)
        {
            PrintPreviewDialog = printPreviewDialog;
        }


        /// <summary>
        /// The base instance that is wrapped within the facade.
        /// </summary>
        public PrintPreviewDialog PrintPreviewDialog { get; private set; }
    }
}