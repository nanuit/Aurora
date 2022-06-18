namespace Aurora.Forms.CustomControls
{
    partial class Slider
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableSliderLayout = new System.Windows.Forms.TableLayoutPanel();
            this.trackSlider = new System.Windows.Forms.TrackBar();
            this.textValue = new System.Windows.Forms.TextBox();
            this.tableSliderLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // tableSliderLayout
            // 
            this.tableSliderLayout.ColumnCount = 2;
            this.tableSliderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableSliderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableSliderLayout.Controls.Add(this.trackSlider, 0, 0);
            this.tableSliderLayout.Controls.Add(this.textValue, 1, 0);
            this.tableSliderLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableSliderLayout.Location = new System.Drawing.Point(0, 0);
            this.tableSliderLayout.Name = "tableSliderLayout";
            this.tableSliderLayout.RowCount = 2;
            this.tableSliderLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableSliderLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableSliderLayout.Size = new System.Drawing.Size(238, 30);
            this.tableSliderLayout.TabIndex = 12;
            // 
            // trackSlider
            // 
            this.trackSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackSlider.Location = new System.Drawing.Point(3, 3);
            this.trackSlider.Maximum = 1000;
            this.trackSlider.Minimum = 1;
            this.trackSlider.Name = "trackSlider";
            this.trackSlider.Size = new System.Drawing.Size(201, 24);
            this.trackSlider.TabIndex = 9;
            this.trackSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackSlider.Value = 1000;
            this.trackSlider.Scroll += new System.EventHandler(this.trackSlider_Scrolled);
            this.trackSlider.ValueChanged += new System.EventHandler(this.trackSlider_ValueChanged);
            // 
            // textValue
            // 
            this.textValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.textValue.Location = new System.Drawing.Point(210, 3);
            this.textValue.Name = "textValue";
            this.textValue.Size = new System.Drawing.Size(25, 20);
            this.textValue.TabIndex = 10;
            this.textValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textValue.TextChanged += new System.EventHandler(this.textValue_TextChanged);
            // 
            // Slider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableSliderLayout);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Slider";
            this.Size = new System.Drawing.Size(238, 30);
            this.RightToLeftChanged += new System.EventHandler(this.Slider_RightToLeftChanged);
            this.tableSliderLayout.ResumeLayout(false);
            this.tableSliderLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableSliderLayout;
        private System.Windows.Forms.TrackBar trackSlider;
        private System.Windows.Forms.TextBox textValue;
    }
}
