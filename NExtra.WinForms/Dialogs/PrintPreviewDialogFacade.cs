using System.Windows.Forms;

namespace NExtra.WinForms.Dialogs
{
    /// <summary>
    /// This class can be used to wrap PrintPreviewDialog instances.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
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


        public PrintPreviewDialog PrintPreviewDialog { get; private set; }
    }
}