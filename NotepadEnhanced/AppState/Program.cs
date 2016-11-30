using System;
using System.Diagnostics;
using System.Windows.Forms;
using NotepadEnhanced.Localization;

[assembly: CLSCompliant(true)]
namespace NotepadEnhanced.AppState
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] arguments)
        {
            SupportedCultures.SetCulture();
            // Command line switches will only be expected
            // when the first instance starts, when more app instances
            // pass args into this instance, they will not be processed
            // and we will assume they are filenames.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var app = new SingleAppInstance(arguments);
            app.Run(arguments);
        }

        /// <summary>
        /// Starts a process by the its given path.
        /// </summary>
        /// <param name="path">The local file or URL to open in a new process.</param>
        /// <param name="argument">The arguments to pass to the process.</param>
        public static void StartProcess(string path, string argument = "")
        {
            try
            {
                Process.Start(path, argument);
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }
    }
}