using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachineAssignment
{
    public class ButtonControl
    {
        public static void DisableAllControls(Form form)
        {
            foreach (Control control in form.Controls)
            {
                control.Enabled = false;
            }
        }
        public static void EnableAllControls(Form form)
        {
            foreach (Control control in form.Controls)
            {
                control.Enabled = true;
            }
        }
    }
}
