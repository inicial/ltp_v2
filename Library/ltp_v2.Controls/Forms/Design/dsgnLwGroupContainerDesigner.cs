using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;

namespace ltp_v2.Controls.Forms.Design
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class dsgnLwGroupContainerDesigner : ControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            lwGroupContainer uc = (lwGroupContainer)component;
            EnableDesignMode(uc.PnlContainer, "PnlContainer");
        }
    }
}
