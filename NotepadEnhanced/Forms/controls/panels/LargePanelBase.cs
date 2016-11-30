using System.ComponentModel;
using System.Windows.Forms;

namespace NotepadEnhanced.Forms
{
    public partial class LargePanelBase : DockedPanel
    {
        /// <summary>
        /// Gets or sets the name of the panel which will be displayed
        /// at the very top in a subtle green font.
        /// </summary>
        [Description("The caption for this panel.")]
        [Localizable(true)]
        public string PanelName
        {
            get { return labelPanelName.Text; }
            set { labelPanelName.Text = value; }
        }

        protected LargePanelBase()
        {
            InitializeComponent();
            base.Dock = DockStyle.Right;
        }
    }
}
