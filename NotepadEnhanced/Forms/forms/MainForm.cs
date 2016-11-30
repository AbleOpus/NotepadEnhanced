using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AboPersistance.Updating;
using AboPersistance.Views;
using FastColoredTextBoxNS;
using NinjaWordsApi;
using NotepadEnhanced.AppState;
using NotepadEnhanced.Localization;
using NotepadEnhanced.Properties;
using NotepadEnhanced.Forms;

namespace NotepadEnhanced.Forms
{
    public partial class MainForm : Form
    {
        private uint ticks;
        private string lastFindTerm = string.Empty;
        private Printing printing;
        private FindPanel panelFind;
        private GotoPanel panelGoto;
        private ReplacePanel panelReplace;
        private PromptButton buttonPrompt;
        private readonly Settings Options = Settings.Instance; // Shortened settings reference
        private readonly NeTrayIcon trayIcon;

        /// <summary>
        /// Gets the <see cref="PlainTextBox"/> associated with the currently selected <see cref="TabPage"/>.
        /// </summary>
        public PlainTextBox SelectedPlainTextBox => tabControl.SelectedPlainTextBox;

        /// <summary>
        /// Gets all of the <see cref="PlainTextBox"/>es on the <see cref="Form"/>.
        /// </summary>
        public PlainTextBox[] PlainTextBoxes => tabControl.PlainTextBoxes.ToArray();

        /// <summary>
        /// Gets or sets whether to track the caret on the forms <see cref="TabControl"/>.
        /// </summary>
        public bool TrackCaretOnTabControl
        {
            get { return tabControl.TrackCaret; }
            set { tabControl.TrackCaret = value; }
        }

        #region MainForm
        public MainForm()
        {
            InitializeComponent();
            SuspendLayout(); // Resume layout in OnLoad()
            trayIcon = new NeTrayIcon(this);
            LoadLastSettings();
            tabControl.BringToFront();
            UpdateControlAbilitys();
        }

        /// <summary>
        /// Updates the form to load the last state, as well as to reflect the users preferences.
        /// </summary>
        public void LoadLastSettings()
        {
            tabControl.TrackCaret = Options.TrackSelection;
            menuItemWordWrap.Checked = Options.WordWrap;
            menuItemStatusBar.Checked = Options.StatusBarVisible;
            menuItemAlwaysOnTop.Checked = Options.TopMost;
            menuItemAutoIndent.Checked = Options.AutoIndent;
            menuItemLineNumbers.Checked = Options.LineNumberVisible;

            tabControl.WordWrap = Options.WordWrap;
            SetMultilineTabbing();

            if (Options.FirstBoot)
            {
                SetDefaults();
            }
            else
            {
                Bounds = Options.MainFormBounds;
                WindowState = Options.MainFormState;
            }
        }

        /// <summary>
        /// Set program defaults for first boot.
        /// </summary>
        private void SetDefaults()
        {
            CenterToScreen();
            Options.MainFormBounds = Bounds;
            // New textbox can only do monospace fonts now.
            // TODO: Make new list of preffered fonts.
            string[] familyNames = { "Consolas", "Calibri", "Verdana", "Tahoma" };
            Options.Font = FontSelection.GetBest(familyNames, 14f);
            Options.Signature = Environment.UserName;
            Options.FirstBoot = false;
        }

        private void AddBlankTab()
        {
            //if (Text != Application.ProductName)
            //    this.Text = Application.ProductName;
            timerMessage.Dispose();
            tabControl.TabPages.Add(Strings.NewDoc);
            tabControl.SelectedIndex = tabControl.TabCount - 1;
            SelectedPlainTextBox.Focus();
        }

        private void SaveCurrentSession()
        {
            int selectionIndex = -1, selectionLength = -1;

            if (tabControl.TabCount > 0)
            {
                selectionIndex = SelectedPlainTextBox.SelectionStart;
                selectionLength = SelectedPlainTextBox.SelectionLength;
            }

            string tempLastFindTerm;
            // If find panel open use the textbox within for the last searh term
            if (panelFind != null)
                tempLastFindTerm = panelFind.PatternBox.Text;
            // Do the same for the replace panel
            else if (panelReplace != null)
                tempLastFindTerm = panelReplace.FindText;
            else
                tempLastFindTerm = this.lastFindTerm;

            var openFiles = PlainTextBoxes.Select(t => t.FileName).ToList();
            Options.LastSession.FindPanelOpen = menuItemFind.Checked;
            Options.LastSession.ReplacePanelOpen = menuItemReplace.Checked;
            Options.LastSession.GotoPanelOpen = menuItemGoto.Checked;
            Options.LastSession.SelectedTabIndex = tabControl.SelectedIndex;
            Options.LastSession.FilesOpen = openFiles;
            Options.LastSession.SelectedTextLength = selectionLength;
            Options.LastSession.SelectedTextIndex = selectionIndex;
            Options.LastSession.FindText = tempLastFindTerm;
        }

        private void SaveFormState()
        {
            //Save form dimension and size for default
            Options.MainFormState = WindowState;

            if (WindowState == FormWindowState.Normal)
                Options.MainFormBounds = Bounds;
            else
                Options.MainFormBounds = RestoreBounds;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (SingleAppInstance.CmdLineArguments.Length > 0)
            {
                LoadDocuments(SingleAppInstance.CmdLineArguments);
            }
            // Only add blank tab if no documents are loaded on startup
            else if (Options.AddTabOnStart)
            {
                AddBlankTab();
                SelectedPlainTextBox.Select();
            }

            // If blank tab has been added
            if (tabControl.SelectedIndex != -1)
            {
                printing = new Printing(SelectedPlainTextBox);
            }

            UpdateChecker.CheckQuietlyAsync(Resources.DownloadLink);

            if (Options.PromptToRestore && Options.LastSession != null)
            {
                buttonPrompt = new PromptButton(tabControl);
                buttonPrompt.Click += buttonPrompt_Click;
                Controls.Add(buttonPrompt);
            }

            ResumeLayout(true);
            // Work around for textBox bug
            tabControl.LineNumbersVisible = Options.LineNumberVisible;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (Options.PromptToRestore) SaveCurrentSession();
            base.OnClosing(e);
            int lastIndex = tabControl.SelectedIndex;
            tabControl.SelectedIndex = 0;

            //Prompt to save modified documents
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                bool hasTabPages = tabControl.TabCount != 0;

                if (hasTabPages && SelectedPlainTextBox.Modified && PromptToSave())
                {
                    e.Cancel = true;
                    tabControl.SelectedIndex = lastIndex;
                    return;
                }

                tabControl.SelectedIndex++;
            }

            SaveFormState();

            if (panelFind != null)
                Options.IsFindMatchCase = panelFind.MatchCase;

            Options.Save();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyData)
            {
                case Keys.L | Keys.Control:
                    menuItemLineNumbers.Checked = !menuItemLineNumbers.Checked;
                    break;

                case Keys.Escape:
                    menuItemFullscreen.Checked = false;
                    break;

                case Keys.Print:
                    printing.PrintRichTextDocument(SelectedPlainTextBox.SafeFileName);
                    break;
            }

            // zooming
            //else if (e.KeyData == (Keys.Oemplus | Keys.Control))
            //{
            //if (tabControl.SelectedIndex == -1) return;
            //Font font = Options.Font;
            //Options.Font = new Font(font.FontFamily, font.SizeInPoints + 2, font.Style);

            //foreach (RicherTextBox plainTextBox in PlainTextBoxes)
            //    plainTextBox.Font = Options.Font;
            // }
            //else if (e.KeyData == (Keys.OemMinus | Keys.Control))
            //{
            //    if (Options.Font.Size < 8 || tabControl.SelectedIndex.Equals(-1))
            //        return;

            //    Font font = Options.Font;
            //    Options.Font = new Font(font.FontFamily, font.SizeInPoints - 2, font.Style);

            //    foreach (RicherTextBox plainTextBox in PlainTextBoxes)
            //        plainTextBox.Font = Options.Font;
            //}
        }
        #endregion

        #region Main Menu
        #region File Menu
        private void menuItemFile_MouseEnter(object sender, EventArgs e)
        {
            menuItemOpenRecent.DropDownItems.Clear();

            if (Options.RecentFilesEnabled)
            {
                foreach (string name in Options.RecentFiles)
                {
                    string safeFileName = Path.GetFileName(name);

                    var menuItem = new ToolStripMenuItem
                        (safeFileName, null, buttonRecentFileDropDown_Click);

                    menuItem.TextAlign = ContentAlignment.MiddleCenter;
                    menuItem.Tag = menuItem.ToolTipText = name;
                    menuItemOpenRecent.DropDownItems.Add(menuItem);
                }

                menuItemOpenRecent.Enabled = (Options.RecentFiles.Items.Length > 0);
            }
            else
            {
                menuItemOpenRecent.Enabled = false;
            }
        }

        private void menuItemAddTab_Click(object sender, EventArgs e)
        {
            AddBlankTab();
        }

        private void menuItemCloseTab_Click(object sender, EventArgs e)
        {
            CloseSelectedTab();
        }

        private void menuItemCloseAllTabs_Click(object sender, EventArgs e)
        {
            SuspendLayout();

            while (tabControl.TabCount > 0)
                CloseSelectedTab();

            ResumeLayout();
        }

        private void tmsiCloseAllButCurrent_Click(object sender, EventArgs e)
        {
            tabControl.SuspendLayout();
            TabPage activeTab = tabControl.SelectedTab;
            tabControl.SelectedIndex = 0;

            while (tabControl.TabCount > 1)
            {
                if (tabControl.SelectedTab == activeTab)
                    tabControl.SelectedIndex++;

                CloseSelectedTab();
            }

            tabControl.ResumeLayout();
        }

        private void cmsiCloseAllButCurrent_Click(object sender, EventArgs e)
        {
            tabControl.SuspendLayout();
            tabControl.SelectedIndex = 0;
            int tabIndex = (int)contextMenuTabPage.Tag;
            TabPage activeTab = tabControl.TabPages[tabIndex];

            while (tabControl.TabCount > 1)
            {
                if (tabControl.SelectedTab == activeTab)
                    tabControl.SelectedIndex++;

                CloseSelectedTab();
            }

            tabControl.ResumeLayout();
        }

        private void cmsiCloseThis_Click(object sender, EventArgs e)
        {
            int clickedIndex = (int)contextMenuTabPage.Tag;

            if (clickedIndex == tabControl.SelectedIndex)
            {
                tabControl.SelectedIndex = clickedIndex;
                CloseSelectedTab();
            }
            else
            {
                // Only restore the last selected tab if
                // closing a tab that is not the current selection
                TabPage tab = tabControl.SelectedTab;
                tabControl.SelectedIndex = clickedIndex;
                CloseSelectedTab();
                tabControl.SelectedTab = tab;
            }
        }

        private void cmsiShowInFolder_Click(object sender, EventArgs e)
        {
            int clickedIndex = (int)contextMenuTabPage.Tag;
            string fileName = PlainTextBoxes[clickedIndex].FileName;
            // Construct argument using the select switch and the entire file path.
            // to select the file after showing in folder
            Program.StartProcess("explorer.exe", $@"/select, ""{fileName}""");
        }

        private void cmsiOpenInWinNotepad_Click(object sender, EventArgs e)
        {
            int clickedIndex = (int)contextMenuTabPage.Tag;
            string fileName = PlainTextBoxes[clickedIndex].FileName;
            Program.StartProcess("Notepad.exe", fileName);
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            using (var dlgOpenFile = new OpenFileDialog())
            {
                dlgOpenFile.Multiselect = true;
                dlgOpenFile.Filter = Strings.FilterOpenFile;
                dlgOpenFile.FilterIndex = Options.OpenFilterIndex; // 7 is the last in the list

                if (dlgOpenFile.ShowDialog() == DialogResult.OK)
                {
                    LoadDocuments(dlgOpenFile.FileNames);
                    Options.OpenFilterIndex = dlgOpenFile.FilterIndex;
                }
            }
        }

        private void menuItemDlWebpage_DropDownOpened(object sender, EventArgs e)
        {
            // Check to see if there is a link in the clipboard, if there is then use it
            string text = Clipboard.GetText();
            UriHostNameType nameType = Uri.CheckHostName(text);

            if (nameType != UriHostNameType.Unknown)
            {
                textBoxHTMLLink.Text = text;
            }

            textBoxHTMLLink.Focus();
            textBoxHTMLLink.SelectAll();
        }

        private void textBoxHtmlLink_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                DownloadWebpageAsync();
            }
        }

        /// <summary>
        /// Makes a URL friendly
        /// </summary>
        private static string MakeUrlFriendly(string link)
        {
            if (Regex.IsMatch(link, @"https?://", RegexOptions.IgnoreCase))
                link = link.Insert(0, @"http://");

            return link;
        }

        /// <summary>
        /// Downloads a webpage with the specified link, returns an empty string
        /// if download fails
        /// </summary>
        private async void DownloadWebpageAsync()
        {
            menuItemDlWebpage.Enabled = false;
            menuItemFile.HideDropDown();
            string link = MakeUrlFriendly(textBoxHTMLLink.Text);
            var client = new WebClient();
            Cursor = Cursors.WaitCursor;

            try
            {
                // We want any possible exceptions to raise here, before adding a new tab
                var content = await client.DownloadStringTaskAsync(link);

                if (tabControl.TabCount > 0)
                {
                    if (SelectedPlainTextBox.FileName.Length != 0)
                        AddBlankTab();
                }
                else AddBlankTab();

                SelectedPlainTextBox.Text = content;
                string title = MakeStringFilenameSafe(menuItemDlWebpage.Text);
                SelectedPlainTextBox.SafeFileName = title;
                textBoxHTMLLink.Clear();
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
            finally
            {
                client.Dispose();
                Cursor = Cursors.Default;
                menuItemDlWebpage.Enabled = true;
            }
        }

        private void buttonRecentFileDropDown_Click(object sender, EventArgs e)
        {
            string filename = ((ToolStripMenuItem)sender).Tag.ToString();
            LoadDocuments(filename);
        }

        /// <summary>
        /// Write to file with or without prompt accordingly
        /// </summary>
        private void Save()
        {
            if (SelectedPlainTextBox.SavedOrOpened)
            {
                WriteActiveDocumentToFile();
                SelectedPlainTextBox.Modified = false;
                UpdateTabTextModifiedIndicator();
            }
            else
            {
                SaveAs();
            }
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void menuItemSaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void SaveAs()
        {
            using (var dialogSaveFile = new SaveFileDialog())
            {
                dialogSaveFile.Filter = Strings.FilterSaveFile;

                // If no safefilename and first line has little text then
                if (SelectedPlainTextBox.SafeFileName.Equals(Strings.NewDoc) &&
                    SelectedPlainTextBox.Text.Length > 0 && SelectedPlainTextBox.Lines[0].Length < 30)
                {
                    // use first line as filename
                    dialogSaveFile.FileName = MakeStringFilenameSafe(SelectedPlainTextBox.Lines[0]);
                }
                else
                {
                    string title = MakeStringFilenameSafe(SelectedPlainTextBox.SafeFileName);
                    dialogSaveFile.FileName = title;
                }

                string ext = Path.GetExtension(SelectedPlainTextBox.SafeFileName);

                // if no extension specified of extension is .txt
                if (ext == string.Empty || ext.Equals(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    dialogSaveFile.FilterIndex = 1; // txt file
                }
                else
                {
                    dialogSaveFile.FilterIndex = 2; // other file
                }

                if (dialogSaveFile.ShowDialog() == DialogResult.OK)
                {
                    SelectedPlainTextBox.FileName = dialogSaveFile.FileName;
                    WriteActiveDocumentToFile();
                    string safeFileName = Path.GetFileName(dialogSaveFile.FileName);
                    safeFileName = safeFileName.EllipsisClip(tabControl.Font, Options.MaxTabTextWidth);
                    tabControl.SelectedTab.Text = safeFileName;
                    Options.SaveFilterIndex = dialogSaveFile.FilterIndex;
                    SelectedPlainTextBox.SavedOrOpened = true;
                    SelectedPlainTextBox.Modified = false;
                    UpdateTabTextModifiedIndicator();
                }
            }
        }

        private void WriteActiveDocumentToFile()
        {
            SelectedPlainTextBox.ClearUndo();

            try
            {
                File.WriteAllLines(SelectedPlainTextBox.FileName, SelectedPlainTextBox.Lines);
                // Display save animation
                var save = new SaveAnimation(this);
                save.Animate();
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        private void menuItemPrint_Click(object sender, EventArgs e)
        {
            printing.PrintRichTextDocument(SelectedPlainTextBox.SafeFileName);
        }

        private void menuItemPrintPreview_Click(object sender, EventArgs e)
        {
            // Make sure the form is not "Always on top"
            bool mainFormTopMost = TopMost;
            TopMost = false;
            printing.ShowPrintPreview();
            TopMost = mainFormTopMost;
        }

        private void menuItemPageSetup_Click(object sender, EventArgs e)
        {
            printing.ShowPageSetupDialog();
        }

        private void menuItemCloseAndDelete_Click(object sender, EventArgs e)
        {
            if (SelectedPlainTextBox.FileName.Length > 0)
            {
                DialogResult result = MessageDialog.Show(Strings.MsgDeleteConfirmation,
                    MessageBoxIcon.Question, MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (File.Exists(SelectedPlainTextBox.FileName))
                            File.Delete(SelectedPlainTextBox.FileName);
                    }
                    catch (Exception ex)
                    {
                        ex.ShowError();
                    }

                    SelectedPlainTextBox.Modified = false;
                    CloseSelectedTab();
                }
            }
            else
            {
                CloseSelectedTab();
            }
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Edit Menu
        private void menuItemUndo_Click(object sender, EventArgs e)
        {
            // Strategically choose what textbox to undo
            if (SelectedPlainTextBox.Focused)
            {
                SelectedPlainTextBox.Undo();
                UpdateRedoUndoMenuItems();
            }
            else
            {
                var userControl = ActiveControl as UserControl;

                if (userControl != null)
                {
                    var textBox = userControl.ActiveControl as TextBox;
                    textBox?.Undo();
                }
                else
                {
                    var textBox = ActiveControl as TextBox;
                    textBox?.Undo();
                }
            }
        }

        private void menuItemRedo_Click(object sender, EventArgs e)
        {
            // Strategically choose what textbox to redo
            if (SelectedPlainTextBox.Focused)
            {
                SelectedPlainTextBox.Redo();
                UpdateRedoUndoMenuItems();
            }
        }

        private void menuItemCut_Click(object sender, EventArgs e)
        {
            // Strategically choose what textbox to cut
            if (SelectedPlainTextBox.Focused)
            {
                SelectedPlainTextBox.Cut();
            }
            //else
            //{
            //    UserControl userControl = this.ActiveControl as UserControl;

            //    if (userControl != null)
            //    {
            //        TextBox textBox = userControl.ActiveControl as TextBox;
            //        if (textBox != null) textBox.Cut();
            //    }
            //    else
            //    {
            //        TextBox textBox = this.ActiveControl as TextBox;
            //        if (textBox != null) textBox.Cut();
            //    }
            //}
        }

        private void menuItemCopy_Click(object sender, EventArgs e)
        {
            // Strategically choose what textbox to copy
            if (SelectedPlainTextBox.Focused)
            {
                SelectedPlainTextBox.Copy();
            }
            //else
            //{
            //    UserControl userControl = this.ActiveControl as UserControl;

            //    if (userControl != null)
            //    {
            //        TextBox textBox = userControl.ActiveControl as TextBox;
            //        if (textBox != null) textBox.Copy();
            //    }
            //    else
            //    {
            //        TextBox textBox = this.ActiveControl as TextBox;
            //        if (textBox != null) textBox.Copy();
            //    }
            //}
        }

        private void menuItemPaste_Click(object sender, EventArgs e)
        {
            if (SelectedPlainTextBox.Focused)
            {
                //var formats = DataFormats.GetFormat(DataFormats.Text);
                //PtbActive.Modified = false;
                SelectedPlainTextBox.Paste();
            }
            //else
            //{
            //    UserControl userControl = this.ActiveControl as UserControl;

            //    if (userControl != null)
            //    {
            //        TextBox textBox = userControl.ActiveControl as TextBox;
            //        if (textBox != null) textBox.Paste();
            //    }
            //    else
            //    {
            //        TextBox textBox = this.ActiveControl as TextBox;
            //        if (textBox != null) textBox.Paste();
            //    }
            //}
        }

        private void menuItemDelete_Click(object sender, EventArgs e)
        {
            if (SelectedPlainTextBox.Focused)
            {
                SelectedPlainTextBox.SelectedText = string.Empty;
            }
            else
            {
                UserControl userControl = ActiveControl as UserControl;

                if (userControl != null)
                {
                    TextBox textBox = userControl.ActiveControl as TextBox;
                    if (textBox != null) textBox.SelectedText = string.Empty;
                }
                else
                {
                    TextBox textBox = ActiveControl as TextBox;
                    if (textBox != null) textBox.SelectedText = string.Empty;
                }
            }
        }

        private void menuItemFind_CheckedChanged(object sender, EventArgs e)
        {
            if (menuItemFind.Checked)
            {
                panelFind = new FindPanel();
                panelFind.MatchCase = Options.IsFindMatchCase;
                panelFind.UpdateMainAcceptButton += (s, button) => AcceptButton = button;
                panelFind.FindNextClicked += (s, args) =>
                {
                    bool isFinished = SelectedPlainTextBox.FindNext
                    (panelFind.PatternBox.Text, FastFindMode.Contains, panelFind.MatchCase);

                    panelFind.PatternBox.BackColor = isFinished ?
                        Settings.SearchDoneColor : Color.FromKnownColor(KnownColor.Window);

                    panelFind.PatternBox.Focus();
                };

                panelFind.PatternBox.Text = SelectedPlainTextBox.SelectedText.Length > 0 ?
                    SelectedPlainTextBox.SelectedText : lastFindTerm;

                panelFind.RelatedMenuItem = menuItemFind;
                Controls.Add(panelFind);
                panelFind.Show();
                panelFind.PatternBox.Focus();
            }
            else
            {
                lastFindTerm = panelFind.PatternBox.Text;
            }
        }

        private void menuItemFindNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lastFindTerm))
            {
                menuItemFind.Checked = true;
            }
            else
            {
                bool finishedSearching = SelectedPlainTextBox.FindNext
                    (lastFindTerm, FastFindMode.Contains, Options.IsFindMatchCase);

                var color = finishedSearching ? Settings.SearchDoneColor : Color.FromKnownColor(KnownColor.Window);
                SetFindTextBoxBackColors(color);
            }
        }

        private void SetFindTextBoxBackColors(Color color)
        {
            if (panelFind != null)
                panelFind.PatternBox.BackColor = color;

            panelReplace?.SetFindTextBoxBackColor(color);
        }

        private void menuItemReplace_CheckedChanged(object sender, EventArgs e)
        {
            if (menuItemReplace.Checked)
            {
                panelReplace = new ReplacePanel(this) { RelatedMenuItem = menuItemReplace };

                if (SelectedPlainTextBox.SelectedText.Length > 0)
                    panelReplace.FindText = SelectedPlainTextBox.SelectedText;
                else
                    panelReplace.FindText = lastFindTerm;

                Controls.Add(panelReplace);
                panelReplace.BringToFront();
                tabControl.BringToFront();
                panelReplace.Show();
                panelReplace.SetTextBoxFocus();
            }

            else
            {
                lastFindTerm = panelReplace.FindText;
            }
        }

        private void menuItemGoto_CheckedChanged(object sender, EventArgs e)
        {
            if (menuItemGoto.Checked)
            {
                panelGoto = new GotoPanel(this) { RelatedMenuItem = menuItemGoto };
                Controls.Add(panelGoto);
                panelGoto.Show();
            }
        }

        private void menuItemSelectAll_Click(object sender, EventArgs e)
        {
            SelectedPlainTextBox.SelectAll();
        }

        private void menuItemLongDateTime_Click(object sender, EventArgs e)
        {
            SelectedPlainTextBox.SelectedText = DateTime.Now.ToLongDateString()
                + " " + DateTime.Now.ToLongTimeString();
        }

        private void menuItemShortDateTime_Click(object sender, EventArgs e)
        {
            SelectedPlainTextBox.SelectedText = DateTime.Now.ToShortDateString()
                + " " + DateTime.Now.ToShortTimeString();
        }

        private void menuItemSignature_Click(object sender, EventArgs e)
        {
            SelectedPlainTextBox.AppendLine().AppendLine().AppendText(Options.Signature);
        }

        // Also used to handle the enable changed event
        private void menuItemAutoIndent_CheckedChanged(object sender, EventArgs e)
        {
            // Does this code even ever fire?
            if (!menuItemAutoIndent.Enabled)
            {
                Options.AutoIndent = false;
                return;
            }

            Options.AutoIndent = menuItemAutoIndent.Checked;

            foreach (PlainTextBox textBox in PlainTextBoxes)
            {
                textBox.AutoIndent = menuItemAutoIndent.Checked;
                //textBox.SmartTabbing = menuItemSmartTabbing.Checked;
            }
        }

        private void menuItemRegexRefactoring_Click(object sender, EventArgs e)
        {
            using (var dialogRegexRefact = new RegexRefactoringForm(SelectedPlainTextBox))
            {
                dialogRegexRefact.ShowDialog();
            }
        }
        #endregion

        #region View Menu
        private void menuItemStatusBar_CheckedChanged(object sender, EventArgs e)
        {
            if (menuItemStatusBar.Checked)
            {
                statusBar.Show();
                UpdateStatusBar();
                menuItemWordWrap.Checked = menuItemWordWrap.Enabled = false;
            }
            else
            {
                statusBar.Hide();
                menuItemWordWrap.Enabled = true;
            }

            Options.StatusBarVisible = statusBar.Visible;
        }

        private void menuItemWordWrap_CheckedChanged(object sender, EventArgs e)
        {
            //Apply wordwrap to all richTextBoxes and save it as a setting
            foreach (PlainTextBox textBox in PlainTextBoxes)
            {
                textBox.WordWrap = menuItemWordWrap.Checked;
            }

            if (menuItemWordWrap.Checked) statusBar.Hide();
            menuItemAutoIndent.Enabled = !menuItemWordWrap.Checked;
            menuItemStatusBar.Enabled = !menuItemWordWrap.Checked;
            Options.WordWrap = menuItemWordWrap.Checked;
        }

        private void menuItemLineNumbers_CheckedChanged(object sender, EventArgs e)
        {
            Options.LineNumberVisible = menuItemLineNumbers.Checked;
            tabControl.LineNumbersVisible = menuItemLineNumbers.Checked;
        }

        private void menuItemFullscreen_CheckedChanged(object sender, EventArgs e)
        {
            SuspendLayout();

            if (menuItemFullscreen.Checked)
            {
                if (WindowState == FormWindowState.Maximized)
                {
                    WindowState = FormWindowState.Normal;
                }

                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                mainMenu.Hide();
            }
            else
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                mainMenu.Show();
            }

            ResumeLayout();
        }

        private void menuItemSettings_CheckedChanged(object sender, EventArgs e)
        {
            using (var formSettings = new SettingsDialog(this))
            {
                formSettings.TopMost = Options.TopMost;
                formSettings.ShowDialog();
            }
        }

        private void menuItemShowReadingWindow_Click(object sender, EventArgs e)
        {
            Hide();
            var formReadingView = new ReadingForm(SelectedPlainTextBox.Text);
            formReadingView.Closed += delegate { Show(); };
            formReadingView.ClientSize = new Size(Options.ReadingWidth, 500);

            if (Options.ReadingViewBounds.Equals(Rectangle.Empty))
            {
                formReadingView.ClientSize = new Size(Options.ReadingWidth, 500);
                formReadingView.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                formReadingView.DesktopBounds = Options.ReadingViewBounds;
            }

            formReadingView.Show();
        }

        private void menuItemMinimizeToTray_Click(object sender, EventArgs e)
        {
            trayIcon.MinimizeToTray();
        }

        private void menuItemAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            Options.TopMost = menuItemAlwaysOnTop.Checked;
            TopMost = menuItemAlwaysOnTop.Checked;
        }
        #endregion

        #region Help Menu
        private void menuItemAbout_CheckedChanged(object sender, EventArgs e)
        {
            using (var formAbout = new AboutForm())
            {
                formAbout.TopMost = TopMost;
                formAbout.ShowDialog();
            }
        }

        private void menuItemProductDoc_Click(object sender, EventArgs e)
        {
            Program.StartProcess(Resources.DocumentationFilename);
        }

        private void menuItemUpdates_Click(object sender, EventArgs e)
        {
            using (var formUpdate = new UpdateForm(Resources.DownloadLink))
            {
                formUpdate.ShowDialog();
            }
        }
        #endregion
        #endregion

        #region PlainTextBox
        private void PlainTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateAllInfo();
        }

        private void PlainTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            // Make sure enter key is for newlines when textbox has focus
            AcceptButton = null;
            toolTip.Hide((PlainTextBox)sender);
        }

        private void PlainTextBox_SelectionChanged(object sender, EventArgs e)
        {
            if (statusBar.Visible)
            {
                labelCurrentLine.Text = SelectedPlainTextBox.Selection.ToLine.ToString();
                labelCurrentColumn.Text = SelectedPlainTextBox.Selection.End.ToString();
            }

            //if (Options.TrackSelection)
            //{
            //    tabControl.UpdateCaretTraker();
            //}
        }

        private void PlainTextBox_DragDrop(object sender, DragEventArgs e)
        {
            // If drag content is text, insert at cursor pos
            // Otherwise append file if filedrop
            //if (e.Data.GetDataPresent(DataFormats.Text))
            //{
            //    string content = e.Data.GetData(DataFormats.Text).ToString();
            //    Point pos = new Point(e.X, e.Y);
            //    pos = PtbActive.PointToClient(pos);
            //    int index = PtbActive.GetCharIndexFromPosition(pos);
            //    PtbActive.Text = PtbActive.Text.Insert(index, content);
            //    PtbActive.Select(index, 0);
            //    PtbActive.Focus();
            //}
            //else
            //{
            //    var filenames = e.Data.GetData(DataFormats.FileDrop) as string[];
            //    if (filenames != null) AppendFiles(filenames);
            //}
        }

        private void plainTextBox_FileNameChanged(object sender, EventArgs e)
        {
            var box = (PlainTextBox)sender;
            tabControl.SelectedTab.ToolTipText = box.FileName;
        }

        private void plainTextBox_Scroll(object sender, EventArgs e)
        {
            //if (Options.TrackSelection)
            //{
            //    tabControl.UpdateCaretTraker();
            //}
        }

        private void plainTextBox_ModifiedChanged(object sender, EventArgs e)
        {
            UpdateTabTextModifiedIndicator();
        }
        #endregion

        #region TabControl
        /// <summary>
        /// Every time a tapPage is added tot he tabControl. Add a PlainTextBox
        /// Control inside that tabPage. Also setup events for the textBox.
        /// </summary>
        private void tabControl_ControlAdded(object sender, ControlEventArgs e)
        {
            timerMessage.Dispose();
            Text = Application.ProductName;
            // Only Update for the first tab as the selected index changed event will not raise
            if (tabControl.TabCount == 1)
            {
                UpdateControlAbilitys();
            }

            var plainTextBox = (PlainTextBox)e.Control.Controls[0];
            plainTextBox.Font = Options.Font;
            plainTextBox.AutoIndent = Options.AutoIndent;
            plainTextBox.ContextMenuStrip = contextMenuTextArea;
            //plainTextBox.Modified = false; // Modified is true by default for some reason...?
            plainTextBox.TextChanged += PlainTextBox_TextChanged;
            plainTextBox.SelectionChanged += PlainTextBox_SelectionChanged;
            plainTextBox.MouseClick += PlainTextBox_MouseClick;
            plainTextBox.DragDrop += PlainTextBox_DragDrop;
            plainTextBox.Scroll += plainTextBox_Scroll;
            plainTextBox.Scroll += plainTextBox_Scroll;
            //plainTextBox.FileNameChanged += plainTextBox_FileNameChanged;
            plainTextBox.ModifiedChanged += plainTextBox_ModifiedChanged;
            printing = new Printing(SelectedPlainTextBox);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAllInfo();
            UpdateControlAbilitys();

            if (tabControl.TabCount > 0)
            {
                printing = new Printing(SelectedPlainTextBox);
                SelectedPlainTextBox.Select();
            }
        }

        private void tabControl_MouseDown(object sender, MouseEventArgs e)
        {
            //if we right click the tab we will open up a context for that tab
            if (e.Button != MouseButtons.Right) return;

            for (int i = 0; i < tabControl.TabCount; i++)
            {
                if (tabControl.GetTabRect(i).Contains(e.Location))
                {
                    contextMenuTabPage.Tag = i;
                    bool hasFilename = SelectedPlainTextBox.FileName.Length > 0;
                    cmsiShowInFolder.Enabled = cmsiOpenInWinNotepad.Enabled = hasFilename;
                    contextMenuTabPage.Show(tabControl, e.Location);
                    return;
                }
            }
        }

        private void tabControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (menuItemFullscreen.Checked)
            {
                // The smaller the number the less sensitive
                const uint SHOW_SENSITIVITY = 5;
                mainMenu.Visible = (e.Y < SHOW_SENSITIVITY);
            }

            for (int i = 0; i < tabControl.TabCount; i++)
            {
                if (tabControl.GetTabRect(i).Contains(e.Location))
                {
                    tabControl.TabPages[i].ToolTipText = PlainTextBoxes[i].FileName;
                    return;
                }
            }
        }

        private void tabControl_DragDrop(object sender, DragEventArgs e)
        {
            var fileNames = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (fileNames != null) LoadDocuments(fileNames);
        }

        private void tabControl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                e.Effect = DragDropEffects.All;
            }
        }
        #endregion

        #region Misc Functions
        /// <summary>
        /// Loads documents into the application.
        /// Always call this instead of the two "load into" methods.
        /// </summary>
        private void LoadDocuments(params string[] fileNames)
        {
            tabControl.SuspendLayout();
            LoadIntoSeparateTabs(fileNames);
            UpdateAllInfo();
            tabControl.ResumeLayout();
        }

        /// <summary>
        /// Extracts and returns the file safe characters as a string.
        /// </summary>
        private static string MakeStringFilenameSafe(string text)
        {
            char[] invalids = Path.GetInvalidPathChars();
            var builder = new StringBuilder();

            // Iterate characters that are a letter, digit, or safe symbol.
            foreach (char c in text.Where(c => !invalids.Contains(c)))
                builder.Append(c);

            return builder.ToString();
        }

        /// <summary>
        /// Displays a message box and prompts for save
        /// the return value indicates whether or whether not the tab or app
        /// should be closed when the user presses a button.
        /// Cancel of course returns true so nothing will happen in the calling code.
        /// </summary>
        private bool PromptToSave()
        {
            // Display from tab text here because it is all visual
            // full safe file name is not required
            string message = string.Format(Strings.MsgSaveFile, SelectedPlainTextBox.SafeFileName);
            DialogResult result = MessageDialog.Show(message, MessageBoxIcon.Question, MessageBoxButtons.YesNoCancel);

            //return true to cancel the closing of the form
            if (result == DialogResult.Yes)
            {
                Save();
            }
            else if (result == DialogResult.Cancel)
            {
                return true;
            }

            return false;
        }

        private void CloseSelectedTab()
        {
            // A save prompt will only pop-up when document has been modified
            // and the current text does not match up with initial text state.
            if (SelectedPlainTextBox.Modified)
            {
                if (!PromptToSave()) CleanUp();
            }
            else
            {
                CleanUp();
            }
        }

        private void CleanUp()
        {
            // Remove all document dependent panels before closing last tab
            if (tabControl.TabCount == 1)
            {
                menuItemGoto.Checked = menuItemFind.Checked = false;
                menuItemReplace.Checked = false;
            }

            SelectedPlainTextBox.Dispose();
            tabControl.TabPages.Remove(tabControl.SelectedTab);
            tabControl.SelectedIndex = tabControl.TabCount - 1;
        }

        private void UpdateStatusBar()
        {
            if (statusBar.Visible && tabControl.SelectedIndex != -1)
            {
                labelTabCount.Text = (tabControl.TabCount).ToString();
                labelTabSelected.Text = (tabControl.SelectedIndex + 1).ToString();
                labelCurrentLine.Text = SelectedPlainTextBox.Selection.ToLine.ToString();
                labelCurrentColumn.Text = SelectedPlainTextBox.Selection.End.ToString();
                labelCharCount.Text = SelectedPlainTextBox.Text.Length.ToString();
            }
        }

        private void UpdateAllInfo()
        {
            if (tabControl.TabCount == 0)
            {
                labelTabSelected.Text = labelCurrentLine.Text =
                    labelCurrentColumn.Text = labelTabCount.Text = "0";
            }
            else
            {
                UpdateStatusBar();
                UpdateRedoUndoMenuItems();
                UpdateTabTextModifiedIndicator();
            }
        }

        /// <summary>
        /// Updates the tab-text property with the appropriate save indication if necessary
        /// </summary>
        private void UpdateTabTextModifiedIndicator()
        {
            string title = tabControl.SelectedTab.Text.TrimEnd('*');

            if (SelectedPlainTextBox.SavedOrOpened && SelectedPlainTextBox.Modified)
            {
                title += "*";
            }

            if (tabControl.SelectedTab.Text[tabControl.SelectedTab.Text.Length - 1] !=
                title[title.Length - 1])
            {
                tabControl.SelectedTab.Text = title;
            }
        }

        private void AppendFiles(IEnumerable<string> fileNames)
        {
            SelectedPlainTextBox.SuspendLayout();

            foreach (string name in fileNames)
            {
                if (!LoadLargeFile(name)) continue;

                StreamReader SR = null;

                try
                {
                    SR = new StreamReader(name);
                    SelectedPlainTextBox.AppendLine(SR.ReadToEnd()).AppendLine();
                    Options.RecentFiles.Push(name);
                    SelectedPlainTextBox.Modified = true;
                }
                catch (Exception ex)
                {
                    ex.ShowError();
                }
                finally
                {
                    SR?.Close();
                }
            }

            SelectedPlainTextBox.Text = SelectedPlainTextBox.Text.Trim();
            SelectedPlainTextBox.ResumeLayout();
        }

        /// <summary>
        /// Checks to see if file is already loaded into a tab, if it is, the
        /// method returns true and selects that tab.
        /// </summary>
        private bool IsAlreadyOpen(string fileName)
        {
            for (int i = 0; i < PlainTextBoxes.Length; i++)
            {
                if (fileName.Equals(PlainTextBoxes[i].FileName, StringComparison.OrdinalIgnoreCase))
                {
                    // Do not select the tabPage if it is already selected
                    // otherwise the tabControl will navigate to last selected
                    if (!tabControl.SelectedIndex.Equals(i))
                    {
                        tabControl.SelectTab(i);
                    }

                    return true;
                }
            }

            return false;
        }

        /// <returns>Returns true if user agrees to load large file, otherwise return false</returns>
        private static bool LoadLargeFile(string fileName)
        {
            var fileInfo = new FileInfo(fileName);

            if (Settings.Instance.ShowLargeFileWarning && fileInfo.IsFileLarge())
            {
                string safeFileName = Path.GetFileName(fileName);
                var msg = safeFileName + " " + Strings.MsgBigFile;
                DialogResult result = MessageDialog.Show(msg, MessageBoxIcon.Warning, MessageBoxButtons.YesNo);
                return (result == DialogResult.Yes);
            }

            return true;
        }

        private void LoadIntoSeparateTabs(IEnumerable<string> fileNames)
        {
            bool hasOneFileAlreadyOpen = false;

            foreach (string name in fileNames)
            {
                if (name.Length == 0)
                {
                    AddBlankTab();
                    continue;
                }

                // If user decides not to load big file
                if (!LoadLargeFile(name)) continue;
                hasOneFileAlreadyOpen = IsAlreadyOpen(name);
                if (hasOneFileAlreadyOpen) continue;

                try
                {
                    string safeFileName = Path.GetFileName(name);
                    safeFileName = safeFileName.EllipsisClip(tabControl.Font, Options.MaxTabTextWidth);
                    tabControl.TabPages.Add(safeFileName);
                    int index = tabControl.TabPages.Count - 1;
                    string content = File.ReadAllText(name);
                    //RicherTextBoxes[index].LoadFile(name, RichTextBoxStreamType.PlainText);
                    PlainTextBoxes[index].Text = content;
                    PlainTextBoxes[index].FileName = name.TrimEnd();
                    PlainTextBoxes[index].Modified = false;
                    PlainTextBoxes[index].SavedOrOpened = true;
                    Options.RecentFiles.Push(name);
                }
                catch (Exception ex)
                {
                    tabControl.SelectedIndex = tabControl.TabCount - 1;
                    CloseSelectedTab();
                    ex.ShowError();
                }
            }

            if (!hasOneFileAlreadyOpen)
            {
                tabControl.SelectedIndex = tabControl.TabCount - 1;
            }

            UpdateAllInfo();
        }

        public void OpenFileFromArguments(string[] args)
        {
            LoadDocuments(args);
            trayIcon.UnMinimizeFromTray();
            BringToFront();
        }

        /// <summary>
        /// Disables and enables certain controls according to whether or not there are tabs
        /// Disabling controls lets the user know that certain operations are unavailable
        /// with certain criteria. This is better than an error dialog box by far.
        /// </summary>
        private void UpdateControlAbilitys()
        {
            bool isEnabled = (tabControl.TabCount > 0);
            menuItemEdit.Enabled = menuItemWordWrap.Enabled = isEnabled;
            menuItemFind.Enabled = menuItemGoto.Enabled = isEnabled;
            menuItemReplace.Enabled = menuItemInsert.Enabled = isEnabled;
            menuItemFindNext.Enabled = isEnabled;
            menuItemSaveAs.Enabled = menuItemSave.Enabled = isEnabled;
            menuItemShortDateTime.Enabled = menuItemLongDateTime.Enabled = isEnabled;
            menuItemPageSetup.Enabled = menuItemPrint.Enabled = isEnabled;
            menuItemPrintPreview.Enabled = menuItemCloseTab.Enabled = isEnabled;
            menuItemCloseAllTabs.Enabled = menuItemCloseAllButCurrent.Enabled = isEnabled;
            menuItemCloseAndDelete.Enabled = menuItemSelectAll.Enabled = isEnabled;
            menuItemReadingWindow.Enabled = isEnabled;

            if (!isEnabled)
            {
                menuItemUndo.Enabled = menuItemRedo.Enabled = false;
            }
        }

        private void UpdateRedoUndoMenuItems()
        {
            menuItemUndo.Enabled = SelectedPlainTextBox.UndoEnabled;
            menuItemRedo.Enabled = SelectedPlainTextBox.RedoEnabled;
        }

        /// <summary>
        /// To update the multi-line tab placement from the preference panel.
        /// </summary>
        public void SetMultilineTabbing()
        {
            tabControl.Multiline = Options.MultiLineTabs;
        }
        #endregion

        #region General Event Handlers
        private void buttonPrompt_Click(object sender, EventArgs e)
        {
            SuspendLayout();

            // Get rid of blank tab if present
            if (tabControl.TabCount > 0)
            {
                CloseSelectedTab();
            }

            if (Options.LastSession.FilesOpen.Count > 0)
                LoadDocuments(Options.LastSession.FilesOpen.ToArray());

            if (tabControl.TabCount > 0 && Options.LastSession.SelectedTabIndex < tabControl.TabCount)
            {
                menuItemFind.Checked = Options.LastSession.FindPanelOpen;
                menuItemGoto.Checked = Options.LastSession.GotoPanelOpen;
                menuItemReplace.Checked = Options.LastSession.ReplacePanelOpen;

                // Do not reselect tab or it will be unselected
                if (!tabControl.SelectedIndex.Equals(Options.LastSession.SelectedTabIndex))
                    tabControl.SelectedIndex = Options.LastSession.SelectedTabIndex;

                SelectedPlainTextBox.SelectionStart = Options.LastSession.SelectedTextIndex;
                SelectedPlainTextBox.SelectionLength = Options.LastSession.SelectedTextLength;
            }

            ResumeLayout();
        }

        private void timerMessage_Tick(object sender, EventArgs e)
        {
            // The amount of time required for the app to idle before prompting to add tabs
            const int IDLE_TIME_BEFORE_PROMPT = 15;

            if (ticks++ == IDLE_TIME_BEFORE_PROMPT)
            {
                Text = Application.ProductName + " - " + Strings.MsgAddTabPrompt;
                // We will only display this message once so we may as well dispose of this after using
                timerMessage.Dispose();
            }
        }

        private void statusBar_VisibleChanged(object sender, EventArgs e)
        {
            UpdateStatusBar();
        }

        private void Generic_MouseMove(object sender, MouseEventArgs e)
        {
            if (menuItemFullscreen.Checked)
                mainMenu.Visible = (e.Y < 5);
        }

        private async void menuItemNinjaWords_Click(object sender, EventArgs e)
        {
            try
            {
                var selTextBox = SelectedPlainTextBox;
                var terms = await Ninja.GetTermsAsync(selTextBox.SelectedText);

                if (selTextBox != null)
                {
                    var selection = selTextBox.Selection;
                    var size = Style.GetSizeOfRange(selection);

                    // Always align to the left of the selection so that the tooltip
                    // appears directly under the selection.
                    Place leftMostCharPlace = selection.Start.iChar < selection.End.iChar
                        ? selection.Start : selection.End;

                    Point pos = selTextBox.PositionToPoint(selTextBox.PlaceToPosition(leftMostCharPlace));
                    pos = new Point(pos.X, pos.Y + size.Height);

                    string text = terms == null || terms.Length == 0 || !terms.First().Defined
                        ? Strings.NoDefFound : terms.First().ToString();

                    toolTip.Show(text, selTextBox, pos);
                }
            }
            catch (WebException ex)
            {
                ex.ShowError();
            }
            catch (ArgumentException ex)
            {
                ex.ShowError();
            }
        }
        #endregion
    }
}