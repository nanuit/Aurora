using System;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Aurora.Forms.CustomControls.RegExpTextBox
{
    public class RegExpTextBox : MaskedTextBox
    {
        #region To Life and Die in Starlight

        public RegExpTextBox()
        {
            Validating += new CancelEventHandler(ValidatingEventHandler);
            TextChanged += new EventHandler(TextChangedHandler);
            m_ValidBackColor = BackColor;
            m_ValidForeColor = ForeColor;
        }

        #endregion

        private void SetValidityColors()
        {
            if (IsValid)
            {
                ForeColor = !InvalidForeColor.IsEmpty && !m_ValidForeColor.IsEmpty ? m_ValidForeColor : ForeColor;
                BackColor = !InvalidBackColor.IsEmpty && !m_ValidBackColor.IsEmpty ? m_ValidBackColor : BackColor;
            }
            else
            {
                if (ForeColor != InvalidForeColor)
                {
                    m_ValidForeColor = ForeColor;
                    ForeColor = !InvalidForeColor.IsEmpty ? InvalidForeColor : ForeColor;
                }
                if (BackColor != InvalidBackColor)
                {
                    m_ValidBackColor = BackColor;
                    BackColor = !InvalidBackColor.IsEmpty ? InvalidBackColor : BackColor;
                }
            }
        }

        private void TextChangedHandler(object sender, EventArgs e)
        {
            ValidateRegexp();
            if (ForceValidity && !IsValid)
            {
                SystemSounds.Exclamation.Play();
                int oldSelectionStart = SelectionStart;
                int oldSelectionLength = SelectionLength;
                this.Text = m_LastValidText;
                SelectionStart = oldSelectionStart > 0 ? oldSelectionStart - 1 : 0;
                SelectionLength = oldSelectionLength;
            }
        }

        protected virtual void ValidateRegexp()
        {
            IsValid = false;
            if (!String.IsNullOrEmpty(RegExpPattern))
            {
                try
                {
                    if (m_RegEx.IsMatch(Text))
                    {
                        IsValid = true;
                        m_LastValidText = Text;
                        OnMatch();
                    }
                    else
                    {
                        OnNoMatch();
                    }
                }
                catch
                {
                    OnInvalidRegExp();
                }
            }
            else
            {
                m_LastValidText = String.Empty;
            }
            SetValidityColors();
        }

        private void ValidatingEventHandler(object sender, CancelEventArgs e)
        {
            ValidateRegexp();
            if (!IsValid && ForceValidity)
            {
                SelectAll();
                e.Cancel = true;
            }
        }

        #region Properties

        public Regex RegEx
        {
            get { return m_RegEx; }
        }

        public bool IsValid { get; private set; }
        public bool ForceValidity { get; set; }
        public Color InvalidForeColor { get; set; }
        public Color InvalidBackColor { get; set; }


        public virtual String RegExpPattern
        {
            get { return (m_RegExpPattern); }
            set
            {
                m_RegExpPattern = value;
                if (m_RegExpPattern != null)
                    m_RegEx = new Regex(m_RegExpPattern);
                ValidateRegexp();
            }
        }

        #endregion

        #region Private Members

        protected Regex m_RegEx;
        private String m_RegExpPattern;
        private String m_LastValidText;
        private Color m_ValidForeColor;
        private Color m_ValidBackColor;

        #endregion

        #region Events

        public event EventHandler Match;

        protected virtual void OnMatch()
        {
            if (Match != null)
                Match(this, null);
        }

        public event EventHandler InvalidRegExp;

        protected virtual void OnInvalidRegExp()
        {
            if (InvalidRegExp != null)
                InvalidRegExp(this, null);
        }

        public event EventHandler NoMatch;

        protected virtual void OnNoMatch()
        {
            if (NoMatch != null)
                NoMatch(this, null);
        }

        #endregion
    }
}
