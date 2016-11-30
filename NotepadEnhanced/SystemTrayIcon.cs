using System;
using System.Windows.Forms;
using System.Drawing;
using NotepadEnhanced.Localization;

namespace NotepadEnhanced
{
    internal class NeTrayIcon : IDisposable
    {
        private readonly Form form;
        private readonly NotifyIcon notifyIcon;

        /// <summary>
        /// Creates an instance of SystemTrayIcon.
        /// </summary>
        /// <param name="form">The Form to alter.</param>
        public NeTrayIcon(Form form)
        {
            this.form = form;
            notifyIcon = GetNotifyIcon();
        }

        /// <summary>
        /// Hide the form and show the system tray icon.
        /// </summary>
        public void MinimizeToTray()
        {
            form.Hide();
            notifyIcon.Visible = true;
        }

        private NotifyIcon GetNotifyIcon()
        {
            var NI = new NotifyIcon
            {
                Icon = new Icon(form.Icon, 16, 16),
                ContextMenuStrip = CreateContextMenuStrip(),
                Text = Application.ProductName
            };

            NI.MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    UnMinimizeFromTray();
            };
            return NI;
        }

        private ContextMenuStrip CreateContextMenuStrip()
        {
            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add(Strings.CmsiShowText, null, (s, e) => UnMinimizeFromTray());
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(Strings.CmsiExitText, null, (s, e) => form.Close());
            return contextMenu;
        }

        public void UnMinimizeFromTray()
        {
            if (!form.Visible)
            {
                notifyIcon.Visible = false;
                form.Show();
            }
        }

        public void Dispose()
        {
            notifyIcon.Dispose();
        }
    }
}