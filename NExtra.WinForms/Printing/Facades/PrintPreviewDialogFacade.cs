using System.Windows.Forms;
using NExtra.WinForms.Printing.Abstractions;

namespace NExtra.WinForms.Printing.Facades
{
    /// <summary>
    /// This class can be used as facade for the
    /// PrintPreviewDialog class.
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
        public PrintPreviewDialogFacade(PrintPreviewDialog printPreviewDialog)
        {
            PrintPreviewDialog = printPreviewDialog;
        }


        /// <summary>
        /// The print preview dialog that is wrapped by the facade.
        /// </summary>
        public PrintPreviewDialog PrintPreviewDialog { get; private set; }
    }
}