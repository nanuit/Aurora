using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace Aurora.Forms.CustomDataGrid
{
    public partial class CustomDataGrid : DataGridView
    {
        #region Private Members

        /// <summary>
        ///     Indicates whether the SetStatusInfo Method has been called
        /// </summary>
        private bool m_StatusInfo;

        #endregion

        #region Constructors

        public CustomDataGrid()
        {
            InitializeComponent();

            CellEndEdit += new DataGridViewCellEventHandler(this.CellEndEditEvent);
            DataError += new DataGridViewDataErrorEventHandler(DataErrorEvent);
            ColumnAdded += new DataGridViewColumnEventHandler(ColumnAddedEvent);
        }

        #endregion

        /// <summary>
        ///     this method should be overwritten when innheriting the class
        /// </summary>
        protected virtual void SetColumns()
        {
        }

        #region Public Methods

        /// <summary>
        ///     Register the Events for StatusInfohandling
        /// </summary>
        public void SetStatusInfo()
        {
            if (m_StatusInfo)
                return;

            m_StatusInfo = true;
            DataBindingComplete += new DataGridViewBindingCompleteEventHandler(DataBindingCompletedEvent);
            SelectionChanged += new EventHandler(SelectionChangedEvent);
            DataSourceChanged += new EventHandler(DataSourceChangedEvent);
        }

        /// <summary>
        ///     Set the Grids data source with the newly created binding. The bindings datasource is set with the given datatable
        ///     If the Reload configData is true the Columns will not be Changed because they should already be correct
        /// </summary>
        /// <param name="Data">DataTable to be assigned as the new bindings Datasource</param>
        public virtual void FillGrid(DataTable Data)
        {
            try
            {
                if (Data == null)
                    return;
                else
                {
                    BindingSource DataBinding = new BindingSource();
                    DataBinding.DataSource = Data;
                    DataSource = DataBinding;
                }
                if (Columns.Count == 0)
                    SetColumns();
                AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("FillGrid failed: " + ex.Message);
                Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        ///     Retrieve the Datatable from the
        /// </summary>
        /// <returns></returns>
        public DataTable GetDatafromGrid()
        {
            DataTable Data = null;
            BindingSource DataBinding = DataSource as BindingSource;
            if (DataBinding != null)
                Data = DataBinding.DataSource as DataTable;
            return (Data);
        }

        /// <summary>
        ///     Retrieve the changed rows from the Grids Datasource Datatable
        /// </summary>
        /// <returns></returns>
        public DataTable GetChanges()
        {
            BindingSource DataBinding = DataSource as BindingSource;
            DataTable Data = DataBinding.DataSource as DataTable;
            BindingContext[DataSource].EndCurrentEdit();
            if (Data.GetChanges() != null)
                return (Data.GetChanges());
            else
                return (null);
        }

        #endregion

        #region Column handling

        #region DataGridViewByteColumn

        /// <summary>
        ///     Insert a DataGridViewByteColumn column into the DataGridView at the given index
        /// </summary>
        /// <param name="DataName">Name of the corresponding data field for this new column</param>
        /// <param name="HeaderName">Name to be displayed in the column header</param>
        /// <param name="ReadOnly">ReadOnlyflag for the new column</param>
        /// <returns>DataGridViewByteColumn</returns>
        public DataGridViewByteColumn InsertNumericColumn(String DataName, String HeaderName, bool ReadOnly)
        {
            DataGridViewByteColumn gridviewColumn = DataGrid.CreateNumericColumn(DataName, HeaderName, ReadOnly);
            Columns.Add(gridviewColumn);
            return (gridviewColumn);
        }

        /// <summary>
        ///     Insert a DataGridViewByteColumn column into the DataGridView at the given index
        /// </summary>
        /// <param name="Index">Index at which the new Column should be inserted</param>
        /// <param name="DataName">Name of the corresponding data field for this new column</param>
        /// <param name="HeaderName">Name to be displayed in the column header</param>
        /// <param name="ReadOnly">ReadOnlyflag for the new column</param>
        /// <returns>DataGridViewByteColumn</returns>
        public DataGridViewByteColumn InsertNumericColumn(int Index, String DataName, String HeaderName, bool ReadOnly)
        {
            DataGridViewByteColumn gridviewColumn = DataGrid.CreateNumericColumn(DataName, HeaderName, ReadOnly);
            Columns.Insert(Index, gridviewColumn);
            return (gridviewColumn);
        }

        #endregion

        #region DataGridViewCheckBoxColumn

        /// <summary>
        ///     Insert a DataGridViewCheckBoxColumn column into the DataGridView at the given index
        /// </summary>
        /// <param name="DataName">Name of the corresponding data field for this new column</param>
        /// <param name="HeaderName">Name to be displayed in the column header</param>
        /// <param name="ReadOnly">ReadOnlyflag for the new column</param>
        /// <returns>DataGridViewCheckBoxColumn</returns>
        public DataGridViewCheckBoxColumn InsertCheckBoxColumn(String DataName, String HeaderName, bool ReadOnly)
        {
            DataGridViewCheckBoxColumn gridviewColumn = DataGrid.CreateCheckBoxColumn(DataName, HeaderName, ReadOnly);
            Columns.Add(gridviewColumn);
            return (gridviewColumn);
        }

        /// <summary>
        ///     Insert a DataGridViewCheckBoxColumn column into the DataGridView at the given index
        /// </summary>
        /// <param name="Index">Index at which the new Column should be inserted</param>
        /// <param name="DataName">Name of the corresponding data field for this new column</param>
        /// <param name="HeaderName">Name to be displayed in the column header</param>
        /// <param name="ReadOnly">ReadOnlyflag for the new column</param>
        /// <returns>DataGridViewCheckBoxColumn</returns>
        public DataGridViewCheckBoxColumn InsertCheckBoxColumn(int Index, String DataName, String HeaderName, bool ReadOnly)
        {
            DataGridViewCheckBoxColumn gridviewColumn = DataGrid.CreateCheckBoxColumn(DataName, HeaderName, ReadOnly);
            Columns.Insert(Index, gridviewColumn);
            return (gridviewColumn);
        }

        #endregion

        #region DataGridViewColumn

        /// <summary>
        ///     Insert a DataGridViewColumn column into the DataGridView at the given index
        /// </summary>
        /// <param name="Index">Index at which the new Column should be inserted</param>
        /// <param name="DataName">Name of the corresponding data field for this new column</param>
        /// <param name="HeaderName">Name to be displayed in the column header</param>
        /// <param name="ReadOnly">ReadOnlyflag for the new column</param>
        /// <returns>DataGridViewColumn</returns>
        public DataGridViewColumn InsertGridViewColumn(int Index, String DataName, String HeaderName, bool ReadOnly)
        {
            DataGridViewColumn gridviewColumn = DataGrid.CreateGridViewColumn(DataName, HeaderName, ReadOnly);
            Columns.Insert(Index, gridviewColumn);
            return (gridviewColumn);
        }

        /// <summary>
        ///     Add a DataGridViewColumn column to the end of the DataGridView
        /// </summary>
        /// <param name="DataName">Name of the corresponding data field for this new column</param>
        /// <param name="HeaderName">Name to be displayed in the column header</param>
        /// <param name="ReadOnly">ReadOnlyflag for the new column</param>
        /// <returns>DataGridViewColumn</returns>
        public DataGridViewColumn InsertGridViewColumn(String DataName, String HeaderName, bool ReadOnly)
        {
            DataGridViewColumn gridviewColumn = DataGrid.CreateGridViewColumn(DataName, HeaderName, ReadOnly);
            Columns.Add(gridviewColumn);
            return (gridviewColumn);
        }

        #endregion

        #region CustomDataGridComboBoxColumn

        /// <summary>
        ///     Add a CustomDataGridComboBoxColumn column for EnumComboboxes to the end of the DataGridView
        /// </summary>
        /// <param name="DataName">Name of the corresponding data field for this new column</param>
        /// <param name="HeaderName">Name to be displayed in the column header</param>
        /// <param name="ReadOnly">ReadOnlyflag for the new column</param>
        /// <param name="Values">DataTable containing the standard IDTags for the entries in the combobox</param>
        /// <returns>CustomDataGridComboBoxColumn</returns>
        public CustomDataGridComboBoxColumn InsertComboBoxColumn<T>(String DataName, String HeaderName, bool ReadOnly)
        {
            CustomDataGridComboBoxColumn comboboxColumn = DataGrid.CreateComboBoxColumn(DataName, HeaderName, ReadOnly, EnumComboBox<T>.Enumerations, "Index", "Text");
            Columns.Add(comboboxColumn);
            return (comboboxColumn);
        }

        /// <summary>
        ///     Add a CustomDataGridComboBoxColumn column to the end of the DataGridView
        /// </summary>
        /// <param name="DataName">Name of the corresponding data field for this new column</param>
        /// <param name="HeaderName">Name to be displayed in the column header</param>
        /// <param name="ReadOnly">ReadOnlyflag for the new column</param>
        /// <param name="Values">DataTable containing the standard IDTags for the entries in the combobox</param>
        /// <returns>CustomDataGridComboBoxColumn</returns>
        public CustomDataGridComboBoxColumn InsertComboBoxColumn(String DataName, String HeaderName, bool ReadOnly, DataTable Values)
        {
            CustomDataGridComboBoxColumn comboboxColumn = DataGrid.CreateComboBoxColumn(DataName, HeaderName, ReadOnly, Values, "Index", "Text");
            Columns.Add(comboboxColumn);
            return (comboboxColumn);
        }

        /// <summary>
        ///     Add a CustomDataGridComboBoxColumn column to the end of the DataGridView
        /// </summary>
        /// <param name="DataName">Name of the corresponding data field for this new column</param>
        /// <param name="HeaderName">Name to be displayed in the column header</param>
        /// <param name="ReadOnly">ReadOnlyflag for the new column</param>
        /// <param name="object">object containing the values used as combobox entries</param>
        /// <param name="IndexName">index field within the Values object</param>
        /// <param name="ValueName">value field within the Values object</param>
        /// <returns>CustomDataGridComboBoxColumn</returns>
        public CustomDataGridComboBoxColumn InsertComboBoxColumn(String DataName, String HeaderName, bool ReadOnly, object Values, String IndexName, String ValueName)
        {
            CustomDataGridComboBoxColumn comboboxColumn = DataGrid.CreateComboBoxColumn(DataName, HeaderName, ReadOnly, Values, IndexName, ValueName);
            Columns.Add(comboboxColumn);
            return (comboboxColumn);
        }

        /// <summary>
        ///     Insert a CustomDataGridComboBoxColumn column into the DataGridView at the given index
        /// </summary>
        /// <param name="Index">Index at which the new Column should be inserted</param>
        /// <param name="DataName">Name of the corresponding data field for this new column</param>
        /// <param name="HeaderName">Name to be displayed in the column header</param>
        /// <param name="ReadOnly">ReadOnlyflag for the new column</param>
        /// <param name="Values">DataTable containing the standard IDTags for the entries in the combobox</param>
        /// <returns>CustomDataGridComboBoxColumn</returns>
        public CustomDataGridComboBoxColumn InsertComboBoxColumn(int Index, String DataName, String HeaderName, bool ReadOnly, DataTable Values)
        {
            CustomDataGridComboBoxColumn comboboxColumn = DataGrid.CreateComboBoxColumn(DataName, HeaderName, ReadOnly, Values, "Index", "Text");
            Columns.Insert(Index, comboboxColumn);
            return (comboboxColumn);
        }

        /// <summary>
        ///     Insert a CustomDataGridComboBoxColumn column into the DataGridView at the given index
        /// </summary>
        /// <param name="Index">Index at which the new Column should be inserted</param>
        /// <param name="DataName">Name of the corresponding data field for this new column</param>
        /// <param name="HeaderName">Name to be displayed in the column header</param>
        /// <param name="ReadOnly">ReadOnlyflag for the new column</param>
        /// <param name="object">object containing the values used as comboboxentries</param>
        /// <param name="IndexName">index field within the Values object</param>
        /// <param name="ValueName">value field within the Values object</param>
        /// <returns>CustomDataGridComboBoxColumn</returns>
        public CustomDataGridComboBoxColumn InsertComboBoxColumn(int Index, String DataName, String HeaderName, bool ReadOnly, object Values, String IndexName, String ValueName)
        {
            CustomDataGridComboBoxColumn comboboxColumn = DataGrid.CreateComboBoxColumn(DataName, HeaderName, ReadOnly, Values, IndexName, ValueName);
            Columns.Insert(Index, comboboxColumn);
            return (comboboxColumn);
        }

        #endregion

        #region DataGridEnumComboBoxColumn

        /// <summary>
        ///     Add a DataGridEnumComboBoxColumn column for EnumComboboxes to the end of the DataGridView
        /// </summary>
        /// <param name="DataName">Name of the corresponding data field for this new column</param>
        /// <param name="HeaderName">Name to be displayed in the column header</param>
        /// <param name="ReadOnly">ReadOnlyflag for the new column</param>
        /// <param name="Values">DataTable containing the standard IDTags for the entries in the combobox</param>
        /// <returns>DataGridEnumComboBoxColumn</returns>
        public DataGridEnumComboBoxColumn<T> InsertEnumComboBoxColumn<T>(String DataName, String HeaderName, bool ReadOnly)
        {
            DataGridEnumComboBoxColumn<T> comboboxColumn = DataGrid.CreateEnumComboBoxColumn<T>(DataName, HeaderName, ReadOnly);
            Columns.Add(comboboxColumn);
            return (comboboxColumn);
        }

        /// <summary>
        ///     Insert a DataGridEnumComboBoxColumn column into the DataGridView at the given index
        /// </summary>
        /// <param name="Index">Index at which the new Column should be inserted</param>
        /// <param name="DataName">Name of the corresponding data field for this new column</param>
        /// <param name="HeaderName">Name to be displayed in the column header</param>
        /// <param name="ReadOnly">ReadOnlyflag for the new column</param>
        /// <param name="Values">DataTable containing the standard IDTags for the entries in the combobox</param>
        /// <returns>DataGridEnumComboBoxColumn</returns>
        public DataGridEnumComboBoxColumn<T> InsertEnumComboBoxColumn<T>(int Index, String DataName, String HeaderName, bool ReadOnly)
        {
            DataGridEnumComboBoxColumn<T> comboboxColumn = DataGrid.CreateEnumComboBoxColumn<T>(DataName, HeaderName, ReadOnly);
            Columns.Insert(Index, comboboxColumn);
            return (comboboxColumn);
        }

        #endregion

        /// <summary>
        ///     Remove to column with the given Name from the column collection.
        ///     The colmun will only be removed if it exists within the collection
        /// </summary>
        /// <param name="NameToRemove">Name of the column to be removed</param>
        protected void RemoveColumnByName(String NameToRemove)
        {
            if (Columns.Contains(NameToRemove))
                Columns.Remove(NameToRemove);
        }

        /// <summary>
        ///     Set the read Only state of the column with the given name. If the column has an Context menu assigned it will be
        ///     en-/disabled also
        /// </summary>
        /// <param name="ColumnName">Name of the column</param>
        /// <param name="ReadOnly">ReadOnly/enable state of the column/contextmenu</param>
        protected void SetColumnReadOnly(String ColumnName, bool ReadOnly)
        {
            Columns[ColumnName].ReadOnly = ReadOnly;
            if (ReadOnly)
                Columns[ColumnName].ContextMenuStrip = null;
            else
                SetColumnContextMenu(Columns[ColumnName]);
        }

        #endregion

        #region ContextMenu

        /// <summary>
        ///     a contextmenu is created and assigned to the column
        /// </summary>
        /// <param name="e"></param>
        private void SetColumnContextMenu(DataGridViewColumn Column)
        {
            ToolStripMenuItem MenuStrip = new ToolStripMenuItem();
            MenuStrip.Text = Column.HeaderText;
            MenuStrip.Enabled = !Column.ReadOnly;
            if ((Column as DataGridViewComboBoxColumn) != null)
            {
                AddComboBoxColumnContextMenu(MenuStrip, (DataGridViewComboBoxColumn) Column);
            }
            else if ((Column as DataGridViewColumn) != null)
            {
                AddColumnContextMenu(Column, MenuStrip);
            }

            Column.ContextMenuStrip = new ContextMenuStrip();
            Column.ContextMenuStrip.Items.Add(MenuStrip);
        }

        /// <summary>
        ///     Set the menuitem parameters to use for common DataGridColumns
        /// </summary>
        /// <param name="Column">The column the menu is set for</param>
        /// <param name="MenuStrip">Menustrip to set the context menu for</param>
        protected virtual void AddColumnContextMenu(DataGridViewColumn Column, ToolStripMenuItem MenuStrip)
        {
            MenuStrip.Click += new EventHandler(ColumnContextMenuClick);
            MenuStrip.Tag = new ColumnDataDef(Column, MenuStrip.Text, ColumnDataType.InputValue, null);
        }

        /// <summary>
        ///     ComboboxColumn the contextmenu is filled with submenues.
        ///     For every value in the Combobox a menuitem is created. In the Tag field of this menu a KeyValuePair is stored
        ///     containing the Columnheader
        ///     name as Kvp Key and the corresponding value in the datasource for this combovalue as Kvp Value.
        ///     This Kvp is used when the Menu is clicked to identify the columns and the value that should be set for the rows
        /// </summary>
        /// <param name="MenuItemStrip">ContextMenuitem to add the submenues to</param>
        /// <param name="ComboColumn">Column in the grid to create the item for</param>
        private void AddComboBoxColumnContextMenu(ToolStripMenuItem MenuItemStrip, DataGridViewComboBoxColumn ComboColumn)
        {
            if (ComboColumn == null)
                return;
            DataTable Data = ComboColumn.DataSource as DataTable;
            if (Data != null)
            {
                // the Datasource is a DataTable class (the combobox entries are read from the database)
                foreach (DataRow Row in Data.Rows)
                {
                    ToolStripMenuItem ComboMenu = new ToolStripMenuItem();
                    ComboMenu.Text = Row[ComboColumn.DisplayMember].ToString();
                    ComboMenu.Click += new EventHandler(ColumnContextMenuClick);
                    ComboMenu.Tag = new ColumnDataDef(ComboColumn, MenuItemStrip.Text, ColumnDataType.FixedValue, Row.ItemArray[0]);
                    MenuItemStrip.DropDownItems.Add(ComboMenu);
                }
            }
            return;
        }

        /// <summary>
        ///     When a Context menu is clicked by the user the data value represented by the menuitem will be set to all selected
        ///     rows in the Datagrid
        ///     If the Column is a Combobox column ( a keyValuePair is stored in the Tag properties of the column) the previously
        ///     stored value for
        ///     this menu will be set to all selected cells.
        ///     With any other column type a user input is requested and that value then used.
        /// </summary>
        /// <param name="sender">The Menuitem that has been clicked</param>
        /// <param name="e">EventArgs - not used</param>
        private void ColumnContextMenuClick(object sender, EventArgs e)
        {
            ContextMenuWorker.RunWorkerAsync(sender as ToolStripDropDownItem);
        }

        #endregion

        #region Event Methods

        /// <summary>
        ///     when the editmode has ended, the errortext is emptied
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">DataGridViewCellEventArgs</param>
        protected void CellEndEditEvent(object sender, DataGridViewCellEventArgs e)
        {
            Rows[e.RowIndex].ErrorText = String.Empty;
        }

        /// <summary>
        ///     On Format exception the header with an errortext is set as errortext for the column
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">DataGridViewDataErrorEventArgs</param>
        protected void DataErrorEvent(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.GetType() == typeof (FormatException))
                Rows[e.RowIndex].ErrorText =
                    Columns[e.ColumnIndex].Name + " hat einen ungültigen Wert";
        }

        /// <summary>
        ///     When a new Column is added and the Contextmenuflag is set a a ContextMenu is assigned to the grid containing the
        ///     selections
        ///     for multirow Valueset.
        ///     When the Read Only Flag is set all Columns will be set to read only
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">SafeDataGridColumnEventArgs</param>
        private void ColumnAddedEvent(object sender, DataGridViewColumnEventArgs e)
        {
            if (!e.Column.ReadOnly)
                SetColumnContextMenu(e.Column);
        }

        #endregion

        #region DataChangeFlag

        /// <summary>
        ///     This Method is called when the Datasource has been Changed
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        protected virtual void DataSourceChangedEvent(object sender, EventArgs e)
        {
            BindingSource BoundData = DataSource as BindingSource;
            if (BoundData != null && DataSource != null)
            {
                DataTable Table = BoundData.DataSource as DataTable;
                if (Table != null)
                {
                    Table.RowChanged += new DataRowChangeEventHandler(DataTable_RowChanged);
                    DataContentChanged();
                }
            }
        }

        /// <summary>
        ///     This method is called when a row of the assigned DataTable has changed
        /// </summary>
        /// <param name="Sender">Default</param>
        /// <param name="e">Default</param>
        protected virtual void DataTable_RowChanged(object Sender, DataRowChangeEventArgs e)
        {
            DataContentChanged();
        }

        #endregion

        #region StatusInfohandling

        /// <summary>
        ///     When the StatusInfo has been set this method will be called when the Change of DataSource has been completed.
        ///     At this moment a statusinfo can be computed and displayed
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        protected virtual void DataBindingCompletedEvent(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataContentChanged();
        }

        /// <summary>
        ///     When the StatusInfo has been set this method will be called when the selection within the Datagrid has been
        ///     changed.
        ///     At this moment a statusinfo can be computed and displayed
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        protected virtual void SelectionChangedEvent(object sender, EventArgs e)
        {
            DataSelectionChanged();
        }

        /// <summary>
        ///     This method is called whenever the DataContent in the Datagrid have changed
        /// </summary>
        protected virtual void DataContentChanged()
        {
        }

        /// <summary>
        ///     This method is called whenever the selection in the DataGrid has changed
        /// </summary>
        protected virtual void DataSelectionChanged()
        {
        }

        #endregion
    }
}
