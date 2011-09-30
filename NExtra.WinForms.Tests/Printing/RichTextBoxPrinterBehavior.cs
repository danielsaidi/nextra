using System.Drawing.Printing;
using System.Windows.Forms;
using NExtra.WinForms.Printing;
using NExtra.WinForms.Printing.Abstractions;
using NSubstitute;
using NUnit.Framework;

namespace NExtra.WinForms.Tests.Printing
{
    [TestFixture]
    public class RichTextBoxPrinterBehavior
    {
        private RichTextBoxPrinter printer;
        private RichTextBox richTextBox;
        private PageSetupDialog pageSetupDialog;
        private IPageSetupDialogFacade pageSetupDialogFacade;
        private PrintDialog printDialog;
        private IPrintDialogFacade printDialogFacade;
        private PrintDocument printDocument;
        private IPrintDocumentFacade printDocumentFacade;
        private PrintPreviewDialog printPreviewDialog;
        private IPrintPreviewDialogFacade printPreviewDialogFacade;


        [SetUp]
        public void SetUp()
        {
            richTextBox = new RichTextBox();

            pageSetupDialog = new PageSetupDialog();
            pageSetupDialogFacade = Substitute.For<IPageSetupDialogFacade>();
            pageSetupDialogFacade.PageSetupDialog.Returns(pageSetupDialog);
            
            printDialog = new PrintDialog();
            printDialogFacade = Substitute.For<IPrintDialogFacade>();
            printDialogFacade.PrintDialog.Returns(printDialog);
            
            printDocument = new PrintDocument { DefaultPageSettings = {Margins = new Margins(10, 20, 30, 40)}};
            printDocumentFacade = Substitute.For<IPrintDocumentFacade>();
            printDocumentFacade.PrintDocument.Returns(printDocument);
            
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialogFacade = Substitute.For<IPrintPreviewDialogFacade>();
            printPreviewDialogFacade.PrintPreviewDialog.Returns(printPreviewDialog);

            printer = new RichTextBoxPrinter(richTextBox, pageSetupDialogFacade, printPreviewDialogFacade, printDialogFacade, printDocumentFacade);
        }


        [Test]
        public void Constructor_ShouldCreateDefaultInstance()
        {
            printer = new RichTextBoxPrinter(richTextBox);

            Assert.That(printer.TargetControl, Is.EqualTo(richTextBox));
        }

        [Test]
        public void Constructor_ShouldCreateCustomInstance()
        {
            printer = new RichTextBoxPrinter(richTextBox, pageSetupDialog, printPreviewDialog, printDialog, printDocument);

            Assert.That(printer.TargetControl, Is.EqualTo(richTextBox));
            Assert.That(printer.PageSetupDialog, Is.EqualTo(pageSetupDialog));
            Assert.That(printer.PrintPreviewDialog, Is.EqualTo(printPreviewDialog));
            Assert.That(printer.PrintDialog, Is.EqualTo(printDialog));
            Assert.That(printer.PrintDocument, Is.EqualTo(printDocument));
        }

        [Test]
        public void Constructor_ShouldCreateTestInstance()
        {
            new RichTextBoxPrinter(richTextBox, pageSetupDialogFacade, printPreviewDialogFacade, printDialogFacade, printDocumentFacade);
        }

        [Test]
        public void Constructor_ShouldOnlyBindBeginPrintEvent()
        {
            printer = new RichTextBoxPrinter(richTextBox, pageSetupDialogFacade, printPreviewDialogFacade, printDialogFacade, printDocumentFacade);

            printDocumentFacade.Received().BindBeginPrintEvent(printer);
            printDocumentFacade.Received().BindEndPrintEvent(printer);
            printDocumentFacade.Received().BindPrintPageEvent(printer);
        }


        [Test]
        public void Print_ShouldNotPrintIfPrintDialogResultIsNotOK()
        {
            printDialogFacade.ShowDialog().Returns(DialogResult.Abort);
            printer.Print();
            printDocumentFacade.DidNotReceive().Print();

            printDialogFacade.ShowDialog().Returns(DialogResult.Cancel);
            printer.Print();
            printDocumentFacade.DidNotReceive().Print();

            printDialogFacade.ShowDialog().Returns(DialogResult.Ignore);
            printer.Print();
            printDocumentFacade.DidNotReceive().Print();

            printDialogFacade.ShowDialog().Returns(DialogResult.No);
            printer.Print();
            printDocumentFacade.DidNotReceive().Print();

            printDialogFacade.ShowDialog().Returns(DialogResult.None);
            printer.Print();
            printDocumentFacade.DidNotReceive().Print();

            printDialogFacade.ShowDialog().Returns(DialogResult.Retry);
            printer.Print();
            printDocumentFacade.DidNotReceive().Print();

            printDialogFacade.ShowDialog().Returns(DialogResult.Yes);
            printer.Print();
            printDocumentFacade.DidNotReceive().Print();
        }

        [Test]
        public void Print_ShouldPrintIfPrintDialogResultIsOK()
        {
            printDialogFacade.ShowDialog().Returns(DialogResult.OK);
            printer.Print();
            printDocumentFacade.Received().Print();
        }


        [Test]
        public void PrintDocument_BeginPrint_ShouldSetPrinterMarginsAndRtbCharIndex()
        {
            printer.PrintDocument_BeginPrint(printer, new PrintEventArgs());

            Assert.That(printer.PrePrintPrinterMargins, Is.EqualTo(new Margins(10, 20, 30, 40)));
            Assert.That(printer.RtbCharIndex, Is.EqualTo(0));
        }

        [Test]
        public void PrintDocument_EndPrint_ShouldRestorePrinterMargins()
        {
            printer.PrintDocument_BeginPrint(printer, new PrintEventArgs());
            printer.PrintDocument.DefaultPageSettings.Margins = new Margins(20, 30, 40, 50);
            printer.PrintDocument_EndPrint(printer, new PrintEventArgs());

            Assert.That(printer.PrintDocument.DefaultPageSettings.Margins, Is.EqualTo(new Margins(10, 20, 30, 40)));
        }

        [Test, Ignore]
        public void Todo_PrintDocument_PrintPage_ShouldCallPrivateMethodUntilPrintingIsDone()
        {
        }
    }
}