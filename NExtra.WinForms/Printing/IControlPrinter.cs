using System.Drawing.Printing;
using System.Windows.Forms;

namespace NExtra.WinForms.Printing
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// should be able to print a certain type of control.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IControlPrinter<T>
    {
        /// <summary>
        /// The PageSetupDialog instance that is used by the printer.
        /// </summary>
        PageSetupDialog PageSetupDialog { get; }

        /// <summary>
        /// The PrintDialog instance that is used by the printer.
        /// </summary>
        PrintDialog PrintDialog { get; }

        /// <summary>
        /// The PrintDocument instance that is used by the printer.
        /// </summary>
        PrintDocument PrintDocument { get; }

        /// <summary>
        /// The PrintPreviewDialog instance that is used by the printer.
        /// </summary>
        PrintPreviewDialog PrintPreviewDialog { get; }

        /// <summary>
        /// The target control.
        /// </summary>
        T TargetControl { get; set; }


        /// <summary>
        /// Print the target control.
        /// </summary>
        void Print();


        /// <summary>
        /// This event is triggered when printing begins.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">Print event arguments.</param>
        void PrintDocument_BeginPrint(object sender, PrintEventArgs e);

        /// <summary>
        /// This event is triggered when printing ends.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">Print event arguments.</param>
        void PrintDocument_EndPrint(object sender, PrintEventArgs e);

        /// <summary>
        /// This event is triggered for each page that is printed.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">Print page event arguments.</param>
        void PrintDocument_PrintPage(object sender, PrintPageEventArgs e);
    }
}
