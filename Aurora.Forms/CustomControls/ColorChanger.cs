using System;
using System.Drawing;
using System.Windows.Forms;

namespace Aurora.Forms.CustomControls
{
    public partial class ColorChanger : UserControl
    {
        private Color m_Color;

        public ColorChanger()
        {
            InitializeComponent();
        }

        public Color Color
        {
            get { return m_Color; }
            set { picColor.BackColor = m_Color = value; }
        }

        public event EventHandler ColorChanged;

        protected virtual void OnColorChange()
        {
            if (ColorChanged != null)
                ColorChanged(this, null);
        }

        private void Color_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.AllowFullOpen = true;
            color.Color = Color;
            color.AnyColor = true;
            DialogResult result = color.ShowDialog();
            if (result == DialogResult.OK)
            {
                Color = color.Color;
                OnColorChange();
            }
        }
    }
}
