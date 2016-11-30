using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using NotepadEnhanced.Refactexing;

namespace NotepadEnhanced.Forms
{
    public partial class AddRefactexForm : Form
    {
        /// <summary>
        /// Gets the Refactexes that are picked for addition.
        /// </summary>
        [Browsable(false)]
        public Stack<Refactex> ToBeAdded { get; private set; }

        public AddRefactexForm()
        {
            InitializeComponent();
            ToBeAdded = new Stack<Refactex>();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ToBeAdded.Push(refactexPanel.Refactex);
            refactexPanel.ClearInput();
        }

        private void refactexPanel_SubmittableChanged(object sender, EventArgs e)
        {
            buttonAdd.Enabled = refactexPanel.Submittable;
        }
    }
}
