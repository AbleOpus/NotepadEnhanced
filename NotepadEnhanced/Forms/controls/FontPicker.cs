using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NotepadEnhanced.Forms
{
    /// <summary>
    /// Represents a control to choose a <see cref="Font"/>.
    /// </summary>
    [DefaultEvent("SelectedFontChanged")]
    class FontPicker : Control
    {
        private readonly Button buttonPick = new Button();
        private readonly Label labelCaption = new Label();

        #region Properties
        /// <summary>
        /// Gets or sets whether to preview the selected <see cref="Font"/> in the caption.
        /// </summary>
        [DefaultValue(true)]
        [Category("Appearance")]
        [Description("Whether to preview the selected Font in the caption.")]
        public bool PreviewFont { get; set; }

        /// <summary>
        /// Gets or sets whether to show effects in the <see cref="FontDialog"/>.
        /// </summary>
        [DefaultValue(false)]
        [Category("Appearance")]
        [Description("Whether to show effects in the FontDialog.")]
        public bool ShowEffects { get; set; }

        private Font selectedFont;
        /// <summary>
        /// Gets or sets the currently selected font.
        /// </summary>
        [DefaultValue(null)]
        [Category("Input")]
        [Description("The currently selected font.")]
        public Font SelectedFont
        {
            get { return selectedFont; }
            set
            {
                if (value != selectedFont)
                {
                    if (value != null && PreviewFont)
                        labelCaption.Font = value;

                    selectedFont = value;
                    SelectedFontChanged(this, EventArgs.Empty);
                }

                UpdateCaption();
            }
        }

        private string noFontText = "None";
        /// <summary>
        /// Gets or sets the text to show when the Selected Font is null.
        /// </summary>
        [Localizable(true)]
        [DefaultValue("None")]
        [Category("Behavior")]
        [Description("The text to show when the Selected Font is null.")]
        public string NoFontText
        {
            get { return noFontText; }
            set { noFontText = value; }
        }
        #endregion

        /// <summary>
        /// Occurs when the value of the <see cref="SelectedFont"/> property is changed.
        /// </summary>
        [Description("Occurs when the value of the SelectedFont property is changed.")]
        public event EventHandler SelectedFontChanged = delegate { };

        /// <summary>
        /// Initializes a new instance of the <see cref="FontPicker"/> class.
        /// </summary>
        public FontPicker()
        {
            PreviewFont = true;
            labelCaption.Dock = DockStyle.Fill;
            labelCaption.Text = string.Empty;
            labelCaption.TextAlign = ContentAlignment.MiddleCenter;
            labelCaption.BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(labelCaption);
            buttonPick.Text = "...";
            buttonPick.Width = 50;
            buttonPick.Dock = DockStyle.Right;
            buttonPick.Click += buttonPick_Click;
            Controls.Add(buttonPick);
            SelectedFont = null;
        }

        private void UpdateCaption()
        {
            if (SelectedFont == null)
            {
                labelCaption.Text = "None";
                return;
            }

            const string FORMAT = "{0} {1} {2}";
            labelCaption.Text = String.Format(FORMAT,
                SelectedFont.Name, SelectedFont.Size, SelectedFont.Style);
        }

        protected override Size DefaultSize
        {
            get { return new Size(200, 23); }
        }

        private void buttonPick_Click(object sender, EventArgs e)
        {
            using (var dialogFont = new FontDialog())
            {
                dialogFont.ShowEffects = ShowEffects;
                dialogFont.Font = labelCaption.Font;

                if (dialogFont.ShowDialog() == DialogResult.OK)
                {
                    SelectedFont = dialogFont.Font;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            buttonPick.Dispose();
            labelCaption.Dispose();
        }
    }
}
