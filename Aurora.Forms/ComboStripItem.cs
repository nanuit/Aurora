using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Aurora.Forms
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.MenuStrip |
                                       ToolStripItemDesignerAvailability.ContextMenuStrip |
                                       ToolStripItemDesignerAvailability.StatusStrip)]
    public class ComboStripItem : ToolStripControlHost
    {
        #region To Life and Die in Starlight

        public ComboStripItem() : base(new ComboBox())
        {
            this.Box = this.Control as ComboBox;
        }

        #endregion

        #region Properties

        public ComboBox Box { get; set; }

        #endregion
    }
}
