using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NotepadEnhanced.Forms
{
    /// <summary>
    /// Represents a Label with extended scrolling abilities.
    /// </summary>
    public partial class ScrollingLabel : UserControl
    {
        private Point lastPos; // Last click positions
        private int lineHeight;

        #region Properties
        // The controls font will be that of the labels
        public override Font Font
        {
            get { return base.Font; }
            set { label.Font = value; }
        }

        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                panelInner.BackColor = value;
                label.BackColor = value;
            }
        }

        // The controls fore-color will be that of the labels
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { label.ForeColor = value; }
        }

        /// <summary>
        /// Gets or sets the sum of right and left padding for this control.
        /// </summary>
        [Description("The sum of right and left padding for this control.")]
        [Category("Layout")]
        public int HorizontalPadding
        {
            get { return Padding.Right; }
            set
            {
                Padding = new Padding(value, Padding.Top, value, Padding.Bottom);
            }
        }

        /// <summary>
        /// Gets or sets the sum of top and bottom padding for this control.
        /// </summary>
        [Description("The sum of top and bottom padding for this control.")]
        [Category("Layout")]
        public int VerticalPadding
        {
            get { return Padding.Top; }
            set
            {
                Padding = new Padding(Padding.Left, value, Padding.Right, value);
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrollingLabel"/> class.
        /// </summary>
        public ScrollingLabel()
        {
            InitializeComponent();
            base.DoubleBuffered = true;
            ResizeRedraw = true;
            SetFontHeight();
        }

        private void panelInner_SizeChanged(object sender, EventArgs e)
        {
            label.MaximumSize = new Size(panelInner.ClientSize.Width, 0);
            CheckBoundarys();
        }

        private void label_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                label.Top += e.Y - lastPos.Y;
            }
        }

        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lastPos = e.Location;
            }
        }

        private void label_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CheckBoundarys();
            }
        }

        /// <summary>
        /// Checks to see if the label has been scrolled to the point where there is empty space in
        /// its parent. If it is, then use a loop to quickly animate it back.
        /// </summary>
        private void CheckBoundarys()
        {
            if (label.Height < ClientSize.Height)
            {
                label.Top = 0;
            }
            else if (label.Location.Y > 0)
            {
                label.Top = 0;
            }
            else if (label.Location.Y < (label.Height * -1) + panelInner.ClientSize.Height)
            {
                label.Top = (label.Height * -1) + panelInner.ClientSize.Height;
            }
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);

            switch (e.KeyCode)
            {
                // Page down to scroll to end of text
                case Keys.PageDown: label.Top = (label.Height * -1) + panelInner.ClientSize.Height; break;
                // Page up to scroll to start of text
                case Keys.PageUp: label.Top = 0; break;
                // Down to scroll down one line
                case Keys.Down: label.Top -= lineHeight; break;
                // Up to scroll up one line
                case Keys.Up: label.Top += lineHeight; break;
                // Left to scroll back a "page" of lines
                case Keys.Left: label.Top += panelInner.ClientSize.Height - lineHeight; break;
                // Right to scroll forward a "page" of lines
                case Keys.Right: label.Top -= panelInner.ClientSize.Height - lineHeight; break;
                // Control + Plus to increase font size
                case (Keys.Oemplus | Keys.ControlKey): label.Font = label.Font.AddToSize(1); break;
                // Control + Minus to decrease font size
                case (Keys.OemMinus | Keys.ControlKey): label.Font = label.Font.AddToSize(-1); break;
                // Numpad 4 to decrease side padding
                case (Keys.NumPad4): HorizontalPadding -= 2; break;
                // Numpad 6 to increase side padding
                case (Keys.NumPad6): HorizontalPadding += 2; break;
                // Numpad 2 to decrease vertical padding
                case (Keys.NumPad2): VerticalPadding -= 2; break;
                // Numpad 8 to increase vertical padding
                case (Keys.NumPad8): VerticalPadding += 2; break;
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            label.Top += e.Delta;
            CheckBoundarys();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    CheckBoundarys();
                    break;
            }
        }

        private void label_FontChanged(object sender, EventArgs e)
        {
            SetFontHeight();
        }

        private void SetFontHeight()
        {
            using (Graphics graphics = CreateGraphics())
            {
                lineHeight = (int)(graphics.MeasureString("ABC123", label.Font).Height + 0.5);
            }
        }

        /// <summary>
        /// Sets the text content for the scrolling label.
        /// </summary>
        public void SetLabelText(string text)
        {
            label.Text = text;
        }
    }
}