namespace Aurora.Forms.CustomDataGrid
{
    partial class frmDataInput
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.grbOU = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.tableMainLayout.SuspendLayout();
            this.grbOU.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableMainLayout
            // 
            this.tableMainLayout.ColumnCount = 3;
            this.tableMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableMainLayout.Controls.Add(this.grbOU, 1, 1);
            this.tableMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMainLayout.Location = new System.Drawing.Point(0, 0);
            this.tableMainLayout.Name = "tableMainLayout";
            this.tableMainLayout.RowCount = 4;
            this.tableMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableMainLayout.Size = new System.Drawing.Size(272, 77);
            this.tableMainLayout.TabIndex = 1;
            // 
            // grbOU
            // 
            this.grbOU.Controls.Add(this.tableLayoutPanel1);
            this.grbOU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbOU.Location = new System.Drawing.Point(11, 11);
            this.grbOU.Name = "grbOU";
            this.grbOU.Size = new System.Drawing.Size(248, 54);
            this.grbOU.TabIndex = 6;
            this.grbOU.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnApply, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtValue, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(242, 35);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // btnApply
            // 
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApply.Location = new System.Drawing.Point(162, 3);
            this.btnApply.MaximumSize = new System.Drawing.Size(77, 25);
            this.btnApply.MinimumSize = new System.Drawing.Size(77, 25);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(77, 25);
            this.btnApply.TabIndex = 4;
            this.btnApply.TabStop = false;
            this.btnApply.Text = "Übernehmen";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.Apply);
            // 
            // txtValue
            // 
            this.txtValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValue.Location = new System.Drawing.Point(3, 3);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(153, 20);
            this.txtValue.TabIndex = 1;
            this.txtValue.Tag = "btnOU";
            // 
            // frmDataInput
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnApply;
            this.ClientSize = new System.Drawing.Size(272, 77);
            this.Controls.Add(this.tableMainLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmDataInput";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDataInput_FormClosing);
            this.Load += new System.EventHandler(this.frmDataInput_Load);
            this.tableMainLayout.ResumeLayout(false);
            this.grbOU.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableMainLayout;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox grbOU;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}