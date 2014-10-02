using System;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using NExtra.WinForms.Dialogs;

namespace NExtra.WinForms.Printing
{
    /// <summary>
    /// This class can be used to print RichTextBox content.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class RichTextBoxPrinter : IControlPrinter<RichTextBox>
    {
        private const double AnInch = 14.4;
        private const int WmUser = 0x0400;
        private const int EmFormatrange = WmUser + 57;

        private readonly IPageSetupDialogFacade _pageSetupDialogFacade;
        private readonly IPrintDialogFacade _printDialogFacade;
        private readonly IPrintDocumentFacade _printDocumentFacade;
        private readonly IPrintPreviewDialogFacade _printPreviewDialogFacade;

        
        public RichTextBoxPrinter(RichTextBox richTextBox)
            : this(richTextBox, new PageSetupDialogFacade(new PageSetupDialog()), new PrintPreviewDialogFacade(new PrintPreviewDialog()), new PrintDialogFacade(new PrintDialog()), new PrintDocumentFacade(new PrintDocument())) 
        { }

        public RichTextBoxPrinter(RichTextBox richTextBox, PageSetupDialog pageSetupDialog, PrintPreviewDialog printPreviewDialog, PrintDialog printDialog, PrintDocument printDocument)
            : this(richTextBox, new PageSetupDialogFacade(pageSetupDialog), new PrintPreviewDialogFacade(printPreviewDialog), new PrintDialogFacade(printDialog), new PrintDocumentFacade(printDocument))
        { }

        public RichTextBoxPrinter(RichTextBox richTextBox, IPageSetupDialogFacade pageSetupDialogFacade, IPrintPreviewDialogFacade printPreviewDialogFacade, IPrintDialogFacade printDialogFacade, IPrintDocumentFacade printDocumentFacade)
        {
            TargetControl = richTextBox;

            _pageSetupDialogFacade = pageSetupDialogFacade;
            _printPreviewDialogFacade = printPreviewDialogFacade;
            _printDialogFacade = printDialogFacade;
            _printDocumentFacade = printDocumentFacade;

            _printDocumentFacade.BindBeginPrintEvent(this);
            _printDocumentFacade.BindEndPrintEvent(this);
            _printDocumentFacade.BindPrintPageEvent(this);
        }


        public PageSetupDialog PageSetupDialog { get { return _pageSetupDialogFacade.PageSetupDialog; } }

        public Margins PrePrintPrinterMargins { get; private set; }

        public PrintDialog PrintDialog { get { return _printDialogFacade.PrintDialog; } }

        public PrintDocument PrintDocument { get { return _printDocumentFacade.PrintDocument; } }

        public PrintPreviewDialog PrintPreviewDialog { get { return _printPreviewDialogFacade.PrintPreviewDialog; } }

        public int RtbCharIndex { get; private set; }

        public RichTextBox TargetControl { get; set; }


        public void Print()
        {
            if (_printDialogFacade.ShowDialog() == DialogResult.OK)
                _printDocumentFacade.Print();
        }

        public int Print(int charFrom, int charTo, PrintPageEventArgs e)
        {
            //Abort if either charFrom or charTo is invalid
            if (charFrom < 0 || charTo < charFrom)
            {
                e.HasMorePages = false;
                return 0;
            }

            //Get handle
            var hdc = e.Graphics.GetHdc();

            //Setup the printing format
            var fmtRange = Print_GetFmtRange(charFrom, charTo, e, hdc);

            //Setup window params
            var wparam = new IntPtr(1);

            //Get the pointer to the FORMATRANGE structure in memory
            var lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange));
            Marshal.StructureToPtr(fmtRange, lparam, false);

            //Send the rendered data for printing 
            var result = SendMessage(TargetControl.Handle, EmFormatrange, wparam, lparam).ToInt32();

            //Free the block of memory allocated
            Marshal.FreeCoTaskMem(lparam);

            //Release the device context handle obtained by a previous call
            e.Graphics.ReleaseHdc(hdc);
            e.HasMorePages = (result < TargetControl.TextLength);

            //Return last + 1 character printer
            return result;
        }

        private static FormatRange Print_GetFmtRange(int charFrom, int charTo, PrintPageEventArgs e, IntPtr hdc)
        {
            FormatRange fmtRange;
            fmtRange.chrg.cpMax = charTo;
            fmtRange.chrg.cpMin = charFrom;
            fmtRange.hdc = hdc;
            fmtRange.hdcTarget = hdc;
            fmtRange.rc = Print_GetRectToPrint(e);
            fmtRange.rcPage = Print_GetRectPage(e);
            return fmtRange;
        }

        private static Rect Print_GetRectPage(PrintPageEventArgs e)
        {
            Rect rectPage;
            rectPage.Top = (int)(e.PageBounds.Top * AnInch);
            rectPage.Bottom = (int)(e.PageBounds.Bottom * AnInch);
            rectPage.Left = (int)(e.PageBounds.Left * AnInch);
            rectPage.Right = (int)(e.PageBounds.Right * AnInch);
            return rectPage;
        }

        private static Rect Print_GetRectToPrint(PrintPageEventArgs e)
        {
            Rect rectToPrint;
            rectToPrint.Top = (int)(e.MarginBounds.Top * AnInch);
            rectToPrint.Bottom = (int)(e.MarginBounds.Bottom * AnInch);
            rectToPrint.Left = (int)(e.MarginBounds.Left * AnInch);
            rectToPrint.Right = (int)(e.MarginBounds.Right * AnInch);
            return rectToPrint;
        }

        
        public void PrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            PrePrintPrinterMargins = _printDocumentFacade.PrintDocument.DefaultPageSettings.Margins;
            RtbCharIndex = 0;
        }

        public void PrintDocument_EndPrint(object sender, PrintEventArgs e)
        {
            _printDocumentFacade.PrintDocument.DefaultPageSettings.Margins = PrePrintPrinterMargins;
        }

        public void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.HasMorePages = false;
            RtbCharIndex = Print(RtbCharIndex, TargetControl.TextLength, e);
        }



        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CharRange
        {
            public int cpMin;   //First character of range (0 for start of doc)
            public int cpMax;   //Last character of range (-1 for end of doc)
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct FormatRange
        {
            public IntPtr hdc;          //Actual DC to draw on
            public IntPtr hdcTarget;    //Target DC for determining text formatting
            public Rect rc;             //Region of the DC to draw to (in twips)
            public Rect rcPage;         //Region of the whole DC (page size) (in twips)
            public CharRange chrg;      //Range of text to draw (see earlier declaration)
        }

        [DllImport("USER32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
}