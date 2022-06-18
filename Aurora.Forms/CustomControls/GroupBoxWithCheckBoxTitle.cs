using System;
using System.Drawing;
using System.Windows.Forms;

namespace Aurora.Forms.CustomControls
{
    public partial class GroupBoxWithCheckBoxTitle : UserControl
    {
        public GroupBoxWithCheckBoxTitle()
        {
            InitializeComponent();
        }

        public String GroupTitle
        {
            set { TitleCheckBox.Text = value; }
            get { return (TitleCheckBox.Text); }
        }

        public GroupBox GroupBox { get; set; }
        public CheckBox TitleCheckBox { get; set; }

        private void checkTitle_CheckedChanged(object sender, EventArgs e)
        {
            //// Make sure the CheckBox isn't in the GroupBox.
            //// This will only happen the first time.
            //if (this.checkTitle.Parent == this.groupBody)
            //{
            //    // Reparent the CheckBox so it's not in the GroupBox.
            //    groupBody.Parent.Controls.Add(checkTitle);

            //    // Adjust the CheckBox's location.
            //    checkTitle.Location = new Point(
            //        checkTitle.Left + groupBody.Left,
            //        checkTitle.Top + groupBody.Top);

            //    // Move the CheckBox to the top of the stacking order.
            //    checkTitle.BringToFront();
            //}

            // Enable or disable the GroupBox.
            GroupBox.Enabled = (TitleCheckBox.Checked);

            // Get the appropriate color for the contained controls.
            Color foreColor;
            if (GroupBox.Enabled)
            {
                foreColor = Color.FromKnownColor(KnownColor.ActiveCaptionText);
            }
            else
            {
                foreColor = Color.FromKnownColor(KnownColor.InactiveCaptionText);
            }

            // Color the controls in the GroupBox.
            foreach (Control ctl in GroupBox.Controls)
            {
                ctl.ForeColor = foreColor;
            }
        }
    }
}
