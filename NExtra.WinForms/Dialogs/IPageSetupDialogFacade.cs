using System.Windows.Forms;

namespace NExtra.WinForms.Dialogs
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// should be able to be used as facade classes for a
    /// PageSetupDialog instance.
    /// </summary>
    public interface IPageSetupDialogFacade
    {
        /// <summary>
        /// Base PageSetupDialog instance.
        /// </summary>
        PageSetupDialog PageSetupDialog { get; }
    }
}