namespace NotepadEnhanced.Forms
{
    partial class DockedPanel
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
            this.SuspendLayout();
            // 
            // DockedPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "DockedPanel";
            this.Size = new System.Drawing.Size(373, 416);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DisplayControls_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DisplayControls_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DisplayControls_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
