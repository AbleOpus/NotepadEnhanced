using System.Text.RegularExpressions;

namespace NotepadEnhanced.Refactexing
{
    // Consider putting these in an XML file.
    /// <summary>
    /// Provides a set of preset <see cref="Refactex"/>es.
    /// </summary>
    internal static class RefactexPresets
    {
        /// <summary>
        /// Gets a <see cref="Refactex"/> used for trimming whitespace.
        /// </summary>
        public static Refactex TrimWhiteSpace
        {
            get
            {
                const string NAME = "Trim White Space";
                const string DESCRIP = "Removes trailing and leading whitespace";
                const string PATTERN = @"(^\s+)|(\s+$)";
                return new Refactex(NAME, DESCRIP, PATTERN);
            }
        }

        /// <summary>
        /// Gets a <see cref="Refactex"/> that is used for bullet insertion
        /// </summary>
        public static Refactex BulletInserter
        {
            get
            {
                const string NAME = "Bullet Inserter";
                const string DESCRIP = "Inserts bullets at the start of each line (replaces line numbers)";
                const string PATTERN = @"^(?!•)(\d+\.)?";
                return new Refactex(NAME, DESCRIP, PATTERN, "•", RegexOptions.Multiline);
            }
        }

        /// <summary>
        /// Gets a <see cref="Refactex"/> that is used to reduce whitespace to one space character.
        /// </summary>
        public static Refactex SingleSpaceOnly
        {
            get
            {
                const string NAME = "Single Space Only";
                const string DESCRIP = "All whitespace is replaced by a single space";
                const string PATTERN = @"\s\s+";
                return new Refactex(NAME, DESCRIP, PATTERN, " ");
            }
        }

        /// <summary>
        /// Gets a <see cref="Refactex"/> that is used to remove numbered lists.
        /// </summary>
        public static Refactex RemoveNumberedList
        {
            get
            {
                const string NAME = "Remove Numbered List";
                const string DESCRIP = "Removes numbered lists";
                const string PATTERN = @"^\d+\.\s+";
                return new Refactex(NAME, DESCRIP, PATTERN, string.Empty, RegexOptions.Multiline);
            }
        }

        /// <summary>
        /// Gets a <see cref="Refactex"/> that is used to reduce newlines to double spacing.
        /// </summary>
        public static Refactex ReduceToDoubleNewlines
        {
            get
            {
                const string NAME = "Reduce To Double Newlines";
                const string DESCRIP = "Reduces multiple newlines to a double newline";
                return new Refactex(NAME, DESCRIP, @"(\n|\r){3,}", "\n\n");
            }
        }
    }
}
