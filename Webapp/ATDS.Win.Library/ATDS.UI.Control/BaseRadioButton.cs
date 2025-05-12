using System;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ATDS.UI.Control
{
    public class BaseRadioButton : RadioButton
    {
        private const string lcCategory = "オリジナル";

        private const bool lcDVIsNextControl = false;

        private const int lcDVValue = 0;

        private const string lcDVMsgTitle = "ラジオボタン";

        private const string lcDSIsNextControl = "Enterキーで次の項目に移動するかを設定します。";

        private const string lcDSValue = "識別できる値です。";

        private bool _IsNextControl;

        private int _Value;

        private string _MsgTitle;

        [Category("オリジナル")]
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

        [Category("オリジナル")]
        [Description("識別できる値です。")]
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }

        protected override bool ShowFocusCues => true;

        public BaseRadioButton()
        {
            base.KeyDown += BaseRadioButton_KeyDown;
            _IsNextControl = false;
            _Value = 0;
            _MsgTitle = "ラジオボタン";
        }

        protected virtual bool ShouldSerializeIsNextControl()
        {
            return !IsNextControl.Equals(obj: false);
        }

        protected virtual bool ShouldSerializeValue()
        {
            return !Value.Equals(0);
        }

        private void BaseRadioButton_KeyDown(object sender, KeyEventArgs e)
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
            base.TabStop = true;
        }
    }
}
