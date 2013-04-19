using System.Windows.Forms;

namespace NExtra.WinForms.Dialogs
{
    /// <summary>
    /// This class can be used to wrap a PrintDialog instance.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class PrintDialogFacade : IPrintDialogFacade
    {
        public PrintDialogFacade(PrintDialog printDialog)
        {
            PrintDialog = printDialog;
        }


        public PrintDialog PrintDialog { get; private set; }


        public DialogResult ShowDialog()
        {
            return PrintDialog.ShowDialog();
        }
    }
}