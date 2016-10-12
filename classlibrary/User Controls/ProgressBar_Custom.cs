using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ClassLibrary.User_Controls
{
    /// <summary>
    /// Custom progressbar with the following features:
    /// - Change progressbar colour
    /// </summary>
    public partial class ProgressBar_Custom : ProgressBar
    {
        private Color _progressbarColor;

        public ProgressBar_Custom()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        [Description("Choose a custom colour for the progressbar"), Category("Appearance")]
        public Color ProgressbarColor
        {
            get { return _progressbarColor; }
            set { _progressbarColor = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = e.ClipRectangle;
            SolidBrush brush = new SolidBrush(_progressbarColor);

            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            rec.Height = rec.Height - 4;
            e.Graphics.FillRectangle(brush, 2, 2, rec.Width, rec.Height);
        }
    }
}