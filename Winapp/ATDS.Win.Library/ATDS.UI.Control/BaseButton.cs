using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.UI.Control
{
    public class BaseButton : Button
    {
        protected override bool ShowFocusCues => true;

        private void Init()
        {
            base.FlatStyle = FlatStyle.System;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((uint)(keyData - 37) <= 3u)
            {
                return true;
            }

            return false;
        }
    }
}
