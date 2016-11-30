using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using NotepadEnhanced.AppState;

namespace NotepadEnhanced.Localization
{
    /// <summary>
    /// Represents all of the supported cultures of this application.
    /// </summary>
    internal class SupportedCultures
    {
        /// <summary>
        /// All of the supported cultures.
        /// </summary>
        public List<CultureInfo> All { get; } = new List<CultureInfo>();

        /// <summary>
        /// The to string method must be called first before the index is set.
        /// </summary>
        public int DefaultCultureIndex { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SupportedCultures"/> class.
        /// </summary>
        public SupportedCultures()
        {
            SetSupportedCultures();
        }

        /// <summary>
        /// Sets the culture for the program, this must be done manually because the application's 
        /// non UI culture may need to be set to the users UI culture (needs validation).
        /// Also, display a message to non-English users to better translations.
        /// </summary>
        public static void SetCulture()
        {
            string cultureNotation = Settings.Instance.Culture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(cultureNotation);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(cultureNotation);
        }

        private void SetSupportedCultures()
        {
            try
            {
                // Find directories with only two letters in the names
                string[] directories = Directory.GetDirectories(Application.StartupPath, "??", SearchOption.TopDirectoryOnly);
                // Add English manually as it is used as the default values
                All.Add(CultureInfo.GetCultureInfo("en"));

                foreach (var langDirectory in directories.Select(dir => new DirectoryInfo(dir)))
                {
                    All.Add(CultureInfo.GetCultureInfo(langDirectory.Name));
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        public string[] ToStringArray()
        {
            var stringList = new List<string>();

            for (int i = 0; i < All.Count; i++)
            {
                string itemValue = All[i].NativeName;

                // Set default culture index to set a ComboBox to the appropriate item
                // We need to check the parent for specific locals as well
                if (All[i].Name.Equals(Thread.CurrentThread.CurrentCulture.Name) ||
                    (All[i].Name.Equals(Thread.CurrentThread.CurrentCulture.Parent.Name)))
                {
                    DefaultCultureIndex = i;
                }

                stringList.Add(itemValue.ToTitleCase());
            }

            return stringList.ToArray();
        }
    }
}
