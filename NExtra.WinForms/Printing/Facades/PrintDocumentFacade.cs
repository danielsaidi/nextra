using System.Drawing.Printing;
using NExtra.WinForms.Printing.Abstractions;

namespace NExtra.WinForms.Printing.Facades
{
    /// <summary>
    /// This class can be used as facade for the PrintDocument
    /// class, to simplify unit testing.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class PrintDocumentFacade : IPrintDocumentFacade
    {
        /// <summary>
        /// Create an instance of the class.
        /// </summary>
        /// <param name="printDocument">The base instance to wrap.</param>
        public PrintDocumentFacade(PrintDocument printDocument)
        {
            PrintDocument = printDocument;
        }


        /// <summary>
        /// The base instance that is wrapped within the facade.
        /// </summary>
        public PrintDocument PrintDocument { get; private set; }


        /// <summary>
        /// Bind the BeginPrint event of the wrapped base instance.
        /// </summary>
        /// <param name="controlPrinter">The IControlPrinter that handles printing.</param>
        public void BindBeginPrintEvent<T>(IControlPrinter<T> controlPrinter)
        {
            PrintDocument.BeginPrint += controlPrinter.PrintDocument_BeginPrint;
        }

        /// <summary>
        /// Bind the PrintPage event of the wrapped base instance.
        /// </summary>
        /// <param name="controlPrinter">The IControlPrinter that handles printing.</param>
        public void BindPrintPageEvent<T>(IControlPrinter<T> controlPrinter)
        {
            PrintDocument.PrintPage += controlPrinter.PrintDocument_PrintPage;
        }

        /// <summary>
        /// Bind the EndPrint event of the wrapped base instance.
        /// </summary>
        /// <param name="controlPrinter">The IControlPrinter that handles printing.</param>
        public void BindEndPrintEvent<T>(IControlPrinter<T> controlPrinter)
        {
            PrintDocument.EndPrint += controlPrinter.PrintDocument_EndPrint;
        }

        /// <summary>
        /// Print the PrintDocument instance.
        /// </summary>
        public void Print()
        {
            PrintDocument.Print();
        }
    }
}