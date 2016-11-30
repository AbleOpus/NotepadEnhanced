using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using NotepadEnhanced.Refactexing;

namespace NotepadEnhanced.Forms
{
    /// <summary>
    /// Presents regex refactoring functionality.
    /// </summary>
    public partial class RefactexPanel : UserControl
    {
        /// <summary>
        /// Gets or sets the currently displayed <see cref="Refactex"/>.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Refactex Refactex
        {
            get
            {
                return new Refactex(textBoxName.Text, textBoxDescription.Text, textBoxPattern.Text,
                    textBoxReplacement.Text, regexOptionsPicker.Options);
            }
            set
            {
                if (value == null)
                {
                    ClearInput();
                    return;
                }

                textBoxDescription.Text = value.Description;
                textBoxName.Text = value.Name;
                regexOptionsPicker.Options = value.Options;
                textBoxPattern.Text = value.Pattern;
                textBoxReplacement.Text = value.Replacement;
            }
        }

        private bool submittable;
        /// <summary>
        /// Gets whether there is enough info for this input to be submitted
        /// </summary>
        [Browsable(false)]
        public bool Submittable
        {
            get { return submittable; }
            private set
            {
                if (value == submittable) return;
                submittable = value;
                SubmittableChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Occurs when the value of the <see cref="Submittable"/> property changes.
        /// </summary>
        [Description("Occurs when the value of the Submittable property changes.")]
        public event EventHandler SubmittableChanged = delegate { };

        /// <summary>
        /// Initializes a new instance of the <see cref="RefactexPanel"/>.
        /// </summary>
        public RefactexPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Resets all controls to their original state
        /// </summary>
        public void ClearInput()
        {
            foreach (var textBox in Controls.OfType<TextBox>())
                textBox.Clear();

            regexOptionsPicker.UncheckAll();
        }

        private void MandatoryStringInput_TextChanged(object sender, EventArgs e)
        {
            Submittable = textBoxName.TextLength > 0 && textBoxPattern.TextLength > 0;
        }
    }
}
