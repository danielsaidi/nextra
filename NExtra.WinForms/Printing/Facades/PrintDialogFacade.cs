using System.Windows.Forms;
using NExtra.WinForms.Printing.Abstractions;

namespace NExtra.WinForms.Printing.Facades
{
    /// <summary>
    /// This class can be used as facade for the PrintDialog
    /// class, to simplify unit testing.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class PrintDialogFacade : IPrintDialogFacade
    {
        /// <summary>
        /// Create an instance of the class.
        /// </summary>
        /// <param name="printDialog">The base instance to wrap.</param>
        public PrintDialogFacade(PrintDialog printDialog)
        {
            PrintDialog = printDialog;
        }


        /// <summary>
        /// The base instance that is wrapped within the facade.
        /// </summary>
        public PrintDialog PrintDialog { get; private set; }


        /// <summary>
        /// Call the ShowDialog function of the wrapped base instance.
        /// </summary>
        /// <returns>Base instance ShowDialog result.</returns>
        public DialogResult ShowDialog()
        {
            return PrintDialog.ShowDialog();
        }
    }
}