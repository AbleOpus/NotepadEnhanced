using NotepadEnhanced.Refactexing;
using NotepadEnhanced.Forms;

namespace NotepadEnhanced.Forms
{
    partial class EditRefactexForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditRefactexForm));
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonDiscard = new System.Windows.Forms.Button();
            this.refactexPanel = new NotepadEnhanced.Forms.RefactexPanel();
            this.SuspendLayout();
            // 
            // buttonAccept
            // 
            resources.ApplyResources(this.buttonAccept, "buttonAccept");
            this.buttonAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            // 
            // buttonDiscard
            // 
            resources.ApplyResources(this.buttonDiscard, "buttonDiscard");
            this.buttonDiscard.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonDiscard.Name = "buttonDiscard";
            this.buttonDiscard.UseVisualStyleBackColor = true;
            // 
            // refactexPanel
            // 
            resources.ApplyResources(this.refactexPanel, "refactexPanel");
            this.refactexPanel.Name = "refactexPanel";
            this.refactexPanel.SubmittableChanged += new System.EventHandler(this.refactexPanel_SubmittableChanged);
            // 
            // EditRefactexForm
            // 
            this.AcceptButton = this.buttonAccept;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonDiscard;
            this.Controls.Add(this.buttonDiscard);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.refactexPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditRefactexForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

        }

        #endregion

        private RefactexPanel refactexPanel;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonDiscard;
    }
}