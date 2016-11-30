namespace NotepadEnhanced.Forms
{
    partial class LookupPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LookupPanel));
            this.label1 = new System.Windows.Forms.Label();
            this.scrollingLabel = new NotepadEnhanced.Forms.ScrollingLabel();
            this.buttonGoogle = new System.Windows.Forms.Button();
            this.buttonWiki = new System.Windows.Forms.Button();
            this.buttonDictionary = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // scrollingLabel
            // 
            resources.ApplyResources(this.scrollingLabel, "scrollingLabel");
            this.scrollingLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.scrollingLabel.HorizontalPadding = 0;
            this.scrollingLabel.Name = "scrollingLabel";
            this.scrollingLabel.VerticalPadding = 0;
            // 
            // buttonGoogle
            // 
            resources.ApplyResources(this.buttonGoogle, "buttonGoogle");
            this.buttonGoogle.Name = "buttonGoogle";
            this.toolTip.SetToolTip(this.buttonGoogle, resources.GetString("buttonGoogle.ToolTip"));
            this.buttonGoogle.UseVisualStyleBackColor = true;
            // 
            // buttonWiki
            // 
            resources.ApplyResources(this.buttonWiki, "buttonWiki");
            this.buttonWiki.Name = "buttonWiki";
            this.toolTip.SetToolTip(this.buttonWiki, resources.GetString("buttonWiki.ToolTip"));
            this.buttonWiki.UseVisualStyleBackColor = true;
            // 
            // buttonDictionary
            // 
            resources.ApplyResources(this.buttonDictionary, "buttonDictionary");
            this.buttonDictionary.Name = "buttonDictionary";
            this.toolTip.SetToolTip(this.buttonDictionary, resources.GetString("buttonDictionary.ToolTip"));
            this.buttonDictionary.UseVisualStyleBackColor = true;
            // 
            // LookupPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonDictionary);
            this.Controls.Add(this.buttonWiki);
            this.Controls.Add(this.buttonGoogle);
            this.Controls.Add(this.scrollingLabel);
            this.Controls.Add(this.label1);
            this.Name = "LookupPanel";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.scrollingLabel, 0);
            this.Controls.SetChildIndex(this.buttonGoogle, 0);
            this.Controls.SetChildIndex(this.buttonWiki, 0);
            this.Controls.SetChildIndex(this.buttonDictionary, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ScrollingLabel scrollingLabel;
        private System.Windows.Forms.Button buttonGoogle;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonWiki;
        private System.Windows.Forms.Button buttonDictionary;
    }
}
