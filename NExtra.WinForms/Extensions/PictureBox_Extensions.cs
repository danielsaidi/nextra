using System.Windows.Forms;
using NExtra.WinForms.Printing;

namespace NExtra.WinForms.Extensions
{
	/// <summary>
	/// Extension methods for System.Windows.Forms.PictureBox.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://danielsaidi.github.com/nextra
	/// </remarks>
	public static class PictureBox_Extensions
	{
		public static void Print(this PictureBox pictureBox)
		{
			pictureBox.Print(new PictureBoxPrinter(pictureBox));
		}

        public static void Print(this PictureBox pictureBox, IControlPrinter<PictureBox> controlPrinter)
		{
			controlPrinter.TargetControl = pictureBox;
			controlPrinter.Print();
		}
	}
}
