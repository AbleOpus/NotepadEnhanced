using System.ComponentModel;
using System.Windows.Forms;
using NotepadEnhanced.Refactexing;

namespace NotepadEnhanced.Forms
{
    /// <summary>
    /// A Form for editing <see cref="Refactex"/>es.
    /// </summary>
    public partial class EditRefactexForm : Form
    {
        /// <summary>
        /// Gets the Refactex that has been edited.
        /// </summary>
        [Browsable(false)]
        public Refactex Refactex
        {
            get { return refactexPanel.Refactex; }
        }

        public EditRefactexForm(Refactex refactex)
        {
            InitializeComponent();
            refactexPanel.Refactex = refactex;
        }

        private void refactexPanel_SubmittableChanged(object sender, System.EventArgs e)
        {
            buttonAccept.Enabled = refactexPanel.Submittable;
        }
    }
}
