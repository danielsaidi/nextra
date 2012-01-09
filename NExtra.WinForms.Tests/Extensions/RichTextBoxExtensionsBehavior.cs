using System.Windows.Forms;
using NExtra.WinForms.Extensions;
using NExtra.WinForms.Printing;
using NSubstitute;
using NUnit.Framework;

namespace NExtra.WinForms.Tests.Extensions
{
	[TestFixture]
	public class RichTextBoxExtensionsBehavior
	{
        [Test]
        public void Print_ShouldBecomeTargetControlAndUseIControlPrinterToPrint()
        {
            Castle.DynamicProxy.Generators.AttributesToAvoidReplicating.Add(
                typeof (System.Security.Permissions.UIPermissionAttribute));

            var richTextBox = new RichTextBox();
            var printer = Substitute.For<IControlPrinter<RichTextBox>>();

            richTextBox.Print(printer);

            Assert.That(printer.TargetControl, Is.EqualTo(richTextBox));
            printer.Received().Print();
        }
	}
}
