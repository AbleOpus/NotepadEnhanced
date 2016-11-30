using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;

namespace NotepadEnhanced
{
    /// <summary>
    /// Provides functionality for auto selecting a Font.
    /// </summary>
    internal static class FontSelection
    {
        /// <summary>
        /// Gets the first installed Font using the specified family names. If no 
        /// Font names are valid, then the fall-back font is used.
        /// </summary>
        /// <param name="familyNames">The Font names to choose from.</param>
        /// <param name="size">The size of the Font instance returned.</param>
        /// <param name="style">The style of the Font instance returned.</param>
        public static Font GetBest(IEnumerable<string> familyNames, float size, FontStyle style = FontStyle.Regular)
        {
            foreach (var name in familyNames)
            {
                Font font = new Font(name, size, style);
                if (font.Installed()) return font;
            }
            // Return a default
            return new Font(string.Empty, size, style);
        }
    }
}
