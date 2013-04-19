using System.Drawing.Printing;

namespace NExtra.WinForms.Printing
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can be used as facade classes for a PrintDocument
    /// instance.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IPrintDocumentFacade
    {
        PrintDocument PrintDocument { get; }

        void BindBeginPrintEvent<T>(IControlPrinter<T> controlPrinter);
        void BindPrintPageEvent<T>(IControlPrinter<T> controlPrinter);
        void BindEndPrintEvent<T>(IControlPrinter<T> controlPrinter);
        void Print();
    }
}