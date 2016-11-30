namespace NotepadEnhanced.Forms
{
    partial class ReplacePanel
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
            System.Windows.Forms.Label label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReplacePanel));
            System.Windows.Forms.Label label6;
            this.buttonReplaceAll = new System.Windows.Forms.Button();
            this.buttonReplaceSelected = new System.Windows.Forms.Button();
            this.buttonPanelFindNext = new System.Windows.Forms.Button();
            this.textBoxFind = new NotepadEnhanced.Forms.HotTrackedTextBox();
            this.textBoxReplace = new NotepadEnhanced.Forms.HotTrackedTextBox();
            this.checkBoxMatchCase = new System.Windows.Forms.CheckBox();
            this.labelReplaceCount = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // buttonReplaceAll
            // 
            resources.ApplyResources(this.buttonReplaceAll, "buttonReplaceAll");
            this.buttonReplaceAll.Name = "buttonReplaceAll";
            this.buttonReplaceAll.UseVisualStyleBackColor = true;
            this.buttonReplaceAll.Click += new System.EventHandler(this.buttonReplaceAll_Click);
            // 
            // buttonReplaceSelected
            // 
            resources.ApplyResources(this.buttonReplaceSelected, "buttonReplaceSelected");
            this.buttonReplaceSelected.Name = "buttonReplaceSelected";
            this.buttonReplaceSelected.UseVisualStyleBackColor = true;
            this.buttonReplaceSelected.Click += new System.EventHandler(this.buttonReplace_Click);
            // 
            // buttonPanelFindNext
            // 
            resources.ApplyResources(this.buttonPanelFindNext, "buttonPanelFindNext");
            this.buttonPanelFindNext.AutoEllipsis = true;
            this.buttonPanelFindNext.Name = "buttonPanelFindNext";
            this.buttonPanelFindNext.UseVisualStyleBackColor = true;
            this.buttonPanelFindNext.Click += new System.EventHandler(this.buttonPanelFindNext_Click);
            // 
            // textBoxFind
            // 
            resources.ApplyResources(this.textBoxFind, "textBoxFind");
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.TextChanged += new System.EventHandler(this.textBoxFind_TextChanged);
            this.textBoxFind.Enter += new System.EventHandler(this.textBoxFind_Enter);
            // 
            // textBoxReplace
            // 
            resources.ApplyResources(this.textBoxReplace, "textBoxReplace");
            this.textBoxReplace.Name = "textBoxReplace";
            this.textBoxReplace.Enter += new System.EventHandler(this.textBoxReplace_Enter);
            // 
            // checkBoxMatchCase
            // 
            resources.ApplyResources(this.checkBoxMatchCase, "checkBoxMatchCase");
            this.checkBoxMatchCase.Name = "checkBoxMatchCase";
            this.checkBoxMatchCase.UseVisualStyleBackColor = true;
            // 
            // labelReplaceCount
            // 
            resources.ApplyResources(this.labelReplaceCount, "labelReplaceCount");
            this.labelReplaceCount.BackColor = System.Drawing.Color.Transparent;
            this.labelReplaceCount.Name = "labelReplaceCount";
            // 
            // ReplacePanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelReplaceCount);
            this.Controls.Add(this.checkBoxMatchCase);
            this.Controls.Add(this.textBoxReplace);
            this.Controls.Add(this.textBoxFind);
            this.Controls.Add(label5);
            this.Controls.Add(label6);
            this.Controls.Add(this.buttonReplaceAll);
            this.Controls.Add(this.buttonReplaceSelected);
            this.Controls.Add(this.buttonPanelFindNext);
            this.Name = "ReplacePanel";
            this.Controls.SetChildIndex(this.buttonPanelFindNext, 0);
            this.Controls.SetChildIndex(this.buttonReplaceSelected, 0);
            this.Controls.SetChildIndex(this.buttonReplaceAll, 0);
            this.Controls.SetChildIndex(label6, 0);
            this.Controls.SetChildIndex(label5, 0);
            this.Controls.SetChildIndex(this.textBoxFind, 0);
            this.Controls.SetChildIndex(this.textBoxReplace, 0);
            this.Controls.SetChildIndex(this.checkBoxMatchCase, 0);
            this.Controls.SetChildIndex(this.labelReplaceCount, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonReplaceAll;
        private System.Windows.Forms.Button buttonReplaceSelected;
        private System.Windows.Forms.Button buttonPanelFindNext;
        private HotTrackedTextBox textBoxFind;
        private HotTrackedTextBox textBoxReplace;
        private System.Windows.Forms.CheckBox checkBoxMatchCase;
        private System.Windows.Forms.Label labelReplaceCount;
    }
}
