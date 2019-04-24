using System;
using System.Windows.Forms;

namespace ltp_v2.Controls.Forms
{
    public class QuestionBox
    {
        public static DialogResult Show(string text, string caption)
        {
            return MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
