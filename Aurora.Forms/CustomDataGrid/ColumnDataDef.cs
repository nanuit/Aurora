using System;
using System.Windows.Forms;

namespace Aurora.Forms.CustomDataGrid
{
    public enum ColumnDataType
    {
        FixedValue,
        InputValue,
        IncrementBoxNumber,
        IncrementSynergy
    }

    public class ColumnDataDef
    {
        #region Properties

        public DataGridViewColumn Column;
        public String ColumnName { get; set; }
        public ColumnDataType DataType { get; set; }
        public object Data { get; set; }

        #endregion

        #region Constructors

        public ColumnDataDef(DataGridViewColumn Column, String ColumnName, ColumnDataType DataType, object Data)
        {
            this.Column = Column;
            this.ColumnName = ColumnName;
            this.DataType = DataType;
            this.Data = Data;
        }

        public ColumnDataDef()
        {
        }

        #endregion
    }
}
