using ATDS.UI.Control.Utils;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ATDS.UI.Control
{
    public class BaseNumber : BaseText
    {
        private decimal _MaxValue;

        private decimal _MinValue;

        private Color _MinusColor;

        private Round _RoundType;

        private decimal _BeforeValue;

        private int m_InputIntDigit;

        private int m_InputDecDigit;

        private string m_DisplayFormat;

        private bool _IsEnterKey;

        private decimal _DefaultValue;

        private bool blnInputNumeric;

        private bool blnDecimalDeleteZeroFlg;

        private const decimal lcDVMaxValue = 99999m;

        private const decimal lcDVMinValue = -99999m;

        private const decimal lcDVValue = 0m;

        private Color lcDVMinusColor;

        private const Round lcDVRoundType = Round.Off;

        private const string lcDVDisplayFormat = "####0";

        private const decimal lcDVBeforeValue = 0m;

        private const decimal lcDVDefaultValue = 0m;

        private const int lcDVInputIntDigit = 5;

        private const int lcDVInputDecDigit = 0;

        private const string lcCategory = "オリジナル";

        private const string lcDSMaxValue = "入力最大値を設定します。";

        private const string lcDSMinValue = "入力最小値を設定します。";

        private const string lcDSValue = "";

        private const string lcDSMinusColor = "負数の場合に赤字で表示するかを設定します。";

        private const string lcDSRoundType = "小数点以下の数値の処理形式を設定します。";

        private const string lcDSDisplayFormat = "表示書式を設定します。";

        private const string lcDSInputIntDigit = "整数部の入力桁数を取得または設定します。";

        private const string lcDSInputDecDigit = "小数部の入力桁数を取得または設定します。";

        public new string Text => base.Text;

        [DefaultValue(0f)]
        [Browsable(true)]
        public decimal Value
        {
            get
            {
                if (!CheckText(Text))
                {
                    return default(decimal);
                }

                return Conversions.ToDecimal(Text);
            }
            set
            {
                if (!base.DesignMode)
                {
                    base.Text = value.ToString(m_DisplayFormat);
                }
            }
        }

        [DefaultValue(0f)]
        [Browsable(true)]
        public decimal DefaultValue
        {
            get
            {
                return _DefaultValue;
            }
            set
            {
                _DefaultValue = value;
            }
        }

        [Category("オリジナル")]
        [DefaultValue(99999f)]
        [Description("入力最大値を設定します。")]
        public decimal MaxValue
        {
            get
            {
                return _MaxValue;
            }
            set
            {
                _MaxValue = value;
            }
        }

        [Category("オリジナル")]
        [DefaultValue(-99999f)]
        [Description("入力最小値を設定します。")]
        public decimal MinValue
        {
            get
            {
                return _MinValue;
            }
            set
            {
                _MinValue = value;
            }
        }

        [Category("オリジナル")]
        [Description("負数の場合に赤字で表示するかを設定します。")]
        public Color MinusColor
        {
            get
            {
                return _MinusColor;
            }
            set
            {
                _MinusColor = value;
            }
        }

        [Category("オリジナル")]
        [Description("小数点以下の数値の処理形式を設定します。")]
        public Round RoundType
        {
            get
            {
                return _RoundType;
            }
            set
            {
                _RoundType = value;
            }
        }

        [Category("オリジナル")]
        [DefaultValue(5)]
        [Description("整数部の入力桁数を取得または設定します。")]
        public int InputIntDigit
        {
            get
            {
                return m_InputIntDigit;
            }
            set
            {
                m_InputIntDigit = value;
                SetMaxLength();
            }
        }

        [Category("オリジナル")]
        [DefaultValue(0)]
        [Description("小数部の入力桁数を取得または設定します。")]
        public int InputDecDigit
        {
            get
            {
                return m_InputDecDigit;
            }
            set
            {
                m_InputDecDigit = value;
                SetMaxLength();
            }
        }

        [Category("オリジナル")]
        [DefaultValue("####0")]
        [Description("表示書式を設定します。")]
        public string DisplayFormat
        {
            get
            {
                return m_DisplayFormat;
            }
            set
            {
                m_DisplayFormat = value;
                if (!base.DesignMode)
                {
                    base.Text = Value.ToString(m_DisplayFormat);
                }
            }
        }

        [Browsable(false)]
        public decimal BeforeValue
        {
            get
            {
                if ((decimal.Compare(_BeforeValue, MinValue) < 0) | (decimal.Compare(_BeforeValue, MaxValue) > 0))
                {
                    _BeforeValue = MinValue;
                }

                return _BeforeValue;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new int MaxLength
        {
            get
            {
                return base.MaxLength;
            }
            set
            {
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new int ImeMode
        {
            get
            {
                return (int)base.ImeMode;
            }
            set
            {
            }
        }

        [Browsable(false)]
        protected bool IsEnterKey => _IsEnterKey;

        public BaseNumber()
        {
            base.Enter += BaseNumber_Enter;
            base.Leave += BaseNumber_Leave;
            base.KeyPress += BaseNumber_KeyPress;
            base.KeyDown += BaseNumber_KeyDown;
            base.TextChanged += BaseNumber_TextChanged;
            base.Validating += BaseNumber_Validating;
            base.Validated += BaseEdit_Validated;
            base.MouseClick += BaseNumber2_MouseClick;
            _MaxValue = 99999m;
            _MinValue = -99999m;
            _MinusColor = lcDVMinusColor;
            _RoundType = Round.Off;
            _BeforeValue = default(decimal);
            m_InputIntDigit = 5;
            m_InputDecDigit = 0;
            m_DisplayFormat = "####0";
            _IsEnterKey = false;
            _DefaultValue = default(decimal);
            blnInputNumeric = false;
            blnDecimalDeleteZeroFlg = true;
            lcDVMinusColor = Color.Red;
        }

        protected virtual bool ShouldSerializeMinusColor()
        {
            return !MinusColor.Equals(lcDVMinusColor);
        }

        protected virtual bool ShouldSerializeRoundType()
        {
            return !RoundType.Equals(Round.Off);
        }

        private void BaseNumber_Enter(object sender, EventArgs e)
        {
            if (decimal.Compare(Value, 0m) == 0)
            {
                base.Text = Value.ToString(m_DisplayFormat);
            }

            BackColor = Color.MistyRose;
            base.ImeMode = System.Windows.Forms.ImeMode.Disable;
        }

        public void BaseNumber_Leave(object sender, EventArgs e)
        {
            BackColor = SystemColors.Window;
        }

        private void BaseNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            int num = Strings.Asc(e.KeyChar);
            bool flag = false;
            int num2 = num;
            if (num2 == 8)
            {
                InputBackSpace();
                flag = true;
            }
            else if (num2 >= 48 && num2 <= 57)
            {
                flag = InputNumeric(e.KeyChar);
            }
            else
            {
                switch (num2)
                {
                    case 45:
                        if (Strings.InStr(Text, "-") == 0)
                        {
                            base.Text = "-" + Text;
                            base.SelectionStart = Strings.InStr(Text, "-");
                        }
                        else
                        {
                            base.Text = Text.Remove(0, 1);
                        }

                        flag = true;
                        break;
                    case 46:
                        flag = InputDecimal();
                        break;
                    case 43:
                        if (Strings.InStr(Text, "-") != 0)
                        {
                            base.Text = Text.Remove(0, 1);
                        }

                        flag = true;
                        break;
                    default:
                        flag = true;
                        break;
                }
            }

            e.Handled = flag;
        }

        private void BaseNumber_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    InputDelete();
                    e.Handled = true;
                    break;
                case Keys.Return:
                    _IsEnterKey = true;
                    break;
            }
        }

        private void BaseNumber_TextChanged(object sender, EventArgs e)
        {
            ChangeMinusColor();
        }

        private void BaseNumber_Validating(object sender, CancelEventArgs e)
        {
            if (CheckText(base.Text))
            {
                Value = Conversions.ToDecimal(base.Text);
            }
            else
            {
                Value = 0m;
            }

            ValueCheck();
            _BeforeValue = Value;
        }

        private void BaseEdit_Validated(object sender, EventArgs e)
        {
            if (_IsEnterKey)
            {
                CheckValue();
            }

            _IsEnterKey = false;
            _BeforeValue = Value;
        }

        private void BaseNumber2_MouseClick(object sender, MouseEventArgs e)
        {
            if (Operators.CompareString(SelectedText, "", TextCompare: false) == 0)
            {
                SelectAll();
            }
        }

        private void ValueCheck()
        {
            if (Operators.CompareString(Text, "", TextCompare: false) != 0 && !((decimal.Compare(MaxValue, 0m) == 0) & (decimal.Compare(MinValue, 0m) == 0)))
            {
                bool flag = true;
                if (flag == decimal.Compare(Value, MaxValue) > 0)
                {
                    Value = BeforeValue;
                }
                else if (flag == decimal.Compare(Value, MinValue) < 0)
                {
                    Value = BeforeValue;
                }
            }
        }

        private void Init()
        {
            base.ImeMode = System.Windows.Forms.ImeMode.Disable;
            base.TextAlign = HorizontalAlignment.Right;
        }

        private bool CheckText(string vstrValue)
        {
            if (Information.IsNothing(vstrValue) | (Operators.CompareString(vstrValue, "", TextCompare: false) == 0) | (Operators.CompareString(vstrValue, "-", TextCompare: false) == 0) | (Operators.CompareString(vstrValue, ".", TextCompare: false) == 0) | (Operators.CompareString(vstrValue, "-.", TextCompare: false) == 0))
            {
                return false;
            }

            return true;
        }

        private bool ChangeMinusColor()
        {
            if (Strings.InStr(Text, "-") != 0)
            {
                ForeColor = Color.Red;
            }
            else
            {
                ForeColor = Color.Black;
            }

            bool result = default(bool);
            return result;
        }

        private void SetMaxLength()
        {
            int num = 0;
            checked
            {
                num += m_InputIntDigit;
                if (m_InputDecDigit > 0)
                {
                    num += m_InputDecDigit + 1;
                }

                base.MaxLength = num;
            }
        }

        private void OnPaste(EventArgs e)
        {
            string text = "";
            string text2 = "";
            try
            {
                object objectValue = RuntimeHelpers.GetObjectValue(Clipboard.GetDataObject().GetData(DataFormats.Text));
                if (objectValue != null)
                {
                    text = objectValue.ToString();
                    text2 = GetPermitedString(text);
                    SelectedText = text2;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
        }

        private string GetPermitedString(string strTarget)
        {
            string text = "";
            foreach (char c in strTarget)
            {
                if (Versioned.IsNumeric(c))
                {
                    text += Conversions.ToString(c);
                }
            }

            return text;
        }

        private bool InputNumeric(char KeyChar)
        {
            checked
            {
                int num = Text.Length - (base.SelectionStart + SelectionLength);
                int num2 = 0;
                string text = Text;
                int num3 = base.SelectionStart;
                int num4 = Strings.InStr(Text, ".");
                if (SelectionLength != 0)
                {
                    text = text.Remove(num3, SelectionLength);
                    num2 = Strings.InStr(SelectedText, ".");
                    if (num2 != 0 && SelectedText.Length - num2 == m_InputDecDigit)
                    {
                        num4 = 0;
                    }
                }

                int num5 = Strings.InStr(text, "-");
                if (num3 < num5)
                {
                    num3 = num5;
                }

                if (unchecked(Strings.InStr(text, ".") == 0 && num4 != 0))
                {
                    text = text.Insert(num3, ".");
                }

                int num6 = Strings.InStr(text, ".");
                int length = ((num6 != 0) ? (num6 - 1) : Text.Length);
                if (unchecked(base.SelectionStart >= num4 && num4 > 0))
                {
                    if (Strings.Mid(text, num4 + 1).Length >= m_InputDecDigit)
                    {
                        text = text.Insert(num3, Conversions.ToString(KeyChar));
                        num3 = 0;
                        int length2 = Strings.Mid(text, num4 + 1).Length;
                        if (length2 > m_InputDecDigit)
                        {
                            text = text.Remove(num4 + m_InputDecDigit, length2 - m_InputDecDigit);
                            num3 = 1;
                        }
                    }
                    else
                    {
                        text = text.Insert(num3, Conversions.ToString(KeyChar));
                        num3 = 0;
                    }
                }
                else
                {
                    string text2 = Strings.Replace(Strings.Mid(text, 1, length), "-", "");
                    if (Information.IsNothing(text2))
                    {
                        text2 = "";
                    }

                    if (text2.Length >= m_InputIntDigit)
                    {
                        if (CheckText(text))
                        {
                            Value = Conversions.ToDecimal(text);
                        }
                        else
                        {
                            base.Text = text;
                        }

                        base.SelectionStart = num3;
                        SelectionLength = 0;
                        return true;
                    }

                    text = text.Insert(num3, Conversions.ToString(KeyChar));
                    num3 = 0;
                }

                if (CheckText(text))
                {
                    Value = Conversions.ToDecimal(text);
                }
                else
                {
                    base.Text = text;
                }

                if (Operators.CompareString(Text, "", TextCompare: false) != 0)
                {
                    if (Text.Length >= num)
                    {
                        base.SelectionStart = Text.Length - num + num3;
                    }

                    if ((num2 > 0) & (Strings.InStr(Text, ".") != 0))
                    {
                        base.SelectionStart = Strings.InStr(Text, ".") - 1;
                    }
                }
                else
                {
                    base.SelectionStart = text.Length;
                }

                SelectionLength = 0;
                return true;
            }
        }

        private bool InputDecimal()
        {
            if (m_InputDecDigit == 0)
            {
                return true;
            }

            string text = Text;
            int num = base.SelectionStart;
            if (SelectionLength != 0)
            {
                text = text.Remove(num, SelectionLength);
            }

            int num2 = Strings.InStr(text, "-");
            if (num < num2)
            {
                num = num2;
            }

            if (Strings.InStr(text, ".") == 0)
            {
                text = text.Insert(num, ".");
            }

            text = text.Replace(",", "");
            int num3 = Strings.InStr(text, ".");
            checked
            {
                int num4 = text.Length - num3;
                if (num4 > m_InputDecDigit)
                {
                    text = text.Remove(num3 + m_InputDecDigit, num4 - m_InputDecDigit);
                }

                if (CheckText(text))
                {
                    Value = Conversions.ToDecimal(text);
                }
                else
                {
                    base.Text = text;
                }

                if ((Strings.InStr(text, ".") != 0) & (Strings.InStr(Text, ".") == 0))
                {
                    base.Text = Text.Insert(Text.Length, ".");
                }

                base.SelectionStart = Strings.InStr(Text, ".");
                return true;
            }
        }

        private void InputBackSpace()
        {
            if ((base.SelectionStart == 0) & (SelectionLength == 0))
            {
                return;
            }

            int selectionStart = base.SelectionStart;
            int num = Strings.InStr(Text, "-");
            int num2 = Strings.InStr(Text, ".");
            string text = Text;
            int length = Text.Length;
            int num3 = 0;
            num3 = SelectionLength;
            int num6;
            if (num3 > 0)
            {
                if (SelectionLength == Text.Length)
                {
                    text = "";
                }
                else if (SelectionLength != 0)
                {
                    text = text.Remove(base.SelectionStart, SelectionLength);
                }

                int num4 = Strings.InStr(text, "-");
                int num5 = Strings.InStr(text, ".");
                if (num2 != 0 && num5 == 0 && text.Length > 0 && text.Length > base.SelectionStart)
                {
                    text = text.Insert(base.SelectionStart, ".");
                }

                if ((num != 0 && num4 == 0) & (text.Length > 0))
                {
                    text = text.Insert(0, "-");
                }

                num6 = selectionStart;
            }
            else
            {
                string left = Strings.Mid(text, base.SelectionStart, 1).ToString();
                if (Operators.CompareString(left, "-", TextCompare: false) == 0)
                {
                    base.Text = text;
                    return;
                }

                checked
                {
                    if (Operators.CompareString(left, ".", TextCompare: false) == 0)
                    {
                        if (base.SelectionStart >= 2)
                        {
                            text = text.Remove(base.SelectionStart - 2, 1);
                        }

                        num6 = selectionStart - 2;
                        num2 = Strings.InStr(text, ".");
                        if (num2 == text.Length)
                        {
                            text = text.Remove(num2 - 1);
                        }
                    }
                    else
                    {
                        text = text.Remove(base.SelectionStart - 1, 1);
                        num6 = selectionStart - 1;
                    }
                }
            }

            base.Text = text;
            if (num6 < 0)
            {
                num6 = 0;
            }

            base.SelectionStart = num6;
        }

        private void InputDelete()
        {
            if ((base.SelectionStart == Text.Length) & (SelectionLength == 0))
            {
                return;
            }

            int num = 0;
            int num2 = base.SelectionStart;
            int num3 = Strings.InStr(Text, "-");
            int num4 = Strings.InStr(Text, ".");
            string text = Text;
            int length = Text.Length;
            int num5 = 0;
            checked
            {
                int num6 = Text.Length - base.SelectionStart;
                num5 = SelectionLength;
                int num9;
                if (num5 > 0)
                {
                    if (SelectionLength == Text.Length)
                    {
                        text = "";
                    }
                    else if (SelectionLength != 0)
                    {
                        text = text.Remove(base.SelectionStart, SelectionLength);
                    }

                    int num7 = Strings.InStr(text, "-");
                    int num8 = Strings.InStr(text, ".");
                    if (num4 != 0 && num8 == 0 && text.Length > 0 && text.Length > base.SelectionStart)
                    {
                        text = text.Insert(base.SelectionStart, ".");
                        num = Strings.InStr(SelectedText, ".");
                    }

                    if (unchecked(num3 != 0 && num7 == 0) & (text.Length > 0))
                    {
                        text = text.Insert(0, "-");
                    }

                    num9 = num2;
                }
                else
                {
                    switch (Strings.Mid(text, base.SelectionStart + 1, 1).ToString())
                    {
                        case "-":
                            base.Text = text;
                            return;
                        case ".":
                        case ",":
                            if (num4 != Text.Length)
                            {
                                text = text.Remove(base.SelectionStart + 1, 1);
                                num2++;
                            }

                            break;
                        default:
                            text = text.Remove(base.SelectionStart, 1);
                            break;
                    }

                    if (num2 == Strings.InStr(text, ".") - 1)
                    {
                        num2++;
                    }

                    num9 = num2;
                }

                int num10 = text.Length - text.Replace(",", "").Length;
                text = text.Replace(",", "");
                if (CheckText(text))
                {
                    Value = Conversions.ToDecimal(text);
                }
                else
                {
                    base.Text = text;
                }

                int num11 = Text.Length - Text.Replace(",", "").Length;
                int num12 = num10 - num11;
                if (unchecked(num4 != 0 && num2 > num4))
                {
                    base.SelectionStart = num2;
                }
                else if (num > 0)
                {
                    base.SelectionStart = Strings.InStr(Text, ".") - 1;
                }
                else
                {
                    if (num9 > 0)
                    {
                        num9 -= num12;
                    }

                    if ((num9 == 0) & (Strings.InStr(Text, "-") > 0))
                    {
                        num9++;
                    }

                    base.SelectionStart = num9;
                }

                SelectionLength = 0;
            }
        }

        protected void EnterKeyOff()
        {
            _IsEnterKey = false;
        }

        protected override void WndProc(ref Message m)
        {
            int msg = m.Msg;
            if (msg != 770)
            {
                base.WndProc(ref m);
            }
        }

        protected override void OnCreateControl()
        {
            Value = 0m;
            ContextMenuStrip = new ContextMenuStrip();
            SetMaxLength();
        }

        public override bool CheckValue()
        {
            if (base.IsNeed & (decimal.Compare(Value, 0m) == 0))
            {
                MessageBox.Show(base.ErrMessage_Need, base.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Focus();
                return false;
            }

            return true;
        }
    }
}
