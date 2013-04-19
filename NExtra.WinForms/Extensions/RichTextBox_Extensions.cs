using System.Windows.Forms;
using NExtra.WinForms.Printing;

namespace NExtra.WinForms.Extensions
{
	/// <summary>
	/// Extension methods for System.Windows.Forms.RichTextBox.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://danielsaidi.github.com/nextra
	/// </remarks>
	public static class RichTextBox_Extensions
	{
		public static void Print(this RichTextBox richTextBox)
		{
			richTextBox.Print(new RichTextBoxPrinter(richTextBox));
		}

        public static void Print(this RichTextBox richTextBox, IControlPrinter<RichTextBox> controlPrinter)
		{
			controlPrinter.TargetControl = richTextBox;
            controlPrinter.Print();
		}
	}
}
