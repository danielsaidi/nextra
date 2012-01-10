using System.Windows.Forms;

namespace NExtra.WinForms.Dialogs
{
    /// <summary>
    /// This class can be used as facade for the
    /// PrintDialog class.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public class PrintDialogFacade : IPrintDialogFacade
    {
        /// <summary>
        /// Create an instance of the class.
        /// </summary>
        public PrintDialogFacade(PrintDialog printDialog)
        {
            PrintDialog = printDialog;
        }


        /// <summary>
        /// The print dialog that is wrapped by the facade.
        /// </summary>
        public PrintDialog PrintDialog { get; private set; }


        /// <summary>
        /// Call the ShowDialog function of the wrapped base instance.
        /// </summary>
        public DialogResult ShowDialog()
        {
            return PrintDialog.ShowDialog();
        }
    }
}