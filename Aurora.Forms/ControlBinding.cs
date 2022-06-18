using System;
using System.Windows.Forms;

namespace Aurora.Forms
{
    internal class ControlBinding
    {
        public static void TextBoxToButton(TextBox Text, Button Button)
        {
            Text.Tag = Button;
            Button.Tag = Text;
            Text.TextChanged += OnTextChangeSetButtonEnable;
            Text.Enter += OnEnterTextBoxSetDefaultButton;
        }

        public static void TextBoxToButton(RichTextBox Text, Button Button)
        {
            Text.Tag = Button;
            Button.Tag = Text;
            Text.TextChanged += OnRichTextChangeSetButtonEnable;
            Text.Enter += OnEnterRichTextBoxSetDefaultButton;
        }

        private static void OnEnterTextBoxSetDefaultButton(object sender, EventArgs e)
        {
            var ThisBox = sender as TextBox;
            SetDefaultButtonOnText(ThisBox.Text, ThisBox, (Button) ThisBox.Tag);
        }

        private static void OnTextChangeSetButtonEnable(object sender, EventArgs e)
        {
            var ThisBox = sender as TextBox;
            var CorrespondingButton = ThisBox.Tag as Button;
            SetDefaultButtonOnText(ThisBox.Text, ThisBox, (Button) ThisBox.Tag);
            CorrespondingButton.Enabled = !String.IsNullOrEmpty(ThisBox.Text);
        }

        private static void OnEnterRichTextBoxSetDefaultButton(object sender, EventArgs e)
        {
            var ThisBox = sender as RichTextBox;
            SetDefaultButtonOnText(ThisBox.Text, ThisBox, (Button) ThisBox.Tag);
        }

        private static void OnRichTextChangeSetButtonEnable(object sender, EventArgs e)
        {
            var ThisBox = sender as RichTextBox;
            var CorrespondingButton = ThisBox.Tag as Button;
            SetDefaultButtonOnText(ThisBox.Text, ThisBox, (Button) ThisBox.Tag);
            CorrespondingButton.Enabled = !String.IsNullOrEmpty(ThisBox.Text);
        }

        public static void SetDefaultButtonOnText(String TexttoCheckfor, Control Ctrl, Button DefaultButton)
        {
            Form Parentform = Misc.GetParentForm(Ctrl);
            if (Parentform == null)
                return;
            if (!String.IsNullOrEmpty(TexttoCheckfor))
                Parentform.AcceptButton = DefaultButton;
        }
    }
}
