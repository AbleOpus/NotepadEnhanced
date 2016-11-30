namespace NotepadEnhanced.Forms
{
    partial class RefactexPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RefactexPanel));
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxReplacement = new System.Windows.Forms.TextBox();
            this.textBoxPattern = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.regexOptionsPicker = new NotepadEnhanced.Forms.RegexOptionsCheckedListBox();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // textBoxDescription
            // 
            resources.ApplyResources(this.textBoxDescription, "textBoxDescription");
            this.textBoxDescription.Name = "textBoxDescription";
            // 
            // textBoxReplacement
            // 
            resources.ApplyResources(this.textBoxReplacement, "textBoxReplacement");
            this.textBoxReplacement.Name = "textBoxReplacement";
            // 
            // textBoxPattern
            // 
            resources.ApplyResources(this.textBoxPattern, "textBoxPattern");
            this.textBoxPattern.Name = "textBoxPattern";
            this.textBoxPattern.TextChanged += new System.EventHandler(this.MandatoryStringInput_TextChanged);
            // 
            // textBoxName
            // 
            resources.ApplyResources(this.textBoxName, "textBoxName");
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.TextChanged += new System.EventHandler(this.MandatoryStringInput_TextChanged);
            // 
            // regexOptionsPicker
            // 
            resources.ApplyResources(this.regexOptionsPicker, "regexOptionsPicker");
            this.regexOptionsPicker.CheckOnClick = true;
            this.regexOptionsPicker.FormattingEnabled = true;
            this.regexOptionsPicker.Items.AddRange(new object[] {
            ((object)(resources.GetObject("regexOptionsPicker.Items"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items1"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items2"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items3"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items4"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items5"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items6"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items7"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items8"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items9"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items10"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items11"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items12"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items13"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items14"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items15"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items16"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items17"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items18"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items19"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items20"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items21"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items22"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items23"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items24"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items25"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items26"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items27"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items28"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items29"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items30"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items31"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items32"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items33"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items34"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items35"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items36"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items37"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items38"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items39"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items40"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items41"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items42"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items43"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items44"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items45"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items46"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items47"))),
            ((object)(resources.GetObject("regexOptionsPicker.Items48")))});
            this.regexOptionsPicker.Name = "regexOptionsPicker";
            this.regexOptionsPicker.Options = System.Text.RegularExpressions.RegexOptions.None;
            // 
            // RefactexPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(label5);
            this.Controls.Add(this.regexOptionsPicker);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxReplacement);
            this.Controls.Add(label4);
            this.Controls.Add(this.textBoxPattern);
            this.Controls.Add(label3);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Name = "RefactexPanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RegexOptionsCheckedListBox regexOptionsPicker;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxReplacement;
        private System.Windows.Forms.TextBox textBoxPattern;
        private System.Windows.Forms.TextBox textBoxName;
    }
}
