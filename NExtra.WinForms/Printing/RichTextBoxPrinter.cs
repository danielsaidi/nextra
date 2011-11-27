using System;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using NExtra.WinForms.Printing.Abstractions;
using NExtra.WinForms.Printing.Facades;

namespace NExtra.WinForms.Printing
{
    /// <summary>
    /// This class can be used to print the content of a RichTextBox instance.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class RichTextBoxPrinter : IControlPrinter<RichTextBox>
    {
        private const double anInch = 14.4;
        private const int WM_USER = 0x0400;
        private const int EM_FORMATRANGE = WM_USER + 57;

        private readonly IPageSetupDialogFacade pageSetupDialogFacade;
        private readonly IPrintDialogFacade printDialogFacade;
        private readonly IPrintDocumentFacade printDocumentFacade;
        private readonly IPrintPreviewDialogFacade printPreviewDialogFacade;

        
        /// <summary>
        /// Create an instance of the class, using default dialogs.
        /// </summary>
        public RichTextBoxPrinter(RichTextBox RichTextBox)
            : this(RichTextBox, new PageSetupDialogFacade(new PageSetupDialog()), new PrintPreviewDialogFacade(new PrintPreviewDialog()), new PrintDialogFacade(new PrintDialog()), new PrintDocumentFacade(new PrintDocument())) 
        { }

        /// <summary>
        /// Create an instance of the class, using custom dialogs.
        /// </summary>
        public RichTextBoxPrinter(RichTextBox RichTextBox, PageSetupDialog pageSetupDialog, PrintPreviewDialog printPreviewDialog, PrintDialog printDialog, PrintDocument printDocument)
            : this(RichTextBox, new PageSetupDialogFacade(pageSetupDialog), new PrintPreviewDialogFacade(printPreviewDialog), new PrintDialogFacade(printDialog), new PrintDocumentFacade(printDocument))
        { }

        /// <summary>
        /// Create an instance of the class, using abstract dialogs.
        /// </summary>
        public RichTextBoxPrinter(RichTextBox RichTextBox, IPageSetupDialogFacade pageSetupDialogFacade, IPrintPreviewDialogFacade printPreviewDialogFacade, IPrintDialogFacade printDialogFacade, IPrintDocumentFacade printDocumentFacade)
        {
            TargetControl = RichTextBox;

            this.pageSetupDialogFacade = pageSetupDialogFacade;
            this.printPreviewDialogFacade = printPreviewDialogFacade;
            this.printDialogFacade = printDialogFacade;
            this.printDocumentFacade = printDocumentFacade;

            this.printDocumentFacade.BindBeginPrintEvent(this);
            this.printDocumentFacade.BindEndPrintEvent(this);
            this.printDocumentFacade.BindPrintPageEvent(this);
        }


        /// <summary>
        /// The PageSetupDialog instance to use.
        /// </summary>
        public PageSetupDialog PageSetupDialog { get { return pageSetupDialogFacade.PageSetupDialog; } }

        /// <summary>
        /// The margins that were used before the latest print operation started.
        /// </summary>
        public Margins PrePrintPrinterMargins { get; private set; }

        /// <summary>
        /// The PrintDialog instance to use.
        /// </summary>
        public PrintDialog PrintDialog { get { return printDialogFacade.PrintDialog; } }

        /// <summary>
        /// The PrintDocument instance to use.
        /// </summary>
        public PrintDocument PrintDocument { get { return printDocumentFacade.PrintDocument; } }

        /// <summary>
        /// The PrintPreviewDialog instance to use.
        /// </summary>
        public PrintPreviewDialog PrintPreviewDialog { get { return printPreviewDialogFacade.PrintPreviewDialog; } }

        /// <summary>
        /// The start index of the latest print operation.
        /// </summary>
        public int RtbCharIndex { get; private set; }

        /// <summary>
        /// The control to print.
        /// </summary>
        public RichTextBox TargetControl { get; set; }


        /// <summary>
        /// Print the target control.
        /// </summary>
        public void Print()
        {
            if (printDialogFacade.ShowDialog() == DialogResult.OK)
                printDocumentFacade.Print();
        }

        /// <summary>
        /// Continue printing the control.
        /// </summary>
        /// <returns>The last character printed + 1 (printing start from this point for next page)</returns>
        public int Print(int charFrom, int charTo, PrintPageEventArgs e)
        {
            //Abort if either charFrom or charTo is invalid
            if (charFrom < 0 || charTo < charFrom)
            {
                e.HasMorePages = false;
                return 0;
            }

            //Calculate the area to render and print
            RECT rectToPrint;
            rectToPrint.Top = (int)(e.MarginBounds.Top * anInch);
            rectToPrint.Bottom = (int)(e.MarginBounds.Bottom * anInch);
            rectToPrint.Left = (int)(e.MarginBounds.Left * anInch);
            rectToPrint.Right = (int)(e.MarginBounds.Right * anInch);

            //Calculate the size of the page
            RECT rectPage;
            rectPage.Top = (int)(e.PageBounds.Top * anInch);
            rectPage.Bottom = (int)(e.PageBounds.Bottom * anInch);
            rectPage.Left = (int)(e.PageBounds.Left * anInch);
            rectPage.Right = (int)(e.PageBounds.Right * anInch);

            //Get handle
            var hdc = e.Graphics.GetHdc();

            //Setup the printing format
            FORMATRANGE fmtRange;
            fmtRange.chrg.cpMax = charTo;
            fmtRange.chrg.cpMin = charFrom;
            fmtRange.hdc = hdc;
            fmtRange.hdcTarget = hdc;
            fmtRange.rc = rectToPrint;
            fmtRange.rcPage = rectPage;

            //Setup window params
            var wparam = new IntPtr(1);

            //Get the pointer to the FORMATRANGE structure in memory
            var lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange));
            Marshal.StructureToPtr(fmtRange, lparam, false);

            //Send the rendered data for printing 
            var res = SendMessage(TargetControl.Handle, EM_FORMATRANGE, wparam, lparam);
            var result = res.ToInt32();

            //Free the block of memory allocated
            Marshal.FreeCoTaskMem(lparam);

            //Release the device context handle obtained by a previous call
            e.Graphics.ReleaseHdc(hdc);
            e.HasMorePages = (result < TargetControl.TextLength);

            //Return last + 1 character printer
            return result;
        }

        /// <summary>
        /// The event method that is called when the printing begins. 
        /// </summary>
        public void PrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            PrePrintPrinterMargins = printDocumentFacade.PrintDocument.DefaultPageSettings.Margins;
            RtbCharIndex = 0;
        }

        /// <summary>
        /// The event method that is called when the printing ends. 
        /// </summary>
        public void PrintDocument_EndPrint(object sender, PrintEventArgs e)
        {
            printDocumentFacade.PrintDocument.DefaultPageSettings.Margins = PrePrintPrinterMargins;
        }

        /// <summary>
        /// The event method that is called when each page is printed. 
        /// </summary>
        public void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.HasMorePages = false;
            RtbCharIndex = Print(RtbCharIndex, TargetControl.TextLength, e);
        }




        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CHARRANGE
        {
            public int cpMin;   //First character of range (0 for start of doc)
            public int cpMax;   //Last character of range (-1 for end of doc)
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct FORMATRANGE
        {
            public IntPtr hdc;          //Actual DC to draw on
            public IntPtr hdcTarget;    //Target DC for determining text formatting
            public RECT rc;             //Region of the DC to draw to (in twips)
            public RECT rcPage;         //Region of the whole DC (page size) (in twips)
            public CHARRANGE chrg;      //Range of text to draw (see earlier declaration)
        }

        [DllImport("USER32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
}