using System.Drawing.Printing;
using System.Windows.Forms;

namespace NExtra.WinForms.Printing
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can be used to print a certain type of control.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IControlPrinter<T>
    {
        PageSetupDialog PageSetupDialog { get; }
        PrintDialog PrintDialog { get; }
        PrintDocument PrintDocument { get; }
        PrintPreviewDialog PrintPreviewDialog { get; }
        T TargetControl { get; set; }

        void Print();
        
        void PrintDocument_BeginPrint(object sender, PrintEventArgs e);
        void PrintDocument_EndPrint(object sender, PrintEventArgs e);
        void PrintDocument_PrintPage(object sender, PrintPageEventArgs e);
    }
}
