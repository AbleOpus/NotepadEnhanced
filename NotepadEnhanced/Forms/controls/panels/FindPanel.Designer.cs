namespace NotepadEnhanced.Forms
{
    partial class FindPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindPanel));
            this.checkBoxMatchCase = new System.Windows.Forms.CheckBox();
            this.buttonFindNext = new System.Windows.Forms.Button();
            this.textBoxPattern = new NotepadEnhanced.Forms.HotTrackedTextBox();
            this.SuspendLayout();
            // 
            // checkBoxMatchCase
            // 
            resources.ApplyResources(this.checkBoxMatchCase, "checkBoxMatchCase");
            this.checkBoxMatchCase.Name = "checkBoxMatchCase";
            this.checkBoxMatchCase.UseVisualStyleBackColor = true;
            // 
            // buttonFindNext
            // 
            resources.ApplyResources(this.buttonFindNext, "buttonFindNext");
            this.buttonFindNext.Image = global::NotepadEnhanced.Properties.Resources.Find;
            this.buttonFindNext.Name = "buttonFindNext";
            this.buttonFindNext.UseVisualStyleBackColor = true;
            // 
            // textBoxPattern
            // 
            resources.ApplyResources(this.textBoxPattern, "textBoxPattern");
            this.textBoxPattern.Name = "textBoxPattern";
            this.textBoxPattern.TextChanged += new System.EventHandler(this.textBoxPattern_TextChanged);
            // 
            // FindPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Controls.Add(this.textBoxPattern);
            this.Controls.Add(this.checkBoxMatchCase);
            this.Controls.Add(this.buttonFindNext);
            this.Name = "FindPanel";
            resources.ApplyResources(this, "$this");
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HotTrackedTextBox textBoxPattern;
        private System.Windows.Forms.CheckBox checkBoxMatchCase;
        private System.Windows.Forms.Button buttonFindNext;
    }
}
