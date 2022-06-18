using System;

namespace Aurora.Forms.NumericUpDown
{
    public class UInt32NumericUpDown : System.Windows.Forms.NumericUpDown
    {
        public UInt32 IntValue
        {
            get { return (Convert.ToUInt32(this.Value)); }
            set { this.Value = Convert.ToDecimal(value); }
        }
    }
}
