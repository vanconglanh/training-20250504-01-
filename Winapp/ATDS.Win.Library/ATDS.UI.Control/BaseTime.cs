using System;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ATDS.Common;


namespace ATDS.UI.Control
{
    public class BaseTime : BaseEdit
    {
        private FunctionLib.SeirekiWarekiDiv _SeirekiWareki;

        private string _TimeString;

        private const string lcMessage_ErrorNeed = "日付を入力して下さい。";

        private const string lcMessage_ErrorInvalid = "有効な日付ではありません。";

        private const string lcRegex_Kyoka = "([0-9]|\\.|:)";

        public FunctionLib.SeirekiWarekiDiv SeirekiWareki
        {
            get
            {
                return _SeirekiWareki;
            }
            set
            {
                _SeirekiWareki = value;
            }
        }

        public string TimeString
        {
            get
            {
                ChangeTime(base.Text);
                return _TimeString;
            }
            set
            {
                base.Text = ChangeTime(value);
            }
        }

        public new string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        public BaseTime()
        {
            base.Validating += BaseDate_Validating;
            base.KeyPress += txtPostal_KeyPress;
            _SeirekiWareki = FunctionLib.SeirekiWarekiDiv.Seireki;
            _TimeString = "";
        }

        protected virtual bool ShouldSerializeSeirekiWareki()
        {
            return !SeirekiWareki.Equals(FunctionLib.SeirekiWarekiDiv.Seireki);
        }

        protected virtual bool ShouldSerializeDateString()
        {
            return !DateAndTime.DateString.Equals("");
        }

        private void BaseDate_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (Operators.CompareString(Text, "", TextCompare: false) != 0)
                {
                    Text = ChangeTime(Text);
                    if (Operators.CompareString(Text, "", TextCompare: false) == 0)
                    {
                        EnterKeyOff();
                        e.Cancel = true;
                    }
                }
                else
                {
                    _TimeString = "";
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
        }

        private void txtPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') | (e.KeyChar > '9')) & (e.KeyChar != '.') & (e.KeyChar != ':') & (e.KeyChar != '-') & (Operators.CompareString(Conversions.ToString(e.KeyChar), "\b", TextCompare: false) != 0))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void Init()
        {
            MaxLength = 8;
            base.MojiSyurui = "H";
        }

        private string ChangeTime(string strValue)
        {
            string result = "";
            string TimeString = "";
            string text = "";
            try
            {
                if (Operators.CompareString(strValue, "", TextCompare: false) == 0)
                {
                    _TimeString = "";
                    return result;
                }

                result = UIFunctionLib.ChangeTime(strValue, SeirekiWareki, ref TimeString);
                if (Operators.CompareString(result, "", TextCompare: false) == 0)
                {
                    MessageBox.Show("有効な日付ではありません。", base.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Focus();
                    _TimeString = "";
                }
                else
                {
                    _TimeString = TimeString;
                }

                return result;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
        }

        public bool CheckedValue()
        {
            try
            {
                if (base.IsNeed & (Operators.CompareString(Strings.Trim(TimeString), "", TextCompare: false) == 0))
                {
                    MessageBox.Show("日付を入力して下さい。", base.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
        }
    }
}
