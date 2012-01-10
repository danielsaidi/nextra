using System.Drawing.Printing;

namespace NExtra.WinForms.Printing
{
    /// <summary>
    /// This class can be used as facade for the
    /// PrintDocument class.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public class PrintDocumentFacade : IPrintDocumentFacade
    {
        /// <summary>
        /// Create an instance of the class.
        /// </summary>
        public PrintDocumentFacade(PrintDocument printDocument)
        {
            PrintDocument = printDocument;
        }


        /// <summary>
        /// The print document that is wrapped by the facade.
        /// </summary>
        public PrintDocument PrintDocument { get; private set; }


        /// <summary>
        /// Bind the BeginPrint event of the wrapped base instance.
        /// </summary>
        public void BindBeginPrintEvent<T>(IControlPrinter<T> controlPrinter)
        {
            PrintDocument.BeginPrint += controlPrinter.PrintDocument_BeginPrint;
        }

        /// <summary>
        /// Bind the PrintPage event of the wrapped base instance.
        /// </summary>
        public void BindPrintPageEvent<T>(IControlPrinter<T> controlPrinter)
        {
            PrintDocument.PrintPage += controlPrinter.PrintDocument_PrintPage;
        }

        /// <summary>
        /// Bind the EndPrint event of the wrapped base instance.
        /// </summary>
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