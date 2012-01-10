using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NExtra.WinForms.Controls
{
    /// <summary>
    /// This control inherits System.Windows.Forms.Panel
    /// and adds the posibility to apply rounded corners.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public class RoundedCornersPanel : Panel
    {
        /// <summary>
        /// Create an instance of the control.
        /// </summary>
        public RoundedCornersPanel()
        {
            CornerRadius = 20;
        }


        /// <summary>
        /// The corner radius to apply to the panel.
        /// </summary>
        public int CornerRadius { get; set; }


        /// <summary>
        /// Raises the paint event.
        /// </summary>
        /// <param name="e">Paint event arguments.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            var ptr = CreateRoundRectRgn(0, 0, Width, Height, CornerRadius, CornerRadius);
            Region = Region.FromHrgn(ptr);
            DeleteObject(ptr);

            base.OnPaint(e);
        }


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern System.IntPtr CreateRoundRectRgn
        (
         int nLeftRect, // x-coordinate of upper-left corner
         int nTopRect, // y-coordinate of upper-left corner
         int nRightRect, // x-coordinate of lower-right corner
         int nBottomRect, // y-coordinate of lower-right corner
         int nWidthEllipse, // height of ellipse
         int nHeightEllipse // width of ellipse
        );

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        private static extern bool DeleteObject(System.IntPtr hObject);
    }
}
