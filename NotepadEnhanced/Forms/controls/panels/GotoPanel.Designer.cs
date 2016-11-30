namespace NotepadEnhanced.Forms
{
    partial class GotoPanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GotoPanel));
            this.numberBoxLineNumber = new System.Windows.Forms.NumericUpDown();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonGoto = new NotepadEnhanced.Forms.IlluminateButton();
            this.buttonGotoBottom = new NotepadEnhanced.Forms.IlluminateButton();
            this.buttonGotoTop = new NotepadEnhanced.Forms.IlluminateButton();
            ((System.ComponentModel.ISupportInitialize)(this.numberBoxLineNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // numberBoxLineNumber
            // 
            resources.ApplyResources(this.numberBoxLineNumber, "numberBoxLineNumber");
            this.numberBoxLineNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberBoxLineNumber.Name = "numberBoxLineNumber";
            this.numberBoxLineNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonGoto
            // 
            resources.ApplyResources(this.buttonGoto, "buttonGoto");
            this.buttonGoto.BackColor = System.Drawing.Color.Transparent;
            this.buttonGoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGoto.DepressBrightness = 1F;
            this.buttonGoto.DepressConstrast = 1F;
            this.buttonGoto.DepressGamma = 1F;
            this.buttonGoto.FlatAppearance.BorderSize = 0;
            this.buttonGoto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonGoto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonGoto.HoverBrightness = 1F;
            this.buttonGoto.HoverContrast = 1.2F;
            this.buttonGoto.Image = global::NotepadEnhanced.Properties.Resources.Goto;
            this.buttonGoto.Name = "buttonGoto";
            this.buttonGoto.UseVisualStyleBackColor = false;
            this.buttonGoto.Click += new System.EventHandler(this.buttonGoto_Click);
            // 
            // buttonGotoBottom
            // 
            resources.ApplyResources(this.buttonGotoBottom, "buttonGotoBottom");
            this.buttonGotoBottom.BackColor = System.Drawing.Color.Transparent;
            this.buttonGotoBottom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGotoBottom.DepressBrightness = 1F;
            this.buttonGotoBottom.DepressConstrast = 1F;
            this.buttonGotoBottom.DepressGamma = 1F;
            this.buttonGotoBottom.FlatAppearance.BorderSize = 0;
            this.buttonGotoBottom.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonGotoBottom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonGotoBottom.HoverBrightness = 1F;
            this.buttonGotoBottom.HoverContrast = 1.2F;
            this.buttonGotoBottom.Image = global::NotepadEnhanced.Properties.Resources.Down_Arrow;
            this.buttonGotoBottom.Name = "buttonGotoBottom";
            this.buttonGotoBottom.UseVisualStyleBackColor = false;
            this.buttonGotoBottom.Click += new System.EventHandler(this.buttonGotoBottom_Click);
            // 
            // buttonGotoTop
            // 
            resources.ApplyResources(this.buttonGotoTop, "buttonGotoTop");
            this.buttonGotoTop.BackColor = System.Drawing.Color.Transparent;
            this.buttonGotoTop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGotoTop.DepressBrightness = 1F;
            this.buttonGotoTop.DepressConstrast = 1F;
            this.buttonGotoTop.DepressGamma = 1F;
            this.buttonGotoTop.FlatAppearance.BorderSize = 0;
            this.buttonGotoTop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonGotoTop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonGotoTop.HoverBrightness = 1F;
            this.buttonGotoTop.HoverContrast = 1.2F;
            this.buttonGotoTop.Image = global::NotepadEnhanced.Properties.Resources.Up_Arrow;
            this.buttonGotoTop.Name = "buttonGotoTop";
            this.buttonGotoTop.UseVisualStyleBackColor = false;
            this.buttonGotoTop.Click += new System.EventHandler(this.buttonGotoTop_Click);
            // 
            // GotoPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonGotoTop);
            this.Controls.Add(this.buttonGotoBottom);
            this.Controls.Add(this.buttonGoto);
            this.Controls.Add(this.numberBoxLineNumber);
            this.Name = "GotoPanel";
            this.MouseEnter += new System.EventHandler(this.GotoPanel_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.numberBoxLineNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numberBoxLineNumber;
        private System.Windows.Forms.ToolTip toolTip;
        private IlluminateButton buttonGoto;
        private IlluminateButton buttonGotoBottom;
        private IlluminateButton buttonGotoTop;
    }
}
