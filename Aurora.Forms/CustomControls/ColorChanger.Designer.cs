namespace Aurora.Forms.CustomControls
{
    partial class ColorChanger
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
            this.picColor = new System.Windows.Forms.PictureBox();
            this.tableObstacleLayout = new System.Windows.Forms.TableLayoutPanel();
            this.trackNumberOfObstacles = new Slider();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).BeginInit();
            this.tableObstacleLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // picColor
            // 
            this.picColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picColor.Location = new System.Drawing.Point(0, 0);
            this.picColor.Name = "picColor";
            this.picColor.Size = new System.Drawing.Size(55, 79);
            this.picColor.TabIndex = 16;
            this.picColor.TabStop = false;
            this.picColor.Click += new System.EventHandler(this.Color_Click);
            // 
            // tableObstacleLayout
            // 
            this.tableObstacleLayout.ColumnCount = 3;
            this.tableObstacleLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableObstacleLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableObstacleLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableObstacleLayout.Controls.Add(this.trackNumberOfObstacles, 1, 0);
            this.tableObstacleLayout.Location = new System.Drawing.Point(0, 0);
            this.tableObstacleLayout.Name = "tableObstacleLayout";
            this.tableObstacleLayout.RowCount = 1;
            this.tableObstacleLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableObstacleLayout.Size = new System.Drawing.Size(200, 100);
            this.tableObstacleLayout.TabIndex = 0;
            // 
            // trackNumberOfObstacles
            // 
            this.trackNumberOfObstacles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackNumberOfObstacles.LargeChange = 5;
            this.trackNumberOfObstacles.Location = new System.Drawing.Point(3, 3);
            this.trackNumberOfObstacles.Maximum = 40;
            this.trackNumberOfObstacles.Minimum = 0;
            this.trackNumberOfObstacles.Name = "trackNumberOfObstacles";
            this.trackNumberOfObstacles.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.trackNumberOfObstacles.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackNumberOfObstacles.Size = new System.Drawing.Size(144, 94);
            this.trackNumberOfObstacles.SmallChange = 1;
            this.trackNumberOfObstacles.TabIndex = 14;
            this.trackNumberOfObstacles.TickFrequency = 1;
            this.trackNumberOfObstacles.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackNumberOfObstacles.Value = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 51);
            this.label7.TabIndex = 13;
            this.label7.Text = "Number";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColorChanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picColor);
            this.Name = "ColorChanger";
            this.Size = new System.Drawing.Size(55, 79);
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).EndInit();
            this.tableObstacleLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picColor;
        private System.Windows.Forms.TableLayoutPanel tableObstacleLayout;
        private Slider trackNumberOfObstacles;
        private System.Windows.Forms.Label label7;
    }
}
