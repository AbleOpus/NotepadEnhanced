using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NotepadEnhanced.Forms
{
    /// <summary>
    /// Represents a panel to be docked.
    /// </summary>
    public partial class DockedPanel : UserControl
    {
        private readonly Color borderColor = Color.FromKnownColor(KnownColor.ActiveBorder);
        private Point lastPos;

        private ToolStripMenuItem menuItemRelated;
        /// <summary>
        /// Gets or sets the <see cref="ToolStripMenuItem"/> that is (un)checked to open this panel
        /// The panel needs control of this item so it may uncheck and check appropriately.
        /// </summary>
        [Browsable(false)]
        public ToolStripMenuItem RelatedMenuItem
        {
            get { return menuItemRelated; }
            set
            {
                menuItemRelated = value;

                if (menuItemRelated != null)
                    menuItemRelated.CheckedChanged += _relatedMenuItem_CheckedChanged;
            }
        }

        /// <summary>
        /// Gets or sets whether swipe closing is enabled.
        /// </summary>
        private bool SwipeCloseEnabled { get; set; }

        protected DockedPanel()
        {
            SwipeCloseEnabled = true;
            InitializeComponent();
            ResizeRedraw = true;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            // We want to allow drag close with labels as well
            if (e.Control is Label)
            {
                e.Control.MouseDown += DisplayControls_MouseDown;
                e.Control.MouseMove += DisplayControls_MouseMove;
                e.Control.MouseUp += DisplayControls_MouseUp;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            if (DesignMode)
                Dock = DockStyle.None;

            base.OnLoad(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, borderColor, ButtonBorderStyle.Solid);
        }

        private void HidePanel()
        {
            if (RelatedMenuItem == null) Visible = false;
            else RelatedMenuItem.Checked = false;
        }

        private void DisplayControls_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && SwipeCloseEnabled)
            {
                lastPos = e.Location;

                switch (Dock)
                {
                    case DockStyle.Right: Cursor = Cursors.PanEast; break;
                    case DockStyle.Left: Cursor = Cursors.PanWest; break;
                    case DockStyle.Top: Cursor = Cursors.PanNorth; break;
                    case DockStyle.Bottom: Cursor = Cursors.PanSouth; break;
                }
            }
        }

        private void DisplayControls_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || !SwipeCloseEnabled) return;
            // Drag has to be 30% of the controls width to have an effect
            const float DRAG_FACTOR = 0.3f;

            switch (Dock)
            {
                case DockStyle.Right: if (e.X - lastPos.X > Width * DRAG_FACTOR) HidePanel(); break;
                case DockStyle.Left: if (lastPos.X - e.X > Width * DRAG_FACTOR) HidePanel(); break;
                case DockStyle.Top: if (lastPos.Y - e.Y > Height * DRAG_FACTOR) HidePanel(); break;
                case DockStyle.Bottom: if (e.Y - lastPos.Y > Height * DRAG_FACTOR) HidePanel(); break;
            }
        }

        private void DisplayControls_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && SwipeCloseEnabled)
                Cursor = Cursors.Default;
        }

        private void _relatedMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (menuItemRelated != null && !menuItemRelated.Checked)
            {
                Visible = menuItemRelated.Checked;
            }
        }
    }
}