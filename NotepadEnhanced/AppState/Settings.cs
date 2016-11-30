using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AboPersistance;
using NotepadEnhanced.Localization;
using NotepadEnhanced.Refactexing;
using NotepadEnhanced.Forms;
using NotepadEnhanced.Forms;

namespace NotepadEnhanced.AppState
{
    /// <summary>
    /// Represents settings for Notepad Enhanced.
    /// </summary>
    [Serializable]
    public class Settings : SettingsBase<Settings>
    {
        /// <summary>
        /// The Color to use (typically for a TextBox backcolor) when a search is done.
        /// </summary>
        [NonSerialized]
        public static readonly Color SearchDoneColor = Color.FromArgb(255, 192, 192);

        #region Properties
        /// <summary>
        /// Get or sets a value indicating whether word-wrap is in use for all tabs.
        /// </summary>
        public bool WordWrap { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the status bar is visible.
        /// </summary>
        public bool StatusBarVisible { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use AutoWordSelection for all PlainTextBoxes.
        /// </summary>
        public bool AutoWordSelection { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is the first boot of the application.
        /// </summary>
        public bool FirstBoot { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to keep the main window always on top.
        /// </summary>
        public bool TopMost { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance of the app will be a single instance.
        /// </summary>
        public bool SingleInstance { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether line numbers are visible.
        /// </summary>
        public bool LineNumberVisible { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use smart tabbing.
        /// </summary>
        public bool AutoIndent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use multiple lines for the tabs.
        /// </summary>
        public bool MultiLineTabs { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to track selection around the PlainTextBoxes
        /// with green rectangular indicators.
        /// </summary>
        public bool TrackSelection { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to add a blank tab on startup.
        /// </summary>
        public bool AddTabOnStart { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the recent file queue is enabled.
        /// </summary>
        public bool RecentFilesEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to add the title of the document to the
        /// print out when printing the document.
        /// </summary>
        public bool AddTitleToPrint { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use case-sensitivity when finding sub-strings.
        /// </summary>
        public bool IsFindMatchCase { get; set; }

        /// <summary>
        /// Gets or sets whether to show the large file warning in a 
        /// message box
        /// </summary>
        public bool ShowLargeFileWarning { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show the 
        /// selection margin (to the left) for all <see cref="PlainTextBox"/>es.
        /// </summary>
        public bool ShowSelectionMargin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to prompt the user to restore to the last session.
        /// </summary>
        public bool PromptToRestore { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the reading view will stay on top of other windows.
        /// </summary>
        public bool ReadingViewTopMost { get; set; }

        /// <summary>
        /// Gets or sets the last reading view width.
        /// </summary>
        public int ReadingWidth { get; set; }

        /// <summary>
        /// Gets or sets the reading view horizontal padding.
        /// </summary>
        public int ReadingHorizPadding { get; set; }

        /// <summary>
        /// Get or sets the reading vertical padding.
        /// </summary>
        public int ReadingVertPadding { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="OpenFileDialog"/> filter index.
        /// </summary>
        public int OpenFilterIndex { get; set; }

        /// <summary>
        /// Get or sets the boot count of this program.
        /// </summary>
        public int BootCount { get; set; }

        /// <summary>
        /// Gets or sets the print title alignment.
        /// </summary>
        public int PrintTitleAlign { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="SaveFileDialog"/> filter index.
        /// </summary>
        public int SaveFilterIndex { get; set; }

        /// <summary>
        /// Gets or sets the index of the last opened settings tab.
        /// </summary>
        public int SettingsTabIndex { get; set; }

        /// <summary>
        /// Gets the maximum width of a tabs caption.
        /// </summary>
        public int MaxTabTextWidth  {  get { return 150; } set { } }

        /// <summary>
        /// Gets or sets the reading mode for the reading view.
        /// </summary>
        public ReadingMode ReadingMode { get; set; }

        /// <summary>
        /// Gets or sets the culture notation.
        /// </summary>
        public string Culture { get; set; }

        /// <summary>
        /// Gets or sets the users signature.
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// Gets or sets the recent files list.
        /// </summary>
        public RecentCollection<string> RecentFiles { get; set; }

        /// <summary>
        /// Gets or sets the color of the font for all <see cref="PlainTextBox"/>es.
        /// </summary>
        public Color FontColor { get; set; }

        /// <summary>
        /// Gets or sets the line number foreground color.
        /// </summary>
        public Color LineNumForeColor { get; set; }

        /// <summary>
        /// Gets or sets the reading text background color.
        /// </summary>
        public Color ReadingBackColor { get; set; }

        /// <summary>
        /// Gets or sets the reading window color.
        /// </summary>
        public Color ReadingWindowColor { get; set; }

        /// <summary>
        /// Gets or sets the reading foreground color.
        /// </summary>
        public Color ReadingForeColor { get; set; }

        /// <summary>
        /// Gets or sets the editor background color.
        /// </summary>
        public Color BackColor { get; set; }

        /// <summary>
        /// Gets or sets the editors font.
        /// </summary>
        public Font Font { get; set; }

        /// <summary>
        /// Gets or sets the reading view font.
        /// </summary>
        public Font ReadingFont { get; set; }

        /// <summary>
        /// Gets or sets the reading view bounds.
        /// </summary>
        public Rectangle ReadingViewBounds { get; set; }

        /// <summary>
        /// Gets or sets the bounds of the MainForm.
        /// </summary>
        public Rectangle MainFormBounds { get; set; }

        /// <summary>
        /// Gets or sets the MainForm's last window state.
        /// </summary>
        public FormWindowState MainFormState { get; set; }

        /// <summary>
        /// Gets or sets the last session data.
        /// </summary>
        public LastSession LastSession { get; set; }

        /// <summary>
        /// Gets or sets a list of Refactex.
        /// </summary>
        public List<Refactex> Refactexes { get; set; }
        #endregion

        public override void Reset()
        {
            WordWrap = true;
            FirstBoot = true;
            SingleInstance = true;
            AddTabOnStart = true;
            RecentFilesEnabled = true;
            AddTitleToPrint = true;
            ShowLargeFileWarning = true;
            ShowSelectionMargin = true;
            ReadingViewTopMost = true;
            ReadingWidth = 800;
            ReadingHorizPadding = 30;
            OpenFilterIndex = 7;
            ReadingVertPadding = 30;
            SettingsTabIndex = 0;
            BootCount = 5;
            RecentFiles = new RecentCollection<string>(6);
            PrintTitleAlign = 1;
            MaxTabTextWidth = 150;
            Culture = "en-us";
            Signature = String.Empty;
            FontColor = Color.FromKnownColor(KnownColor.ControlText);
            ReadingBackColor = Color.PapayaWhip;
            ReadingWindowColor = ReadingBackColor = Color.Tan;
            ReadingForeColor = Color.FromArgb(40, 40, 40);
            BackColor = Color.FromKnownColor(KnownColor.ControlLightLight);
            LineNumForeColor = Color.FromArgb(136, 136, 136);
            Font = new Font("Tahoma", 12f);
            ReadingFont = new Font("Verdana", 14.25f);
            ReadingViewBounds = Rectangle.Empty;
            MainFormBounds = new Rectangle(0, 0, 600, 600);
            MainFormState = FormWindowState.Normal;
            LastSession = new LastSession();
            SetDefaultRefactexes();
        }

        protected override void OnLoadFailed(Exception ex)
        {
            MessageDialog.ShowError(Strings.SettingsReset);
        }

        private void SetDefaultRefactexes()
        {
            Refactexes = new List<Refactex>(new[]
                {
                    RefactexPresets.BulletInserter,
                     RefactexPresets.TrimWhiteSpace,
                      RefactexPresets.SingleSpaceOnly,
                      RefactexPresets.RemoveNumberedList,
                      RefactexPresets.ReduceToDoubleNewlines
                });
        }
    }
}