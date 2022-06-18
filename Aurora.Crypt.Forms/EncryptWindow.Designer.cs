namespace Aurora.Crypt.Forms
{
    partial class EncryptWindow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblInput = new System.Windows.Forms.Label();
            this.lblOutPut = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtOutPut = new System.Windows.Forms.TextBox();
            this.comboApplicationId = new System.Windows.Forms.ComboBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.checkDecrypt = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.82796F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblInput, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblOutPut, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtInput, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtOutPut, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboApplicationId, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCopy, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkDecrypt, 3, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(443, 105);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Application";
            // 
            // lblInput
            // 
            this.lblInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(11, 43);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(59, 13);
            this.lblInput.TabIndex = 0;
            this.lblInput.Text = "Password";
            // 
            // lblOutPut
            // 
            this.lblOutPut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOutPut.AutoSize = true;
            this.lblOutPut.Location = new System.Drawing.Point(11, 69);
            this.lblOutPut.Name = "lblOutPut";
            this.lblOutPut.Size = new System.Drawing.Size(59, 13);
            this.lblOutPut.TabIndex = 1;
            this.lblOutPut.Text = "Cypher";
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(76, 40);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(275, 20);
            this.txtInput.TabIndex = 2;
            this.txtInput.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // txtOutPut
            // 
            this.txtOutPut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutPut.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtOutPut.Location = new System.Drawing.Point(76, 66);
            this.txtOutPut.Name = "txtOutPut";
            this.txtOutPut.ReadOnly = true;
            this.txtOutPut.Size = new System.Drawing.Size(275, 20);
            this.txtOutPut.TabIndex = 3;
            // 
            // comboApplicationId
            // 
            this.comboApplicationId.FormattingEnabled = true;
            this.comboApplicationId.Location = new System.Drawing.Point(76, 11);
            this.comboApplicationId.Name = "comboApplicationId";
            this.comboApplicationId.Size = new System.Drawing.Size(270, 21);
            this.comboApplicationId.TabIndex = 6;
            this.comboApplicationId.SelectedIndexChanged += new System.EventHandler(this.comboApplicationId_SelectedIndexChanged);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(357, 11);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // checkDecrypt
            // 
            this.checkDecrypt.AutoSize = true;
            this.checkDecrypt.Location = new System.Drawing.Point(357, 40);
            this.checkDecrypt.Name = "checkDecrypt";
            this.checkDecrypt.Size = new System.Drawing.Size(63, 17);
            this.checkDecrypt.TabIndex = 7;
            this.checkDecrypt.Text = "Decrypt";
            this.checkDecrypt.UseVisualStyleBackColor = true;
            this.checkDecrypt.CheckedChanged += new System.EventHandler(this.checkDecrypt_CheckedChanged);
            // 
            // EncryptWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 105);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EncryptWindow";
            this.Text = "EncryptWindow";
            this.Load += new System.EventHandler(this.EncryptWindow_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblOutPut;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutPut;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboApplicationId;
        private System.Windows.Forms.CheckBox checkDecrypt;
    }
}