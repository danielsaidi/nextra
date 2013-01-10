using System.Windows.Forms;

namespace NExtra.WinForms.Dialogs
{
    /// <summary>
    /// This class can be used to wrap PrintDialog instances.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
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