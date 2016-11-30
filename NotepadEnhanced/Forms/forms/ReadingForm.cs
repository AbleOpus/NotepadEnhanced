using System;
using System.Drawing;
using System.Windows.Forms;
using NotepadEnhanced.AppState;

namespace NotepadEnhanced.Forms
{
    /// <summary>
    /// Specifies the different reading modes.
    /// </summary>
    public enum ReadingMode
    {
        /// <summary>
        /// Reading will be done in a normal windowed fashion.
        /// </summary>
        Normal,
        /// <summary>
        /// Reading will be adapted for a written script.
        /// </summary>
        Script,
        /// <summary>
        /// Reading will be full-screen.
        /// </summary>
        FullScreen
    };

    public partial class ReadingForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadingForm"/> class
        /// with the specified argument.
        /// </summary>
        /// <param name="text">The text to read.</param>
        public ReadingForm(string text)
        {
            InitializeComponent();
            labelScrolling.SetLabelText(text);
            LoadSettingsAndDefaults();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyData == Keys.Escape)
            {
                if (WindowState == FormWindowState.Maximized)
                {
                    WindowState = FormWindowState.Normal;
                }
                else
                {
                    Close();
                }
            }
            else if (e.KeyCode.Equals(Keys.Left) || e.KeyCode.Equals(Keys.Right) ||
                     e.KeyCode.Equals(Keys.Down) || e.KeyCode.Equals(Keys.Up))
            {
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.F && e.Control)
            {
                if (Settings.Instance.ReadingMode != ReadingMode.FullScreen)
                {
                    SetReadingMode(ReadingMode.FullScreen);
                }
                else
                {
                    SetReadingMode(ReadingMode.Normal);
                }
            }
        }

        private void SetReadingWidth()
        {
            MinimumSize = new Size(Settings.Instance.ReadingWidth, 0);
            labelScrolling.Width = Settings.Instance.ReadingWidth;
        }

        private void LoadSettingsAndDefaults()
        {
            BackColor = Settings.Instance.ReadingWindowColor;
            labelScrolling.BackColor = Settings.Instance.ReadingBackColor;
            labelScrolling.ForeColor = Settings.Instance.ReadingForeColor;
            labelScrolling.Font = Settings.Instance.ReadingFont;
            labelScrolling.HorizontalPadding = Settings.Instance.ReadingHorizPadding;
            labelScrolling.VerticalPadding = Settings.Instance.ReadingVertPadding;

            SetReadingWidth();

            switch (Settings.Instance.ReadingMode)
            {
                case ReadingMode.Normal: menuItemNormal.PerformClick(); break;
                case ReadingMode.FullScreen: menuItemFullScreen.PerformClick(); break;
                case ReadingMode.Script: menuItemScript.PerformClick(); break;
            }
        }

        private void UpdateTextBoxBounds()
        {
            int x = (ClientSize.Width / 2) - (labelScrolling.Width / 2);
            int y = (controlExtender.Visible) ? controlExtender.Height : 0;
            int width = Settings.Instance.ReadingWidth;
            int height = ClientSize.Height - y;
            labelScrolling.Bounds = new Rectangle(x, y, width, height);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateTextBoxBounds();
        }

        protected override void OnClosed(EventArgs e)
        {
            Settings.Instance.ReadingViewBounds = DesktopBounds;
            Settings.Instance.ReadingVertPadding = labelScrolling.Padding.Top;
            Settings.Instance.ReadingHorizPadding = labelScrolling.Padding.Right;
            base.OnClosed(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Put this in the constructor?
            UpdateTextBoxBounds();
            // Activate the control so we can scroll and what not right away
            ActiveControl = labelScrolling;
        }

        private void menuItemNormal_Click(object sender, EventArgs e)
        {
            menuItemNormal.Checked = true;
            menuItemScript.Checked = false;
            menuItemFullScreen.Checked = false;
            SetReadingMode(ReadingMode.Normal);
        }

        private void menuItemScript_Click(object sender, EventArgs e)
        {
            menuItemScript.Checked = true;
            menuItemNormal.Checked = false;
            menuItemFullScreen.Checked = false;
            SetReadingMode(ReadingMode.Script);
        }

        private void menuItemFullScreen_Click(object sender, EventArgs e)
        {
            menuItemFullScreen.Checked = true;
            menuItemNormal.Checked = false;
            menuItemScript.Checked = false;
            SetReadingMode(ReadingMode.FullScreen);
        }

        private void menuItemEditor_Click(object sender, EventArgs e)
        {
            Settings.Instance.ReadingFont = Settings.Instance.Font;
            Settings.Instance.ReadingForeColor = Settings.Instance.FontColor;
            Settings.Instance.ReadingWindowColor = Settings.Instance.BackColor;
            Settings.Instance.ReadingBackColor = Settings.Instance.BackColor;
            LoadSettingsAndDefaults();
        }

        private void menuItemOldScripture_Click(object sender, EventArgs e)
        {
            Font font = new Font("Book Antiqua", 14f, FontStyle.Regular);
            if (font.Installed()) Settings.Instance.ReadingFont = font;
            Settings.Instance.ReadingForeColor = Color.FromArgb(64, 64, 64);
            Settings.Instance.ReadingBackColor = Color.PapayaWhip;
            Settings.Instance.ReadingWindowColor = Color.Tan;
            LoadSettingsAndDefaults();
        }

        private void menuItemComputerConsole_Click(object sender, EventArgs e)
        {
            Font font = new Font("Calibri", 14f, FontStyle.Regular);
            if (font.Installed()) Settings.Instance.ReadingFont = font;
            Settings.Instance.ReadingForeColor = Color.LimeGreen;
            Settings.Instance.ReadingBackColor = Color.Black;
            Settings.Instance.ReadingWindowColor = Color.Black;
            LoadSettingsAndDefaults();
        }

        private void menuItemNovel_Click(object sender, EventArgs e)
        {
            Font font = new Font("Courier", 14f, FontStyle.Regular);
            if (font.Installed()) Settings.Instance.ReadingFont = font;
            Settings.Instance.ReadingForeColor = Color.Black;
            Settings.Instance.ReadingBackColor = Color.White;
            Settings.Instance.ReadingWindowColor = Color.DarkGray;
            Settings.Instance.ReadingVertPadding = 10;
            Settings.Instance.ReadingHorizPadding = 20;
            LoadSettingsAndDefaults();
        }

        private void menuItemModernDark_Click(object sender, EventArgs e)
        {
            var names = new[] { "Lyon", "Ideal Sans", "Helvetica", "Trebuchet MS", "Calibri" };
            Settings.Instance.ReadingFont = FontSelection.GetBest(names, 14);
            Settings.Instance.ReadingForeColor = Color.LightGray;
            Settings.Instance.ReadingBackColor = Color.FromArgb(20, 20, 20);
            Settings.Instance.ReadingWindowColor = Color.FromArgb(20, 20, 20);
            Settings.Instance.ReadingVertPadding = 10;
            Settings.Instance.ReadingHorizPadding = 20;
            LoadSettingsAndDefaults();
        }

        private void menuItemClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetReadingMode(ReadingMode mode)
        {
            switch (mode)
            {
                case ReadingMode.FullScreen:
                    controlExtender.Visible = false;
                    TopMost = true;
                    FormBorderStyle = FormBorderStyle.None;
                    Bounds = Screen.GetBounds(this);
                    BringToFront();
                    break;

                case ReadingMode.Normal:
                    FormBorderStyle = FormBorderStyle.Sizable;
                    controlExtender.Visible = false;
                    Bounds = RestoreBounds;
                    TopMost = Settings.Instance.ReadingViewTopMost;
                    Size = new Size(Settings.Instance.ReadingWidth, 500);
                    CenterToScreen();
                    FormBorderStyle = FormBorderStyle.Sizable;
                    break;

                case ReadingMode.Script:
                    controlExtender.Visible = true;
                    TopMost = true;
                    WindowState = FormWindowState.Normal;
                    FormBorderStyle = FormBorderStyle.None;
                    const int HEIGHT = 200;
                    var screenRect = Screen.GetBounds(this);
                    var size = new Size(screenRect.Width, HEIGHT);
                    int y = screenRect.Y + screenRect.Height - HEIGHT;
                    var pos = new Point(screenRect.X, y);
                    Bounds = new Rectangle(pos, size);
                    break;
            }

            Settings.Instance.ReadingMode = mode;
        }
    }
}