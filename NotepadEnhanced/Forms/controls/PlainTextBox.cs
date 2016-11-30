using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace NotepadEnhanced.Forms
{
    public enum FastFindMode
    {
        Contains,
        Regex
    }

    public enum FastFindDirection
    {
        Forward,
        Backward
    }

    /// <summary>
    /// Represents a fast coloring textbox for plain-text.
    /// </summary>
    public class PlainTextBox : FastColoredTextBox, INotifyPropertyChanged, ICloneable
    {
        private string lastFindPattern = string.Empty;
        private int lastFindPos; // Gets the last position after finding a word or yielding no results

        private bool modified;
        public bool Modified
        {
            get { return modified; }
            set
            {
                if (value != modified)
                {
                    modified = value;
                    OnModifiedChanged();
                }
            }
        }

        public bool SavedOrOpened { get; set; }

        /// <summary>
        /// Gets the new line char used by the <see cref="RichTextBox"/>.
        /// </summary>
        [Browsable(false)]
        public char NewLine => '\n';

        private string safeFileName = "New Text Document";
        /// <summary>
        /// Gets or sets the filename, without the directory and with the extension.
        /// </summary>
        [Browsable(false)]
        public string SafeFileName
        {
            get { return safeFileName; }
            set
            {
                safeFileName = value;
                string dir = Path.GetDirectoryName(safeFileName);
                fileName = Path.Combine(dir, safeFileName);
                SafeFileNameChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private string fileName = string.Empty;
        /// <summary>
        /// Gets or sets the filename for the most recently loaded file.
        /// </summary>z
        public string FileName
        {
            get { return fileName; }
            set
            {
                if (fileName.Equals(value, StringComparison.OrdinalIgnoreCase)) return;
                fileName = value;
                safeFileName = Path.GetFileName(fileName);

                // Combine if
                if (!value.Equals(fileName, StringComparison.OrdinalIgnoreCase))
                {
                    // TODO: Pass in rtb??
                    FileNameChanged(this, EventArgs.Empty);
                }
            }
        }

        private bool hasText;
        /// <summary>
        /// Gets whether the <see cref="Control.Text"/> property is empty.
        /// </summary>
        [Bindable(true)]
        [Browsable(false)]
        public bool HasText
        {
            get { return hasText; }
            set
            {
                if (hasText != value)
                {
                    hasText = value;
                    OnPropertyChanged("HasText");
                }
            }
        }

        /// <summary>
        /// Occurs when the value of the <see cref="SafeFileName"/> property changes.
        /// </summary>
        public event EventHandler SafeFileNameChanged = delegate { };

        /// <summary>
        /// Occurs when the value of the <see cref="FileName"/> property changes.
        /// </summary>
        public event EventHandler FileNameChanged = delegate { };

        public PlainTextBox()
        {
            BorderStyle = BorderStyle.FixedSingle;
            Paddings = new Padding(3);
        }

        public event EventHandler ModifiedChanged;

        protected virtual void OnModifiedChanged()
        {
            ModifiedChanged?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnTextChanged(TextChangedEventArgs args)
        {
            base.OnTextChanged(args);
            Modified = true;
            HasText = Text.Length > 0;
        }

        /// <summary>
        /// Occurs when the value of a bindable property changes.
        /// </summary>
        [Browsable(false)]
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void GoTo(int line)
        {
            Selection = new Range(this, 0, line, 0, line);
        }

        /// <summary>
        /// Selects a range of text with the specified indexes.
        /// </summary>
        /// <param name="start">The start of the selection.</param>
        /// <param name="lenth">The length of the selection.</param>
        public void Select(int start, int lenth)
        {
            Selection = new Range(this, start, 0, start + lenth, 0);
        }

        public int Find(string pattern, int startAt, FastFindMode mode, bool matchCase, 
            FastFindDirection direction = FastFindDirection.Forward)
        {
            if (mode == FastFindMode.Contains)
            {
                StringComparison SC = matchCase ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
                int index = -1;

                if (direction == FastFindDirection.Forward)
                {
                    index = Text.IndexOf(pattern, startAt, SC);
                }
                else
                {
                    index = Text.LastIndexOf(pattern, startAt, SC);
                }

                if (index != -1)
                {
                    SelectionStart = index;
                    SelectionLength = pattern.Length;
                    return index;
                }
            }
            else
            {
                RegexOptions options = matchCase ? RegexOptions.None : RegexOptions.IgnoreCase;
                Match match = Regex.Match(Text, pattern, options);

                if (match.Success)
                {
                    SelectionStart = match.Index;
                    SelectionLength = match.Length;
                    return match.Index;
                }
            }

            return -1;
        }

        public bool FindNext(string pattern, FastFindMode mode, bool matchCase,       
            FastFindDirection direction = FastFindDirection.Forward)
        {
            if (pattern.Length == 0 || HasText == false) return false;
            int pos;

            if (lastFindPos > -1 && lastFindPattern == pattern)
            {
                int start = (lastFindPos + 1 > Text.Length) ? 0 : lastFindPos + 1;
                pos = Find(pattern, start, mode, matchCase, direction);
            }
            else
            {
                pos = Find(pattern, 0, mode, matchCase, direction);
            }

            lastFindPos = (pos < 0) ? 0 : pos;
            lastFindPattern = pattern;
            return pos != -1;
        }

        /// <summary>
        /// Appends the specified text followed by a new line.
        /// </summary>
        /// <param name="text">The text to append.</param>
        public PlainTextBox AppendLine(string text = "")
        {
            AppendText(text + NewLine);
            return this;
        }

        /// <summary>
        /// Clone for typical multi-tab use.
        /// </summary>
        public object Clone()
        {
            var box = new PlainTextBox
            {
                ForeColor = ForeColor,
                BackColor = BackColor,
                Font = (Font) Font.Clone(),
                Dock = Dock,
                WordWrap = WordWrap,
                BorderStyle = BorderStyle,
                DelayedEventsInterval = DelayedEventsInterval,
                DelayedTextChangedInterval = DelayedTextChangedInterval
            };
            //_keyShortcuts = new Dictionary<Keys, Action>(_keyShortcuts),
            //var clone = (RicherTextBox)MemberwiseClone();
            //// Clone reference types
            //clone.LazySelecter = (LazyEventer)LazySelecter.Clone();
            //clone.LazyTyper = (LazyEventer)LazyTyper.Clone();
            //clone._lazyStateTracker = (LazyEventer) _lazyStateTracker.Clone();
            //clone._redoUndoMan = new RedoUndoManger<RichTextState>();
            //clone._keyShortcuts = new Dictionary<Keys, Action>(_keyShortcuts);
            //clone.Font = (Font)Font.Clone();
            //clone.Text = Text.Clone().ToString();
            return box;
        }
    }
}
