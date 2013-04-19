using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NExtra.WinForms.Controls
{
    /// <summary>
    /// This control inherits System.Windows.Forms.Panel
    /// and adds the ability to apply rounded corners to
    /// the panel.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class RoundedCornersPanel : Panel
    {
        public RoundedCornersPanel()
            : this(20)
        {
        }

        public RoundedCornersPanel(int cornerRadius)
        {
            CornerRadius = cornerRadius;
        }


        public int CornerRadius { get; set; }


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
