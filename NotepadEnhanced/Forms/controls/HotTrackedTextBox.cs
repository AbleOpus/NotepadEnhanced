using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace NotepadEnhanced.Forms
{
    /// <summary>
    /// Represents a <see cref="TextBox"/> that is hot-tracked.
    /// </summary>
    public class HotTrackedTextBox : TextBox
    {
        private Graphics graphics;
        private bool isPaintRegistered;
        private const int STROKE_SIZE = 1;

        private void Parent_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);

            if (ContainsFocus)
            {
                DrawHotTrack(Brushes.Goldenrod);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!ContainsFocus) DrawHotTrack(Brushes.CornflowerBlue);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!ContainsFocus) ClearHotTrack();
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            DrawHotTrack(Brushes.Goldenrod);
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (graphics == null)
            {
                graphics = Parent.CreateGraphics();
            }

            if (!isPaintRegistered)
            {
                Parent.Paint += Parent_Paint;
                isPaintRegistered = true;
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            ClearHotTrack();
        }

        private void ClearHotTrack()
        {
            Brush brush = new SolidBrush(Parent.BackColor);
            DrawHotTrack(brush);
        }

        private void DrawHotTrack(Brush brush)
        {
            if (graphics != null)
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int xPos = Location.X - STROKE_SIZE;
                int yPos = Location.Y - STROKE_SIZE;
                int width = Size.Width + STROKE_SIZE * 2;
                int height = Size.Height + STROKE_SIZE * 2;
                graphics.FillRectangle(brush, xPos, yPos, width, height);
            }
        }
    }
}