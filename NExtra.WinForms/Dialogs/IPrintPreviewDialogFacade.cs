using System.Windows.Forms;

namespace NExtra.WinForms.Dialogs
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// should be able to be used as facade classes for a
    /// PrintPreviewDialog instance.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IPrintPreviewDialogFacade
    {
        /// <summary>
        /// Base PrintPreviewDialog instance.
        /// </summary>
        PrintPreviewDialog PrintPreviewDialog { get; }
    }
}