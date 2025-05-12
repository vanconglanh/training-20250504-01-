using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ATDS.UI.Control
{
    public class BaseEdit : BaseText
    {
        private enum KeyWords
        {
            eidai,
            eidaiZ,
            eiko,
            eikoZ,
            suti,
            sutiZ,
            sutikigou,
            sutikigouZ,
            kigou,
            kigouZ,
            nisinsu,
            nisinsuZ,
            jyurokusinsu,
            jyurokusinsuZ,
            katakana,
            katakanaZ,
            hankaku,
            hiragana,
            zenkaku
        }

        public enum Mode : byte
        {
            Only,
            Without
        }

        public enum PadChar : byte
        {
            Off,
            Zero,
            Space
        }

        private const string lcDVErrMessage_NoExist = "存在しないコードです。";

        private const string lcDVErrMessage_Exist = "同一のコードが存在します。";

        private const string lcDVErrMessage_Invalid = "値が不正です。";

        private const string lcDVErrMessage_SelectKey = "キー項目が設定されていません。";

        private const bool lcDVIsCausesValidation = true;

        private const ExistCheckMode lcDVIsCheckExist = ExistCheckMode.Exist;

        private const bool lcDVIsEdit = true;

        private const bool lcDVIsEnterKey = false;

        private const bool lcDVIsMultiLine = false;

        private const bool lcDVIsCancel_Validating = false;

        private const bool lcDVIsCancel_Validated = false;

        private const PadChar lcDVIsPad = PadChar.Off;

        private const string lcDVMojiSyurui = "";

        private const string lcDVLastData = "";

        private const bool lcDVFuriganaRenketu = false;

        private const Mode lcDVMojisyuruiMode = Mode.Only;

        private const string lcCategory = "オリジナル";

        private const string lcDSErrMessage_NoExist = "存在チェックエラー時に表示するメッセージを設定または取得します。(存在しない場合)";

        private const string lcDSErrMessage_Exist = "存在チェックエラー時に表示するメッセージを設定または取得します。(存在する場合)";

        private const string lcDSErrMessage_Invalid = "妥当性チェックエラー時に表示するメッセージを設定または取得します。";

        private const string lcDSErrMessage_SelectKey = "キー項目チェックエラー時に表示するメッセージを設定または取得します。";

        private const string lcDSIsCausesValidation = "Validationイベントを発生させるかどうかを設定または取得します。";

        private const string lcDSIsCheckExist = "存在チェックのモードを設定または取得します。";

        private const string lcDSIsEnterKey = "Enterキーが押されたかどうかを取得します。";

        private const string lcDSIsMultiLine = "複数行にするかどうかを設定または取得します。";

        private const string lcDSIsCancel_Validating = "Validatingイベントがキャンセルされたかどうかを取得します。";

        private const string lcDSIsCancel_Validated = "Validatedイベントがキャンセルされたかどうかを取得します。";

        private const string lcDSSetText_CopySaki = "コピー先のテキストボックスを設定または取得します。";

        private const string lcDSSetText_Edit = "テキストコントロールを設定または取得します。";

        private const string lcDSSetText_Number = "数値コントロールを設定または取得します。";

        private const string lcDSSetText_Date = "日付コントロールを設定または取得します。";

        private const string lcDSSetText_Time = "時間コントロールを設定または取得します。";

        private const string lcDSSetText_CheckBox = "チェックボックスコントロールを設定または取得します。";

        private const string lcDSSetLabel = "ラベルコントロールを設定または取得します。";

        private const string lcDSSetText_Furigana = "フリガナを出力するテキストボックスを設定または取得します。";

        private const string lcDSMojiSyurui = "入力可能な文字種の制限を設定または取得します。\r\nA-英大文字\u3000    H-全ての半角\r\na-英小文字\r\n9-数値のみ        Ｊ-ひらがな\r\n#-数値及び記号 Ｚ-全ての全角\r\n@-記号\r\nB-2進数\r\nX-16進数\r\nk-カタカナ";

        private const string lcDSFuriganaRenketu = "ふりがなの戻り値を設定または取得します。\r\nTrue:連結 False:単品";

        private const string lcDSMojisyuruiMode = "MojiSyuruiの文字指定モード設定または取得します。";

        private const string lcDSIsPad = "MaxLengthまで指定文字で埋めを行うかを設定または取得します。";

        private string _ErrMessage_NoExist;

        private string _ErrMessage_Exist;

        private string _ErrMessage_Invalid;

        private string _ErrMessage_SelectKey;

        private bool _IsCausesValidation;

        private ExistCheckMode _IsCheckExist;

        private bool _IsEdit;

        private bool _IsEnterKey;

        private bool _IsMultiLine;

        private bool _IsCancel_Validating;

        private bool _IsCancel_Validated;

        private BaseEdit _SetText_CopySaki;

        private BaseEdit _SetText_Furigana;

        private PadChar _IsPad;

        private string _MojiSyurui;

        private string _LastData;

        private Mode _MojiSyuruiMode;

        private bool _FuriganaRenketu;

        private string _HintText;

        private BaseEdit[] _SetText_Edit;

        private BaseNumber[] _SetText_Number;

        private BaseDate[] _SetText_Date;

        private BaseTime[] _SetText_Time;

        private BaseCheckBox[] _SetText_CheckBox;

        private BaseLabel[] _SetLabel;

        private bool HaritukeFlag;

        private KeyEventArgs KeyState;

        private bool[] Keys;

        private const int GCL_CONVERSION = 1;

        private const int GCL_REVERSECONVERSION = 2;

        private const int GCS_RESULTREADSTR = 512;

        private const int BEGIN_OFFSET = 6;

        [Category("オリジナル")]
        [Description("入力可能な文字種の制限を設定または取得します。\r\nA-英大文字\u3000    H-全ての半角\r\na-英小文字\r\n9-数値のみ        Ｊ-ひらがな\r\n#-数値及び記号 Ｚ-全ての全角\r\n@-記号\r\nB-2進数\r\nX-16進数\r\nk-カタカナ")]
        public string MojiSyurui
        {
            get
            {
                return _MojiSyurui;
            }
            set
            {
                _MojiSyurui = value;
                SetImeMode();
            }
        }

        [Browsable(false)]
        public string LastData
        {
            get
            {
                return _LastData;
            }
            set
            {
                _LastData = value;
            }
        }

        [Category("オリジナル")]
        [Description("MojiSyuruiの文字指定モード設定または取得します。")]
        public Mode MojiSyuruiMode
        {
            get
            {
                return _MojiSyuruiMode;
            }
            set
            {
                _MojiSyuruiMode = value;
            }
        }

        [Category("オリジナル")]
        [DefaultValue(false)]
        [Description("ふりがなの戻り値を設定または取得します。\r\nTrue:連結 False:単品")]
        public bool FurigaRenketu
        {
            get
            {
                return _FuriganaRenketu;
            }
            set
            {
                _FuriganaRenketu = value;
            }
        }

        [Category("オリジナル")]
        [Description("存在チェックエラー時に表示するメッセージを設定または取得します。(存在する場合)")]
        public string ErrMessage_Exist
        {
            get
            {
                return _ErrMessage_Exist;
            }
            set
            {
                _ErrMessage_Exist = value;
            }
        }

        [Category("オリジナル")]
        [Description("存在チェックエラー時に表示するメッセージを設定または取得します。(存在しない場合)")]
        public string ErrMessage_NoExist
        {
            get
            {
                return _ErrMessage_NoExist;
            }
            set
            {
                _ErrMessage_NoExist = value;
            }
        }

        [Category("オリジナル")]
        [Description("妥当性チェックエラー時に表示するメッセージを設定または取得します。")]
        public string ErrMessage_Invalid
        {
            get
            {
                return _ErrMessage_Invalid;
            }
            set
            {
                _ErrMessage_Invalid = value;
            }
        }

        [Category("オリジナル")]
        [Description("キー項目チェックエラー時に表示するメッセージを設定または取得します。")]
        public string ErrMessage_SelectKey
        {
            get
            {
                return _ErrMessage_SelectKey;
            }
            set
            {
                _ErrMessage_SelectKey = value;
            }
        }

        [Category("オリジナル")]
        [DefaultValue(true)]
        [Description("Validationイベントを発生させるかどうかを設定または取得します。")]
        public bool IsCausesValidation
        {
            get
            {
                return _IsCausesValidation;
            }
            set
            {
                _IsCausesValidation = value;
            }
        }

        [Category("オリジナル")]
        [Description("存在チェックのモードを設定または取得します。")]
        public virtual ExistCheckMode IsCheckExist
        {
            get
            {
                return _IsCheckExist;
            }
            set
            {
                _IsCheckExist = value;
            }
        }

        [Browsable(false)]
        protected bool IsEnterKey => _IsEnterKey;

        [Category("オリジナル")]
        [DefaultValue(false)]
        [Description("複数行にするかどうかを設定または取得します。")]
        public bool IsMultiLine
        {
            get
            {
                return _IsMultiLine;
            }
            set
            {
                _IsMultiLine = value;
                Multiline = value;
                base.AcceptsReturn = !value;
            }
        }

        [Category("オリジナル")]
        [DefaultValue(false)]
        [Description("Validatingイベントがキャンセルされたかどうかを取得します。")]
        public bool IsCancel_Validating
        {
            get
            {
                return _IsCancel_Validating;
            }
            set
            {
                _IsCancel_Validating = value;
            }
        }

        [Category("オリジナル")]
        [DefaultValue(false)]
        [Description("Validatedイベントがキャンセルされたかどうかを取得します。")]
        public bool IsCancel_Validated
        {
            get
            {
                return _IsCancel_Validated;
            }
            set
            {
                _IsCancel_Validated = value;
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
                string text = "";
                text = ((MaxLength == 0) ? value : BaseModule.LeftB(value, MaxLength));
                base.Text = text;
            }
        }

        [Category("オリジナル")]
        [Description("MaxLengthまで指定文字で埋めを行うかを設定または取得します。")]
        public PadChar IsPad
        {
            get
            {
                return _IsPad;
            }
            set
            {
                _IsPad = value;
            }
        }

        [Description("コピー先のテキストボックスを設定または取得します。")]
        public BaseEdit SetText_CopySaki
        {
            get
            {
                return _SetText_CopySaki;
            }
            set
            {
                _SetText_CopySaki = value;
            }
        }

        [Description("フリガナを出力するテキストボックスを設定または取得します。")]
        public BaseEdit SetText_Furigana
        {
            get
            {
                return _SetText_Furigana;
            }
            set
            {
                _SetText_Furigana = value;
            }
        }

        [Description("テキストコントロールを設定または取得します。")]
        //public BaseEdit SetText_Edit 
        //{
        //    get
        //    {
        //        return _SetText_Edit[idx];
        //    }
        //    set
        //    {
        //        _SetText_Edit[idx] = value;
        //    }
        //}
        public BaseEdit SetText_Edit(int idx)
        {
            if (idx < 0 || idx >= _SetText_Edit.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(idx));
            }

            return _SetText_Edit[idx];
        }
        public void SetText_Edit(int idx, BaseEdit baseEdit)
        {
            if (idx < 0 || idx >= _SetText_Edit.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(idx));
            }

            _SetText_Edit[idx] = baseEdit;
        }

        [Description("数値コントロールを設定または取得します。")]
        //public BaseNumber SetText_Number
        //{
        //    get
        //    {
        //        return _SetText_Number[idx];
        //    }
        //    set
        //    {
        //        _SetText_Number[idx] = value;
        //    }
        //}
        public BaseNumber get_SetText_Number(int idx)
        {
            if (idx < 0 || idx >= _SetText_Number.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(idx));
            }

            return _SetText_Number[idx];
        }

        [Description("日付コントロールを設定または取得します。")]
        //public BaseDate SetText_Date
        //{
        //    get
        //    {
        //        return _SetText_Date[idx];
        //    }
        //    set
        //    {
        //        _SetText_Date[idx] = value;
        //    }
        //}
        public BaseDate get_SetText_Date(int idx)
        {
            if (idx < 0 || idx >= _SetText_Date.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(idx));
            }

            return _SetText_Date[idx];
        }

        [Description("時間コントロールを設定または取得します。")]
        //public BaseTime SetText_Time
        //{
        //    get
        //    {
        //        return _SetText_Time[idx];
        //    }
        //    set
        //    {
        //        _SetText_Time[idx] = value;
        //    }
        //}
        public BaseTime get_SetText_Time(int idx)
        {
            if (idx < 0 || idx >= _SetText_Time.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(idx));
            }

            return _SetText_Time[idx];
        }

        [Description("チェックボックスコントロールを設定または取得します。")]
        //public BaseCheckBox SetText_CheckBox
        //{
        //    get
        //    {
        //        return _SetText_CheckBox[idx];
        //    }
        //    set
        //    {
        //        _SetText_CheckBox[idx] = value;
        //    }
        //}
        public BaseCheckBox get_SetText_CheckBox(int idx)
        {
            if (idx < 0 || idx >= _SetText_CheckBox.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(idx));
            }

            return _SetText_CheckBox[idx];
        }

        [Description("ラベルコントロールを設定または取得します。")]
        //public BaseLabel SetLabel
        //{
        //    get
        //    {
        //        return _SetLabel[idx];
        //    }
        //    set
        //    {
        //        _SetLabel[idx] = value;
        //    }
        //}
        public BaseLabel get_SetLabel(int idx)
        {
            if (idx < 0 || idx >= _SetLabel.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(idx));
            }

            return _SetLabel[idx];
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

        public BaseEdit()
        {
            base.KeyDown += BaseEdit_KeyDown;
            base.Validating += BaseEdit_Validating;
            base.Validated += BaseEdit_Validated;
            base.Enter += BaseEdit_Enter;
            base.Leave += BaseEdit_Leave;
            _ErrMessage_NoExist = "存在しないコードです。";
            _ErrMessage_Exist = "同一のコードが存在します。";
            _ErrMessage_Invalid = "値が不正です。";
            _ErrMessage_SelectKey = "キー項目が設定されていません。";
            _IsCausesValidation = true;
            _IsCheckExist = ExistCheckMode.Exist;
            _IsEdit = true;
            _IsEnterKey = false;
            _IsMultiLine = false;
            _IsCancel_Validating = false;
            _IsCancel_Validated = false;
            _MojiSyurui = "";
            _LastData = "";
            _MojiSyuruiMode = Mode.Only;
            _FuriganaRenketu = false;
            _HintText = "";
            Keys = new bool[19];
        }

        [DllImport("imm32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr ImmGetContext(IntPtr Handle);

        [DllImport("imm32.dll", CharSet = CharSet.Ansi, EntryPoint = "ImmGetCompositionStringA", ExactSpelling = true, SetLastError = true)]
        private static extern int ImmGetCompositionString(IntPtr hIMC, int dwIndex, byte[] strBuffer, int dwBufLen);

        [DllImport("imm32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern int ImmReleaseContext(IntPtr Handle, IntPtr hIMC);

        protected virtual bool ShouldSerializeMojiSyurui()
        {
            return !MojiSyurui.Equals("");
        }

        protected virtual bool ShouldSerializeLastData()
        {
            return !LastData.Equals("");
        }

        protected virtual bool ShouldSerializeMojiSyuruiMode()
        {
            return !MojiSyuruiMode.Equals(Mode.Only);
        }

        protected virtual bool ShouldSerializeErrMessage_Exist()
        {
            return !ErrMessage_Exist.Equals("同一のコードが存在します。");
        }

        protected virtual bool ShouldSerializeErrMessage_NoExist()
        {
            return !ErrMessage_NoExist.Equals("存在しないコードです。");
        }

        protected virtual bool ShouldSerializeErrMessage_Invalid()
        {
            return !ErrMessage_Invalid.Equals("値が不正です。");
        }

        protected virtual bool ShouldSerializeErrMessage_SelectKey()
        {
            return !ErrMessage_SelectKey.Equals("キー項目が設定されていません。");
        }

        protected virtual bool ShouldSerializeIsCheckExist()
        {
            return !IsCheckExist.Equals(ExistCheckMode.Exist);
        }

        protected virtual bool ShouldSerializeIsPad()
        {
            return !IsPad.Equals(PadChar.Off);
        }

        private bool ShouldSerializeSetText_CopySaki()
        {
            return SetText_CopySaki != null;
        }

        private bool ShouldSerializeSetText_Furigana()
        {
            return SetText_Furigana != null;
        }

        private bool ShouldSerializeSetText_Edit(int idx)
        {
            return _SetText_Edit[idx] != null;
        }

        private bool ShouldSerializeSetText_Number(int idx)
        {
            return _SetText_Edit[idx] != null;
        }

        private bool ShouldSerializeSetText_Date(int idx)
        {
            return _SetText_Date[idx] != null;
        }

        private bool ShouldSerializeSetText_Time(int idx)
        {
            return _SetText_Time[idx] != null;
        }

        private bool ShouldSerializeSetText_CheckBox(int idx)
        {
            return _SetText_CheckBox[idx] != null;
        }

        private bool ShouldSerializeSetLabel(int idx)
        {
            return _SetLabel[idx] != null;
        }

        protected virtual bool ShouldSerializeHintText()
        {
            return !HintText.Equals("");
        }

        private void BaseEdit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                base.ReadOnly = false;
                switch (e.KeyCode)
                {
                    case System.Windows.Forms.Keys.Return:
                        _IsEnterKey = true;
                        break;
                    case System.Windows.Forms.Keys.F3:
                        if (base.IsUseFunctionKey)
                        {
                            ShowSearch();
                        }

                        break;
                    case System.Windows.Forms.Keys.Space:
                        if (base.IsSearch_SpaceKey)
                        {
                            ShowSearch();
                        }

                        break;
                    case System.Windows.Forms.Keys.Back:
                        KeyState = e;
                        break;
                    default:
                        KeyState = null;
                        break;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                MessageBox.Show(ex2.Message, base.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ProjectData.ClearProjectError();
            }
            finally
            {
            }
        }

        private void BaseEdit_Validating(object sender, CancelEventArgs e)
        {
            if (Operators.CompareString(Text, "", TextCompare: false) != 0)
            {
                switch (IsPad)
                {
                    case PadChar.Space:
                        Text = Text.PadLeft(MaxLength, ' ');
                        break;
                    case PadChar.Zero:
                        Text = Text.PadLeft(MaxLength, '0');
                        break;
                }
            }
        }

        private void BaseEdit_Validated(object sender, EventArgs e)
        {
            _IsCancel_Validated = false;
            if (_IsEnterKey)
            {
                _IsCancel_Validated = !CheckValue();
            }

            _IsEnterKey = false;
            if (!Information.IsNothing(_SetText_CopySaki) && Operators.CompareString(_SetText_CopySaki.Text, "", TextCompare: false) == 0)
            {
                _SetText_CopySaki.Text = Text;
            }

            if ((Operators.CompareString(Text, "", TextCompare: false) == 0) & (_SetText_Furigana != null))
            {
                _SetText_Furigana.Text = "";
            }
        }

        private void BaseEdit_Enter(object sender, EventArgs e)
        {
            BackColor = Color.MistyRose;
            if (base.InputMode == InputModeEnum.OverWrite)
            {
                SelectAll();
            }
            else
            {
                base.SelectionStart = Text.Length;
            }

            if (Operators.CompareString(HintText, "", TextCompare: false) == 0)
            {
            }
        }

        public void BaseEdit_Leave(object sender, EventArgs e)
        {
            BackColor = SystemColors.Window;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 258:
                    {
                        KeyPressEventArgs keyPressEventArgs = new KeyPressEventArgs(Strings.ChrW(m.WParam.ToInt32()));
                        OnChar(keyPressEventArgs);
                        if (keyPressEventArgs.Handled)
                        {
                            return;
                        }

                        break;
                    }
                case 770:
                    HaritukeFlag = true;
                    if (checked(MaxLength * 2) > MaxLength)
                    {
                        OnPaste(new EventArgs());
                        return;
                    }

                    if (_MojiSyurui != null && _MojiSyurui.Length > 0)
                    {
                        OnPaste(new EventArgs());
                        return;
                    }

                    if (!base.AllowSpace)
                    {
                        OnPaste(new EventArgs());
                        return;
                    }

                    break;
                case 270:
                    SetFurigana();
                    break;
            }

            base.WndProc(ref m);
        }

        protected virtual void OnPaste(EventArgs e)
        {
            object objectValue = RuntimeHelpers.GetObjectValue(Clipboard.GetDataObject().GetData(DataFormats.Text));
            if (objectValue == null)
            {
                return;
            }

            string strTarget = Clipboard.GetDataObject().GetData(DataFormats.Text).ToString();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding("Shift_JIS");
            string permitedString = GetPermitedString(strTarget);
            int byteCount = encoding.GetByteCount(Text);
            int byteCount2 = encoding.GetByteCount(permitedString);
            int byteCount3 = encoding.GetByteCount(SelectedText);
            int num = checked(MaxLength - (byteCount - byteCount3));
            if (MaxLength == 0 || num > 0)
            {
                if ((num >= byteCount2) | (MaxLength == 0))
                {
                    SelectedText = permitedString;
                }
                else
                {
                    SelectedText = BaseModule.LeftB(permitedString, num);
                }
            }
        }

        protected virtual bool CheckValueEx()
        {
            return true;
        }

        protected virtual bool CheckExist()
        {
            return true;
        }

        protected virtual bool CheckSelectKey()
        {
            return true;
        }

        protected void EnterKeyOff()
        {
            _IsEnterKey = false;
        }

        protected virtual void ShowSearch()
        {
        }

        private void OnChar(KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            HaritukeFlag = false;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding("Shift_JIS");
            int byteCount = encoding.GetByteCount(Text);
            int byteCount2 = encoding.GetByteCount(e.KeyChar.ToString());
            int byteCount3 = encoding.GetByteCount(SelectedText);
            string text = "";
            if ((checked(byteCount + byteCount2 - byteCount3) > MaxLength) & (MaxLength != 0))
            {
                e.Handled = true;
                return;
            }

            text = GetPermissionChar(e.KeyChar);
            if (Operators.CompareString(text, "", TextCompare: false) != 0)
            {
                SelectedText = text;
                e.Handled = true;
            }

            if (!HasPermitChars(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool HasPermitChars(char chTarget)
        {
            bool result = false;
            if (Operators.CompareString(_MojiSyurui, "", TextCompare: false) == 0)
            {
                return true;
            }

            bool flag = true;
            if (flag == Regex.IsMatch(Conversions.ToString(chTarget), "^[Ａ-Ｆ]$"))
            {
                if (MojiSyuruiMode == Mode.Only)
                {
                    if (Keys[1] | Keys[13] | Keys[18])
                    {
                        result = true;
                    }
                }
                else if (!Keys[1] & !Keys[13] & !Keys[18])
                {
                    result = true;
                }
            }
            else if (flag == Regex.IsMatch(Conversions.ToString(chTarget), "^[A-F]$"))
            {
                if (MojiSyuruiMode == Mode.Only)
                {
                    if (Keys[0] | Keys[12] | Keys[16])
                    {
                        result = true;
                    }
                }
                else if (!Keys[0] & !Keys[12] & !Keys[16])
                {
                    result = true;
                }
            }
            else if (flag == Regex.IsMatch(Conversions.ToString(chTarget), "^[ａ-ｆ]$"))
            {
                if (MojiSyuruiMode == Mode.Only)
                {
                    if (Keys[3] | Keys[13] | Keys[18])
                    {
                        result = true;
                    }
                }
                else if (!Keys[3] & !Keys[13] & !Keys[18])
                {
                    result = true;
                }
            }
            else if (flag == Regex.IsMatch(Conversions.ToString(chTarget), "^[a-f]$"))
            {
                if (MojiSyuruiMode == Mode.Only)
                {
                    if (Keys[2] | Keys[12] | Keys[16])
                    {
                        result = true;
                    }
                }
                else if (!Keys[2] & !Keys[12] & !Keys[16])
                {
                    result = true;
                }
            }
            else if (flag == Regex.IsMatch(Conversions.ToString(chTarget), "^[Ｇ-Ｚ]$"))
            {
                if (MojiSyuruiMode == Mode.Only)
                {
                    if (Keys[1] | Keys[18])
                    {
                        result = true;
                    }
                }
                else if (!Keys[1] & !Keys[18])
                {
                    result = true;
                }
            }
            else if (flag == Regex.IsMatch(Conversions.ToString(chTarget), "^[G-Z]$"))
            {
                if (MojiSyuruiMode == Mode.Only)
                {
                    if (Keys[0] | Keys[16])
                    {
                        result = true;
                    }
                }
                else if (!Keys[0] & !Keys[16])
                {
                    result = true;
                }
            }
            else if (flag == Regex.IsMatch(Conversions.ToString(chTarget), "^[ｇ-ｚ]$"))
            {
                if (MojiSyuruiMode == Mode.Only)
                {
                    if (Keys[3] | Keys[18])
                    {
                        result = true;
                    }
                }
                else if (!Keys[3] & !Keys[18])
                {
                    result = true;
                }
            }
            else if (flag == Regex.IsMatch(Conversions.ToString(chTarget), "^[g-z]$"))
            {
                if (MojiSyuruiMode == Mode.Only)
                {
                    if (Keys[2] | Keys[16])
                    {
                        result = true;
                    }
                }
                else if (!Keys[2] & !Keys[16])
                {
                    result = true;
                }
            }
            else if (flag == Regex.IsMatch(Conversions.ToString(chTarget), "^[０-１]$"))
            {
                if (MojiSyuruiMode == Mode.Only)
                {
                    if (Keys[5] | Keys[11] | Keys[7] | Keys[13] | Keys[18])
                    {
                        result = true;
                    }
                }
                else if (!Keys[5] & !Keys[11] & !Keys[7] & !Keys[13] & !Keys[18])
                {
                    result = true;
                }
            }
            else if (flag == Regex.IsMatch(Conversions.ToString(chTarget), "^[0-1]$"))
            {
                if (MojiSyuruiMode == Mode.Only)
                {
                    if (Keys[4] | Keys[10] | Keys[6] | Keys[12] | Keys[16])
                    {
                        result = true;
                    }
                }
                else if (!Keys[4] & !Keys[10] & !Keys[6] & !Keys[12] & !Keys[16])
                {
                    result = true;
                }
            }
            else if (flag == Regex.IsMatch(Conversions.ToString(chTarget), "^[２-９]$"))
            {
                if (MojiSyuruiMode == Mode.Only)
                {
                    if (Keys[5] | Keys[7] | Keys[13] | Keys[18])
                    {
                        result = true;
                    }
                }
                else if (!Keys[5] & !Keys[7] & !Keys[13] & !Keys[18])
                {
                    result = true;
                }
            }
            else if (flag == Regex.IsMatch(Conversions.ToString(chTarget), "^[2-9]$"))
            {
                if (MojiSyuruiMode == Mode.Only)
                {
                    if (Keys[4] | Keys[6] | Keys[12] | Keys[16])
                    {
                        result = true;
                    }
                }
                else if (!Keys[4] & !Keys[6] & !Keys[12] & !Keys[16])
                {
                    result = true;
                }
            }
            else if (flag == (Regex.IsMatch(Conversions.ToString(chTarget), "^\\p{IsHiragana}*$") | Regex.IsMatch(Conversions.ToString(chTarget), "^[～]$")))
            {
                if (MojiSyuruiMode == Mode.Only)
                {
                    if (Keys[17] | Keys[18])
                    {
                        result = true;
                    }
                }
                else if (!Keys[17] & !Keys[18])
                {
                    result = true;
                }
            }
            else if (flag == Regex.IsMatch(Conversions.ToString(chTarget), "^\\p{IsCJKUnifiedIdeographs}*$"))
            {
                if (MojiSyuruiMode == Mode.Only)
                {
                    if (Keys[18])
                    {
                        result = true;
                    }
                }
                else if (!Keys[18])
                {
                    result = true;
                }
            }
            else if (flag == Regex.IsMatch(Conversions.ToString(chTarget), "^\\p{IsKatakana}*$"))
            {
                if (MojiSyuruiMode == Mode.Only)
                {
                    if (Keys[15] | Keys[18])
                    {
                        result = true;
                    }
                }
                else if (!Keys[15] & !Keys[18])
                {
                    result = true;
                }
            }
            else if (flag == Regex.IsMatch(Conversions.ToString(chTarget), "^[ｦ-ﾟ]$"))
            {
                if (MojiSyuruiMode == Mode.Only)
                {
                    if (Keys[14] | Keys[16])
                    {
                        result = true;
                    }
                }
                else if (!Keys[14] & !Keys[16])
                {
                    result = true;
                }
            }
            else if (flag == Regex.IsMatch(Conversions.ToString(chTarget), "^[+\\-$%\\\\,.]$"))
            {
                if (MojiSyuruiMode == Mode.Only)
                {
                    if (Keys[6] | Keys[16] | Keys[8])
                    {
                        result = true;
                    }
                }
                else if (!Keys[6] & !Keys[16] & !Keys[8])
                {
                    result = true;
                }
            }
            else if (flag == Regex.IsMatch(Conversions.ToString(chTarget), "^[＋－＄％￥，．]$"))
            {
                if (MojiSyuruiMode == Mode.Only)
                {
                    if (Keys[7] | Keys[18] | Keys[9])
                    {
                        result = true;
                    }
                }
                else if (!Keys[7] & !Keys[18] & !Keys[9])
                {
                    result = true;
                }
            }
            else if (MojiSyuruiMode == Mode.Only)
            {
                if (BaseModule.LenB(Conversions.ToString(chTarget)) == 2)
                {
                    if (Keys[9] | Keys[18])
                    {
                        result = true;
                    }
                }
                else if (Keys[8] | Keys[16])
                {
                    result = true;
                }
            }
            else if (BaseModule.LenB(Conversions.ToString(chTarget)) == 2)
            {
                if (!Keys[9] & !Keys[18])
                {
                    result = true;
                }
            }
            else if (!Keys[8] & !Keys[16])
            {
                result = true;
            }

            return result;
        }

        private string GetPermitedString(string strTarget)
        {
            string text = "";
            foreach (char c in strTarget)
            {
                text = ((!HasPermitChars(c)) ? (text + GetPermissionChar(c)) : (text + Conversions.ToString(c)));
            }

            return text;
        }

        private void SetFurigana()
        {
            string text = "";
            if (Information.IsNothing(_SetText_Furigana))
            {
                return;
            }

            text = GetFurigana();
            if (Operators.CompareString(_SetText_Furigana.MojiSyurui, "", TextCompare: false) != 0)
            {
                switch (_SetText_Furigana.MojiSyurui[0])
                {
                    case 'Ｊ':
                        text = Strings.StrConv(text, VbStrConv.Wide);
                        text = Strings.StrConv(text, VbStrConv.Hiragana);
                        break;
                    case 'Ｋ':
                        text = Strings.StrConv(text, VbStrConv.Wide);
                        break;
                }
            }

            if (_FuriganaRenketu)
            {
                _SetText_Furigana.Text += text;
            }
            else
            {
                _SetText_Furigana.Text = text;
            }
        }

        private string GetFurigana()
        {
            string result = "";
            try
            {
                if (_FuriganaRenketu && KeyState != null && KeyState.KeyCode == System.Windows.Forms.Keys.Back)
                {
                    return "";
                }

                IntPtr hIMC = ImmGetContext(base.Handle);
                byte[] array = new byte[65];
                int num = ImmGetCompositionString(hIMC, 512, array, array.Length);
                ImmReleaseContext(base.Handle, hIMC);
                if (num != 0)
                {
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    result = Encoding.GetEncoding("Shift_JIS").GetString(array, 0, num);
                }

                return result;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Interaction.MsgBox(ex2.ToString());
                throw;
            }
            finally
            {
                IntPtr hIMC = default(IntPtr);
                byte[] array = null;
            }
        }

        private void SetImeMode()
        {
            int i = default(int);
            bool flag2 = default(bool);
            bool flag6 = default(bool);
            bool flag4 = default(bool);
            bool flag3 = default(bool);
            bool flag = default(bool);
            for (Keys = new bool[19]; i != _MojiSyurui.Length; i = checked(i + 1))
            {
                switch (_MojiSyurui[i])
                {
                    case 'A':
                        Keys[0] = true;
                        flag2 = true;
                        break;
                    case 'Ａ':
                        Keys[1] = true;
                        flag6 = true;
                        break;
                    case 'a':
                        Keys[2] = true;
                        flag2 = true;
                        break;
                    case 'ａ':
                        Keys[3] = true;
                        flag6 = true;
                        break;
                    case '9':
                        Keys[4] = true;
                        flag2 = true;
                        break;
                    case '９':
                        {
                            Keys[5] = true;
                            bool flag5 = true;
                            break;
                        }
                    case '#':
                        Keys[6] = true;
                        flag2 = true;
                        break;
                    case '＃':
                        {
                            Keys[7] = true;
                            bool flag5 = true;
                            break;
                        }
                    case '@':
                        Keys[8] = true;
                        flag2 = true;
                        break;
                    case '＠':
                        {
                            Keys[9] = true;
                            bool flag5 = true;
                            break;
                        }
                    case 'B':
                        Keys[10] = true;
                        flag2 = true;
                        break;
                    case 'Ｂ':
                        {
                            Keys[11] = true;
                            bool flag5 = true;
                            break;
                        }
                    case 'X':
                        Keys[12] = true;
                        flag2 = true;
                        break;
                    case 'Ｘ':
                        {
                            Keys[13] = true;
                            bool flag5 = true;
                            break;
                        }
                    case 'K':
                        Keys[14] = true;
                        flag4 = true;
                        break;
                    case 'Ｋ':
                        Keys[15] = true;
                        flag3 = true;
                        break;
                    case 'H':
                        Keys[16] = true;
                        flag2 = true;
                        break;
                    case 'Ｊ':
                        Keys[17] = true;
                        flag = true;
                        break;
                    case 'Ｚ':
                        Keys[18] = true;
                        flag = true;
                        break;
                }
            }

            base.ImeMode = ImeMode.On;
            if (MojiSyuruiMode == Mode.Only)
            {
                bool flag7 = true;
                if (flag7 == flag)
                {
                    base.ImeMode = ImeMode.Hiragana;
                }
                else if (flag7 == flag6)
                {
                    base.ImeMode = ImeMode.AlphaFull;
                }
                else if (flag7 == flag3)
                {
                    base.ImeMode = ImeMode.Katakana;
                }
                else if (flag7 == flag4)
                {
                    base.ImeMode = ImeMode.KatakanaHalf;
                }
                else if (flag7 == flag2)
                {
                    base.ImeMode = ImeMode.Disable;
                }
            }
            else
            {
                bool flag8 = true;
                if (flag8 == Keys[18])
                {
                    base.ImeMode = ImeMode.Disable;
                }
                else if (flag8 == Keys[16])
                {
                    base.ImeMode = ImeMode.Hiragana;
                }
            }
        }

        private void Init()
        {
        }

        private string GetPermissionChar(char chrTarget)
        {
            string result = "";
            if (BaseModule.LenB(Conversions.ToString(chrTarget)) == 2)
            {
                bool flag = true;
                if (flag == char.IsLower(chrTarget))
                {
                    if (MojiSyuruiMode == Mode.Only)
                    {
                        if (Keys[1] & !Keys[3] & !Keys[13] & !Keys[18])
                        {
                            result = Conversions.ToString(char.ToUpper(chrTarget));
                        }
                    }
                    else if (!Keys[1] & Keys[3] & !Keys[18])
                    {
                        result = Conversions.ToString(char.ToUpper(chrTarget));
                    }
                }
                else if (flag == char.IsUpper(chrTarget))
                {
                    if (MojiSyuruiMode == Mode.Only)
                    {
                        if (!Keys[1] & Keys[3] & !Keys[13] & !Keys[18])
                        {
                            result = Conversions.ToString(char.ToLower(chrTarget));
                        }
                    }
                    else if (Keys[1] & !Keys[3] & !Keys[18])
                    {
                        result = Conversions.ToString(char.ToLower(chrTarget));
                    }
                }
                else if (flag == Regex.IsMatch(Conversions.ToString(chrTarget), "^\\p{IsKatakana}*$"))
                {
                    if (MojiSyuruiMode == Mode.Only)
                    {
                        if (Keys[14] & !Keys[15])
                        {
                            result = Strings.StrConv(Conversions.ToString(chrTarget), VbStrConv.Narrow);
                        }
                        else if (Keys[17] & !Keys[14] & !Keys[15])
                        {
                            result = Strings.StrConv(Conversions.ToString(chrTarget), VbStrConv.Hiragana);
                        }
                    }
                    else if (!Keys[14] & Keys[15])
                    {
                        result = Strings.StrConv(Conversions.ToString(chrTarget), VbStrConv.Narrow);
                    }
                    else if (!Keys[17] & Keys[14] & Keys[15])
                    {
                        result = Strings.StrConv(Conversions.ToString(chrTarget), VbStrConv.Hiragana);
                    }
                }
                else if (flag == Regex.IsMatch(Conversions.ToString(chrTarget), "^\\p{IsHiragana}*$"))
                {
                    if (MojiSyuruiMode == Mode.Only)
                    {
                        if (Keys[14] & !Keys[15])
                        {
                            result = Strings.StrConv(Conversions.ToString(chrTarget), VbStrConv.Katakana);
                            result = Strings.StrConv(result, VbStrConv.Narrow);
                        }
                        else if (!Keys[14] & Keys[15])
                        {
                            result = Strings.StrConv(Conversions.ToString(chrTarget), VbStrConv.Katakana);
                        }
                    }
                    else if (!Keys[14] & Keys[15] & Keys[17])
                    {
                        result = Strings.StrConv(Conversions.ToString(chrTarget), VbStrConv.Katakana);
                        result = Strings.StrConv(result, VbStrConv.Narrow);
                    }
                    else if (Keys[14] & !Keys[15] & Keys[17])
                    {
                        result = Strings.StrConv(Conversions.ToString(chrTarget), VbStrConv.Katakana);
                    }
                }
            }
            else
            {
                bool flag2 = true;
                if (flag2 == char.IsLower(chrTarget))
                {
                    if (MojiSyuruiMode == Mode.Only)
                    {
                        if (Keys[0] & !Keys[2] & !Keys[12] & !Keys[16])
                        {
                            result = Conversions.ToString(char.ToUpper(chrTarget));
                        }
                    }
                    else if (!Keys[0] & Keys[2] & !Keys[16])
                    {
                        result = Conversions.ToString(char.ToUpper(chrTarget));
                    }
                }
                else if (flag2 == char.IsUpper(chrTarget))
                {
                    if (MojiSyuruiMode == Mode.Only)
                    {
                        if (!Keys[0] & Keys[2] & !Keys[12] & !Keys[16])
                        {
                            result = Conversions.ToString(char.ToLower(chrTarget));
                        }
                    }
                    else if (Keys[0] & !Keys[2] & !Keys[16])
                    {
                        result = Conversions.ToString(char.ToLower(chrTarget));
                    }
                }
                else if (flag2 == Regex.IsMatch(Conversions.ToString(chrTarget), "^[ｦ-ﾟ]$"))
                {
                    if (MojiSyuruiMode == Mode.Only)
                    {
                        if (!Keys[14] & Keys[15])
                        {
                            result = Strings.StrConv(Conversions.ToString(chrTarget), VbStrConv.Wide);
                        }
                        else if (Keys[17] & !Keys[14] & !Keys[15])
                        {
                            result = Strings.StrConv(Conversions.ToString(chrTarget), VbStrConv.Wide);
                            result = Strings.StrConv(result, VbStrConv.Hiragana);
                        }
                    }
                    else if (Keys[14] & !Keys[15])
                    {
                        result = Strings.StrConv(Conversions.ToString(chrTarget), VbStrConv.Wide);
                    }
                    else if (!Keys[17] & Keys[14] & Keys[15])
                    {
                        result = Strings.StrConv(Conversions.ToString(chrTarget), VbStrConv.Wide);
                        result = Strings.StrConv(result, VbStrConv.Hiragana);
                    }
                }
            }

            return result;
        }

        public override bool CheckValue()
        {
            if (base.IsNeed & (Operators.CompareString(Strings.Trim(Text), "", TextCompare: false) == 0))
            {
                MessageBox.Show(base.ErrMessage_Need, base.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Focus();
                return false;
            }

            if ((Operators.CompareString(Text, "", TextCompare: false) != 0) & !CheckSelectKey())
            {
                MessageBox.Show(_ErrMessage_SelectKey, base.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Focus();
                return false;
            }

            if ((Operators.CompareString(Text, "", TextCompare: false) != 0) & !CheckExist())
            {
                switch (IsCheckExist)
                {
                    case ExistCheckMode.Exist:
                        MessageBox.Show(_ErrMessage_NoExist, base.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case ExistCheckMode.NoExist:
                        MessageBox.Show(_ErrMessage_Exist, base.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                }

                Focus();
                return false;
            }

            if (!CheckValueEx())
            {
                Focus();
                return false;
            }

            return true;
        }

        public void SetLength_Edit(int len)
        {
            _SetText_Edit = new BaseEdit[checked(len + 1)];
        }

        public void SetLength_Number(int len)
        {
            _SetText_Number = new BaseNumber[checked(len + 1)];
        }

        public void SetLength_Date(int len)
        {
            _SetText_Date = new BaseDate[checked(len + 1)];
        }

        public void SetLength_Time(int len)
        {
            _SetText_Time = new BaseTime[checked(len + 1)];
        }

        public void SetLength_CheckBox(int len)
        {
            _SetText_CheckBox = new BaseCheckBox[checked(len + 1)];
        }

        public void SetLength_Label(int len)
        {
            _SetLabel = new BaseLabel[checked(len + 1)];
        }

        public int GetLength_Edit()
        {
            return _SetText_Edit.Length;
        }

        public int GetLength_Number()
        {
            return _SetText_Number.Length;
        }

        public int GetLength_Date()
        {
            return _SetText_Date.Length;
        }

        public int GetLength_Time()
        {
            return _SetText_Time.Length;
        }

        public int GetLength_CheckBox()
        {
            return _SetText_CheckBox.Length;
        }

        public int GetLength_Label()
        {
            return _SetLabel.Length;
        }

        public void Clear_Edit()
        {
            if (Information.IsNothing(_SetText_Edit))
            {
                return;
            }

            checked
            {
                int num = GetLength_Edit() - 1;
                for (int i = 0; i <= num; i++)
                {
                    if (!Information.IsNothing(this.SetText_Edit(i)))
                    {
                        this.SetText_Edit(i).Text = "";
                    }
                }
            }
        }

        public void Clear_Number()
        {
            if (Information.IsNothing(_SetText_Number))
            {
                return;
            }

            checked
            {
                int num = GetLength_Number() - 1;
                for (int i = 0; i <= num; i++)
                {
                    if (!Information.IsNothing(this.get_SetText_Number(i)))
                    {
                        this.get_SetText_Number(i).Value = this.get_SetText_Number(i).DefaultValue;
                    }
                }
            }
        }

        public void Clear_Date()
        {
            if (Information.IsNothing(_SetText_Date))
            {
                return;
            }

            checked
            {
                int num = GetLength_Date() - 1;
                for (int i = 0; i <= num; i++)
                {
                    if (!Information.IsNothing(this.get_SetText_Date(i)))
                    {
                        this.get_SetText_Date(i).SetItem();
                    }
                }
            }
        }

        public void Clear_Time()
        {
            if (Information.IsNothing(_SetText_Time))
            {
                return;
            }

            checked
            {
                int num = GetLength_Time() - 1;
                for (int i = 0; i <= num; i++)
                {
                    if (!Information.IsNothing(this.get_SetText_Time(i)))
                    {
                        this.get_SetText_Time(i).TimeString = "";
                    }
                }
            }
        }

        public void Clear_CheckBox()
        {
            if (Information.IsNothing(_SetText_CheckBox))
            {
                return;
            }

            checked
            {
                int num = GetLength_CheckBox() - 1;
                for (int i = 0; i <= num; i++)
                {
                    if (!Information.IsNothing(this.get_SetText_CheckBox(i)))
                    {
                        this.get_SetText_CheckBox(i).Checked = false;
                    }
                }
            }
        }

        public void Clear_Label()
        {
            checked
            {
                int num = GetLength_Label() - 1;
                for (int i = 0; i <= num; i++)
                {
                    if (!Information.IsNothing(this.get_SetLabel(i)))
                    {
                        this.get_SetLabel(i).Text = "";
                    }
                }
            }
        }

        public void Clear_SetText()
        {
            Clear_Edit();
            Clear_Number();
            Clear_Date();
            Clear_Time();
            Clear_CheckBox();
        }
    }
}
