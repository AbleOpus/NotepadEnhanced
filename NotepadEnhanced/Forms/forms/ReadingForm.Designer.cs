using NotepadEnhanced.Forms;

namespace NotepadEnhanced.Forms
{
    partial class ReadingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadingForm));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemScript = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPresets = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOldScripture = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemComputerConsole = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemModernDark = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNovel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.controlExtender = new NotepadEnhanced.Forms.ControlExtender();
            this.labelScrolling = new NotepadEnhanced.Forms.ScrollingLabel();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemStyle,
            this.menuItemPresets,
            toolStripSeparator1,
            this.menuItemClose});
            this.contextMenuStrip.Name = "contextMenuStrip";
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            // 
            // menuItemStyle
            // 
            this.menuItemStyle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNormal,
            this.menuItemScript,
            this.menuItemFullScreen});
            this.menuItemStyle.Name = "menuItemStyle";
            resources.ApplyResources(this.menuItemStyle, "menuItemStyle");
            // 
            // menuItemNormal
            // 
            this.menuItemNormal.Name = "menuItemNormal";
            resources.ApplyResources(this.menuItemNormal, "menuItemNormal");
            this.menuItemNormal.Click += new System.EventHandler(this.menuItemNormal_Click);
            // 
            // menuItemScript
            // 
            this.menuItemScript.Name = "menuItemScript";
            resources.ApplyResources(this.menuItemScript, "menuItemScript");
            this.menuItemScript.Click += new System.EventHandler(this.menuItemScript_Click);
            // 
            // menuItemFullScreen
            // 
            this.menuItemFullScreen.Name = "menuItemFullScreen";
            resources.ApplyResources(this.menuItemFullScreen, "menuItemFullScreen");
            this.menuItemFullScreen.Click += new System.EventHandler(this.menuItemFullScreen_Click);
            // 
            // menuItemPresets
            // 
            this.menuItemPresets.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemEditor,
            this.menuItemOldScripture,
            this.menuItemComputerConsole,
            this.menuItemModernDark,
            this.menuItemNovel});
            this.menuItemPresets.Name = "menuItemPresets";
            resources.ApplyResources(this.menuItemPresets, "menuItemPresets");
            // 
            // menuItemEditor
            // 
            this.menuItemEditor.Name = "menuItemEditor";
            resources.ApplyResources(this.menuItemEditor, "menuItemEditor");
            this.menuItemEditor.Click += new System.EventHandler(this.menuItemEditor_Click);
            // 
            // menuItemOldScripture
            // 
            this.menuItemOldScripture.Name = "menuItemOldScripture";
            resources.ApplyResources(this.menuItemOldScripture, "menuItemOldScripture");
            this.menuItemOldScripture.Click += new System.EventHandler(this.menuItemOldScripture_Click);
            // 
            // menuItemComputerConsole
            // 
            this.menuItemComputerConsole.Name = "menuItemComputerConsole";
            resources.ApplyResources(this.menuItemComputerConsole, "menuItemComputerConsole");
            this.menuItemComputerConsole.Click += new System.EventHandler(this.menuItemComputerConsole_Click);
            // 
            // menuItemModernDark
            // 
            this.menuItemModernDark.Name = "menuItemModernDark";
            resources.ApplyResources(this.menuItemModernDark, "menuItemModernDark");
            this.menuItemModernDark.Click += new System.EventHandler(this.menuItemModernDark_Click);
            // 
            // menuItemNovel
            // 
            this.menuItemNovel.Name = "menuItemNovel";
            resources.ApplyResources(this.menuItemNovel, "menuItemNovel");
            this.menuItemNovel.Click += new System.EventHandler(this.menuItemNovel_Click);
            // 
            // menuItemClose
            // 
            this.menuItemClose.Name = "menuItemClose";
            resources.ApplyResources(this.menuItemClose, "menuItemClose");
            this.menuItemClose.Click += new System.EventHandler(this.menuItemClose_Click);
            // 
            // controlExtender
            // 
            this.controlExtender.BackColor = System.Drawing.Color.DimGray;
            this.controlExtender.Cursor = System.Windows.Forms.Cursors.SizeNS;
            resources.ApplyResources(this.controlExtender, "controlExtender");
            this.controlExtender.Name = "controlExtender";
            // 
            // labelScrolling
            // 
            this.labelScrolling.BackColor = System.Drawing.Color.WhiteSmoke;
            this.labelScrolling.HorizontalPadding = 0;
            resources.ApplyResources(this.labelScrolling, "labelScrolling");
            this.labelScrolling.Name = "labelScrolling";
            this.labelScrolling.VerticalPadding = 0;
            // 
            // ReadingForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.controlExtender);
            this.Controls.Add(this.labelScrolling);
            this.KeyPreview = true;
            this.Name = "ReadingForm";
            this.TopMost = true;
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemStyle;
        private System.Windows.Forms.ToolStripMenuItem menuItemNormal;
        private System.Windows.Forms.ToolStripMenuItem menuItemScript;
        private System.Windows.Forms.ToolStripMenuItem menuItemFullScreen;
        private ControlExtender controlExtender;
        private System.Windows.Forms.ToolStripMenuItem menuItemPresets;
        private System.Windows.Forms.ToolStripMenuItem menuItemEditor;
        private System.Windows.Forms.ToolStripMenuItem menuItemOldScripture;
        private System.Windows.Forms.ToolStripMenuItem menuItemComputerConsole;
        private System.Windows.Forms.ToolStripMenuItem menuItemModernDark;
        private ScrollingLabel labelScrolling;
        private System.Windows.Forms.ToolStripMenuItem menuItemNovel;
        private System.Windows.Forms.ToolStripMenuItem menuItemClose;
    }
}