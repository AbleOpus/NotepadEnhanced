using System.Globalization;
using System.Windows.Forms;

namespace NotepadEnhanced.Forms
{
    /// <summary>
    /// Provides extended message dialog functionality.
    /// </summary>
    public static class MessageDialog
    {
        private static bool IsRightToLeft(IWin32Window owner)
        {
            var control = owner as Control;

            if (control != null)
            {
                return control.RightToLeft == RightToLeft.Yes;
            }

            // If no parent control is available, ask the CurrentUICulture
            // if we are running under right-to-left.
            return CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft;
        }

        /// <summary>
        /// Shows a message box with the default error setup. 
        /// </summary>
        public static DialogResult ShowError(string text)
        {
            MessageBoxOptions options = 0;

            if (IsRightToLeft(null))
            {
                options |= MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign;
            }

            return MessageBox.Show(null, text, Application.ProductName,
                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
        }

        public static DialogResult Show(string text, MessageBoxIcon icon)
        {
            MessageBoxOptions options = 0;

            if (IsRightToLeft(null))
            {
                options |= MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign;
            }

            return MessageBox.Show(null, text, Application.ProductName,
                MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1, options);
        }

        public static DialogResult Show(string text, MessageBoxIcon icon, MessageBoxButtons buttons)
        {
            MessageBoxOptions options = 0;

            if (IsRightToLeft(null))
            {
                options |= MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign;
            }

            return MessageBox.Show(null, text, Application.ProductName,
                buttons, icon, MessageBoxDefaultButton.Button1, options);
        }
    }
}