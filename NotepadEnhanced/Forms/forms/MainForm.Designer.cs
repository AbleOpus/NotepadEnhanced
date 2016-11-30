using System.Windows.Forms;
using NotepadEnhanced.Forms;

namespace NotepadEnhanced.Forms
{
    partial class MainForm
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
            panelFind?.Dispose();
            panelGoto?.Dispose();
            panelReplace?.Dispose();
            buttonPrompt?.Dispose();
            printing?.Dispose();
            trayIcon.Dispose();

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
            System.Windows.Forms.ToolStripStatusLabel label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ToolStripStatusLabel label3;
            System.Windows.Forms.ToolStripStatusLabel label4;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
            System.Windows.Forms.ToolStripStatusLabel label2;
            System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.labelTabCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelTabSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelCurrentLine = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelCurrentColumn = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelCharCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAddTab = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCloseTab = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCloseAllTabs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCloseAllButCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpenRecent = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDlWebpage = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxHTMLLink = new System.Windows.Forms.ToolStripTextBox();
            this.menuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPageSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCloseAndDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFind = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFindNext = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemGoto = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLongDateTime = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemShortDateTime = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSignature = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAutoIndent = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRegexRefactoring = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStatusBar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemWordWrap = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLineNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFullscreen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemMinimize = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAlwaysOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReadingWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemProductDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuTabPage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiCloseThis = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiCloseAllButThis = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsiShowInFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiOpenInWinNotepad = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuTextArea = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiCut = new System.Windows.Forms.ToolStripMenuItem();
            this.csmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLookup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNinjaWords = new System.Windows.Forms.ToolStripMenuItem();
            this.timerMessage = new System.Windows.Forms.Timer(this.components);
            this.tabControl = new NotepadEnhanced.Forms.PlainTextTabControl();
            label1 = new System.Windows.Forms.ToolStripStatusLabel();
            label3 = new System.Windows.Forms.ToolStripStatusLabel();
            label4 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            label2 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBar.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.contextMenuTabPage.SuspendLayout();
            this.contextMenuTextArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            label1.Margin = new System.Windows.Forms.Padding(4, 3, 0, 2);
            label1.Name = "label1";
            resources.ApplyResources(label1, "label1");
            // 
            // label3
            // 
            label3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            label3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            label3.Name = "label3";
            resources.ApplyResources(label3, "label3");
            // 
            // label4
            // 
            label4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            label4.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
            label4.Name = "label4";
            resources.ApplyResources(label4, "label4");
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(toolStripSeparator6, "toolStripSeparator6");
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(toolStripSeparator3, "toolStripSeparator3");
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.Name = "toolStripSeparator10";
            resources.ApplyResources(toolStripSeparator10, "toolStripSeparator10");
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(toolStripSeparator8, "toolStripSeparator8");
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripSeparator12
            // 
            toolStripSeparator12.Name = "toolStripSeparator12";
            resources.ApplyResources(toolStripSeparator12, "toolStripSeparator12");
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(toolStripSeparator5, "toolStripSeparator5");
            // 
            // toolStripSeparator11
            // 
            toolStripSeparator11.Name = "toolStripSeparator11";
            resources.ApplyResources(toolStripSeparator11, "toolStripSeparator11");
            // 
            // label2
            // 
            label2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            label2.Name = "label2";
            resources.ApplyResources(label2, "label2");
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            resources.ApplyResources(toolStripStatusLabel2, "toolStripStatusLabel2");
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            label1,
            this.labelTabCount,
            label2,
            this.labelTabSelected,
            label3,
            this.labelCurrentLine,
            label4,
            this.labelCurrentColumn,
            toolStripStatusLabel2,
            this.labelCharCount});
            resources.ApplyResources(this.statusBar, "statusBar");
            this.statusBar.Name = "statusBar";
            this.statusBar.SizingGrip = false;
            this.statusBar.VisibleChanged += new System.EventHandler(this.statusBar_VisibleChanged);
            // 
            // labelTabCount
            // 
            this.labelTabCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.labelTabCount.Name = "labelTabCount";
            resources.ApplyResources(this.labelTabCount, "labelTabCount");
            // 
            // labelTabSelected
            // 
            this.labelTabSelected.Name = "labelTabSelected";
            resources.ApplyResources(this.labelTabSelected, "labelTabSelected");
            // 
            // labelCurrentLine
            // 
            this.labelCurrentLine.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.labelCurrentLine.Name = "labelCurrentLine";
            resources.ApplyResources(this.labelCurrentLine, "labelCurrentLine");
            // 
            // labelCurrentColumn
            // 
            this.labelCurrentColumn.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.labelCurrentColumn.Name = "labelCurrentColumn";
            resources.ApplyResources(this.labelCurrentColumn, "labelCurrentColumn");
            // 
            // labelCharCount
            // 
            this.labelCharCount.Name = "labelCharCount";
            resources.ApplyResources(this.labelCharCount, "labelCharCount");
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemEdit,
            this.menuItemView,
            this.menuItemHelp});
            resources.ApplyResources(this.mainMenu, "mainMenu");
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAddTab,
            this.menuItemCloseTab,
            this.menuItemCloseAllTabs,
            this.menuItemCloseAllButCurrent,
            toolStripSeparator1,
            this.menuItemOpen,
            this.menuItemOpenRecent,
            this.menuItemDlWebpage,
            this.menuItemSave,
            this.menuItemSaveAs,
            toolStripSeparator8,
            this.menuItemPrint,
            this.menuItemPrintPreview,
            this.menuItemPageSetup,
            toolStripSeparator2,
            this.menuItemCloseAndDelete,
            toolStripSeparator12,
            this.menuItemExit});
            resources.ApplyResources(this.menuItemFile, "menuItemFile");
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.MouseEnter += new System.EventHandler(this.menuItemFile_MouseEnter);
            // 
            // menuItemAddTab
            // 
            resources.ApplyResources(this.menuItemAddTab, "menuItemAddTab");
            this.menuItemAddTab.Name = "menuItemAddTab";
            this.menuItemAddTab.Click += new System.EventHandler(this.menuItemAddTab_Click);
            // 
            // menuItemCloseTab
            // 
            resources.ApplyResources(this.menuItemCloseTab, "menuItemCloseTab");
            this.menuItemCloseTab.Name = "menuItemCloseTab";
            this.menuItemCloseTab.Click += new System.EventHandler(this.menuItemCloseTab_Click);
            // 
            // menuItemCloseAllTabs
            // 
            this.menuItemCloseAllTabs.Name = "menuItemCloseAllTabs";
            resources.ApplyResources(this.menuItemCloseAllTabs, "menuItemCloseAllTabs");
            this.menuItemCloseAllTabs.Click += new System.EventHandler(this.menuItemCloseAllTabs_Click);
            // 
            // menuItemCloseAllButCurrent
            // 
            this.menuItemCloseAllButCurrent.Name = "menuItemCloseAllButCurrent";
            resources.ApplyResources(this.menuItemCloseAllButCurrent, "menuItemCloseAllButCurrent");
            this.menuItemCloseAllButCurrent.Click += new System.EventHandler(this.tmsiCloseAllButCurrent_Click);
            // 
            // menuItemOpen
            // 
            resources.ApplyResources(this.menuItemOpen, "menuItemOpen");
            this.menuItemOpen.Name = "menuItemOpen";
            this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
            // 
            // menuItemOpenRecent
            // 
            resources.ApplyResources(this.menuItemOpenRecent, "menuItemOpenRecent");
            this.menuItemOpenRecent.Name = "menuItemOpenRecent";
            // 
            // menuItemDlWebpage
            // 
            this.menuItemDlWebpage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textBoxHTMLLink});
            this.menuItemDlWebpage.Name = "menuItemDlWebpage";
            resources.ApplyResources(this.menuItemDlWebpage, "menuItemDlWebpage");
            this.menuItemDlWebpage.DropDownOpened += new System.EventHandler(this.menuItemDlWebpage_DropDownOpened);
            // 
            // textBoxHTMLLink
            // 
            this.textBoxHTMLLink.Name = "textBoxHTMLLink";
            resources.ApplyResources(this.textBoxHTMLLink, "textBoxHTMLLink");
            this.textBoxHTMLLink.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxHtmlLink_KeyDown);
            // 
            // menuItemSave
            // 
            resources.ApplyResources(this.menuItemSave, "menuItemSave");
            this.menuItemSave.Name = "menuItemSave";
            this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
            // 
            // menuItemSaveAs
            // 
            resources.ApplyResources(this.menuItemSaveAs, "menuItemSaveAs");
            this.menuItemSaveAs.Name = "menuItemSaveAs";
            this.menuItemSaveAs.Click += new System.EventHandler(this.menuItemSaveAs_Click);
            // 
            // menuItemPrint
            // 
            resources.ApplyResources(this.menuItemPrint, "menuItemPrint");
            this.menuItemPrint.Name = "menuItemPrint";
            this.menuItemPrint.Click += new System.EventHandler(this.menuItemPrint_Click);
            // 
            // menuItemPrintPreview
            // 
            resources.ApplyResources(this.menuItemPrintPreview, "menuItemPrintPreview");
            this.menuItemPrintPreview.Name = "menuItemPrintPreview";
            this.menuItemPrintPreview.Click += new System.EventHandler(this.menuItemPrintPreview_Click);
            // 
            // menuItemPageSetup
            // 
            resources.ApplyResources(this.menuItemPageSetup, "menuItemPageSetup");
            this.menuItemPageSetup.Name = "menuItemPageSetup";
            this.menuItemPageSetup.Click += new System.EventHandler(this.menuItemPageSetup_Click);
            // 
            // menuItemCloseAndDelete
            // 
            resources.ApplyResources(this.menuItemCloseAndDelete, "menuItemCloseAndDelete");
            this.menuItemCloseAndDelete.Name = "menuItemCloseAndDelete";
            this.menuItemCloseAndDelete.Click += new System.EventHandler(this.menuItemCloseAndDelete_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            resources.ApplyResources(this.menuItemExit, "menuItemExit");
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemUndo,
            this.menuItemRedo,
            toolStripSeparator3,
            this.menuItemFind,
            this.menuItemFindNext,
            this.menuItemReplace,
            this.menuItemGoto,
            toolStripSeparator10,
            this.menuItemSelectAll,
            this.menuItemInsert,
            this.menuItemAutoIndent,
            this.menuItemRegexRefactoring});
            this.menuItemEdit.Name = "menuItemEdit";
            resources.ApplyResources(this.menuItemEdit, "menuItemEdit");
            // 
            // menuItemUndo
            // 
            resources.ApplyResources(this.menuItemUndo, "menuItemUndo");
            this.menuItemUndo.Name = "menuItemUndo";
            this.menuItemUndo.Click += new System.EventHandler(this.menuItemUndo_Click);
            // 
            // menuItemRedo
            // 
            resources.ApplyResources(this.menuItemRedo, "menuItemRedo");
            this.menuItemRedo.Name = "menuItemRedo";
            this.menuItemRedo.Click += new System.EventHandler(this.menuItemRedo_Click);
            // 
            // menuItemFind
            // 
            this.menuItemFind.CheckOnClick = true;
            resources.ApplyResources(this.menuItemFind, "menuItemFind");
            this.menuItemFind.Name = "menuItemFind";
            this.menuItemFind.CheckedChanged += new System.EventHandler(this.menuItemFind_CheckedChanged);
            // 
            // menuItemFindNext
            // 
            resources.ApplyResources(this.menuItemFindNext, "menuItemFindNext");
            this.menuItemFindNext.Name = "menuItemFindNext";
            this.menuItemFindNext.Click += new System.EventHandler(this.menuItemFindNext_Click);
            // 
            // menuItemReplace
            // 
            this.menuItemReplace.CheckOnClick = true;
            this.menuItemReplace.Name = "menuItemReplace";
            resources.ApplyResources(this.menuItemReplace, "menuItemReplace");
            this.menuItemReplace.CheckedChanged += new System.EventHandler(this.menuItemReplace_CheckedChanged);
            // 
            // menuItemGoto
            // 
            this.menuItemGoto.CheckOnClick = true;
            resources.ApplyResources(this.menuItemGoto, "menuItemGoto");
            this.menuItemGoto.Name = "menuItemGoto";
            this.menuItemGoto.CheckedChanged += new System.EventHandler(this.menuItemGoto_CheckedChanged);
            // 
            // menuItemSelectAll
            // 
            this.menuItemSelectAll.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            resources.ApplyResources(this.menuItemSelectAll, "menuItemSelectAll");
            this.menuItemSelectAll.Name = "menuItemSelectAll";
            this.menuItemSelectAll.Click += new System.EventHandler(this.menuItemSelectAll_Click);
            // 
            // menuItemInsert
            // 
            this.menuItemInsert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLongDateTime,
            this.menuItemShortDateTime,
            this.menuItemSignature});
            resources.ApplyResources(this.menuItemInsert, "menuItemInsert");
            this.menuItemInsert.Name = "menuItemInsert";
            // 
            // menuItemLongDateTime
            // 
            resources.ApplyResources(this.menuItemLongDateTime, "menuItemLongDateTime");
            this.menuItemLongDateTime.Name = "menuItemLongDateTime";
            this.menuItemLongDateTime.Click += new System.EventHandler(this.menuItemLongDateTime_Click);
            // 
            // menuItemShortDateTime
            // 
            resources.ApplyResources(this.menuItemShortDateTime, "menuItemShortDateTime");
            this.menuItemShortDateTime.Name = "menuItemShortDateTime";
            this.menuItemShortDateTime.Click += new System.EventHandler(this.menuItemShortDateTime_Click);
            // 
            // menuItemSignature
            // 
            resources.ApplyResources(this.menuItemSignature, "menuItemSignature");
            this.menuItemSignature.Name = "menuItemSignature";
            this.menuItemSignature.Click += new System.EventHandler(this.menuItemSignature_Click);
            // 
            // menuItemAutoIndent
            // 
            this.menuItemAutoIndent.CheckOnClick = true;
            this.menuItemAutoIndent.Name = "menuItemAutoIndent";
            resources.ApplyResources(this.menuItemAutoIndent, "menuItemAutoIndent");
            this.menuItemAutoIndent.CheckedChanged += new System.EventHandler(this.menuItemAutoIndent_CheckedChanged);
            this.menuItemAutoIndent.EnabledChanged += new System.EventHandler(this.menuItemAutoIndent_CheckedChanged);
            // 
            // menuItemRegexRefactoring
            // 
            this.menuItemRegexRefactoring.Name = "menuItemRegexRefactoring";
            resources.ApplyResources(this.menuItemRegexRefactoring, "menuItemRegexRefactoring");
            this.menuItemRegexRefactoring.Click += new System.EventHandler(this.menuItemRegexRefactoring_Click);
            // 
            // menuItemView
            // 
            this.menuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemStatusBar,
            this.menuItemWordWrap,
            this.menuItemLineNumbers,
            toolStripSeparator5,
            this.menuItemFullscreen,
            this.menuItemMinimize,
            this.menuItemAlwaysOnTop,
            toolStripSeparator11,
            this.menuItemReadingWindow,
            this.menuItemSettings});
            this.menuItemView.Name = "menuItemView";
            resources.ApplyResources(this.menuItemView, "menuItemView");
            // 
            // menuItemStatusBar
            // 
            this.menuItemStatusBar.CheckOnClick = true;
            this.menuItemStatusBar.Name = "menuItemStatusBar";
            resources.ApplyResources(this.menuItemStatusBar, "menuItemStatusBar");
            this.menuItemStatusBar.CheckedChanged += new System.EventHandler(this.menuItemStatusBar_CheckedChanged);
            // 
            // menuItemWordWrap
            // 
            this.menuItemWordWrap.CheckOnClick = true;
            this.menuItemWordWrap.Name = "menuItemWordWrap";
            resources.ApplyResources(this.menuItemWordWrap, "menuItemWordWrap");
            this.menuItemWordWrap.CheckedChanged += new System.EventHandler(this.menuItemWordWrap_CheckedChanged);
            // 
            // menuItemLineNumbers
            // 
            this.menuItemLineNumbers.CheckOnClick = true;
            this.menuItemLineNumbers.Name = "menuItemLineNumbers";
            resources.ApplyResources(this.menuItemLineNumbers, "menuItemLineNumbers");
            this.menuItemLineNumbers.CheckedChanged += new System.EventHandler(this.menuItemLineNumbers_CheckedChanged);
            // 
            // menuItemFullscreen
            // 
            this.menuItemFullscreen.CheckOnClick = true;
            resources.ApplyResources(this.menuItemFullscreen, "menuItemFullscreen");
            this.menuItemFullscreen.Name = "menuItemFullscreen";
            this.menuItemFullscreen.CheckedChanged += new System.EventHandler(this.menuItemFullscreen_CheckedChanged);
            // 
            // menuItemMinimize
            // 
            resources.ApplyResources(this.menuItemMinimize, "menuItemMinimize");
            this.menuItemMinimize.Name = "menuItemMinimize";
            this.menuItemMinimize.Click += new System.EventHandler(this.menuItemMinimizeToTray_Click);
            // 
            // menuItemAlwaysOnTop
            // 
            this.menuItemAlwaysOnTop.CheckOnClick = true;
            this.menuItemAlwaysOnTop.Name = "menuItemAlwaysOnTop";
            resources.ApplyResources(this.menuItemAlwaysOnTop, "menuItemAlwaysOnTop");
            this.menuItemAlwaysOnTop.CheckedChanged += new System.EventHandler(this.menuItemAlwaysOnTop_CheckedChanged);
            // 
            // menuItemReadingWindow
            // 
            this.menuItemReadingWindow.Name = "menuItemReadingWindow";
            resources.ApplyResources(this.menuItemReadingWindow, "menuItemReadingWindow");
            this.menuItemReadingWindow.Click += new System.EventHandler(this.menuItemShowReadingWindow_Click);
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.CheckOnClick = true;
            resources.ApplyResources(this.menuItemSettings, "menuItemSettings");
            this.menuItemSettings.Name = "menuItemSettings";
            this.menuItemSettings.CheckedChanged += new System.EventHandler(this.menuItemSettings_CheckedChanged);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAbout,
            this.menuItemProductDoc,
            this.menuItemUpdates});
            this.menuItemHelp.Name = "menuItemHelp";
            resources.ApplyResources(this.menuItemHelp, "menuItemHelp");
            // 
            // menuItemAbout
            // 
            resources.ApplyResources(this.menuItemAbout, "menuItemAbout");
            this.menuItemAbout.CheckOnClick = true;
            this.menuItemAbout.Name = "menuItemAbout";
            this.menuItemAbout.CheckedChanged += new System.EventHandler(this.menuItemAbout_CheckedChanged);
            // 
            // menuItemProductDoc
            // 
            resources.ApplyResources(this.menuItemProductDoc, "menuItemProductDoc");
            this.menuItemProductDoc.Name = "menuItemProductDoc";
            this.menuItemProductDoc.Click += new System.EventHandler(this.menuItemProductDoc_Click);
            // 
            // menuItemUpdates
            // 
            resources.ApplyResources(this.menuItemUpdates, "menuItemUpdates");
            this.menuItemUpdates.Name = "menuItemUpdates";
            this.menuItemUpdates.Click += new System.EventHandler(this.menuItemUpdates_Click);
            // 
            // contextMenuTabPage
            // 
            this.contextMenuTabPage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiCloseThis,
            this.cmsiCloseAllButThis,
            this.toolStripSeparator7,
            this.cmsiShowInFolder,
            this.cmsiOpenInWinNotepad});
            this.contextMenuTabPage.Name = "cmsTabPage";
            resources.ApplyResources(this.contextMenuTabPage, "contextMenuTabPage");
            // 
            // cmsiCloseThis
            // 
            this.cmsiCloseThis.Name = "cmsiCloseThis";
            resources.ApplyResources(this.cmsiCloseThis, "cmsiCloseThis");
            this.cmsiCloseThis.Click += new System.EventHandler(this.cmsiCloseThis_Click);
            // 
            // cmsiCloseAllButThis
            // 
            this.cmsiCloseAllButThis.Name = "cmsiCloseAllButThis";
            resources.ApplyResources(this.cmsiCloseAllButThis, "cmsiCloseAllButThis");
            this.cmsiCloseAllButThis.Click += new System.EventHandler(this.cmsiCloseAllButCurrent_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // cmsiShowInFolder
            // 
            resources.ApplyResources(this.cmsiShowInFolder, "cmsiShowInFolder");
            this.cmsiShowInFolder.Name = "cmsiShowInFolder";
            this.cmsiShowInFolder.Click += new System.EventHandler(this.cmsiShowInFolder_Click);
            // 
            // cmsiOpenInWinNotepad
            // 
            resources.ApplyResources(this.cmsiOpenInWinNotepad, "cmsiOpenInWinNotepad");
            this.cmsiOpenInWinNotepad.Name = "cmsiOpenInWinNotepad";
            this.cmsiOpenInWinNotepad.Click += new System.EventHandler(this.cmsiOpenInWinNotepad_Click);
            // 
            // contextMenuTextArea
            // 
            this.contextMenuTextArea.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiCut,
            this.csmiCopy,
            this.cmsiPaste,
            this.cmsiDelete,
            toolStripSeparator6,
            this.cmsiSelectAll,
            this.menuItemLookup});
            this.contextMenuTextArea.Name = "textBoxContextMenu";
            resources.ApplyResources(this.contextMenuTextArea, "contextMenuTextArea");
            // 
            // cmsiCut
            // 
            resources.ApplyResources(this.cmsiCut, "cmsiCut");
            this.cmsiCut.Name = "cmsiCut";
            this.cmsiCut.Click += new System.EventHandler(this.menuItemCut_Click);
            // 
            // csmiCopy
            // 
            resources.ApplyResources(this.csmiCopy, "csmiCopy");
            this.csmiCopy.Name = "csmiCopy";
            this.csmiCopy.Click += new System.EventHandler(this.menuItemCopy_Click);
            // 
            // cmsiPaste
            // 
            resources.ApplyResources(this.cmsiPaste, "cmsiPaste");
            this.cmsiPaste.Name = "cmsiPaste";
            this.cmsiPaste.Click += new System.EventHandler(this.menuItemPaste_Click);
            // 
            // cmsiDelete
            // 
            resources.ApplyResources(this.cmsiDelete, "cmsiDelete");
            this.cmsiDelete.Name = "cmsiDelete";
            this.cmsiDelete.Click += new System.EventHandler(this.menuItemDelete_Click);
            // 
            // cmsiSelectAll
            // 
            resources.ApplyResources(this.cmsiSelectAll, "cmsiSelectAll");
            this.cmsiSelectAll.Name = "cmsiSelectAll";
            this.cmsiSelectAll.Click += new System.EventHandler(this.menuItemSelectAll_Click);
            // 
            // menuItemLookup
            // 
            this.menuItemLookup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNinjaWords});
            this.menuItemLookup.Name = "menuItemLookup";
            resources.ApplyResources(this.menuItemLookup, "menuItemLookup");
            // 
            // menuItemNinjaWords
            // 
            this.menuItemNinjaWords.Name = "menuItemNinjaWords";
            resources.ApplyResources(this.menuItemNinjaWords, "menuItemNinjaWords");
            this.menuItemNinjaWords.Click += new System.EventHandler(this.menuItemNinjaWords_Click);
            // 
            // timerMessage
            // 
            this.timerMessage.Enabled = true;
            this.timerMessage.Interval = 1000;
            this.timerMessage.Tick += new System.EventHandler(this.timerMessage_Tick);
            // 
            // tabControl
            // 
            this.tabControl.AllowDrop = true;
            this.tabControl.AllowKeyNavigation = true;
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.HotTrack = true;
            this.tabControl.LineNumbersVisible = false;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.TabStop = false;
            this.tabControl.WordWrap = false;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            this.tabControl.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.tabControl_ControlAdded);
            this.tabControl.DragDrop += new System.Windows.Forms.DragEventHandler(this.tabControl_DragDrop);
            this.tabControl.DragEnter += new System.Windows.Forms.DragEventHandler(this.tabControl_DragEnter);
            this.tabControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseDown);
            this.tabControl.MouseEnter += new System.EventHandler(this.menuItemFile_MouseEnter);
            this.tabControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseMove);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Generic_MouseMove);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.contextMenuTabPage.ResumeLayout(false);
            this.contextMenuTextArea.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuItemPageSetup;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem menuItemUndo;
        private System.Windows.Forms.ToolStripMenuItem menuItemFind;
        private System.Windows.Forms.ToolStripMenuItem menuItemFindNext;
        private System.Windows.Forms.ToolStripMenuItem menuItemReplace;
        private System.Windows.Forms.ToolStripMenuItem menuItemGoto;
        private System.Windows.Forms.ToolStripMenuItem menuItemSelectAll;
        private System.Windows.Forms.ToolStripMenuItem menuItemInsert;
        private System.Windows.Forms.ToolStripMenuItem menuItemView;
        private System.Windows.Forms.ToolStripMenuItem menuItemStatusBar;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem menuItemRedo;
        private System.Windows.Forms.ToolStripStatusLabel labelCurrentLine;
        private System.Windows.Forms.ToolStripStatusLabel labelCurrentColumn;
        private System.Windows.Forms.ToolStripMenuItem menuItemCloseTab;
        private System.Windows.Forms.ToolStripStatusLabel labelTabCount;
        private System.Windows.Forms.ToolStripStatusLabel labelTabSelected;
        private ToolStripMenuItem menuItemMinimize;
        private ToolStripMenuItem menuItemProductDoc;
        private ToolStripMenuItem menuItemCloseAllTabs;
        private ToolStripMenuItem menuItemCloseAllButCurrent;
        private ToolStripMenuItem menuItemSettings;
        private ToolStripMenuItem menuItemOpenRecent;
        private ContextMenuStrip contextMenuTabPage;
        private ToolStripMenuItem cmsiCloseAllButThis;
        private ToolStripMenuItem cmsiCloseThis;
        private ToolTip toolTip;
        private ToolStripMenuItem menuItemWordWrap;
        private ToolStripMenuItem menuItemAddTab;
        private ToolStripMenuItem menuItemOpen;
        private ToolStripMenuItem menuItemPrint;
        private ToolStripMenuItem menuItemPrintPreview;
        private ToolStripMenuItem menuItemSave;
        private ToolStripMenuItem menuItemCloseAndDelete;
        private ToolStripSeparator toolStripSeparator7;
        private Timer timerMessage;
        private ToolStripMenuItem menuItemLongDateTime;
        private ToolStripMenuItem menuItemShortDateTime;
        private ToolStripMenuItem menuItemFullscreen;
        private ToolStripMenuItem cmsiShowInFolder;
        private ContextMenuStrip contextMenuTextArea;
        private ToolStripMenuItem csmiCopy;
        private ToolStripMenuItem cmsiPaste;
        private ToolStripMenuItem cmsiCut;
        private ToolStripMenuItem cmsiDelete;
        private ToolStripMenuItem cmsiSelectAll;
        private ToolStripMenuItem menuItemUpdates;
        private ToolStripMenuItem menuItemSignature;
        private ToolStripMenuItem menuItemAlwaysOnTop;
        private ToolStripMenuItem menuItemAutoIndent;
        private ToolStripMenuItem menuItemLineNumbers;
        private PlainTextTabControl tabControl;
        private ToolStripMenuItem cmsiOpenInWinNotepad;
        private ToolStripMenuItem menuItemReadingWindow;
        private ToolStripMenuItem menuItemDlWebpage;
        private ToolStripTextBox textBoxHTMLLink;
        private ToolStripMenuItem menuItemRegexRefactoring;
        private ToolStripMenuItem menuItemLookup;
        private ToolStripMenuItem menuItemNinjaWords;
        private ToolStripStatusLabel labelCharCount;
    }
}

