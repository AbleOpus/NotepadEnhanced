using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NotepadEnhanced.AppState;
using NotepadEnhanced.Localization;
using NotepadEnhanced.Refactexing;
using NotepadEnhanced.Forms;

namespace NotepadEnhanced.Forms
{
    public partial class RegexRefactoringForm : Form
    {
        private readonly PlainTextBox textBox;

        public RegexRefactoringForm(PlainTextBox textBox)
        {
            this.textBox = textBox;
            InitializeComponent();
            PopulateList();
        }

        private void PopulateList()
        {
            listBox.Items.Clear();
            listBox.Items.AddRange(Settings.Instance.Refactexes.ToArray());
        }


        /// <summary>
        /// Checks to see if a Refactex is selected. If one is then show a messageBox.
        /// </summary>
        /// <returns>Returns true, if an item is selected. Otherwise false.</returns>
        private bool CheckForSelected()
        {
            if (listBox.SelectedIndex == -1)
            {
                MessageDialog.ShowError(Strings.NoSelRefactex);
                return false;
            }

            return true;
        }

        private void buttonRefactor_Click(object sender, EventArgs e)
        {
            foreach (Refactex r in listBox.SelectedItems.Cast<Refactex>())
            {
                try
                {
                    if (textBox.SelectionLength > 0)
                    {
                        textBox.SelectedText = Regex.Replace(textBox.SelectedText, 
                            r.Pattern, r.Replacement, r.Options);
                    }
                    else
                    {
                        textBox.Text = Regex.Replace(textBox.Text, r.Pattern, r.Replacement, r.Options);
                    }
                }
                catch (Exception ex)
                {
                    string firstMsg = String.Format(Strings.RefactexErrorFormat);
                    MessageDialog.ShowError(firstMsg + "\n\n" + ex.Message);
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            bool sel = CheckForSelected();

            if (sel)
            {
                var selRefact = (Refactex)listBox.SelectedItem;

                using (var formEditRefactex = new EditRefactexForm(selRefact))
                {
                    if (formEditRefactex.ShowDialog() == DialogResult.OK)
                    {
                        Settings.Instance.Refactexes[listBox.SelectedIndex] = formEditRefactex.Refactex;
                        int selIndex = listBox.SelectedIndex;
                        PopulateList();
                        listBox.SelectedIndex = selIndex;
                    }
                }
            }
        }

        private void UpdateDescription()
        {
            if (listBox.SelectedItem != null)
            {
                labelDescription.Text = ((Refactex)listBox.SelectedItem).Description;
            }
            else
            {
                labelDescription.Text = string.Empty;
            }
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            bool sel = CheckForSelected();

            if (sel)
            {
                for (int i = listBox.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    Settings.Instance.Refactexes.RemoveAt(listBox.SelectedIndices[i]);
                }

                PopulateList();
                UpdateDescription();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (var dlgAddRefactex = new AddRefactexForm())
            {
                dlgAddRefactex.ShowDialog();
                
                while (dlgAddRefactex.ToBeAdded.Count > 0)
                {
                    Settings.Instance.Refactexes.Add(dlgAddRefactex.ToBeAdded.Pop());
                }

                PopulateList();
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonRefactor.Enabled = (listBox.SelectedItems.Count > 0);
        }
    }
}
