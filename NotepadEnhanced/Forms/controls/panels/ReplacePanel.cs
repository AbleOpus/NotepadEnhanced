using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NotepadEnhanced.AppState;
using NotepadEnhanced.Localization;
using NotepadEnhanced.Forms;

namespace NotepadEnhanced.Forms
{
    /// <summary>
    /// Represents a <see cref="Panel"/> to replace substrings within the active document.
    /// </summary>
    public partial class ReplacePanel : LargePanelBase
    {
        private readonly MainForm formMain;
        private bool findingNext;

        /// <summary>
        /// Gets or sets the find text.
        /// </summary>
        public string FindText
        {
            get { return textBoxFind.Text; }
            set { textBoxFind.Text = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReplacePanel"/> class.
        /// </summary>
        /// <param name="formMain"></param>
        public ReplacePanel(MainForm formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
            this.formMain.SelectedPlainTextBox.SelectionChanged += PtbActive_SelectionChanged;
            this.formMain.SelectedPlainTextBox.SelectionChangedDelayed += PtbActive_SelectionChangedDelayed;
            //this.formMain.PtbActive.LazySelecter.EndHook += PtbActive_SelectionChangedDelayed;
        }

        private void PtbActive_SelectionChanged(object sender, EventArgs e)
        {
            buttonReplaceSelected.Enabled = !string.IsNullOrEmpty(formMain.SelectedPlainTextBox.SelectedText);
        }

        private void PtbActive_SelectionChangedDelayed(object sender, EventArgs e)
        {
            if (findingNext)
            {
                findingNext = false;
                return;
            }

            textBoxFind.Text = formMain.SelectedPlainTextBox.SelectedText;
        }

        private void textBoxFind_TextChanged(object sender, EventArgs e)
        {
            bool isEnabled = textBoxFind.TextLength > 0;
            buttonPanelFindNext.Enabled = isEnabled;
            buttonReplaceAll.Enabled = isEnabled;
            textBoxFind.BackColor = Color.FromKnownColor(KnownColor.Window);
        }

        /// <summary>
        /// Gives the appropriate TextBox focus according to the text in textFind.
        /// </summary>
        public void SetTextBoxFocus()
        {
            if (textBoxFind.TextLength > 0)
            {
                textBoxReplace.Select();
            }
            else
            {
                textBoxFind.Select();
            }
        }

        private void buttonPanelFindNext_Click(object sender, EventArgs e)
        {
            findingNext = true;
            bool isFinished = formMain.SelectedPlainTextBox.FindNext(textBoxFind.Text, FastFindMode.Contains, checkBoxMatchCase.Checked);
            textBoxFind.BackColor = isFinished ? Settings.SearchDoneColor : Color.FromKnownColor(KnownColor.Window);
        }

        private void buttonReplace_Click(object sender, EventArgs e)
        {
            formMain.SelectedPlainTextBox.SelectedText = textBoxReplace.Text;
        }

        private void buttonReplaceAll_Click(object sender, EventArgs e)
        {
            RegexOptions options = (checkBoxMatchCase.Checked)
                ? RegexOptions.IgnoreCase : RegexOptions.None;

            DisplayReplaceCount(options);

            formMain.SelectedPlainTextBox.Text = Regex.Replace(formMain.SelectedPlainTextBox.Text,
                textBoxFind.Text, textBoxReplace.Text, options);
        }

        private void DisplayReplaceCount(RegexOptions options)
        {
            MatchCollection MC = Regex.Matches(formMain.SelectedPlainTextBox.Text, textBoxFind.Text, options);
            labelReplaceCount.Text = MC.Count + " " + Strings.ItemsReplaced;
        }

        public void SetFindTextBoxBackColor(Color color)
        {
            textBoxFind.BackColor = color;
        }

        private void textBoxFind_Enter(object sender, EventArgs e)
        {
            formMain.AcceptButton = buttonPanelFindNext;
        }

        private void textBoxReplace_Enter(object sender, EventArgs e)
        {
            formMain.AcceptButton = buttonReplaceAll;
        }
    }
}