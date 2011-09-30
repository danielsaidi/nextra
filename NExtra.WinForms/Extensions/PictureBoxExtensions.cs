using System.Windows.Forms;
using NExtra.WinForms.Printing;
using NExtra.WinForms.Printing.Abstractions;

namespace NExtra.WinForms.Extensions
{
	/// <summary>
	/// Extension methods for System.Windows.Forms.PictureBox.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public static class PictureBoxExtensions
	{
		/// <summary>
        /// Print the control, using a default PictureBoxPrinter instance.
		/// </summary>
		/// <param name="pictureBox">The PictureBox instance to print.</param>
		public static void Print(this PictureBox pictureBox)
		{
			pictureBox.Print(new PictureBoxPrinter(pictureBox));
		}

		/// <summary>
        /// Print the control, using a custom IControlPrinter instance.
		/// </summary>
		/// <param name="pictureBox">The PictureBox instance to print.</param>
        /// <param name="controlPrinter">The IControlPrinter instance to use to print.</param>
        public static void Print(this PictureBox pictureBox, IControlPrinter<PictureBox> controlPrinter)
		{
			controlPrinter.TargetControl = pictureBox;
			controlPrinter.Print();
		}
	}
}
