using NotepadEnhanced.Forms;

namespace NotepadEnhanced.Forms
{
    partial class RegexRefactoringForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegexRefactoringForm));
            this.buttonRefactor = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEdit = new IlluminateButton();
            this.buttonMinus = new IlluminateButton();
            this.buttonAdd = new IlluminateButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // buttonRefactor
            // 
            resources.ApplyResources(this.buttonRefactor, "buttonRefactor");
            this.buttonRefactor.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonRefactor.Name = "buttonRefactor";
            this.toolTip.SetToolTip(this.buttonRefactor, resources.GetString("buttonRefactor.ToolTip"));
            this.buttonRefactor.UseVisualStyleBackColor = true;
            this.buttonRefactor.Click += new System.EventHandler(this.buttonRefactor_Click);
            // 
            // listBox
            // 
            resources.ApplyResources(this.listBox, "listBox");
            this.listBox.FormattingEnabled = true;
            this.listBox.Name = "listBox";
            this.listBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.toolTip.SetToolTip(this.listBox, resources.GetString("listBox.ToolTip"));
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // labelDescription
            // 
            resources.ApplyResources(this.labelDescription, "labelDescription");
            this.labelDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDescription.Name = "labelDescription";
            this.toolTip.SetToolTip(this.labelDescription, resources.GetString("labelDescription.ToolTip"));
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTip.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // buttonEdit
            // 
            resources.ApplyResources(this.buttonEdit, "buttonEdit");
            this.buttonEdit.BackColor = System.Drawing.Color.Transparent;
            this.buttonEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEdit.DepressBrightness = 1F;
            this.buttonEdit.DepressConstrast = 1F;
            this.buttonEdit.DepressGamma = 1F;
            this.buttonEdit.FlatAppearance.BorderSize = 0;
            this.buttonEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonEdit.HoverBrightness = 1F;
            this.buttonEdit.HoverContrast = 1.1F;
            this.buttonEdit.HoverGamma = 0.8F;
            this.buttonEdit.Image = global::NotepadEnhanced.Properties.Resources.Edit;
            this.buttonEdit.Name = "buttonEdit";
            this.toolTip.SetToolTip(this.buttonEdit, resources.GetString("buttonEdit.ToolTip"));
            this.buttonEdit.UseVisualStyleBackColor = false;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonMinus
            // 
            resources.ApplyResources(this.buttonMinus, "buttonMinus");
            this.buttonMinus.BackColor = System.Drawing.Color.Transparent;
            this.buttonMinus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMinus.DepressBrightness = 1F;
            this.buttonMinus.DepressConstrast = 1F;
            this.buttonMinus.DepressGamma = 1F;
            this.buttonMinus.FlatAppearance.BorderSize = 0;
            this.buttonMinus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonMinus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonMinus.HoverBrightness = 1F;
            this.buttonMinus.HoverContrast = 1.1F;
            this.buttonMinus.HoverGamma = 0.8F;
            this.buttonMinus.Image = global::NotepadEnhanced.Properties.Resources.Minus;
            this.buttonMinus.Name = "buttonMinus";
            this.toolTip.SetToolTip(this.buttonMinus, resources.GetString("buttonMinus.ToolTip"));
            this.buttonMinus.UseVisualStyleBackColor = false;
            this.buttonMinus.Click += new System.EventHandler(this.buttonMinus_Click);
            // 
            // buttonAdd
            // 
            resources.ApplyResources(this.buttonAdd, "buttonAdd");
            this.buttonAdd.BackColor = System.Drawing.Color.Transparent;
            this.buttonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdd.DepressBrightness = 1F;
            this.buttonAdd.DepressConstrast = 1F;
            this.buttonAdd.DepressGamma = 1F;
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonAdd.HoverBrightness = 1F;
            this.buttonAdd.HoverContrast = 1.1F;
            this.buttonAdd.HoverGamma = 0.8F;
            this.buttonAdd.Name = "buttonAdd";
            this.toolTip.SetToolTip(this.buttonAdd, resources.GetString("buttonAdd.ToolTip"));
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // RegexRefactoringForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonMinus);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.buttonRefactor);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegexRefactoringForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRefactor;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label labelDescription;
        private IlluminateButton buttonAdd;
        private IlluminateButton buttonMinus;
        private System.Windows.Forms.Label label1;
        private IlluminateButton buttonEdit;
        private System.Windows.Forms.ToolTip toolTip;
    }
}