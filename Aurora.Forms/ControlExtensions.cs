using System;
using System.Windows.Forms;

namespace Aurora.Forms
{
    public static class ControlExtensions
    {
        public static void UIThreadBeginInvoke(this Control control, Action code)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(code);
                return;
            }
            code.Invoke();
        }

        public static void UIThread(this Control control, Action code)
        {
            if (control.InvokeRequired)
            {
                lock (control)
                {
                    if (!control.IsDisposed && !control.Disposing)
                        control.Invoke(code);
                }
                return;
            }
            code.Invoke();
        }
    }
}
