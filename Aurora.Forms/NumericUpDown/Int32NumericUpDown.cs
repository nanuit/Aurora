using System;

namespace Aurora.Forms.NumericUpDown
{
    public class Int32NumericUpDown : System.Windows.Forms.NumericUpDown
    {
        public Int32 IntValue
        {
            get { return (Convert.ToInt32(this.Value)); }
            set { this.Value = Convert.ToDecimal(value); }
        }
    }
}
