using System.Windows.Forms;
using NExtra.WinForms.Printing;
using NExtra.WinForms.Printing.Abstractions;

namespace NExtra.WinForms.Extensions
{
	/// <summary>
	/// Extension methods for System.Windows.Forms.RichTextBox.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public static class RichTextBoxExtensions
	{
		/// <summary>
		/// Print the control, using a default ControlPrinter instance.
		/// </summary>
		public static void Print(this RichTextBox richTextBox)
		{
			richTextBox.Print(new RichTextBoxPrinter(richTextBox));
		}

		/// <summary>
        /// Print the control, using a custom IControlPrinter instance.
		/// </summary>
        public static void Print(this RichTextBox richTextBox, IControlPrinter<RichTextBox> controlPrinter)
		{
			controlPrinter.TargetControl = richTextBox;
            controlPrinter.Print();
		}
	}
}
