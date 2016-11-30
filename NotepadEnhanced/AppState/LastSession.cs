using System;
using System.Collections.Generic;

namespace NotepadEnhanced.AppState
{
    /// <summary>
    /// Represents a state which stores the last known state of the program.
    /// </summary>
    [Serializable]
    public class LastSession
    {
        /// <summary>
        /// Gets or sets whether the FindPanel is open.
        /// </summary>
        public bool FindPanelOpen { get; set; }

        /// <summary>
        /// Gets or sets whether the ReplacePanel is open.
        /// </summary>
        public bool ReplacePanelOpen { get; set; }

        /// <summary>
        /// Gets or sets whether the GotoPanel is open.
        /// </summary>
        public bool GotoPanelOpen { get; set; }

        /// <summary>
        /// Gets or sets the last find term.
        /// </summary>
        public string FindText { get; set; }

        /// <summary>
        /// Gets or sets a list of the file paths of the last files open.
        /// </summary>
        public List<string> FilesOpen { get; set; }

        /// <summary>
        /// Gets or sets the last selected tab index.
        /// </summary>
        public int SelectedTabIndex { get; set; }

        /// <summary>
        /// Gets or sets the last selection length of the last active text-box.
        /// </summary>
        public int SelectedTextLength { get; set; }

        /// <summary>
        /// Gets or sets the last selected index of the last active text-box.
        /// </summary>
        public int SelectedTextIndex { get; set; }
    }
}