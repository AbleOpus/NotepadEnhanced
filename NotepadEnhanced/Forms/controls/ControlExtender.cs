using System.Drawing;
using System.Windows.Forms;

namespace NotepadEnhanced.Forms
{
    /// <summary>
    /// Allows for quick resizing of a <see cref="Control"/>.
    /// </summary>
    class ControlExtender : Control
    {
        private Point lastClick;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlExtender"/> class.
        /// </summary>
        public ControlExtender()
        {
            base.Cursor = Cursors.SizeNS;
            SetStyle(ControlStyles.Selectable, false);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            lastClick = e.Location;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (MouseButtons.Left == e.Button)
            {
                Parent.Height -= e.Y - lastClick.Y;
                Parent.Top += e.Y - lastClick.Y;
            }
        }
    }
}