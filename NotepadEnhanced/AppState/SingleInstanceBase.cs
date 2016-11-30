using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using NotepadEnhanced.Forms;

namespace NotepadEnhanced.AppState
{
    /// <summary>
    /// Represents an instance of a application.
    /// </summary>
    internal class SingleAppInstance : WindowsFormsApplicationBase
    {
        private static List<string> cmdLineArguments = new List<string>();
        /// <summary>
        /// Gets the command line arguments for this instance.
        /// </summary>
        public static string[] CmdLineArguments => cmdLineArguments.ToArray();

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleAppInstance"/> class
        /// with the specified arguments.
        /// </summary>
        /// <param name="bootArguments">The arguments to pass into this instance.</param>
        public SingleAppInstance(IEnumerable<string> bootArguments)
        {
            IsSingleInstance = Settings.Instance.SingleInstance;
            cmdLineArguments = new List<string>(bootArguments);
        }

        protected override bool OnStartup(StartupEventArgs eventArgs)
        {
            MainForm = new MainForm();
            return base.OnStartup(eventArgs);
        }

        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            eventArgs.BringToForeground = (Application.OpenForms.Count == 1);
            base.OnStartupNextInstance(eventArgs);
            cmdLineArguments = new List<string>(eventArgs.CommandLine);
            ((MainForm)MainForm).OpenFileFromArguments(CmdLineArguments);
        }
    }
}