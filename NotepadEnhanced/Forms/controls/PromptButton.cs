using System;
using System.Drawing;
using System.Windows.Forms;
using NotepadEnhanced.Localization;
using NotepadEnhanced.Properties;

namespace NotepadEnhanced.Forms
{
    /// <summary>
    /// Represents an animated button to prompt the user.
    /// </summary>
    class PromptButton : Button
    {
        private readonly Timer timerAutoHide = new Timer();
        private readonly Control control;
        private int timeShown;
        private const int CORNER_PADDING = 10;
        private const int TIME_TO_SHOW = 4;

        /// <summary>
        /// Initializes a new instance of the <see cref="PromptButton"/> class
        /// with the specified argument.
        /// </summary>
        /// <param name="control">The <see cref="Control"/> to add this to.</param>
        public PromptButton(Control control)
        {
            this.control = control;
            control.Resize += delegate { PositionButton(); };
            Padding = new Padding(3);
            Image = Resources.Restore;
            TextImageRelation = TextImageRelation.ImageBeforeText;
            base.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            base.Text = Strings.RestoreSessionPrompt;
            base.AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            timerAutoHide.Interval = 1000;
            timerAutoHide.Tick += timerAutoHide_Tick;
            timerAutoHide.Start();
            PositionButton();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            BringToFront();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Dispose();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            timerAutoHide.Dispose();
        }

        private void PositionButton()
        {
            // TODO: use left and top
            int xPos = control.Location.X + control.ClientSize.Width - Width - CORNER_PADDING;
            int yPos = control.Location.Y + control.ClientSize.Height - Height - CORNER_PADDING;
            Location = new Point(xPos, yPos);
        }

        private void timerAutoHide_Tick(object sender, EventArgs e)
        {
            if (++timeShown == TIME_TO_SHOW)
                Dispose();
        }
    }
}
