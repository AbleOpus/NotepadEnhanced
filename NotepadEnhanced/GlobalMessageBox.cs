using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace NotepadEnhanced
{
    public static class GlobalMessageBox
    {
        private static bool IsRightToLeft(IWin32Window owner)
        {
            Control control = owner as Control;

            if (control != null)
            {
                return control.RightToLeft == RightToLeft.Yes;
            }

            // If no parent control is available, ask the CurrentUICulture
            // if we are running under right-to-left.
            return CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft;
        }

        public static DialogResult Show(IWin32Window owner, string text,
            MessageBoxIcon icon, MessageBoxOptions options)
        {
            if (IsRightToLeft(owner))
            {
                options |= MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign;
            }

            return MessageBox.Show(owner, text, Application.ProductName, 
                MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1, options);
        }

        public static DialogResult Show(string text, MessageBoxIcon icon)
        {
            MessageBoxOptions options = (MessageBoxOptions)0;

            if (IsRightToLeft(null))
            {
                options |= MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign;
            }

            return MessageBox.Show(null, text, Application.ProductName,
                MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1, options);
        }

        public static DialogResult Show(string text, MessageBoxIcon icon, MessageBoxButtons buttons)
        {
            MessageBoxOptions options = (MessageBoxOptions)0;

            if (IsRightToLeft(null))
            {
                options |= MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign;
            }

            return MessageBox.Show(null, text, Application.ProductName,
                buttons, icon, MessageBoxDefaultButton.Button1, options);
        }

        public static DialogResult Show(IWin32Window owner, string text,
            MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxOptions options)
        {
            if (IsRightToLeft(owner))
            {
                options |= MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign;
            }

            return MessageBox.Show(owner, text, Application.ProductName,
                buttons, icon, MessageBoxDefaultButton.Button1, options);
        }
    }
}