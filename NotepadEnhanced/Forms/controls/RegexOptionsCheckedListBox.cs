using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NotepadEnhanced.Forms
{
    /// <summary>
    /// Represents a CheckedListBox for presenting RegexOptions.
    /// </summary>
    class RegexOptionsCheckedListBox : CheckedListBox
    {
        /// <summary>
        /// Gets or sets the checked regex options.
        /// </summary>
        [Browsable(false)]
        public RegexOptions Options
        {
            get
            {
                var options = RegexOptions.None;
                foreach (var item in CheckedItems)
                    options |= (RegexOptions)item;
                return options;
            }
            set
            {
                UncheckAll();

                var vals = Enum.GetValues(value.GetType());

                foreach (var val in vals)
                {
                    var option = (RegexOptions)val;

                    if (value.HasFlag(option))
                        SetItemChecked(option);
                }
            }
        }

        public RegexOptionsCheckedListBox()
        {
            Items.Clear(); // Items may be stacked (design time serialization I assume)
            Items.Add(RegexOptions.IgnorePatternWhitespace);
            Items.Add(RegexOptions.ExplicitCapture);
            Items.Add(RegexOptions.CultureInvariant);
            Items.Add(RegexOptions.IgnoreCase);
            Items.Add(RegexOptions.RightToLeft);
            Items.Add(RegexOptions.Multiline);
            Items.Add(RegexOptions.Singleline);
        }

        /// <summary>
        /// Uncheck all checkboxes.
        /// </summary>
        public void UncheckAll()
        {
            for (int i = 0; i < Items.Count; i++)
                SetItemChecked(i, false);
        }

        /// <summary>
        /// Sets the specified flags as checked.
        /// </summary>
        public void SetItemChecked(RegexOptions option)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (option == (RegexOptions)Items[i])
                {
                    SetItemChecked(i, true);
                    break;
                }
            }
        }
    }
}
