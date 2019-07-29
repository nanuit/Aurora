using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Aurora.Crypt.Forms
{
    public partial class EncryptWindow : Form
    {
        #region Private Members
        private List<EncryptionElement> m_AppIdentifier;
        
        #endregion
        public EncryptWindow(List<EncryptionElement> appIdentifier)
        {
            InitializeComponent();
            m_AppIdentifier = appIdentifier;
            comboApplicationId.Items.AddRange(appIdentifier.ToArray());
        }

        private void EncryptWindow_Load(object sender, EventArgs e)
        {
                
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            EncryptPassword();
        }

        private void EncryptPassword()
        {
            if (txtInput.Text.Length == 0)
                return;
            EncryptionElement element = comboApplicationId.SelectedItem as EncryptionElement;
            try
            {
                if (element != null)
                    txtOutPut.Text = checkDecrypt.Checked ? RijndaelCrypt.Decrypt(txtInput.Text, element.ApplicationId) : RijndaelCrypt.Encrypt(txtInput.Text, element.ApplicationId);
                txtOutPut.BackColor = SystemColors.Control;
                txtOutPut.ForeColor = SystemColors.WindowText;
            }
            catch (Exception ex)
            {
                txtOutPut.Text = ex.Message;
                txtOutPut.BackColor = Color.Red;
                txtOutPut.ForeColor = Color.White;
            }
            
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtOutPut.Text);
        }

        private void comboApplicationId_SelectedIndexChanged(object sender, EventArgs e)
        {
            EncryptPassword();
        }

        private void checkDecrypt_CheckedChanged(object sender, EventArgs e)
        {
            bool decrypt = checkDecrypt.Checked;
            lblInput.Text = decrypt ? "Cypher" : "Passwort";
            lblOutPut.Text = decrypt ? "Passwort" : "Cypher";
            EncryptPassword();
        }
    }
}
