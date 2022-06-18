using System;
using System.Windows.Forms;

namespace Aurora.Forms
{
    public class Message
    {
        /// <summary>
        ///     Display a Messagebox using the default Button, Icon and Title.
        ///     If a progressWindow is shown it is hidden during Messagedisplay
        /// </summary>
        /// <param name="Title">Title for the MessageBox</param>
        /// <param name="Message">Message to be displayed</param>
        /// <param name="Buttons">MessageButtons to be displayed</param>
        /// <param name="Icon">Message Icon to be displayed</param>
        /// <returns>DialogResult of the MessageBox</returns>
        public static DialogResult ShowMessage(String Message)
        {
            return (ShowMessage(Message, "Program", MessageBoxButtons.OK, MessageBoxIcon.Information));
        }

        /// <summary>
        ///     Display a Messagebox.
        ///     If a progressWindow is shown it is hidden during Messagedisplay
        /// </summary>
        /// <param name="Message">Message to be displayed</param>
        /// <param name="Title">Title for the MessageBox</param>
        /// <param name="Buttons">MessageButtons to be displayed</param>
        /// <param name="Icon">Message Icon to be displayed</param>
        /// <returns>DialogResult of the MessageBox</returns>
        public static DialogResult ShowMessage(String Message, String Title, MessageBoxButtons Buttons, MessageBoxIcon Icon)
        {
            DialogResult Result;

            Result = MessageBox.Show(Message, Title, Buttons, Icon);

            return (Result);
        }
    }
}
