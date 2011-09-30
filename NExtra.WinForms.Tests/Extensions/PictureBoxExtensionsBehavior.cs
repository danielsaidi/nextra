using System.Windows.Forms;
using NExtra.WinForms.Extensions;
using NExtra.WinForms.Printing.Abstractions;
using NSubstitute;
using NUnit.Framework;

namespace NExtra.WinForms.Tests.Extensions
{
	[TestFixture]
	public class PictureBoxExtensionsBehavior
	{
        [Test]
		public void Print_ShouldBecomeTargetControlAndUseIControlPrinterToPrint()
        {
            var pictureBox = new PictureBox();
		    var printer = Substitute.For<IControlPrinter<PictureBox>>();

            pictureBox.Print(printer);

            Assert.That(printer.TargetControl, Is.EqualTo(pictureBox));
            printer.Received().Print();
		}
	}
}
