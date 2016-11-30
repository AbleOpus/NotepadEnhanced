using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NotepadEnhanced.Forms
{
    /// <summary>
    /// Represents a find text panel.
    /// </summary>
    public partial class FindPanel : BottomPanelBase
    {
        /// <summary>
        /// Gets the pattern <see cref="TextBox"/>.
        /// </summary>
        [Browsable(false)]
        public TextBox PatternBox
        {
            get { return textBoxPattern; }
        }

        /// <summary>
        /// Gets or sets whether the match case option is set.
        /// </summary>
        [Browsable(false)]
        public bool MatchCase
        {
            get { return checkBoxMatchCase.Checked; }
            set { checkBoxMatchCase.Checked = value; }
        }

        /// <summary>
        /// Occurs when a request to change the main Form's accept button has occurred.
        /// </summary>
        public event EventHandler<Button> UpdateMainAcceptButton = delegate { };

        /// <summary>
        /// Occurs when the find next <see cref="Button"/> is clicked.
        /// </summary>
        public event EventHandler FindNextClicked
        {
            add { buttonFindNext.Click += value; }
            remove { buttonFindNext.Click -= value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FindPanel"/> class.
        /// </summary>
        public FindPanel()
        {
            InitializeComponent();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            UpdateAcceptButton();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            UpdateMainAcceptButton(this, buttonFindNext);
        }

        private void UpdateAcceptButton()
        {
            var button = (Visible && textBoxPattern.TextLength > 0) ? buttonFindNext : null;
            UpdateMainAcceptButton(this, button);
        }

        private void textBoxPattern_TextChanged(object sender, EventArgs e)
        {
            buttonFindNext.Enabled = textBoxPattern.Text.Length > 0;
            textBoxPattern.BackColor = Color.FromKnownColor(KnownColor.Window);
            UpdateAcceptButton();
        }
    }
}