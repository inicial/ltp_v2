using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace rep25991.Controls
{
    public partial class ConvertationEditor : Panel
    {
        #region Вспомогательные классы
        private class variantsClass
        {
            public string Key;
            public string Value;
            public override string ToString()
            {
                return Value;
            }
        }
        #endregion

        #region Свойства
        public string Text
        {
            get { return this.edtFormat.Text; }
            set
            {
                this.edtFormat.Text = value;
                if (TextChange != null) TextChange(this, null);
            }
        }

        public string ExampleText
        {
            get { return lblExample.Text; }
            set { lblExample.Text = value; }
        }
        #endregion

        #region События
        public event EventHandler TextChange;
        #endregion

        #region Методы
        public void SetVariants(Hashtable value)
        {
            edtVariants.Items.Clear();
            edtVariants.Items.Add("Выберите что бы добавить");
            List<variantsClass> val = new List<variantsClass>();
            foreach (string item in value.Keys)
            {
                val.Add(new variantsClass() { Value = item, Key = value[item].ToString() });
            }
            edtVariants.Items.AddRange(val.OrderBy(x => x.Value).ToArray());
            edtVariants.SelectedIndex = 0;
            val.Clear();
            val = null;
            if (TextChange != null)
                TextChange(this, null);
        }

        private int lastCursorPosition = 0;

        private bool CursorNotInTag(bool isDelChar, bool isMoveToLeft)
        {
            bool result = true;
            int CursorPos = edtFormat.SelectionStart + edtFormat.SelectionLength;

            int firstCodeChar = edtFormat.Text.LastIndexOf("<%", CursorPos);
            int lastCodeChar = edtFormat.Text.LastIndexOf("%>", CursorPos);
            if (firstCodeChar > lastCodeChar)
                lastCodeChar = edtFormat.Text.IndexOf("%>", CursorPos);

            if (
                (edtFormat.SelectionStart - lastCodeChar <= 2 && isDelChar
                || edtFormat.SelectionStart - lastCodeChar <= 1) // если стоит не в упор последнему коду или если есть разрушенный <%
                && lastCodeChar > 0
                && firstCodeChar == edtFormat.Text.LastIndexOf("<%", lastCodeChar)  // Если есть разрушенный %>
                && lastCodeChar == edtFormat.Text.IndexOf("%>", firstCodeChar) // Если есть разрушенный <%
                )
            {
                if (isMoveToLeft && CursorPos == lastCursorPosition)
                {
                    edtFormat.Select(firstCodeChar, 0);
                }else 
                if (edtFormat.SelectionLength != lastCodeChar - firstCodeChar + 2)
                {
                    edtFormat.Select(firstCodeChar, lastCodeChar - firstCodeChar + 2);
                    result = false;
                    lastCursorPosition = CursorPos;
                }
            }

            return result;
        }
        #endregion

        bool LocalChange = false;
        #region Конструктор
        public ConvertationEditor()
        {
            InitializeComponents();
        }
        #endregion

        private void edtFormat_TextChanged(object sender, EventArgs e)
        {
            if (!LocalChange)
            {
                LocalChange = true;
                if (TextChange != null) TextChange(this, null);
                LocalChange = false;
            }
        }

        private void edtFormat_Leave(object sender, EventArgs e)
        {
            if (TextChange != null) TextChange(sender, e);
        }

        void btnAddVariants_Click(object sender, EventArgs e)
        {
            if (edtVariants.SelectedIndex > 0)
            {

                int newCursorPos = (edtFormat.Text.Substring(0, edtFormat.SelectionStart)
                    + "<%" + edtVariants.SelectedItem + "%>").Length;

                edtFormat.Text =
                    edtFormat.Text.Substring(0, edtFormat.SelectionStart)
                    + "<%" + edtVariants.SelectedItem + "%>"
                    + edtFormat.Text.Substring(edtFormat.SelectionStart + edtFormat.SelectionLength, edtFormat.Text.Length - (edtFormat.SelectionStart + edtFormat.SelectionLength));

                edtFormat.SelectionStart = newCursorPos;

                edtVariants.SelectedIndex = 0;

                if (TextChange != null) TextChange(this, null);
            }
        }

        private void edtFormat_KeyUp(object sender, KeyEventArgs e)
        {
            CursorNotInTag(false, (e.KeyCode == Keys.Left));
        }

        private void edtFormat_MouseUp(object sender, MouseEventArgs e)
        {
            CursorNotInTag(false, false);
        }

        private void edtFormat_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (!CursorNotInTag(e.KeyChar == (char)8, false))
                e.KeyChar = (char)0;

            if (e.KeyChar == (char)13)
            {
                int lastSelect = edtFormat.SelectionStart;
                edtFormat.Text =
                    edtFormat.Text.Substring(0, edtFormat.SelectionStart) +
                    "<%перенос строки%>" +
                    edtFormat.Text.Substring(edtFormat.SelectionStart + edtFormat.SelectionLength, edtFormat.Text.Length - edtFormat.SelectionStart - edtFormat.SelectionLength);
                edtFormat.Select(lastSelect + ("<%перенос строки%>").Length, 0);
                e.KeyChar = (char)0;
            }
        }
    }
}
