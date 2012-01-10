using System.Windows.Forms;

namespace NExtra.WinForms.Dialogs
{
    /// <summary>
    /// This class can be used as facade for the
    /// PrintPreviewDialog class.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
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