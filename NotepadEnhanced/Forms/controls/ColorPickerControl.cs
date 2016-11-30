using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NotepadEnhanced.Forms
{
    /// <summary>
    /// Represents a way of opening a <see cref="ColorDialog"/> 
    /// and showing the currently picked <see cref="Color"/>.
    /// </summary>
    [DefaultEvent("ColorPicked")]
    public partial class ColorPickerControl : UserControl
    {
        /// <summary>
        /// Gets or sets the color that is currently selected.
        /// </summary>
        [Browsable(false)]
        public Color PickedColor
        {
            get { return panelBackColor.BackColor; }
            set { panelBackColor.BackColor = value; }
        }

        /// <summary>
        /// Gets or sets the custom colors that will be displayed for alternative picking.
        /// </summary>
        [Browsable(false)]
        public Color[] CustomColors { get; set; }

        /// <summary>
        /// Gets or sets the text to display on the control.
        /// </summary>
        [Localizable(true)]
        [Description("The text to display on the control.")]
        [Category("Appearance")]
        public string Caption
        {
            get { return labelCaption.Text; }
            set { labelCaption.Text = value; }
        }

        /// <summary>
        /// Occurs when a new color is picked by the ColorDialog.
        /// </summary>
        [Description("Occurs when a new color is picked by the ColorDialog.")]
        public event EventHandler ColorPicked = delegate { };

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorPickerControl"/> class.
        /// </summary>
        public ColorPickerControl()
        {
            InitializeComponent();
        }

        private void panelBackColor_Click(object sender, EventArgs e)
        {
            using (var dialogColor = new ColorDialog())
            {
                dialogColor.Color = PickedColor;
                dialogColor.FullOpen = true;

                if (CustomColors != null && CustomColors.Length > 0)
                {
                    // Converts the custom colors to there int representations, so a color dialog can use them
                    dialogColor.CustomColors = CustomColors.Select(color => color.ToRgb()).ToArray();
                }

                if (dialogColor.ShowDialog() == DialogResult.OK && PickedColor != dialogColor.Color)
                {
                    PickedColor = dialogColor.Color;
                    ColorPicked(this, EventArgs.Empty);
                }
            }
        }

        private void panelBackColor_MouseEnter(object sender, EventArgs e)
        {
            Font = Font.SetStyle(FontStyle.Underline);
        }

        private void panelBackColor_MouseLeave(object sender, EventArgs e)
        {
            Font = Font.SetStyle(FontStyle.Regular);
        }
    }
}
