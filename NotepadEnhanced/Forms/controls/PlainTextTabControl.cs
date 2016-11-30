using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace NotepadEnhanced.Forms
{
    /// <summary>
    /// Represents a <see cref="TabControl"/> with a <see cref="PlainTextBox"/> on each <see cref="TabPage"/>.
    /// </summary>
    public class PlainTextTabControl : TabControl
    {
        #region Properties
        // The thickness of the tracker in pixels
        private const int TRACKER_WIDTH = 10;
        private LinearGradientBrush upperLgb, leftLgb;

        private bool trackCaret;
        /// <summary>
        /// Gets or sets whether to show the tracker.
        /// </summary>
        [DefaultValue(false)]
        [Description("Whether to show the tracker.")]
        [Category("Appearance")]
        public bool TrackCaret
        {
            get { return trackCaret; }
            set
            {
                trackCaret = value;
                SetTrackerPadding();
            }
        }

        private PlainTextBox defaultPlainTextBox = new PlainTextBox();
        /// <summary>
        /// Gets or sets the default <see cref="PlainTextBox"/> for all editors.
        /// </summary>
        [Category("Appearance")]
        [Description("The default PlainTextBox for all editors.")]
        public PlainTextBox DefaultPlainTextBox
        {
            get { return defaultPlainTextBox; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                defaultPlainTextBox = value;

                foreach (TabPage page in TabPages)
                {
                    page.Controls.Clear();
                    page.Controls.Add((Control)defaultPlainTextBox.Clone());
                }

                Invalidate();
            }
        }

        private bool wordWrap;
        /// <summary>
        /// Gets or sets a value indicating whether to wrap words on all <see cref="PlainTextBox"/>es.
        ///  Also determines the default word wrap value for all added <see cref="PlainTextBox"/>es.
        /// </summary>
        [Browsable(false)]
        public bool WordWrap
        {
            get { return wordWrap; }
            set
            {
                wordWrap = value;

                foreach (PlainTextBox box in PlainTextBoxes)
                    box.WordWrap = value;
            }
        }

        /// <summary>
        /// Gets all of the <see cref="PlainTextBox"/>es.
        /// </summary>
        [Browsable(false)]
        public IEnumerable<PlainTextBox> PlainTextBoxes => 
            (from Control control in Controls
            select (PlainTextBox)control.Controls[0]);

        /// <summary>
        /// Gets the <see cref="PlainTextBox"/> of the selected <see cref="TabPage"/>.
        /// </summary>
        [Browsable(false)]
        public PlainTextBox SelectedPlainTextBox => (PlainTextBox)SelectedTab.Controls[0];

        /// <summary>
        /// Gets or sets whether the user can use keys 1-9 to navigate the tabs.
        /// </summary>
        public bool AllowKeyNavigation { get; set; }

        private bool lineNumbersVisible;
        /// <summary>
        /// Gets or sets whether the line-number strips in this control are visible.
        /// </summary>
        /// <remarks>This property applies to all line numbers. If specific lines numbers
        /// are set to be hidden or shown, their visibility will be set to value.</remarks>
        public bool LineNumbersVisible
        {
            get { return lineNumbersVisible; }
            set
            {
                lineNumbersVisible = value;

                foreach (var box in PlainTextBoxes)
                {
                    box.ShowLineNumbers = value;
                    box.NeedRecalc();
                }

                DefaultPlainTextBox.ShowLineNumbers = value;
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PlainTextTabControl"/> class.
        /// </summary>
        public PlainTextTabControl()
        {
            AllowKeyNavigation = true;
            // Set default controls
            defaultPlainTextBox.Dock = DockStyle.Fill;
            // For tracker painting
            base.DoubleBuffered = true;
            SetupGradients();
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            e.Control.Paint += TabPage_Paint;
            var page = (TabPage)e.Control;
            page.BorderStyle = BorderStyle.None;
            page.Padding = new Padding(3);
            page.BackColor = Color.White;
            var box = (PlainTextBox)defaultPlainTextBox.Clone();
            box.Scroll += delegate { UpdateCaretTraker(); };
            box.SelectionChanged += delegate { UpdateCaretTraker(); };
            box.WordWrap = wordWrap;
            box.Dock = DockStyle.Fill;
            e.Control.Controls.Add(box);

            if (trackCaret)
            {
                e.Control.Padding = new Padding(TRACKER_WIDTH, TRACKER_WIDTH, 0, 0);
            }

            base.OnControlAdded(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (AllowKeyNavigation)
            {
                // Allow the user to navigate through the tabs with ctrl + number
                bool isNum1To9 = (e.KeyValue >= (int)Keys.D1 && e.KeyValue <= (int)Keys.D9);

                if (e.Control && isNum1To9)
                {
                    int tabIndex = e.KeyValue - ((int)Keys.D1);

                    if (tabIndex < TabCount)
                        SelectedIndex = tabIndex;
                }
            }
        }

        private void SetupGradients()
        {
            upperLgb = new LinearGradientBrush(Point.Empty, new Point(0, TRACKER_WIDTH / 2),
                Color.White, Color.YellowGreen);

            leftLgb = new LinearGradientBrush(Point.Empty, new Point(TRACKER_WIDTH / 2, 0),
                Color.White, Color.YellowGreen);

            leftLgb.WrapMode = upperLgb.WrapMode = WrapMode.TileFlipX;
        }

        private void TabPage_Paint(object sender, PaintEventArgs e)
        {
            if (trackCaret)
            {
                //var box = (PlainTextBox)SelectedTab.Controls[0];
                //e.Graphics.Clear(SelectedTab.BackColor);
                // Track on left side
                //float yPos = box.GetPositionFromCharIndex(box.SelectionStart).Y + _TRACKER_WIDTH;
                //e.Graphics.FillRectangle(_leftLgb, 0, yPos, _TRACKER_WIDTH, box.SelectionHeight);
                // Track on top side
                //int width = box.SelectionWidth;
                // Track topside even when no text is selected
                //if (width < _TRACKER_WIDTH) width = _TRACKER_WIDTH;
                //int xPos = box.GetPositionFromCharIndex(box.SelectionStart).X;
                //xPos += box.Location.X + 2; // Add 2 to compensate for the form border
                //e.Graphics.FillRectangle(_upperLgb, xPos, 0, width, _TRACKER_WIDTH);
            }
        }

        public void UpdateCaretTraker()
        {
            // Invalidate selected tabpage
            SelectedTab.Invalidate();
        }

        private void SetTrackerPadding()
        {
            for (int i = 0; i < TabPages.Count; i++)
            {
                if (trackCaret)
                {
                    TabPages[i].Padding = new Padding
                        (TRACKER_WIDTH, TRACKER_WIDTH, 0, 0);
                }
                else
                {
                    TabPages[i].Padding = new Padding(0);
                }
            }
        }
    }
}
