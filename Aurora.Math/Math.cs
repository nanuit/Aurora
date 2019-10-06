using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Misc
{
    public class Math
    {
        public static int GetPercentage(int value, int percent)
        {
            return value > 0 ? (System.Math.Min(Convert.ToInt32(System.Math.Ceiling(percent / ((double)value / 100))), 100)) : (0);
        }
    }
}
