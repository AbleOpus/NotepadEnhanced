using System;
using NotepadEnhanced.Forms;

namespace NotepadEnhanced.Forms
{
    /// <summary>
    /// Represents a panel to present 'goto' text-editor functionality.
    /// </summary>
    public partial class GotoPanel : BottomPanelBase
    {
        private readonly MainForm formMain;

        /// <summary>
        /// Initializes a new instance of the <see cref="GotoPanel"/> class with
        /// the specified argument.
        /// </summary>
        /// <param name="formMain"></param>
        public GotoPanel(MainForm formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
            formMain.AcceptButton = buttonGoto;
            formMain.SelectedPlainTextBox.TextChanged += _activePTB_TextChanged;
            numberBoxLineNumber.Maximum = formMain.SelectedPlainTextBox.LinesCount;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            numberBoxLineNumber.Focus();
        }

        private void _activePTB_TextChanged(object sender, EventArgs e)
        {
            numberBoxLineNumber.Maximum = formMain.SelectedPlainTextBox.LinesCount;
        }

        private void buttonGoto_Click(object sender, EventArgs e)
        {
            int lineIndex = (int)numberBoxLineNumber.Value - 1;
            formMain.SelectedPlainTextBox.GoTo(lineIndex);
            formMain.SelectedPlainTextBox.Focus();
        }

        private void GotoPanel_MouseEnter(object sender, EventArgs e)
        {
            formMain.AcceptButton = buttonGoto;
        }

        private void buttonGotoTop_Click(object sender, EventArgs e)
        {
            formMain.SelectedPlainTextBox.SelectionStart = 0;
            formMain.SelectedPlainTextBox.Focus();
        }

        private void buttonGotoBottom_Click(object sender, EventArgs e)
        {
            formMain.SelectedPlainTextBox.SelectionStart = formMain.SelectedPlainTextBox.Text.Length
                - formMain.SelectedPlainTextBox.SelectionLength;

            formMain.SelectedPlainTextBox.Focus();
        }
    }
}
