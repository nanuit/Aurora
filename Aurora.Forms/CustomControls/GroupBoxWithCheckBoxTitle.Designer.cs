namespace Aurora.Forms.CustomControls
{
    partial class GroupBoxWithCheckBoxTitle
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
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.TitleCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // groupBody
            // 
            this.GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox.Location = new System.Drawing.Point(0, 0);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(150, 150);
            this.GroupBox.TabIndex = 0;
            this.GroupBox.TabStop = false;
            // 
            // checkTitle
            // 
            this.TitleCheckBox.AutoSize = true;
            this.TitleCheckBox.Location = new System.Drawing.Point(6, 0);
            this.TitleCheckBox.Name = "TitleCheckBox";
            this.TitleCheckBox.Size = new System.Drawing.Size(46, 17);
            this.TitleCheckBox.TabIndex = 1;
            this.TitleCheckBox.Text = "Title";
            this.TitleCheckBox.UseVisualStyleBackColor = true;
            this.TitleCheckBox.CheckedChanged += new System.EventHandler(this.checkTitle_CheckedChanged);
            // 
            // GroupBoxWithCheckBoxTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TitleCheckBox);
            this.Controls.Add(this.GroupBox);
            this.Name = "GroupBoxWithCheckBoxTitle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
