using System.Drawing.Printing;

namespace NExtra.WinForms.Printing
{
    /// <summary>
    /// This class can be used to wrap PrintDocument instances.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class PrintDocumentFacade : IPrintDocumentFacade
    {
        public PrintDocumentFacade(PrintDocument printDocument)
        {
            PrintDocument = printDocument;
        }


        public PrintDocument PrintDocument { get; private set; }


        public void BindBeginPrintEvent<T>(IControlPrinter<T> controlPrinter)
        {
            PrintDocument.BeginPrint += controlPrinter.PrintDocument_BeginPrint;
        }

        public void BindPrintPageEvent<T>(IControlPrinter<T> controlPrinter)
        {
            PrintDocument.PrintPage += controlPrinter.PrintDocument_PrintPage;
        }

        public void BindEndPrintEvent<T>(IControlPrinter<T> controlPrinter)
        {
            PrintDocument.EndPrint += controlPrinter.PrintDocument_EndPrint;
        }

        public void Print()
        {
            PrintDocument.Print();
        }
    }
}