using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using NExtra.WinForms.Dialogs;

namespace NExtra.WinForms.Printing
{
    /// <summary>
    /// This class can be used to print PictureBox content.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class PictureBoxPrinter : IControlPrinter<PictureBox>
    {
        private readonly IPageSetupDialogFacade _pageSetupDialogFacade;
        private readonly IPrintDialogFacade _printDialogFacade;
        private readonly IPrintDocumentFacade _printDocumentFacade;
        private readonly IPrintPreviewDialogFacade _printPreviewDialogFacade;


        public PictureBoxPrinter(PictureBox pictureBox)
            : this(pictureBox, new PageSetupDialogFacade(new PageSetupDialog()), new PrintPreviewDialogFacade(new PrintPreviewDialog()), new PrintDialogFacade(new PrintDialog()), new PrintDocumentFacade(new PrintDocument())) 
        { }

        public PictureBoxPrinter(PictureBox pictureBox, PageSetupDialog pageSetupDialog, PrintPreviewDialog printPreviewDialog, PrintDialog printDialog, PrintDocument printDocument)
            : this(pictureBox, new PageSetupDialogFacade(pageSetupDialog), new PrintPreviewDialogFacade(printPreviewDialog), new PrintDialogFacade(printDialog), new PrintDocumentFacade(printDocument))
        { }

        public PictureBoxPrinter(PictureBox pictureBox, IPageSetupDialogFacade pageSetupDialogFacade, IPrintPreviewDialogFacade printPreviewDialogFacade, IPrintDialogFacade printDialogFacade, IPrintDocumentFacade printDocumentFacade)
        {
            TargetControl = pictureBox;

            _pageSetupDialogFacade = pageSetupDialogFacade;
            _printPreviewDialogFacade = printPreviewDialogFacade;
            _printDialogFacade = printDialogFacade;
            _printDocumentFacade = printDocumentFacade;

            _printDocumentFacade.BindPrintPageEvent(this);
        }


        public PageSetupDialog PageSetupDialog { get { return _pageSetupDialogFacade.PageSetupDialog; } }

        public PrintDialog PrintDialog { get { return _printDialogFacade.PrintDialog; } }

        public PrintDocument PrintDocument { get { return _printDocumentFacade.PrintDocument; } }

        public PrintPreviewDialog PrintPreviewDialog { get { return _printPreviewDialogFacade.PrintPreviewDialog; } }

        public PictureBox TargetControl { get; set; }


        public void Print()
        {
            if (_printDialogFacade.ShowDialog() == DialogResult.OK)
                _printDocumentFacade.Print();
        }

        public void PrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void PrintDocument_EndPrint(object sender, PrintEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(TargetControl.Image, e.MarginBounds.Left, e.MarginBounds.Top);
            e.HasMorePages = false;
        }
    }
}
