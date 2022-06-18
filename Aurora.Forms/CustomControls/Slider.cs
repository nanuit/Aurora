using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace Aurora.Forms.CustomControls
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof (IDesigner))]
    public partial class Slider : UserControl
    {
        public Slider()
        {
            InitializeComponent();
            RightToLeft = RightToLeft.No;
        }

        [Category("Custom")]
        [Description("TickFrequency for TrackBar component")]
        public int TickFrequency
        {
            get { return (trackSlider.TickFrequency); }
            set { trackSlider.TickFrequency = value; }
        }

        [Category("Custom")]
        [Description("TickStyle for TrackBar component")]
        public TickStyle TickStyle
        {
            get { return (trackSlider.TickStyle); }
            set { trackSlider.TickStyle = value; }
        }

        [Category("Custom")]
        [Description("Minimum for TrackBar component")]
        public int Minimum
        {
            get { return (trackSlider.Minimum); }
            set { trackSlider.Minimum = value; }
        }

        [Category("Custom")]
        [Description("Maximum for TrackBar component")]
        public int Maximum
        {
            get { return (trackSlider.Maximum); }
            set { trackSlider.Maximum = value; }
        }

        [Category("Custom")]
        [Description("Value for TrackBar component")]
        public int Value
        {
            get { return (trackSlider.Value); }
            set
            {
                trackSlider.Value = value;
                textValue.Text = trackSlider.Value.ToString();
            }
        }

        [Category("Custom")]
        [Description("Set visibility of the Value textbox")]
        public bool ShowValue
        {
            get { return (textValue.Visible); }
            set { textValue.Visible = value; }
        }

        [Category("Custom")]
        public Orientation Orientation
        {
            get { return (trackSlider.Orientation); }
            set
            {
                trackSlider.Orientation = value;

                if (value == Orientation.Horizontal)
                {
                    tableSliderLayout.SetColumn(textValue, 1);
                    tableSliderLayout.SetRow(textValue, 0);
                }
                else
                {
                    tableSliderLayout.SetColumn(textValue, 0);
                    tableSliderLayout.SetRow(textValue, 1);
                }
            }
        }

        public int SmallChange
        {
            get { return (trackSlider.SmallChange); }
            set { trackSlider.SmallChange = value; }
        }

        public int LargeChange
        {
            get { return (trackSlider.LargeChange); }
            set { trackSlider.LargeChange = value; }
        }

        private void trackSlider_Scrolled(object sender, EventArgs e)
        {
            textValue.Text = trackSlider.Value.ToString();
            textValue.Size = TextRenderer.MeasureText(textValue.Text, textValue.Font);
        }

        private void textValue_TextChanged(object sender, EventArgs e)
        {
            int NewValue = 0;
            if (int.TryParse(textValue.Text, out NewValue))
            {
                if (NewValue != trackSlider.Value)
                {
                    trackSlider.Value = System.Math.Min(System.Math.Max(NewValue, trackSlider.Minimum), trackSlider.Maximum);
                    trackSlider_Scrolled(trackSlider, null);
                }
            }
            else
                textValue.Text = trackSlider.Value.ToString();
        }

        private void trackSlider_ValueChanged(object sender, EventArgs e)
        {
            OnValueChange(e);
        }

        private void Slider_RightToLeftChanged(object sender, EventArgs e)
        {
            textValue.RightToLeft = RightToLeft.No;
        }

        #region Events

        public event EventHandler ValueChanged;

        private void OnValueChange(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        #endregion
    }
}
