using System;
using System.ComponentModel;
using System.Windows.Forms;
using NotepadEnhanced.AppState;
using NotepadEnhanced.Localization;

namespace NotepadEnhanced.Forms
{
    /// <summary>
    /// Represents a Form to display settings
    /// </summary>
    public partial class SettingsDialog : Form
    { 
        private readonly MainForm formMain;
        private readonly SupportedCultures supportedCultures = new SupportedCultures();
        private bool loadingLanguages = true;
        // Keep track of the last selected index as the SelectedIndexChanged event
        // will raise even if the index selected is the same. We do not want this behavior
        private int lastLanguageIndex;

        public SettingsDialog(MainForm formMain)
        {
            this.formMain = formMain;
            InitializeComponent();
            tabControl.SelectedIndex = Settings.Instance.SettingsTabIndex;
            LoadUserSettings();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // All settings that are changed through the GUI,  immediate effect on the app should be saved here
            Settings.Instance.ReadingHorizPadding = (int)numberBoxHorizPadding.Value;
            Settings.Instance.ReadingVertPadding = (int)numberBoxVertPadding.Value;
            Settings.Instance.ReadingWidth = (int)numberBoxReadingWidth.Value;
            Settings.Instance.ReadingViewTopMost = checkBoxReadingTopmost.Checked;
            Settings.Instance.Signature = textBoxSigInsert.Text;
            Settings.Instance.SingleInstance = checkBoxSingleInstance.Checked;
            Settings.Instance.AddTabOnStart = checkBoxAddTabOnStart.Checked;
            Settings.Instance.PromptToRestore = checkBoxRestorePrompt.Checked;
            Settings.Instance.RecentFilesEnabled = checkBoxRecentFilesEnabled.Checked;
            Settings.Instance.AddTitleToPrint = checkBoxAddTitle.Checked;
            Settings.Instance.AutoWordSelection = checkBoxAutoWordSelection.Checked;
            Settings.Instance.RecentFiles.Capacity = (int)numberBoxMaxRecents.Value;
            base.OnClosing(e);
        }
        
        private void LoadUserSettings()
        {
            Settings.Instance.SettingsTabIndex = tabControl.SelectedIndex;
            fontPickerTextBoxArea.SelectedFont = Settings.Instance.Font;
            textBoxSigInsert.Text = Settings.Instance.Signature;
            pickerTextColor.PickedColor = Settings.Instance.FontColor;
            pickerBackColor.PickedColor = Settings.Instance.BackColor;
            pickerLnNumForeColor.PickedColor = Settings.Instance.LineNumForeColor;
            numberBoxMaxRecents.Value = Settings.Instance.RecentFiles.Capacity;
            checkBoxSingleInstance.Checked = Settings.Instance.SingleInstance;
            checkBoxAddTabOnStart.Checked = Settings.Instance.AddTabOnStart;
            checkBoxRecentFilesEnabled.Checked = Settings.Instance.RecentFilesEnabled;
            checkBoxAddTitle.Checked = Settings.Instance.AddTitleToPrint;
            checkBoxSelectionMargin.Checked = Settings.Instance.ShowSelectionMargin;
            checkBoxMultilineTabs.Checked = Settings.Instance.MultiLineTabs;
            checkBoxRestorePrompt.Checked = Settings.Instance.PromptToRestore;
            checkBoxTrackSelection.Checked = Settings.Instance.TrackSelection;
            checkBoxAutoWordSelection.Checked = Settings.Instance.AutoWordSelection;
            // Reading settings
            checkBoxReadingTopmost.Checked = Settings.Instance.ReadingViewTopMost;
            numberBoxReadingWidth.Value = Settings.Instance.ReadingWidth;
            pickerReadBackColor.PickedColor = Settings.Instance.ReadingBackColor;
            pickerReadForeColor.PickedColor = Settings.Instance.ReadingForeColor;
            pickerWindowColor.PickedColor = Settings.Instance.ReadingBackColor;
            fontPickerReading.SelectedFont = Settings.Instance.ReadingFont;
            numberBoxVertPadding.Value = Settings.Instance.ReadingVertPadding;
            numberBoxHorizPadding.Value = Settings.Instance.ReadingHorizPadding;
            ListAvailableLanguages();

            // We are going to click the checkBox in opposed to checking them, as we want to make sure 
            // the logic that unchecks the other checkboxes run
            switch (Settings.Instance.PrintTitleAlign)
            {
                case 0: checkBoxLeft_Click(null, EventArgs.Empty); break;
                case 1: checkBoxMiddle_Click(null, EventArgs.Empty); break;
                case 2: checkBoxRight_Click(null, EventArgs.Empty); break;
                default: checkBoxLeft_Click(null, EventArgs.Empty); break;
            }

            LoadColorPickers();
        }

        private void LoadColorPickers()
        {
            var customColors = new[]
                {
                    Settings.Instance.ReadingForeColor,
                    Settings.Instance.ReadingBackColor,
                    Settings.Instance.FontColor,
                    Settings.Instance.BackColor,
                    Settings.Instance.LineNumForeColor
                };

            pickerTextColor.CustomColors = customColors;
            pickerBackColor.CustomColors = customColors;
            pickerReadForeColor.CustomColors = customColors;
            pickerReadBackColor.CustomColors = customColors;
            pickerWindowColor.CustomColors = customColors;
            pickerLnNumStyleColor.CustomColors = customColors;
            pickerLnNumForeColor.CustomColors = customColors;

            pickerTextColor.PickedColor = Settings.Instance.FontColor;
            pickerBackColor.PickedColor = Settings.Instance.BackColor;
            pickerReadForeColor.PickedColor = Settings.Instance.ReadingForeColor;
            pickerReadBackColor.PickedColor = Settings.Instance.ReadingBackColor;
            pickerWindowColor.PickedColor = Settings.Instance.ReadingBackColor;
            pickerLnNumForeColor.PickedColor = Settings.Instance.LineNumForeColor;
        }

        private void ListAvailableLanguages()
        {
            comboLanguageSelect.SuspendLayout();
            comboLanguageSelect.Items.Clear();
            comboLanguageSelect.Items.AddRange(supportedCultures.ToStringArray());
            comboLanguageSelect.SelectedIndex = supportedCultures.DefaultCultureIndex;
            comboLanguageSelect.ResumeLayout();
            lastLanguageIndex = comboLanguageSelect.SelectedIndex;
            loadingLanguages = false;
        }

        #region General
        private void comboBoxLanguageSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Only apply language settings if the user selects a different language
            if (!loadingLanguages && comboLanguageSelect.SelectedIndex != lastLanguageIndex)
            {
                int index = comboLanguageSelect.SelectedIndex;
                Settings.Instance.Culture = supportedCultures.All[index].Name;
                ShowRestartMessage();
                lastLanguageIndex = comboLanguageSelect.SelectedIndex;
            }
        }

        private static void ShowRestartMessage()
        {
            DialogResult result = MessageDialog.Show(Strings.RestartPrompt, MessageBoxIcon.Question, MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Settings.Instance.Save();
                Application.Restart();
            }
        }

        private void checkBoxSelectionMargin_Click(object sender, EventArgs e)
        {
            Settings.Instance.ShowSelectionMargin = checkBoxSelectionMargin.Checked;

            //foreach (PlainTextBox box in formMain.RicherTextBoxes)
               // box.ShowSelectionMargin = Settings.Instance.ShowSelectionMargin;
        }

        private void checkBoxMultilineTabs_Click(object sender, EventArgs e)
        {
            Settings.Instance.MultiLineTabs = checkBoxMultilineTabs.Checked;
            formMain.SetMultilineTabbing();
        }

        private void checkBoxTrackSelection_Click(object sender, EventArgs e)
        {
            Settings.Instance.TrackSelection = checkBoxTrackSelection.Checked;
            formMain.TrackCaretOnTabControl = checkBoxTrackSelection.Checked;
        }
        #endregion

        #region Text Editor
        private void pickerTextColor_ColorPicked(object sender, EventArgs e)
        {
            Settings.Instance.FontColor = pickerTextColor.PickedColor;
            pickerTextColor.PickedColor = pickerTextColor.PickedColor;

            foreach (PlainTextBox textBox in formMain.PlainTextBoxes)
                textBox.ForeColor = pickerTextColor.PickedColor;
        }

        private void fontPickerTextArea_SelectedFontChanged(object sender, EventArgs e)
        {
            foreach (PlainTextBox plainTextBox in formMain.PlainTextBoxes)
                plainTextBox.Font = fontPickerTextBoxArea.SelectedFont;

            Settings.Instance.Font = fontPickerTextBoxArea.SelectedFont;
        }

        private void pickerBackColor_ColorPicked(object sender, EventArgs e)
        {
            Settings.Instance.BackColor = pickerBackColor.PickedColor;

            foreach (PlainTextBox textBox in formMain.PlainTextBoxes)
                textBox.BackColor = pickerBackColor.PickedColor;
        }

        private void pickerLineNumForeColor_ColorPicked(object sender, EventArgs e)
        {
            Settings.Instance.LineNumForeColor = pickerLnNumForeColor.PickedColor;

            foreach (PlainTextBox textBox in formMain.PlainTextBoxes)
                textBox.LineNumberColor = pickerLnNumForeColor.PickedColor;
        }
        #endregion

        #region Print Title
        private void checkBoxLeft_Click(object sender, EventArgs e)
        {
            Settings.Instance.PrintTitleAlign = 0;
            checkBoxLeft.Checked = true;
            checkBoxMiddle.Checked = checkBoxRight.Checked = false;
        }

        private void checkBoxMiddle_Click(object sender, EventArgs e)
        {
            Settings.Instance.PrintTitleAlign = 1;
            checkBoxMiddle.Checked = true;
            checkBoxRight.Checked = checkBoxLeft.Checked = false;
        }

        private void checkBoxRight_Click(object sender, EventArgs e)
        {
            Settings.Instance.PrintTitleAlign = 2;
            checkBoxRight.Checked = true;
            checkBoxLeft.Checked = checkBoxMiddle.Checked = false;
        }
        #endregion

        #region Reading View
        private void fontPickerReading_SelectedFontChanged(object sender, EventArgs e)
        {
            Settings.Instance.ReadingFont = fontPickerReading.SelectedFont;
        }

        private void pickerReadForeColor_ColorPicked(object sender, EventArgs e)
        {
            Settings.Instance.ReadingForeColor = pickerReadForeColor.PickedColor;
        }

        private void pickerReadBackColor_ColorPicked(object sender, EventArgs e)
        {
            Settings.Instance.ReadingBackColor = pickerReadBackColor.PickedColor;
        }

        private void pickerWindowColor_ColorPicked(object sender, EventArgs e)
        {
            Settings.Instance.ReadingBackColor = pickerWindowColor.PickedColor;
        }
        #endregion

        private void buttonResetAll_Click(object sender, EventArgs e)
        {
            // Reset everything except for culture and bootCount
            string culture = Settings.Instance.Culture;
            int bootCount = Settings.Instance.BootCount;
            Settings.Instance.Reset();
            Settings.Instance.Culture = culture;
            Settings.Instance.BootCount = bootCount;

            SuspendLayout();
            formMain.LoadLastSettings();

            foreach (PlainTextBox box in formMain.PlainTextBoxes)
            {
                //box.ShowSelectionMargin = Settings.Instance.ShowSelectionMargin;
                box.Font = Settings.Instance.Font;
                box.ForeColor = Settings.Instance.FontColor;
                box.BackColor = Settings.Instance.BackColor;
                box.LineNumberColor = Settings.Instance.LineNumForeColor;
            }

            Settings.Instance.Signature = Environment.UserName;
            LoadUserSettings();
            ResumeLayout();
            MessageDialog.Show(Strings.SettingsRestored, MessageBoxIcon.Asterisk);
        }

        private void buttonClearRecentList_Click(object sender, EventArgs e)
        {
            Settings.Instance.RecentFiles.Clear();
            buttonClearRecentList.Enabled = false;
        }
    }
}
