using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using NExtra.WinForms.Printing.Abstractions;
using NExtra.WinForms.Printing.Facades;

namespace NExtra.WinForms.Printing
{
    /// <summary>
    /// This class can be used to print the content of a PictureBox instance.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class PictureBoxPrinter : IControlPrinter<PictureBox>
    {
        private readonly IPageSetupDialogFacade pageSetupDialogFacade;
        private readonly IPrintDialogFacade printDialogFacade;
        private readonly IPrintDocumentFacade printDocumentFacade;
        private readonly IPrintPreviewDialogFacade printPreviewDialogFacade;

        /// <summary>
        /// Create an instance of the class, using default print dialogs.
        /// </summary>
        /// <param name="pictureBox">The PictureBox instance to print.</param>
        public PictureBoxPrinter(PictureBox pictureBox)
            : this(pictureBox, new PageSetupDialogFacade(new PageSetupDialog()), new PrintPreviewDialogFacade(new PrintPreviewDialog()), new PrintDialogFacade(new PrintDialog()), new PrintDocumentFacade(new PrintDocument())) 
        { }

        /// <summary>
        /// Create an instance of the class, using custom print dialogs.
        /// </summary>
        /// <param name="pictureBox">The PictureBox instance to print.</param>
        /// <param name="pageSetupDialog">The PrintPreviewDialog instance to use.</param>
        /// <param name="printPreviewDialog">The PageSetupDialog instance to use.</param>
        /// <param name="printDialog">The PrintDialog instance to use.</param>
        /// <param name="printDocument">The PrintDocument instance to use.</param>
        public PictureBoxPrinter(PictureBox pictureBox, PageSetupDialog pageSetupDialog, PrintPreviewDialog printPreviewDialog, PrintDialog printDialog, PrintDocument printDocument)
            : this(pictureBox, new PageSetupDialogFacade(pageSetupDialog), new PrintPreviewDialogFacade(printPreviewDialog), new PrintDialogFacade(printDialog), new PrintDocumentFacade(printDocument))
        { }

        /// <summary>
        /// Create an instance of the class that is prepared for testing.
        /// </summary>
        /// <param name="pictureBox">The PictureBox instance to print.</param>
        /// <param name="pageSetupDialogFacade">The PrintPreviewDialogFacade instance to use.</param>
        /// <param name="printPreviewDialogFacade">The PageSetupDialogFacade instance to use.</param>
        /// <param name="printDialogFacade">The PrintDialogFacade instance to use.</param>
        /// <param name="printDocumentFacade">The PrintDocumentFacade instance to use.</param>
        public PictureBoxPrinter(PictureBox pictureBox, IPageSetupDialogFacade pageSetupDialogFacade, IPrintPreviewDialogFacade printPreviewDialogFacade, IPrintDialogFacade printDialogFacade, IPrintDocumentFacade printDocumentFacade)
        {
            TargetControl = pictureBox;

            this.pageSetupDialogFacade = pageSetupDialogFacade;
            this.printPreviewDialogFacade = printPreviewDialogFacade;
            this.printDialogFacade = printDialogFacade;
            this.printDocumentFacade = printDocumentFacade;

            this.printDocumentFacade.BindPrintPageEvent(this);
        }


        /// <summary>
        /// The PageSetupDialog instance to use.
        /// </summary>
        public PageSetupDialog PageSetupDialog { get { return pageSetupDialogFacade.PageSetupDialog; } }

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
        /// The control to print.
        /// </summary>
        public PictureBox TargetControl { get; set; }


        /// <summary>
        /// Print the target control.
        /// </summary>
        public void Print()
        {
            if (printDialogFacade.ShowDialog() == DialogResult.OK)
                printDocumentFacade.Print();
        }

        /// <summary>
        /// The event method that is called when the printing begins. 
        /// </summary>
        public void PrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The event method that is called when the printing ends. 
        /// </summary>
        public void PrintDocument_EndPrint(object sender, PrintEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The event method that is called when each page is printed. 
        /// </summary>
        public void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(TargetControl.Image, e.MarginBounds.Left, e.MarginBounds.Top);
            e.HasMorePages = false;
        }
    }
}
