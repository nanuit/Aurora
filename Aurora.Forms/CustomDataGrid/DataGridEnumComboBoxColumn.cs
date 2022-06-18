using System.Windows.Forms;

namespace Aurora.Forms.CustomDataGrid
{
    public class DataGridEnumComboBoxColumn<T> : DataGridViewComboBoxColumn
    {
        public DataGridEnumComboBoxColumn()
        {
            ValueMember = "Index";
            DisplayMember = "Text";
        }

        public override string ToString()
        {
            return (HeaderText ?? "ERR");
        }
    }
}
