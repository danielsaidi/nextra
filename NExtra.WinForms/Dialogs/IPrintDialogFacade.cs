using System.Windows.Forms;

namespace NExtra.WinForms.Dialogs
{
    /// <summary>
    /// This interface can be implemented by classes that can
    /// be used to wrap a PrintDialog instance.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IPrintDialogFacade
    {
        /// <summary>
        /// The wrapped PrintDialog instance.
        /// </summary>
        PrintDialog PrintDialog { get; }

        /// <summary>
        /// Show the PrintDialog.
        /// </summary>
        DialogResult ShowDialog();
    }
}