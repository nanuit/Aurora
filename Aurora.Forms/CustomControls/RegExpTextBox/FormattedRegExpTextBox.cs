using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Aurora.Forms.CustomControls.RegExpTextBox
{
    public class FormattedRegExpTextBox : RegExpTextBox
    {
        #region Public Members

        public void AddFormatSection(int minCharCount, int maxCharCount, String separator)
        {
            Sections.Add(new Section(minCharCount, maxCharCount, separator));
        }

        #endregion

        protected override void OnMatch()
        {
            base.OnMatch();
            m_Groups.Clear();
            Match match = m_RegEx.Match(Text);
            for (int groupCounter = 1; groupCounter < match.Groups.Count; groupCounter++)
            {
                Group grp = match.Groups[groupCounter];
                m_Groups.Add(grp);
            }
        }

        /// <summary>
        ///     Raises the <see cref="E:System.Windows.Forms.Control.PreviewKeyDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PreviewKeyDownEventArgs" /> that contains the event data.</param>
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    e.IsInputKey = true;
                    break;
                default:
                    base.OnPreviewKeyDown(e);
                    break;
            }
        }

        /// <summary>
        ///     Raises the <see cref="E:System.Windows.Forms.Control.KeyDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data. </param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    foreach (Group grp in m_Groups)
                    {
                        if (SelectionStart >= grp.Index && SelectionStart < grp.Index + grp.Length)
                        {
                            m_ActiveGroupIndex = m_Groups.IndexOf(grp);
                        }
                    }

                    if (e.Shift)
                    {
                        m_ActiveGroupIndex = m_ActiveGroupIndex > 0 ? m_ActiveGroupIndex - 1 : m_ActiveGroupIndex;
                    }
                    else
                    {
                        m_ActiveGroupIndex = m_ActiveGroupIndex < m_Groups.Count - 1 ? m_ActiveGroupIndex + 1 : m_ActiveGroupIndex;
                    }
                    SelectionStart = m_Groups[m_ActiveGroupIndex].Index;
                    SelectionLength = m_Groups[m_ActiveGroupIndex].Length;

                    e.SuppressKeyPress = true;

                    break;
                default:
                    base.OnKeyDown(e);
                    break;
            }
        }

        protected struct Section
        {
            public int MaxCharCount;
            public int MinCharCount;
            public String Separator;

            public Section(int minCharCount, int maxCharCount, String separator)
            {
                MinCharCount = minCharCount;
                MaxCharCount = maxCharCount;
                Separator = separator;
            }
        }

        #region Private Members

        private readonly List<Section> Sections = new List<Section>();
        private readonly List<Group> m_Groups = new List<Group>();
        private int m_ActiveGroupIndex;

        #endregion
    }
}
