/* 
 * Custom progressbar to have a different progress bar colour.
 */

 // TODO: Add a property to be able to select the colour.
using System.Drawing;
using System.Windows.Forms;

namespace ClassLibrary.User_Controls
{
    public partial class ProgressBarColor : ProgressBar
    {
        public ProgressBarColor()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = e.ClipRectangle;

            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            rec.Height = rec.Height - 4;
            e.Graphics.FillRectangle(Brushes.Maroon, 2, 2, rec.Width, rec.Height);
        }
    }
}