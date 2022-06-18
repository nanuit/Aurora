namespace Aurora.Forms.CustomControls.RegExpTextBox
{
    public class EmailTextBox : RegExpTextBox
    {
        public override string RegExpPattern
        {
            get { return (@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$"); }
        }
    }
}
