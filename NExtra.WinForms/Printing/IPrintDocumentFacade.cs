using System.Drawing.Printing;

namespace NExtra.WinForms.Printing
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// should be able to be used as facade classes for a
    /// PrintDocument instance.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IPrintDocumentFacade
    {
        /// <summary>
        /// The wrapped PrintDocument instance.
        /// </summary>
        PrintDocument PrintDocument { get; }


        /// <summary>
        /// Bind begin print event for a control printer.
        /// </summary>
        void BindBeginPrintEvent<T>(IControlPrinter<T> controlPrinter);

        /// <summary>
        /// Bind print page event for a control printer.
        /// </summary>
        void BindPrintPageEvent<T>(IControlPrinter<T> controlPrinter);

        /// <summary>
        /// Bind end print event for a control printer.
        /// </summary>
        void BindEndPrintEvent<T>(IControlPrinter<T> controlPrinter);

        /// <summary>
        /// Print the PrintDocument instance.
        /// </summary>
        void Print();
    }
}