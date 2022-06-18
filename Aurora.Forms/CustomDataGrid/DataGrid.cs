using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Aurora.Forms.CustomDataGrid
{
    /// <summary>
    ///     Type Datatable for defaulthandling of Comboboxcolumns to access standard definition
    ///     with "ID" Field for the desired Indexnumber and "Text" for the description to be shown in the
    ///     CustomDataGridComboBoxColumn
    /// </summary>
    public class ComboTypes : DataTable
    {
        public ComboTypes(object[][] Entries)
        {
            DataColumn column = new DataColumn("Index", typeof (int));
            column.AllowDBNull = true;
            Columns.Add(column);
            column = new DataColumn("Text", typeof (String));
            column.AllowDBNull = false;
            Columns.Add(column);
            foreach (object[] Entry in Entries)
            {
                Rows.Add(Entry);
            }
        }
    }

    public class DataGrid
    {
        #region MiscMethods

        /// <summary>
        ///     retreive the rows from the actuall selected cells when there is no complete Row selected
        /// </summary>
        /// <param name="Grid">Grid to get the selected rows from</param>
        /// <returns></returns>
        public static List<DataGridViewRow> GetSelectedRowsFromCells(DataGridView Grid)
        {
            List<DataGridViewRow> AllSelectedRows = new List<DataGridViewRow>();
            foreach (DataGridViewCell Cell in Grid.SelectedCells)
                if (!AllSelectedRows.Contains(Cell.OwningRow))
                    AllSelectedRows.Add(Cell.OwningRow);
            return (AllSelectedRows);
        }

        #endregion

        #region Column handling

        #region DataGridViewByteColumn

        /// <summary>
        ///     Create a DataGridViewByteColumn column in for the DataGridView
        /// </summary>
        /// <param name="DataName">Name of the corresponding data field for this new column</param>
        /// <param name="HeaderName">Name to be displayed in the column header</param>
        /// <param name="ReadOnly">ReadOnlyflag for the new column</param>
        /// <returns>the created DataGridViewByteColumn</returns>
        public static DataGridViewByteColumn CreateNumericColumn(String DataName, String HeaderName, bool ReadOnly)
        {
            DataGridViewByteColumn dataGridColumn = new DataGridViewByteColumn();
            dataGridColumn.DataPropertyName = DataName;
            dataGridColumn.Name = HeaderName;
            dataGridColumn.HeaderText = HeaderName;
            dataGridColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridColumn.Width = 50;
            dataGridColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            return (dataGridColumn);
        }

        #endregion

        #region DataGridViewCheckBoxColumn

        /// <summary>
        ///     Create a DataGridViewCheckBoxColumn column in for the DataGridView
        /// </summary>
        /// <param name="DataName">Name of the corresponding data field for this new column</param>
        /// <param name="HeaderName">Name to be displayed in the column header</param>
        /// <param name="ReadOnly">ReadOnlyflag for the new column</param>
        /// <returns>the created DataGridViewCheckBoxColumn</returns>
        public static DataGridViewCheckBoxColumn CreateCheckBoxColumn(String DataName, String HeaderName, bool ReadOnly)
        {
            DataGridViewCheckBoxColumn dataGridColumn = new DataGridViewCheckBoxColumn();
            dataGridColumn.DataPropertyName = DataName;
            dataGridColumn.Name = HeaderName;
            dataGridColumn.HeaderText = HeaderName;
            dataGridColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridColumn.Width = 50;
            return (dataGridColumn);
        }

        #endregion

        #region DataGridViewColumn

        /// <summary>
        ///     Create a DataGridViewColumn column for the DataGridView
        /// </summary>
        /// <param name="DataName">Name of the corresponding data field for this new column</param>
        /// <param name="HeaderName">Name to be displayed in the column header</param>
        /// <param name="ReadOnly">ReadOnlyflag for the new column</param>
        /// <returns>DataGridViewColumn with DataGridViewTextBoxCell as cell template</returns>
        public static DataGridViewColumn CreateGridViewColumn(String DataName, String HeaderName, bool ReadOnly)
        {
            DataGridViewColumn dataGridColumn = new DataGridViewColumn();
            dataGridColumn.Name = HeaderName;
            dataGridColumn.DataPropertyName = DataName;
            dataGridColumn.HeaderText = HeaderName;
            dataGridColumn.ReadOnly = ReadOnly;
            dataGridColumn.CellTemplate = new DataGridViewTextBoxCell();
            dataGridColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            return (dataGridColumn);
        }

        #endregion

        #region CustomDataGridComboBoxColumn

        /// <summary>
        ///     Create a CustomDataGridComboBoxColumn column
        /// </summary>
        /// <param name="DataName">Name of the corresponding data field for this new column</param>
        /// <param name="HeaderName">Name to be displayed in the column header</param>
        /// <param name="ReadOnly">ReadOnlyflag for the new column</param>
        /// <param name="Values">DataTable containing the standard IDTags for the entries in the combobox</param>
        /// <returns>CustomDataGridComboBoxColumn</returns>
        public static CustomDataGridComboBoxColumn CreateComboBoxColumn(String DataName, String HeaderName, bool ReadOnly, DataTable Values)
        {
            return (CreateComboBoxColumn(DataName, HeaderName, ReadOnly, Values, "Index", "Text"));
        }

        /// <summary>
        ///     Create a CustomDataGridComboBoxColumn column for the DataGridView
        /// </summary>
        /// <param name="DataName">Name of the corresponding data field for this new column</param>
        /// <param name="HeaderName">Name to be displayed in the column header</param>
        /// <param name="ReadOnly">ReadOnlyflag for the new column</param>
        /// <param name="object">object containing the values used as comboboxentries</param>
        /// <param name="IndexName">index field within the Values object</param>
        /// <param name="ValueName">value field within the Values object</param>
        /// <returns>CustomDataGridComboBoxColumn</returns>
        public static CustomDataGridComboBoxColumn CreateComboBoxColumn(String DataName, String HeaderName, bool ReadOnly, object Values, String IndexName, String ValueName)
        {
            CustomDataGridComboBoxColumn comboboxColumn = new CustomDataGridComboBoxColumn();
            comboboxColumn.Name = HeaderName;
            comboboxColumn.DataPropertyName = DataName;
            comboboxColumn.HeaderText = HeaderName;
            comboboxColumn.DropDownWidth = 160;
            comboboxColumn.Width = 90;
            comboboxColumn.MaxDropDownItems = 3;
            comboboxColumn.FlatStyle = FlatStyle.Flat;
            comboboxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            comboboxColumn.ValueMember = IndexName;
            comboboxColumn.DisplayMember = ValueName;
            comboboxColumn.ReadOnly = ReadOnly;
            comboboxColumn.DataSource = Values;
            return (comboboxColumn);
        }

        #endregion

        #region DataGridEnumComboBoxColumn

        /// <summary>
        ///     Create a DataGridEnumComboBoxColumn column for the DataGridView
        /// </summary>
        /// <param name="DataName">Name of the corresponding data field for this new column</param>
        /// <param name="HeaderName">Name to be displayed in the column header</param>
        /// <param name="ReadOnly">ReadOnlyflag for the new column</param>
        /// <returns>DataGridEnumComboBoxColumn</returns>
        public static DataGridEnumComboBoxColumn<T> CreateEnumComboBoxColumn<T>(String DataName, String HeaderName, bool ReadOnly)
        {
            DataGridEnumComboBoxColumn<T> comboboxColumn = new DataGridEnumComboBoxColumn<T>();
            comboboxColumn.Name = HeaderName;
            comboboxColumn.DataPropertyName = DataName;
            comboboxColumn.HeaderText = HeaderName;
            comboboxColumn.DropDownWidth = 160;
            comboboxColumn.Width = 90;
            comboboxColumn.MaxDropDownItems = 3;
            comboboxColumn.FlatStyle = FlatStyle.Flat;
            comboboxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            comboboxColumn.ReadOnly = ReadOnly;
            comboboxColumn.DataSource = EnumComboBox<T>.Enumerations;
            return (comboboxColumn);
        }

        #endregion

        #endregion
    }
}
