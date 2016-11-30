namespace NotepadEnhanced.Forms
{
    partial class ScrollingLabel
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
            this.label = new System.Windows.Forms.Label();
            this.panelInner = new System.Windows.Forms.Panel();
            this.panelInner.SuspendLayout();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.SystemColors.Window;
            this.label.Location = new System.Drawing.Point(3, 0);
            this.label.MaximumSize = new System.Drawing.Size(500, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(0, 13);
            this.label.TabIndex = 0;
            this.label.FontChanged += new System.EventHandler(this.label_FontChanged);
            this.label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            this.label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_MouseMove);
            this.label.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_MouseUp);
            // 
            // panelInner
            // 
            this.panelInner.Controls.Add(this.label);
            this.panelInner.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
            this.panelInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInner.Location = new System.Drawing.Point(0, 0);
            this.panelInner.Name = "panelInner";
            this.panelInner.Size = new System.Drawing.Size(436, 392);
            this.panelInner.TabIndex = 1;
            this.panelInner.SizeChanged += new System.EventHandler(this.panelInner_SizeChanged);
            // 
            // ScrollingLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panelInner);
            this.DoubleBuffered = true;
            this.Name = "ScrollingLabel";
            this.Size = new System.Drawing.Size(436, 392);
            this.panelInner.ResumeLayout(false);
            this.panelInner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Panel panelInner;
    }
}
