using NotepadEnhanced.Forms;

namespace NotepadEnhanced.Forms
{
    partial class SettingsDialog
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
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label labelSigInsert;
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.checkBoxRestorePrompt = new System.Windows.Forms.CheckBox();
            this.checkBoxAddTabOnStart = new System.Windows.Forms.CheckBox();
            this.checkBoxSingleInstance = new System.Windows.Forms.CheckBox();
            this.numberBoxVertPadding = new System.Windows.Forms.NumericUpDown();
            this.numberBoxHorizPadding = new System.Windows.Forms.NumericUpDown();
            this.checkBoxReadingTopmost = new System.Windows.Forms.CheckBox();
            this.numberBoxReadingWidth = new System.Windows.Forms.NumericUpDown();
            this.checkBoxRight = new System.Windows.Forms.CheckBox();
            this.checkBoxMiddle = new System.Windows.Forms.CheckBox();
            this.checkBoxLeft = new System.Windows.Forms.CheckBox();
            this.checkBoxAddTitle = new System.Windows.Forms.CheckBox();
            this.numberBoxMaxRecents = new System.Windows.Forms.NumericUpDown();
            this.checkBoxSelectionMargin = new System.Windows.Forms.CheckBox();
            this.checkBoxMultilineTabs = new System.Windows.Forms.CheckBox();
            this.checkBoxTrackSelection = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoWordSelection = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabBehave = new System.Windows.Forms.TabPage();
            this.comboLanguageSelect = new System.Windows.Forms.ComboBox();
            this.tabTextEditor = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboLnNumStyle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabRecentFile = new System.Windows.Forms.TabPage();
            this.checkBoxRecentFilesEnabled = new System.Windows.Forms.CheckBox();
            this.buttonClearRecentList = new System.Windows.Forms.Button();
            this.tabReadingView = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPrinting = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.textBoxSigInsert = new NotepadEnhanced.Forms.HotTrackedTextBox();
            this.pickerLnNumForeColor = new NotepadEnhanced.Forms.ColorPickerControl();
            this.pickerLnNumStyleColor = new NotepadEnhanced.Forms.ColorPickerControl();
            this.fontPickerTextBoxArea = new NotepadEnhanced.Forms.FontPicker();
            this.pickerBackColor = new NotepadEnhanced.Forms.ColorPickerControl();
            this.pickerTextColor = new NotepadEnhanced.Forms.ColorPickerControl();
            this.fontPickerReading = new NotepadEnhanced.Forms.FontPicker();
            this.pickerWindowColor = new NotepadEnhanced.Forms.ColorPickerControl();
            this.pickerReadBackColor = new NotepadEnhanced.Forms.ColorPickerControl();
            this.pickerReadForeColor = new NotepadEnhanced.Forms.ColorPickerControl();
            label1 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            labelSigInsert = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numberBoxVertPadding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberBoxHorizPadding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberBoxReadingWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberBoxMaxRecents)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabBehave.SuspendLayout();
            this.tabTextEditor.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabRecentFile.SuspendLayout();
            this.tabReadingView.SuspendLayout();
            this.tabPrinting.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // labelSigInsert
            // 
            resources.ApplyResources(labelSigInsert, "labelSigInsert");
            labelSigInsert.Name = "labelSigInsert";
            // 
            // checkBoxRestorePrompt
            // 
            resources.ApplyResources(this.checkBoxRestorePrompt, "checkBoxRestorePrompt");
            this.checkBoxRestorePrompt.Name = "checkBoxRestorePrompt";
            this.toolTip.SetToolTip(this.checkBoxRestorePrompt, resources.GetString("checkBoxRestorePrompt.ToolTip"));
            this.checkBoxRestorePrompt.UseVisualStyleBackColor = true;
            // 
            // checkBoxAddTabOnStart
            // 
            resources.ApplyResources(this.checkBoxAddTabOnStart, "checkBoxAddTabOnStart");
            this.checkBoxAddTabOnStart.Name = "checkBoxAddTabOnStart";
            this.toolTip.SetToolTip(this.checkBoxAddTabOnStart, resources.GetString("checkBoxAddTabOnStart.ToolTip"));
            this.checkBoxAddTabOnStart.UseVisualStyleBackColor = true;
            // 
            // checkBoxSingleInstance
            // 
            resources.ApplyResources(this.checkBoxSingleInstance, "checkBoxSingleInstance");
            this.checkBoxSingleInstance.Name = "checkBoxSingleInstance";
            this.toolTip.SetToolTip(this.checkBoxSingleInstance, resources.GetString("checkBoxSingleInstance.ToolTip"));
            this.checkBoxSingleInstance.UseVisualStyleBackColor = true;
            // 
            // numberBoxVertPadding
            // 
            resources.ApplyResources(this.numberBoxVertPadding, "numberBoxVertPadding");
            this.numberBoxVertPadding.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numberBoxVertPadding.Name = "numberBoxVertPadding";
            this.toolTip.SetToolTip(this.numberBoxVertPadding, resources.GetString("numberBoxVertPadding.ToolTip"));
            // 
            // numberBoxHorizPadding
            // 
            resources.ApplyResources(this.numberBoxHorizPadding, "numberBoxHorizPadding");
            this.numberBoxHorizPadding.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numberBoxHorizPadding.Name = "numberBoxHorizPadding";
            this.toolTip.SetToolTip(this.numberBoxHorizPadding, resources.GetString("numberBoxHorizPadding.ToolTip"));
            // 
            // checkBoxReadingTopmost
            // 
            resources.ApplyResources(this.checkBoxReadingTopmost, "checkBoxReadingTopmost");
            this.checkBoxReadingTopmost.Name = "checkBoxReadingTopmost";
            this.toolTip.SetToolTip(this.checkBoxReadingTopmost, resources.GetString("checkBoxReadingTopmost.ToolTip"));
            this.checkBoxReadingTopmost.UseVisualStyleBackColor = true;
            // 
            // numberBoxReadingWidth
            // 
            resources.ApplyResources(this.numberBoxReadingWidth, "numberBoxReadingWidth");
            this.numberBoxReadingWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numberBoxReadingWidth.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numberBoxReadingWidth.Name = "numberBoxReadingWidth";
            this.toolTip.SetToolTip(this.numberBoxReadingWidth, resources.GetString("numberBoxReadingWidth.ToolTip"));
            this.numberBoxReadingWidth.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // checkBoxRight
            // 
            resources.ApplyResources(this.checkBoxRight, "checkBoxRight");
            this.checkBoxRight.AutoCheck = false;
            this.checkBoxRight.FlatAppearance.BorderSize = 0;
            this.checkBoxRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.checkBoxRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.checkBoxRight.Name = "checkBoxRight";
            this.toolTip.SetToolTip(this.checkBoxRight, resources.GetString("checkBoxRight.ToolTip"));
            this.checkBoxRight.UseVisualStyleBackColor = true;
            // 
            // checkBoxMiddle
            // 
            resources.ApplyResources(this.checkBoxMiddle, "checkBoxMiddle");
            this.checkBoxMiddle.AutoCheck = false;
            this.checkBoxMiddle.FlatAppearance.BorderSize = 0;
            this.checkBoxMiddle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.checkBoxMiddle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.checkBoxMiddle.Name = "checkBoxMiddle";
            this.toolTip.SetToolTip(this.checkBoxMiddle, resources.GetString("checkBoxMiddle.ToolTip"));
            this.checkBoxMiddle.UseVisualStyleBackColor = true;
            // 
            // checkBoxLeft
            // 
            resources.ApplyResources(this.checkBoxLeft, "checkBoxLeft");
            this.checkBoxLeft.AutoCheck = false;
            this.checkBoxLeft.FlatAppearance.BorderSize = 0;
            this.checkBoxLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.checkBoxLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.checkBoxLeft.Name = "checkBoxLeft";
            this.toolTip.SetToolTip(this.checkBoxLeft, resources.GetString("checkBoxLeft.ToolTip"));
            this.checkBoxLeft.UseVisualStyleBackColor = true;
            // 
            // checkBoxAddTitle
            // 
            resources.ApplyResources(this.checkBoxAddTitle, "checkBoxAddTitle");
            this.checkBoxAddTitle.Name = "checkBoxAddTitle";
            this.toolTip.SetToolTip(this.checkBoxAddTitle, resources.GetString("checkBoxAddTitle.ToolTip"));
            this.checkBoxAddTitle.UseVisualStyleBackColor = true;
            // 
            // numberBoxMaxRecents
            // 
            resources.ApplyResources(this.numberBoxMaxRecents, "numberBoxMaxRecents");
            this.numberBoxMaxRecents.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberBoxMaxRecents.Name = "numberBoxMaxRecents";
            this.toolTip.SetToolTip(this.numberBoxMaxRecents, resources.GetString("numberBoxMaxRecents.ToolTip"));
            this.numberBoxMaxRecents.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBoxSelectionMargin
            // 
            resources.ApplyResources(this.checkBoxSelectionMargin, "checkBoxSelectionMargin");
            this.checkBoxSelectionMargin.Name = "checkBoxSelectionMargin";
            this.toolTip.SetToolTip(this.checkBoxSelectionMargin, resources.GetString("checkBoxSelectionMargin.ToolTip"));
            this.checkBoxSelectionMargin.UseVisualStyleBackColor = true;
            this.checkBoxSelectionMargin.Click += new System.EventHandler(this.checkBoxSelectionMargin_Click);
            // 
            // checkBoxMultilineTabs
            // 
            resources.ApplyResources(this.checkBoxMultilineTabs, "checkBoxMultilineTabs");
            this.checkBoxMultilineTabs.Name = "checkBoxMultilineTabs";
            this.toolTip.SetToolTip(this.checkBoxMultilineTabs, resources.GetString("checkBoxMultilineTabs.ToolTip"));
            this.checkBoxMultilineTabs.UseVisualStyleBackColor = true;
            this.checkBoxMultilineTabs.Click += new System.EventHandler(this.checkBoxMultilineTabs_Click);
            // 
            // checkBoxTrackSelection
            // 
            resources.ApplyResources(this.checkBoxTrackSelection, "checkBoxTrackSelection");
            this.checkBoxTrackSelection.Name = "checkBoxTrackSelection";
            this.toolTip.SetToolTip(this.checkBoxTrackSelection, resources.GetString("checkBoxTrackSelection.ToolTip"));
            this.checkBoxTrackSelection.UseVisualStyleBackColor = true;
            this.checkBoxTrackSelection.Click += new System.EventHandler(this.checkBoxTrackSelection_Click);
            // 
            // checkBoxAutoWordSelection
            // 
            resources.ApplyResources(this.checkBoxAutoWordSelection, "checkBoxAutoWordSelection");
            this.checkBoxAutoWordSelection.Name = "checkBoxAutoWordSelection";
            this.toolTip.SetToolTip(this.checkBoxAutoWordSelection, resources.GetString("checkBoxAutoWordSelection.ToolTip"));
            this.checkBoxAutoWordSelection.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Controls.Add(this.tabBehave);
            this.tabControl.Controls.Add(this.tabTextEditor);
            this.tabControl.Controls.Add(this.tabRecentFile);
            this.tabControl.Controls.Add(this.tabReadingView);
            this.tabControl.Controls.Add(this.tabPrinting);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tabBehave
            // 
            this.tabBehave.Controls.Add(labelSigInsert);
            this.tabBehave.Controls.Add(this.textBoxSigInsert);
            this.tabBehave.Controls.Add(label6);
            this.tabBehave.Controls.Add(this.comboLanguageSelect);
            this.tabBehave.Controls.Add(this.checkBoxMultilineTabs);
            this.tabBehave.Controls.Add(this.checkBoxSelectionMargin);
            this.tabBehave.Controls.Add(this.checkBoxRestorePrompt);
            this.tabBehave.Controls.Add(this.checkBoxAddTabOnStart);
            this.tabBehave.Controls.Add(this.checkBoxSingleInstance);
            resources.ApplyResources(this.tabBehave, "tabBehave");
            this.tabBehave.Name = "tabBehave";
            this.tabBehave.UseVisualStyleBackColor = true;
            // 
            // comboLanguageSelect
            // 
            this.comboLanguageSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLanguageSelect.FormattingEnabled = true;
            resources.ApplyResources(this.comboLanguageSelect, "comboLanguageSelect");
            this.comboLanguageSelect.Name = "comboLanguageSelect";
            this.comboLanguageSelect.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguageSelect_SelectedIndexChanged);
            // 
            // tabTextEditor
            // 
            this.tabTextEditor.Controls.Add(this.groupBox2);
            this.tabTextEditor.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.tabTextEditor, "tabTextEditor");
            this.tabTextEditor.Name = "tabTextEditor";
            this.tabTextEditor.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pickerLnNumForeColor);
            this.groupBox2.Controls.Add(this.pickerLnNumStyleColor);
            this.groupBox2.Controls.Add(this.comboLnNumStyle);
            this.groupBox2.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // comboLnNumStyle
            // 
            this.comboLnNumStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLnNumStyle.FormattingEnabled = true;
            this.comboLnNumStyle.Items.AddRange(new object[] {
            resources.GetString("comboLnNumStyle.Items"),
            resources.GetString("comboLnNumStyle.Items1"),
            resources.GetString("comboLnNumStyle.Items2")});
            resources.ApplyResources(this.comboLnNumStyle, "comboLnNumStyle");
            this.comboLnNumStyle.Name = "comboLnNumStyle";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.fontPickerTextBoxArea);
            this.groupBox1.Controls.Add(this.checkBoxTrackSelection);
            this.groupBox1.Controls.Add(this.pickerBackColor);
            this.groupBox1.Controls.Add(this.checkBoxAutoWordSelection);
            this.groupBox1.Controls.Add(this.pickerTextColor);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tabRecentFile
            // 
            this.tabRecentFile.Controls.Add(this.checkBoxRecentFilesEnabled);
            this.tabRecentFile.Controls.Add(this.buttonClearRecentList);
            this.tabRecentFile.Controls.Add(this.numberBoxMaxRecents);
            this.tabRecentFile.Controls.Add(label1);
            resources.ApplyResources(this.tabRecentFile, "tabRecentFile");
            this.tabRecentFile.Name = "tabRecentFile";
            this.tabRecentFile.UseVisualStyleBackColor = true;
            // 
            // checkBoxRecentFilesEnabled
            // 
            resources.ApplyResources(this.checkBoxRecentFilesEnabled, "checkBoxRecentFilesEnabled");
            this.checkBoxRecentFilesEnabled.Name = "checkBoxRecentFilesEnabled";
            this.checkBoxRecentFilesEnabled.UseVisualStyleBackColor = true;
            // 
            // buttonClearRecentList
            // 
            resources.ApplyResources(this.buttonClearRecentList, "buttonClearRecentList");
            this.buttonClearRecentList.Name = "buttonClearRecentList";
            this.buttonClearRecentList.UseVisualStyleBackColor = true;
            this.buttonClearRecentList.Click += new System.EventHandler(this.buttonClearRecentList_Click);
            // 
            // tabReadingView
            // 
            this.tabReadingView.Controls.Add(this.label4);
            this.tabReadingView.Controls.Add(this.label14);
            this.tabReadingView.Controls.Add(this.numberBoxVertPadding);
            this.tabReadingView.Controls.Add(this.label13);
            this.tabReadingView.Controls.Add(this.numberBoxHorizPadding);
            this.tabReadingView.Controls.Add(this.checkBoxReadingTopmost);
            this.tabReadingView.Controls.Add(this.label11);
            this.tabReadingView.Controls.Add(this.numberBoxReadingWidth);
            this.tabReadingView.Controls.Add(this.fontPickerReading);
            this.tabReadingView.Controls.Add(this.pickerWindowColor);
            this.tabReadingView.Controls.Add(this.pickerReadBackColor);
            this.tabReadingView.Controls.Add(this.pickerReadForeColor);
            resources.ApplyResources(this.tabReadingView, "tabReadingView");
            this.tabReadingView.Name = "tabReadingView";
            this.tabReadingView.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // tabPrinting
            // 
            this.tabPrinting.Controls.Add(this.groupBox3);
            resources.ApplyResources(this.tabPrinting, "tabPrinting");
            this.tabPrinting.Name = "tabPrinting";
            this.tabPrinting.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxRight);
            this.groupBox3.Controls.Add(this.checkBoxAddTitle);
            this.groupBox3.Controls.Add(this.checkBoxMiddle);
            this.groupBox3.Controls.Add(this.checkBoxLeft);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // buttonReset
            // 
            resources.ApplyResources(this.buttonReset, "buttonReset");
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonResetAll_Click);
            // 
            // textBoxSigInsert
            // 
            resources.ApplyResources(this.textBoxSigInsert, "textBoxSigInsert");
            this.textBoxSigInsert.Name = "textBoxSigInsert";
            this.toolTip.SetToolTip(this.textBoxSigInsert, resources.GetString("textBoxSigInsert.ToolTip"));
            // 
            // pickerLnNumForeColor
            // 
            resources.ApplyResources(this.pickerLnNumForeColor, "pickerLnNumForeColor");
            this.pickerLnNumForeColor.CustomColors = null;
            this.pickerLnNumForeColor.Name = "pickerLnNumForeColor";
            this.pickerLnNumForeColor.PickedColor = System.Drawing.SystemColors.Control;
            this.pickerLnNumForeColor.ColorPicked += new System.EventHandler(this.pickerLineNumForeColor_ColorPicked);
            // 
            // pickerLnNumStyleColor
            // 
            resources.ApplyResources(this.pickerLnNumStyleColor, "pickerLnNumStyleColor");
            this.pickerLnNumStyleColor.CustomColors = null;
            this.pickerLnNumStyleColor.Name = "pickerLnNumStyleColor";
            this.pickerLnNumStyleColor.PickedColor = System.Drawing.SystemColors.Control;
            // 
            // fontPickerTextBoxArea
            // 
            resources.ApplyResources(this.fontPickerTextBoxArea, "fontPickerTextBoxArea");
            this.fontPickerTextBoxArea.Name = "fontPickerTextBoxArea";
            this.fontPickerTextBoxArea.PreviewFont = false;
            this.fontPickerTextBoxArea.SelectedFontChanged += new System.EventHandler(this.fontPickerTextArea_SelectedFontChanged);
            // 
            // pickerBackColor
            // 
            resources.ApplyResources(this.pickerBackColor, "pickerBackColor");
            this.pickerBackColor.CustomColors = null;
            this.pickerBackColor.Name = "pickerBackColor";
            this.pickerBackColor.PickedColor = System.Drawing.SystemColors.Control;
            this.pickerBackColor.ColorPicked += new System.EventHandler(this.pickerBackColor_ColorPicked);
            // 
            // pickerTextColor
            // 
            resources.ApplyResources(this.pickerTextColor, "pickerTextColor");
            this.pickerTextColor.CustomColors = null;
            this.pickerTextColor.Name = "pickerTextColor";
            this.pickerTextColor.PickedColor = System.Drawing.SystemColors.Control;
            this.pickerTextColor.ColorPicked += new System.EventHandler(this.pickerTextColor_ColorPicked);
            // 
            // fontPickerReading
            // 
            resources.ApplyResources(this.fontPickerReading, "fontPickerReading");
            this.fontPickerReading.Name = "fontPickerReading";
            this.fontPickerReading.PreviewFont = false;
            this.fontPickerReading.SelectedFontChanged += new System.EventHandler(this.fontPickerReading_SelectedFontChanged);
            // 
            // pickerWindowColor
            // 
            resources.ApplyResources(this.pickerWindowColor, "pickerWindowColor");
            this.pickerWindowColor.CustomColors = null;
            this.pickerWindowColor.Name = "pickerWindowColor";
            this.pickerWindowColor.PickedColor = System.Drawing.SystemColors.Control;
            this.pickerWindowColor.ColorPicked += new System.EventHandler(this.pickerWindowColor_ColorPicked);
            // 
            // pickerReadBackColor
            // 
            resources.ApplyResources(this.pickerReadBackColor, "pickerReadBackColor");
            this.pickerReadBackColor.CustomColors = null;
            this.pickerReadBackColor.Name = "pickerReadBackColor";
            this.pickerReadBackColor.PickedColor = System.Drawing.SystemColors.Control;
            this.pickerReadBackColor.ColorPicked += new System.EventHandler(this.pickerReadBackColor_ColorPicked);
            // 
            // pickerReadForeColor
            // 
            resources.ApplyResources(this.pickerReadForeColor, "pickerReadForeColor");
            this.pickerReadForeColor.CustomColors = null;
            this.pickerReadForeColor.Name = "pickerReadForeColor";
            this.pickerReadForeColor.PickedColor = System.Drawing.SystemColors.Control;
            this.pickerReadForeColor.ColorPicked += new System.EventHandler(this.pickerReadForeColor_ColorPicked);
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.numberBoxVertPadding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberBoxHorizPadding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberBoxReadingWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberBoxMaxRecents)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabBehave.ResumeLayout(false);
            this.tabBehave.PerformLayout();
            this.tabTextEditor.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabRecentFile.ResumeLayout(false);
            this.tabRecentFile.PerformLayout();
            this.tabReadingView.ResumeLayout(false);
            this.tabReadingView.PerformLayout();
            this.tabPrinting.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabBehave;
        private System.Windows.Forms.TabPage tabTextEditor;
        private System.Windows.Forms.TabPage tabRecentFile;
        private System.Windows.Forms.TabPage tabReadingView;
        private System.Windows.Forms.TabPage tabPrinting;
        private System.Windows.Forms.CheckBox checkBoxRestorePrompt;
        private System.Windows.Forms.CheckBox checkBoxAddTabOnStart;
        private System.Windows.Forms.CheckBox checkBoxSingleInstance;
        private ColorPickerControl pickerBackColor;
        private ColorPickerControl pickerTextColor;
        private System.Windows.Forms.CheckBox checkBoxRecentFilesEnabled;
        private System.Windows.Forms.Button buttonClearRecentList;
        private System.Windows.Forms.NumericUpDown numberBoxMaxRecents;
        private ColorPickerControl pickerWindowColor;
        private ColorPickerControl pickerReadBackColor;
        private ColorPickerControl pickerReadForeColor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numberBoxVertPadding;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numberBoxHorizPadding;
        private System.Windows.Forms.CheckBox checkBoxReadingTopmost;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numberBoxReadingWidth;
        private System.Windows.Forms.CheckBox checkBoxRight;
        private System.Windows.Forms.CheckBox checkBoxMiddle;
        private System.Windows.Forms.CheckBox checkBoxLeft;
        private System.Windows.Forms.CheckBox checkBoxAddTitle;
        private System.Windows.Forms.CheckBox checkBoxMultilineTabs;
        private System.Windows.Forms.CheckBox checkBoxSelectionMargin;
        private System.Windows.Forms.ComboBox comboLanguageSelect;
        private HotTrackedTextBox textBoxSigInsert;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ColorPickerControl pickerLnNumForeColor;
        private ColorPickerControl pickerLnNumStyleColor;
        private System.Windows.Forms.ComboBox comboLnNumStyle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxTrackSelection;
        private System.Windows.Forms.CheckBox checkBoxAutoWordSelection;
        private FontPicker fontPickerTextBoxArea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private FontPicker fontPickerReading;
    }
}