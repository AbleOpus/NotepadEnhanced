using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NotepadEnhanced
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Shortens and appends an Ellipsis to the specified string, if the specified string is too long.
        /// </summary>
        /// <param name="text">The text to append to.</param>
        /// <param name="font">The font to use as measurement.</param>
        /// <param name="maxWidth">The maximum width the caption should be.</param>
        /// <returns>Returns the original string, if the original string is short enough.</returns>
        public static string EllipsisClip(this string text, Font font, int maxWidth)
        {
            if (TextRenderer.MeasureText(text, font).Width <= maxWidth) return text;
            const string ELLIPSIS = "...";

            while (TextRenderer.MeasureText(text + ELLIPSIS, font).Width > maxWidth)
                text = text.Remove(text.Length - 1, 1);

            return text + ELLIPSIS;
        }

        /// <summary>
        /// Gets whether a Font is installed on the current system.
        /// </summary>
        public static bool Installed(this Font font)
        {
            using (Font testFont = new Font(font.OriginalFontName, 8f))
            {
                var SC = StringComparison.InvariantCultureIgnoreCase;
                return font.OriginalFontName.Equals(testFont.Name, SC);
            }
        }

        /// <summary>
        /// Capitalizes the first letter in a string to upper case.
        /// </summary>
        public static string ToTitleCase(this string text)
        {
            string firstLetter = text[0].ToString();
            firstLetter = firstLetter.ToUpper();
            text = text.Remove(0, 1);
            return text.Insert(0, firstLetter);
        }

        /// <summary>
        /// Adjusts the size of the current font by adding or subtracting from its current size then
        /// returning the new font.
        /// </summary>
        public static Font AddToSize(this Font oldFont, int amount)
        {
            if (oldFont.Size <= 1 && amount < 0) amount = 1;
            return new Font(oldFont.FontFamily.Name, oldFont.Size + amount, oldFont.Style);
        }

        /// <summary>
        /// Adjusts the size of the current font by adding or subtracting from its current size then
        /// returning the new font.
        /// </summary>
        public static Font SetStyle(this Font oldFont, FontStyle style)
        {
            return new Font(oldFont.FontFamily.Name, oldFont.Size, style);
        }

        /// <summary>
        /// Converts a color to solid color represented by an integer.
        /// </summary>
        public static int ToRgb(this Color color)
        {
            return (color.R) | (color.G << 8) | (color.B << 16);
        }

        public static bool IsFileLarge(this FileInfo info)
        {
            // any thing over 120000 bytes will be considered a large document.
            const int SIZE_THRESHOLD = 120000;
            if (!info.Exists)  return false;
            return (info.Length > SIZE_THRESHOLD);
        }

        /// <summary>
        /// Shows the message of an Exception using a Message Dialog.
        /// </summary>
        public static void ShowError(this Exception ex)
        {
            MessageBox.Show(ex.Message, Application.ProductName,
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
