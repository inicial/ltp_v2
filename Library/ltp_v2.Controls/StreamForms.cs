namespace ltp_v2.Controls
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class StreamForms
    {
        public event EventHandler FindControl;

        public void Start(Control rootCtrl)
        {
            foreach (Control control in rootCtrl.Controls)
            {
                if (this.FindControl != null)
                {
                    this.FindControl(control, null);
                }
                if (control.Controls.Count > 0)
                {
                    this.Start(control);
                }
            }
        }
    }
}

