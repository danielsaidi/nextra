using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using NExtra.WinForms.Dialogs;
using NExtra.WinForms.Printing;
using NSubstitute;
using NUnit.Framework;

namespace NExtra.WinForms.Tests.Printing
{
    [TestFixture]
    public class PictureBoxPrinterBehavior
    {
        private PictureBoxPrinter _printer;
        private PictureBox _pictureBox;
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
            _pictureBox = new PictureBox();
            _pageSetupDialog = new PageSetupDialog();
            _pageSetupDialogFacade = Substitute.For<IPageSetupDialogFacade>();
            _printDialog = new PrintDialog();
            _printDialogFacade = Substitute.For<IPrintDialogFacade>();
            _printDocument = new PrintDocument();
            _printDocumentFacade = Substitute.For<IPrintDocumentFacade>();
            _printPreviewDialog = new PrintPreviewDialog();
            _printPreviewDialogFacade = Substitute.For<IPrintPreviewDialogFacade>();

            _printer = new PictureBoxPrinter(_pictureBox, _pageSetupDialogFacade, _printPreviewDialogFacade, _printDialogFacade, _printDocumentFacade);
        }


        [Test]
        public void Constructor_ShouldCreateDefaultInstance()
        {
            _printer = new PictureBoxPrinter(_pictureBox);

            Assert.That(_printer.TargetControl, Is.EqualTo(_pictureBox));
        }

        [Test]
        public void Constructor_ShouldCreateCustomInstance()
        {
            _printer = new PictureBoxPrinter(_pictureBox, _pageSetupDialog, _printPreviewDialog, _printDialog, _printDocument);

            Assert.That(_printer.TargetControl, Is.EqualTo(_pictureBox));
            Assert.That(_printer.PageSetupDialog, Is.EqualTo(_pageSetupDialog));
            Assert.That(_printer.PrintPreviewDialog, Is.EqualTo(_printPreviewDialog));
            Assert.That(_printer.PrintDialog, Is.EqualTo(_printDialog));
            Assert.That(_printer.PrintDocument, Is.EqualTo(_printDocument));
        }

        [Test]
        public void Constructor_ShouldCreateTestInstance()
        {
            new PictureBoxPrinter(_pictureBox, _pageSetupDialogFacade, _printPreviewDialogFacade, _printDialogFacade, _printDocumentFacade);
        }

        [Test]
        public void Constructor_ShouldOnlyBindBeginPrintEvent()
        {
            _printer = new PictureBoxPrinter(_pictureBox, _pageSetupDialogFacade, _printPreviewDialogFacade, _printDialogFacade, _printDocumentFacade);
            
            _printDocumentFacade.DidNotReceive().BindBeginPrintEvent(Arg.Any<IControlPrinter<PictureBox>>());
            _printDocumentFacade.DidNotReceive().BindEndPrintEvent(Arg.Any<IControlPrinter<PictureBox>>());
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


        [Test, ExpectedException(typeof(NotImplementedException))]
        public void PrintDocument_BeginPrint_ShouldNotBeImplemented()
        {
            _printer.PrintDocument_BeginPrint(_printer, new PrintEventArgs());
        }

        [Test, ExpectedException(typeof(NotImplementedException))]
        public void PrintDocument_EndPrint_ShouldNotBeImplemented()
        {
            _printer.PrintDocument_EndPrint(_printer, new PrintEventArgs());
        }
    }
}