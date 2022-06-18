using System.Windows.Forms;

namespace Aurora.Forms
{
    public class Misc
    {
        public static Form GetParentForm(Control parent)
        {
            Form form = parent as Form;
            if (form != null)

                return form;

            if (parent != null) // Walk up the control hierarchy
                return GetParentForm(parent.Parent);

            return (null); // Control is not on a Form
        }
    }
}
