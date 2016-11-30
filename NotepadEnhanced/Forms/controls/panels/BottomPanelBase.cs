using System.Windows.Forms;

namespace NotepadEnhanced.Forms
{
    /// <summary>
    /// Represents a panel to be docked bottom.
    /// </summary>
    public partial class BottomPanelBase : DockedPanel
    {
        protected BottomPanelBase()
        {
            InitializeComponent();
            base.Dock = DockStyle.Bottom;
        }
    }
}