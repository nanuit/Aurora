using System.Windows.Forms;
using Aurora.Math;

namespace Aurora.Forms.CustomDataGrid
{
    public class DataGridViewByteColumn : DataGridViewColumn
    {
        public DataGridViewByteColumn()
        {
            DataGridViewByteCell cell = new DataGridViewByteCell();
            cell.ByteUnit = m_ByteUnit;
            CellTemplate = cell;
            SortMode = DataGridViewColumnSortMode.Automatic;
        }

        #region Properties

        protected Bytes.Unit m_ByteUnit = Bytes.GetUnit(Bytes.UnitFactor.Byte, Bytes.MathBase.Decimal);

        public Bytes.Unit ByteUnit
        {
            get { return (m_ByteUnit); }
            set
            {
                if (m_ByteUnit != value)
                {
                    m_ByteUnit = value;

                    using (DataGridViewByteCell cell = CellTemplate as DataGridViewByteCell)
                    {
                        if (cell != null)
                            cell.ByteUnit = m_ByteUnit;
                    }
                    foreach (DataGridViewRow row in DataGridView.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            using (DataGridViewByteCell byteCell = cell as DataGridViewByteCell)
                            {
                                if (byteCell != null && byteCell.ByteUnit != m_ByteUnit)
                                    byteCell.ByteUnit = m_ByteUnit;
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}
