using System.Drawing.Printing;
using System.Windows.Forms;
using NExtra.WinForms.Dialogs;
using NExtra.WinForms.Printing;
using NSubstitute;
using NUnit.Framework;

namespace NExtra.WinForms.Tests.Printing
{
    [TestFixture]
    public class RichTextBoxPrinterBehavior
    {
        private RichTextBoxPrinter _printer;
        private RichTextBox _richTextBox;
        private PageSetupDialog _pageSetupDialog;
        private IPageSetupDialogFacade _pageSetupDialogFacade;
        private PrintDialog _printDialog;
        private IPrintDialogFacade _printDialogFacade;
        private PrintDocument _printDocument;
        private IPrintDocumentFacade _printDocumentFacade;
        private PrintPreviewDialog _printPreviewDialog;
        private IPrintPreviewDialogFacade _printPreviewDialogFacade;


        [SetUp]
        public void SetUp()
        {
            _richTextBox = new RichTextBox();

            _pageSetupDialog = new PageSetupDialog();
            _pageSetupDialogFacade = Substitute.For<IPageSetupDialogFacade>();
            _pageSetupDialogFacade.PageSetupDialog.Returns(_pageSetupDialog);
            
            _printDialog = new PrintDialog();
            _printDialogFacade = Substitute.For<IPrintDialogFacade>();
            _printDialogFacade.PrintDialog.Returns(_printDialog);
            
            _printDocument = new PrintDocument { DefaultPageSettings = {Margins = new Margins(10, 20, 30, 40)}};
            _printDocumentFacade = Substitute.For<IPrintDocumentFacade>();
            _printDocumentFacade.PrintDocument.Returns(_printDocument);
            
            _printPreviewDialog = new PrintPreviewDialog();
            _printPreviewDialogFacade = Substitute.For<IPrintPreviewDialogFacade>();
            _printPreviewDialogFacade.PrintPreviewDialog.Returns(_printPreviewDialog);

            _printer = new RichTextBoxPrinter(_richTextBox, _pageSetupDialogFacade, _printPreviewDialogFacade, _printDialogFacade, _printDocumentFacade);
        }


        [Test]
        public void Constructor_ShouldCreateDefaultInstance()
        {
            _printer = new RichTextBoxPrinter(_richTextBox);

            Assert.That(_printer.TargetControl, Is.EqualTo(_richTextBox));
        }

        [Test]
        public void Constructor_ShouldCreateCustomInstance()
        {
            _printer = new RichTextBoxPrinter(_richTextBox, _pageSetupDialog, _printPreviewDialog, _printDialog, _printDocument);

            Assert.That(_printer.TargetControl, Is.EqualTo(_richTextBox));
            Assert.That(_printer.PageSetupDialog, Is.EqualTo(_pageSetupDialog));
            Assert.That(_printer.PrintPreviewDialog, Is.EqualTo(_printPreviewDialog));
            Assert.That(_printer.PrintDialog, Is.EqualTo(_printDialog));
            Assert.That(_printer.PrintDocument, Is.EqualTo(_printDocument));
        }

        [Test]
        public void Constructor_ShouldCreateTestInstance()
        {
            new RichTextBoxPrinter(_richTextBox, _pageSetupDialogFacade, _printPreviewDialogFacade, _printDialogFacade, _printDocumentFacade);
        }

        [Test]
        public void Constructor_ShouldOnlyBindBeginPrintEvent()
        {
            _printer = new RichTextBoxPrinter(_richTextBox, _pageSetupDialogFacade, _printPreviewDialogFacade, _printDialogFacade, _printDocumentFacade);

            _printDocumentFacade.Received().BindBeginPrintEvent(_printer);
            _printDocumentFacade.Received().BindEndPrintEvent(_printer);
            _printDocumentFacade.Received().BindPrintPageEvent(_printer);
        }


        [Test]
        public void Print_ShouldNotPrintIfPrintDialogResultIsNotOK()
        {
            _printDialogFacade.ShowDialog().Returns(DialogResult.Abort);
            _printer.Print();
            _printDocumentFacade.DidNotReceive().Print();

            _printDialogFacade.ShowDialog().Returns(DialogResult.Cancel);
            _printer.Print();
            _printDocumentFacade.DidNotReceive().Print();

            _printDialogFacade.ShowDialog().Returns(DialogResult.Ignore);
            _printer.Print();
            _printDocumentFacade.DidNotReceive().Print();

            _printDialogFacade.ShowDialog().Returns(DialogResult.No);
            _printer.Print();
            _printDocumentFacade.DidNotReceive().Print();

            _printDialogFacade.ShowDialog().Returns(DialogResult.None);
            _printer.Print();
            _printDocumentFacade.DidNotReceive().Print();

            _printDialogFacade.ShowDialog().Returns(DialogResult.Retry);
            _printer.Print();
            _printDocumentFacade.DidNotReceive().Print();

            _printDialogFacade.ShowDialog().Returns(DialogResult.Yes);
            _printer.Print();
            _printDocumentFacade.DidNotReceive().Print();
        }

        [Test]
        public void Print_ShouldPrintIfPrintDialogResultIsOK()
        {
            _printDialogFacade.ShowDialog().Returns(DialogResult.OK);
            _printer.Print();
            _printDocumentFacade.Received().Print();
        }


        [Test]
        public void PrintDocument_BeginPrint_ShouldSetPrinterMarginsAndRtbCharIndex()
        {
            _printer.PrintDocument_BeginPrint(_printer, new PrintEventArgs());

            Assert.That(_printer.PrePrintPrinterMargins, Is.EqualTo(new Margins(10, 20, 30, 40)));
            Assert.That(_printer.RtbCharIndex, Is.EqualTo(0));
        }

        [Test]
        public void PrintDocument_EndPrint_ShouldRestorePrinterMargins()
        {
            _printer.PrintDocument_BeginPrint(_printer, new PrintEventArgs());
            _printer.PrintDocument.DefaultPageSettings.Margins = new Margins(20, 30, 40, 50);
            _printer.PrintDocument_EndPrint(_printer, new PrintEventArgs());

            Assert.That(_printer.PrintDocument.DefaultPageSettings.Margins, Is.EqualTo(new Margins(10, 20, 30, 40)));
        }

        [Test, Ignore]
        public void Todo_PrintDocument_PrintPage_ShouldCallPrivateMethodUntilPrintingIsDone()
        {
        }
    }
}