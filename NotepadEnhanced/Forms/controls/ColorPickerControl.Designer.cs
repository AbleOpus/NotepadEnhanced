namespace NotepadEnhanced.Forms
{
    partial class ColorPickerControl
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
            this.labelCaption = new System.Windows.Forms.Label();
            this.panelBackColor = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // labelCaption
            // 
            this.labelCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCaption.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCaption.Location = new System.Drawing.Point(0, 0);
            this.labelCaption.Name = "labelCaption";
            this.labelCaption.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.labelCaption.Size = new System.Drawing.Size(151, 23);
            this.labelCaption.TabIndex = 37;
            this.labelCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelBackColor
            // 
            this.panelBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBackColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelBackColor.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBackColor.Location = new System.Drawing.Point(151, 0);
            this.panelBackColor.Name = "panelBackColor";
            this.panelBackColor.Size = new System.Drawing.Size(28, 23);
            this.panelBackColor.TabIndex = 38;
            this.panelBackColor.Click += new System.EventHandler(this.panelBackColor_Click);
            this.panelBackColor.MouseEnter += new System.EventHandler(this.panelBackColor_MouseEnter);
            this.panelBackColor.MouseLeave += new System.EventHandler(this.panelBackColor_MouseLeave);
            // 
            // ColorPickerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelCaption);
            this.Controls.Add(this.panelBackColor);
            this.Name = "ColorPickerControl";
            this.Size = new System.Drawing.Size(179, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBackColor;
        private System.Windows.Forms.Label labelCaption;
    }
}
