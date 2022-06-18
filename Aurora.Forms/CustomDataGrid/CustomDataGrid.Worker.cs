using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Aurora.Forms.CustomDataGrid
{
    partial class CustomDataGrid
    {
        protected BackgroundWorker ContextMenuWorker;
        protected BackgroundWorker GetDataWorker;
        protected BackgroundWorker SaveDataWorker;

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ContextMenuWorker = new BackgroundWorker();
            GetDataWorker = new BackgroundWorker();
            SaveDataWorker = new BackgroundWorker();
            // 
            // Grid
            // 
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dock = DockStyle.Fill;
            this.Location = new Point(0, 0);
            this.Name = "CustomDataGrid";
            this.Size = new Size(351, 354);
            this.TabIndex = 0;
            // 
            // ContextMenuWorker
            // 
            ContextMenuWorker.DoWork += new DoWorkEventHandler(this.HandleContextMenuAction);
            ContextMenuWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.ContextMenuWorker_RunWorkerCompleted);
            GetDataWorker.DoWork += new DoWorkEventHandler(this.GetDataAsync);
            GetDataWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.DataRetrieved);
            SaveDataWorker.DoWork += new DoWorkEventHandler(this.SaveDataAsync);
            SaveDataWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.DataSaved);
            this.Size = new Size(351, 354);
            this.ResumeLayout(false);
        }

        public void LaunchDataRetrieval(object RetrievalData)
        {
            GetDataWorker.RunWorkerAsync(RetrievalData);
        }

        public void LaunchDataSaving(object RetrievalData)
        {
            SaveDataWorker.RunWorkerAsync(RetrievalData);
        }

        #region ContextMenuEvents

        /// <summary>
        ///     this Method is called when a ContextMenu has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void HandleContextMenuAction(object sender, DoWorkEventArgs e)
        {
            ToolStripDropDownItem Item = e.Argument as ToolStripDropDownItem;
            ColumnDataDef ColumnData = Item.Tag as ColumnDataDef;

            if (ColumnData.DataType == ColumnDataType.FixedValue)
            {
                SetSelectedColumnsValue(ColumnData.ColumnName, ColumnData.Data);
            }
            else
            {
                frmDataInput DataIn = new frmDataInput(ColumnData);
                DataIn.Icon = Misc.GetParentForm(this).Icon;
                if (DataIn.ShowDialog() == DialogResult.OK)
                {
                    switch (ColumnData.DataType)
                    {
                        case ColumnDataType.InputValue:
                            SetSelectedColumnsValue(ColumnData.ColumnName, DataIn.Tag);
                            break;
                    }
                }
            }
        }

        /// <summary>
        ///     This Mezthod is called when the Async ContextMenuAction has completed
        /// </summary>
        /// <param name="sender">Standard</param>
        /// <param name="e">Standard</param>
        protected virtual void ContextMenuWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        /// <summary>
        ///     For all selected rows in the DataGridView the field in the column identified by the ColumnName is set to Value
        /// </summary>
        /// <param name="ColumnName">Column to be used</param>
        /// <param name="Value">Value to be set</param>
        protected void SetSelectedColumnsValue(String ColumnName, object Value)
        {
            this.UIThread(delegate
                          {
                              try
                              {
                                  foreach (DataGridViewCell Cell in SelectedCells)
                                  {
                                      if (Columns[ColumnName].Index == Cell.ColumnIndex)
                                          Cell.Value = Value;
                                  }
                              }
                              catch (Exception ex)
                              {
                                  Debug.WriteLine("SetSelectedColumnsValue exception: " + ex.ToString());
                              }
                          });
        }

        #endregion

        #region GetData Events

        /// <summary>
        ///     this Method handles the data retrieval when the FillGrid Method is called
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e"></param>
        protected virtual void GetDataAsync(object sender, DoWorkEventArgs e)
        {
        }

        /// <summary>
        ///     This Method is called when the Async ContextMenuAction has completed
        /// </summary>
        /// <param name="sender">Standard</param>
        /// <param name="e">Standard</param>
        protected virtual void DataRetrieved(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        #endregion

        #region SaveData Events

        /// <summary>
        ///     this Method handles the data storage when the FillGrid Method is called
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e"></param>
        protected virtual void SaveDataAsync(object sender, DoWorkEventArgs e)
        {
        }

        /// <summary>
        ///     This Method is called when the Async ContextMenuAction has completed
        /// </summary>
        /// <param name="sender">Standard</param>
        /// <param name="e">Standard</param>
        protected virtual void DataSaved(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        #endregion
    }
}
