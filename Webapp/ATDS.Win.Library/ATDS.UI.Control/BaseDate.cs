using ATDS.Common;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ATDS.UI.Control
{
    public class BaseDate : BaseEdit
    {
        private FunctionLib.SeirekiWarekiDiv _SeirekiWareki;

        private FunctionLib.DisplayCalendarDiv _DisplayCalendar;

        private string _DateString;

        private bool _IsMask;

        private const string lcMessage_ErrorNeed = "日付を入力して下さい。";

        private const string lcMessage_ErrorInvalid = "有効な日付ではありません。";

        private const bool lcDVDateValue = false;

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

        public FunctionLib.DisplayCalendarDiv DisplayCalendar
        {
            get
            {
                return _DisplayCalendar;
            }
            set
            {
                _DisplayCalendar = value;
            }
        }

        public string DateString
        {
            get
            {
                if (Operators.CompareString(base.Text, GetMask(), TextCompare: false) != 0)
                {
                    ChangeDate(base.Text);
                }
                else
                {
                    ChangeDate("");
                }

                return _DateString;
            }
            set
            {
                if (Operators.CompareString(value, "", TextCompare: false) != 0)
                {
                    base.Text = ChangeDate(value);
                }
                else
                {
                    SetItem();
                }
            }
        }

        public DateTime DateValue => FunctionLib.CCDate(_DateString);

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

        public bool IsMask
        {
            get
            {
                return _IsMask;
            }
            set
            {
                _IsMask = value;
            }
        }

        public BaseDate()
        {
            base.Enter += BaseDate_Enter;
            base.Validating += BaseDate_Validating;
            base.KeyPress += BaseDate_KeyPress;
            _SeirekiWareki = FunctionLib.SeirekiWarekiDiv.Seireki;
            _DisplayCalendar = FunctionLib.DisplayCalendarDiv.YYYYMMDD;
            _DateString = "";
            _IsMask = false;
        }

        protected virtual bool ShouldSerializeSeirekiWareki()
        {
            return !SeirekiWareki.Equals(FunctionLib.SeirekiWarekiDiv.Seireki);
        }

        protected virtual bool ShouldSerializeDisplayCalendar()
        {
            return !DisplayCalendar.Equals(FunctionLib.DisplayCalendarDiv.YYYYMMDD);
        }

        protected virtual bool ShouldSerializeDateString()
        {
            return !DateString.Equals("");
        }

        protected virtual bool ShouldSerializeIsMask()
        {
            return !IsMask.Equals(obj: false);
        }

        private void BaseDate_Enter(object sender, EventArgs e)
        {
            base.ImeMode = ImeMode.Disable;
        }

        private void BaseDate_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (Operators.CompareString(Text, "", TextCompare: false) == 0 || Operators.CompareString(Text, GetMask(), TextCompare: false) == 0)
                {
                    SetItem();
                    return;
                }

                Text = ChangeDate(Text);
                if (Operators.CompareString(Text, "", TextCompare: false) == 0)
                {
                    EnterKeyOff();
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
        }
        private void BaseDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') | (e.KeyChar > '9')) & (e.KeyChar != '.') & (e.KeyChar != '/') & (e.KeyChar != '-') & !Regex.IsMatch(Conversions.ToString(e.KeyChar), UIFunctionLib.lcRegex_W_Alp()) & (Operators.CompareString(Conversions.ToString(e.KeyChar), "\b", TextCompare: false) != 0))
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
            MaxLength = 16;
            base.MojiSyurui = "H";
        }

        public virtual void SetItem()
        {
            _DateString = "";
            if (IsMask)
            {
                Text = GetMask();
            }
            else
            {
                Text = "";
            }
        }

        private string ChangeDate(string strValue)
        {
            string text = "";
            string TimeString = "";
            string text2 = "";
            try
            {
                if (Operators.CompareString(strValue, "", TextCompare: false) == 0)
                {
                    _DateString = "";
                    return "";
                }
                //TODO
                //text = ((DisplayCalendar == FunctionLib.DisplayCalendarDiv.TIME) ? UIFunctionLib.ChangeTime(strValue, SeirekiWareki, ref TimeString) : UIFunctionLib.ChangeDate(strValue, SeirekiWareki, DisplayCalendar, ref TimeString));
                text = ((DisplayCalendar == FunctionLib.DisplayCalendarDiv.TIME) ? UIFunctionLib.ChangeTime(strValue, SeirekiWareki, ref TimeString) : UIFunctionLib.ChangeDate(strValue, SeirekiWareki, DisplayCalendar, TimeString));
                if (Operators.CompareString(text, "", TextCompare: false) == 0)
                {
                    MessageBox.Show("有効な日付ではありません。", base.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Focus();
                    _DateString = "";
                }
                else
                {
                    _DateString = TimeString;
                }

                return text;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
            finally
            {
                Regex regex = null;
            }
        }

        public override bool CheckValue()
        {
            return CheckedValue();
        }

        public bool CheckedValue()
        {
            try
            {
                if (base.IsNeed & (Operators.CompareString(Strings.Trim(DateString), "", TextCompare: false) == 0))
                {
                    MessageBox.Show("日付を入力して下さい。", base.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Focus();
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

        public string GetMask()
        {
            string text = "";
            string input = "yyyy/MM/dd";
            try
            {
                if (SeirekiWareki == FunctionLib.SeirekiWarekiDiv.Seireki)
                {
                    switch (DisplayCalendar)
                    {
                        case FunctionLib.DisplayCalendarDiv.YYYYMMDD:
                            input = "yyyy/MM/dd";
                            break;
                        case FunctionLib.DisplayCalendarDiv.YYMMDD:
                            input = "yy/MM/dd";
                            break;
                        case FunctionLib.DisplayCalendarDiv.YYYYMM:
                            input = "yyyy/MM";
                            break;
                        case FunctionLib.DisplayCalendarDiv.MMDD:
                            input = "MM/dd";
                            break;
                        case FunctionLib.DisplayCalendarDiv.TIME:
                            input = "HH:mm";
                            break;
                        case FunctionLib.DisplayCalendarDiv.YYYY:
                            input = "yyyy";
                            break;
                    }
                }
                else
                {
                    switch (DisplayCalendar)
                    {
                        case FunctionLib.DisplayCalendarDiv.YYMMDD:
                        case FunctionLib.DisplayCalendarDiv.YYYYMMDD:
                            input = "ggyy年MM月dd日";
                            break;
                        case FunctionLib.DisplayCalendarDiv.YYYYMM:
                            input = "ggyy年MM月";
                            break;
                        case FunctionLib.DisplayCalendarDiv.MMDD:
                            input = "MM月dd日";
                            break;
                        case FunctionLib.DisplayCalendarDiv.TIME:
                            input = "HH時mm分";
                            break;
                        case FunctionLib.DisplayCalendarDiv.YYYY:
                            input = "ggyy年";
                            break;
                    }
                }

                return Regex.Replace(input, "[yMdHmg]", "_");
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (IsMask && Operators.CompareString(Text, GetMask(), TextCompare: false) == 0)
            {
                Text = "";
            }
        }
    }
}
