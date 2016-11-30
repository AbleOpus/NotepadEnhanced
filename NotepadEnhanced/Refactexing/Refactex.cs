using System;
using System.Text.RegularExpressions;

namespace NotepadEnhanced.Refactexing
{
    /// <summary>
    /// Represents a regex refactoring profile.
    /// </summary>
    [Serializable]
    public class Refactex
    {
        #region Properties
        /// <summary>
        /// Gets the regex options to be used with this refactor.
        /// </summary>
        public RegexOptions Options { get; private set; }

        /// <summary>
        /// Gets the pattern to be used for the regex lookup.
        /// </summary>
        public string Pattern { get; private set; }

        /// <summary>
        /// Gets the replacement pattern to be used for regex replace.
        /// </summary>
        public string Replacement { get; private set; }

        /// <summary>
        /// Gets the name of this instance (should briefly describe the operation).
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the value that describes the regex refactoring operation.
        /// </summary>
        public string Description { get; private set; }
        #endregion

        /// <summary>
        /// Initializes an instance of <see cref="Refactex"/>.
        /// </summary>
        /// <param name="name">The name of this instance (should briefly describe the operation).</param>
        /// <param name="descrip">Describes the regex refactoring operation.</param>
        /// <param name="pattern">The pattern to be used for the regex lookup.</param>
        /// <param name="replacement">The replacement pattern to be used for regex replace.</param>
        /// <param name="options">The regex options to be used with this refactor.</param>
        public Refactex(string name, string descrip, string pattern, string replacement = "",
                        RegexOptions options = RegexOptions.None)
        {
            Name = name;
            Description = descrip;
            Pattern = pattern;
            Replacement = replacement;
            Options = options;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
