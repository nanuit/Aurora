using System.ComponentModel;
using System.Windows.Forms;
using Aurora.Math;

namespace Aurora.Forms.CustomDataGrid
{
    public class DataGridViewByteCell : DataGridViewTextBoxCell
    {
        private Bytes.Unit m_ByteUnit = null;

        public DataGridViewByteCell()
        {
            Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public Bytes.Unit ByteUnit
        {
            get { return m_ByteUnit; }
            set
            {
                Bytes.Unit OldValue = m_ByteUnit;
                m_ByteUnit = value;
                if (m_ByteUnit != null && OldValue != m_ByteUnit)
                {
                    Style.Format = "#,#";
                    Style.Format = m_ByteUnit.Format;
                }
            }
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (m_ByteUnit == null)
                return (((DataGridViewByteColumn) OwningColumn).ByteUnit.ComputeBytesAndFormat((long) value));
            else
                return (m_ByteUnit.ComputeBytesAndFormat((long) value));
        }
    }
}
