using System.Windows.Forms;

namespace Aurora.Forms.CustomDataGrid
{
    public class CustomDataGridComboBoxColumn : DataGridViewComboBoxColumn
    {
        public CustomDataGridComboBoxColumn()
        {
        }

        public override string ToString()
        {
            return (HeaderText ?? "ERR");
        }
    }
}
