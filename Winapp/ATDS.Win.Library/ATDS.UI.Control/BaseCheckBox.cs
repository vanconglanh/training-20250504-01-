using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.UI.Control
{
    public class BaseCheckBox : CheckBox
    {
        private const string lcCategory = "オリジナル";

        private const bool lcDVIsNextControl = false;

        private const string lcDVMsgTitle = "チェックボックス";

        private const string lcDSIsNextControl = "Enterキーで次の項目に移動するかを設定します。";

        private bool _IsNextControl;

        private string _MsgTitle;

        private string _HintText;

        [Category("オリジナル")]
        [DefaultValue(false)]
        [Description("Enterキーで次の項目に移動するかを設定します。")]
        public bool IsNextControl
        {
            get
            {
                return _IsNextControl;
            }
            set
            {
                _IsNextControl = value;
            }
        }

        public string HintText
        {
            get
            {
                return _HintText;
            }
            set
            {
                _HintText = value;
            }
        }

        protected override bool ShowFocusCues => true;

        public BaseCheckBox()
        {
            base.KeyDown += BaseCheckBox_KeyDown;
            _IsNextControl = false;
            _MsgTitle = "チェックボックス";
            _HintText = "";
        }

        protected virtual bool ShouldSerializeHintText()
        {
            return !HintText.Equals("");
        }

        private void BaseCheckBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Keys keyCode = e.KeyCode;
                if (keyCode == Keys.Return && _IsNextControl)
                {
                    e.Handled = true;
                    SendKeys.SendWait("\t");
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                MessageBox.Show(ex2.Message, _MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ProjectData.ClearProjectError();
            }
            finally
            {
            }
        }

        private void Init()
        {
            base.FlatStyle = FlatStyle.System;
        }
    }
}
