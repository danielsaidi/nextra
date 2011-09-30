using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using NExtra.WinForms.Printing;
using NExtra.WinForms.Printing.Abstractions;
using NSubstitute;
using NUnit.Framework;

namespace NExtra.WinForms.Tests.Printing
{
    [TestFixture]
    public class PictureBoxPrinterBehavior
    {
        private PictureBoxPrinter printer;
        private PictureBox pictureBox;
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
            pictureBox = new PictureBox();
            pageSetupDialog = new PageSetupDialog();
            pageSetupDialogFacade = Substitute.For<IPageSetupDialogFacade>();
            printDialog = new PrintDialog();
            printDialogFacade = Substitute.For<IPrintDialogFacade>();
            printDocument = new PrintDocument();
            printDocumentFacade = Substitute.For<IPrintDocumentFacade>();
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialogFacade = Substitute.For<IPrintPreviewDialogFacade>();

            printer = new PictureBoxPrinter(pictureBox, pageSetupDialogFacade, printPreviewDialogFacade, printDialogFacade, printDocumentFacade);
        }


        [Test]
        public void Constructor_ShouldCreateDefaultInstance()
        {
            printer = new PictureBoxPrinter(pictureBox);

            Assert.That(printer.TargetControl, Is.EqualTo(pictureBox));
        }

        [Test]
        public void Constructor_ShouldCreateCustomInstance()
        {
            printer = new PictureBoxPrinter(pictureBox, pageSetupDialog, printPreviewDialog, printDialog, printDocument);

            Assert.That(printer.TargetControl, Is.EqualTo(pictureBox));
            Assert.That(printer.PageSetupDialog, Is.EqualTo(pageSetupDialog));
            Assert.That(printer.PrintPreviewDialog, Is.EqualTo(printPreviewDialog));
            Assert.That(printer.PrintDialog, Is.EqualTo(printDialog));
            Assert.That(printer.PrintDocument, Is.EqualTo(printDocument));
        }

        [Test]
        public void Constructor_ShouldCreateTestInstance()
        {
            new PictureBoxPrinter(pictureBox, pageSetupDialogFacade, printPreviewDialogFacade, printDialogFacade, printDocumentFacade);
        }

        [Test]
        public void Constructor_ShouldOnlyBindBeginPrintEvent()
        {
            printer = new PictureBoxPrinter(pictureBox, pageSetupDialogFacade, printPreviewDialogFacade, printDialogFacade, printDocumentFacade);

            printDocumentFacade.DidNotReceive().BindBeginPrintEvent(Arg.Any<IControlPrinter<PictureBox>>());
            printDocumentFacade.DidNotReceive().BindEndPrintEvent(Arg.Any<IControlPrinter<PictureBox>>());
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


        [Test, ExpectedException(typeof(NotImplementedException))]
        public void PrintDocument_BeginPrint_ShouldNotBeImplemented()
        {
            printer.PrintDocument_BeginPrint(printer, new PrintEventArgs());
        }

        [Test, ExpectedException(typeof(NotImplementedException))]
        public void PrintDocument_EndPrint_ShouldNotBeImplemented()
        {
            printer.PrintDocument_EndPrint(printer, new PrintEventArgs());
        }
    }
}