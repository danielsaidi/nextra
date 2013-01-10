using System.Windows.Forms;

namespace NExtra.WinForms.Dialogs
{
    /// <summary>
    /// This interface can be implemented by classes that can
    /// be used to wrap a PageSetupDialog instance.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IPageSetupDialogFacade
    {
        /// <summary>
        /// The wrapped PageSetupDialog instance.
        /// </summary>
        PageSetupDialog PageSetupDialog { get; }
    }
}