using System;
using System.Windows.Forms;

namespace Aurora.Forms.CustomDataGrid
{
    public partial class frmDataInput : Form
    {
        private readonly ColumnDataDef m_DataDef;

        public frmDataInput(ColumnDataDef ColumnData)
        {
            InitializeComponent();
            m_DataDef = ColumnData;
        }

        private void Apply(object sender, EventArgs e)
        {
            this.Tag = txtValue.Text;
            this.Close();
        }

        private void frmDataInput_Load(object sender, EventArgs e)
        {
            switch (m_DataDef.DataType)
            {
                case ColumnDataType.InputValue:
                    grbOU.Text = "Input Value for " + m_DataDef.ColumnName;
                    break;
            }
            Text = grbOU.Text + ".";
            txtValue.Focus();
        }

        private void frmDataInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
                e.Cancel = (Tag == null);
        }
    }
}
