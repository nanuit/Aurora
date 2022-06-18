using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace Aurora.Forms
{
    public partial class ColumnSortListView : ListView
    {
        public ColumnSortListView()
        {
            this.ColumnClick += new ColumnClickEventHandler(this.ColumnClickEvent);
            this.ListViewItemSorter = new ListViewColumnComparer(this, 1);
            this.View = View.Details;
        }

        [Description(@"Index of the column the sort is executed for")]
        public int SortColumn { get; set; }

        private void ColumnClickEvent(object sender, ColumnClickEventArgs e)
        {
            ((ListViewColumnComparer) this.ListViewItemSorter).Col = e.Column;
            if (this.Sorting != SortOrder.Ascending)
                this.Sorting = SortOrder.Ascending;
            else
                this.Sorting = SortOrder.Descending;
        }

        private class ListViewColumnComparer : IComparer
        {
            private int m_SortColumn;
            private readonly ListView m_lvToSort;

            public ListViewColumnComparer(ListView ToSort)
                : this(ToSort, 0)
            {
            }

            public ListViewColumnComparer(ListView ToSort, int column)
            {
                m_SortColumn = column;
                m_lvToSort = ToSort;
            }

            public int Col
            {
                set { m_SortColumn = value; }
            }

            public int Compare(object x, object y)
            {
                ListViewItem First = (ListViewItem) x;
                ListViewItem Second = (ListViewItem) y;
                int ReturnValue = 0;

                try
                {
                    if (m_SortColumn >= First.SubItems.Count || m_SortColumn >= Second.SubItems.Count)
                        ReturnValue = First.SubItems.Count - Second.SubItems.Count;
                    else
                        ReturnValue = String.Compare(First.SubItems[m_SortColumn].Text, Second.SubItems[m_SortColumn].Text);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception: " + ex.ToString());
                }
                if (m_lvToSort.Sorting == SortOrder.Ascending)
                    return (ReturnValue);
                else
                    return (ReturnValue*-1);
            }
        }
    }
}
