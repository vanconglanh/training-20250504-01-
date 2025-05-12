using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ATDS.UI.Control
{
    public abstract class BaseText : TextBox
    {
        public enum InputModeEnum : byte
        {
            Insert,
            OverWrite
        }

        private const bool lcDVIsNeed = false;

        private const bool lcDVIsIndicate = false;

        private const bool lcDVIsNextControl = false;

        private const InputModeEnum lcDVInputMode = InputModeEnum.OverWrite;

        private const bool lcDVAllowSpace = true;

        private const string lcDVMsgTitle = "テキスト";

        private const string lcDVErrMessage_Need = "必須です。";

        private const bool lcDVIsUseFunctionKey = false;

        private const bool lcDVIsSearch_SpaceKey = true;

        private const string lcCategory = "オリジナル";

        private const string lcDSIsNeed = "必須項目かどうかを設定または取得します。";

        private const string lcDSInputMode = "フォーカス時の入力モードを選択します。\r\nInsert:挿入 OverWrite:上書";

        private const string lcDSIsIndicate = "表示用コントロールかを設定します。\r\nTrue:表示用(編集不可) False :入力用";

        private const string lcDSIsNextControl = "Enterキーで次の項目に移動するかを設定します。\r\nTrue:有効 False :無効";

        private const string lcDSAllowSpace = "スペース入力の可否を設定します。\r\nTrue:可 False:不可";

        private const string lcDSErrMessage_Need = "必須チェックエラー時に表示するメッセージを設定または取得します。";

        private const string lcDSMsgTitle = "メッセージボックスのタイトルを設定または取得します。";

        private const string lcDSIsUseFunctionKey = "ファンクションキーの使用可否を設定します。\r\nTrue:有効 False :無効";

        private const string lcDSIsSearch_SpaceKey = "スペースキーでの検索使用可否を設定します。\r\nTrue:有効 False :無効";

        private const int WndProc_LButtonDown = 513;

        private const int WndProc_RButtonDown = 516;

        private const int WndProc_KeyDown = 258;

        private const int WndProc_SetCursor = 32;

        private bool _IsNextControl;

        private bool _IsIndicate;

        private InputModeEnum _InputMode;

        private bool _IsNeed;

        private bool _AllowSpace;

        private string _MsgTitle;

        private string _ErrMessage_Need;

        private bool _IsUseFunctionKey;

        private bool _IsSearch_SpaceKey;

        private bool blnEnterFlag;

        [Category("オリジナル")]
        [Description("フォーカス時の入力モードを選択します。\r\nInsert:挿入 OverWrite:上書")]
        public InputModeEnum InputMode
        {
            get
            {
                return _InputMode;
            }
            set
            {
                _InputMode = value;
            }
        }

        [Category("オリジナル")]
        [Description("Enterキーで次の項目に移動するかを設定します。\r\nTrue:有効 False :無効")]
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
        [DefaultValue(false)]
        [Description("表示用コントロールかを設定します。\r\nTrue:表示用(編集不可) False :入力用")]
        public bool IsIndicate
        {
            get
            {
                return _IsIndicate;
            }
            set
            {
                _IsIndicate = value;
                InitIndicate();
            }
        }

        [Category("オリジナル")]
        [Description("ファンクションキーの使用可否を設定します。\r\nTrue:有効 False :無効")]
        public bool IsUseFunctionKey
        {
            get
            {
                return _IsUseFunctionKey;
            }
            set
            {
                _IsUseFunctionKey = value;
            }
        }

        [Category("オリジナル")]
        [DefaultValue(false)]
        [Description("必須項目かどうかを設定または取得します。")]
        public bool IsNeed
        {
            get
            {
                return _IsNeed;
            }
            set
            {
                _IsNeed = value;
            }
        }

        [Category("オリジナル")]
        [Description("スペースキーでの検索使用可否を設定します。\r\nTrue:有効 False :無効")]
        public bool IsSearch_SpaceKey
        {
            get
            {
                return _IsSearch_SpaceKey;
            }
            set
            {
                _IsSearch_SpaceKey = value;
            }
        }

        [Category("オリジナル")]
        [Description("スペース入力の可否を設定します。\r\nTrue:可 False:不可")]
        public bool AllowSpace
        {
            get
            {
                return _AllowSpace;
            }
            set
            {
                _AllowSpace = value;
            }
        }

        [Category("オリジナル")]
        [Description("必須チェックエラー時に表示するメッセージを設定または取得します。")]
        public string ErrMessage_Need
        {
            get
            {
                return _ErrMessage_Need;
            }
            set
            {
                _ErrMessage_Need = value;
            }
        }

        [Category("オリジナル")]
        [Description("メッセージボックスのタイトルを設定または取得します。")]
        public string MsgTitle
        {
            get
            {
                return _MsgTitle;
            }
            set
            {
                _MsgTitle = value;
            }
        }

        public BaseText()
        {
            base.KeyDown += Basetext_KeyDown;
            base.Enter += Basetext_Enter;
            _IsNextControl = false;
            _IsIndicate = false;
            _InputMode = InputModeEnum.OverWrite;
            _IsNeed = false;
            _AllowSpace = true;
            _MsgTitle = "テキスト";
            _ErrMessage_Need = "必須です。";
            _IsUseFunctionKey = false;
            _IsSearch_SpaceKey = true;
            blnEnterFlag = false;
        }

        protected virtual bool ShouldSerializeInputMode()
        {
            return !InputMode.Equals(InputModeEnum.OverWrite);
        }

        protected virtual bool ShouldSerializeIsNextControl()
        {
            return !IsNextControl.Equals(obj: false);
        }

        protected virtual bool ShouldSerializeIsUseFunctionKey()
        {
            return !IsNextControl.Equals(obj: false);
        }

        protected virtual bool ShouldSerializeIsSearch_SpaceKey()
        {
            return !IsSearch_SpaceKey.Equals(obj: true);
        }

        protected virtual bool ShouldSerializeAllowSpace()
        {
            return !AllowSpace.Equals(obj: true);
        }

        protected virtual bool ShouldSerializeErrMessage_Need()
        {
            return !ErrMessage_Need.Equals("必須です。");
        }

        protected virtual bool ShouldSerializeMsgTitle()
        {
            return !MsgTitle.Equals("テキスト");
        }

        private void Basetext_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                blnEnterFlag = true;
                if (_IsNextControl)
                {
                    e.Handled = true;
                    SendKeys.SendWait("\t");
                }
            }
        }

        private void Basetext_Enter(object sender, EventArgs e)
        {
            if (_InputMode == InputModeEnum.OverWrite)
            {
                SelectAll();
            }
            else
            {
                base.SelectionStart = Text.Length;
            }
        }

        public virtual bool CheckValue()
        {
            if (IsNeed & (Operators.CompareString(Strings.Trim(Text), "", TextCompare: false) == 0))
            {
                MessageBox.Show(_ErrMessage_Need, _MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Focus();
                return false;
            }

            return true;
        }

        public void InitIndicate()
        {
            if (IsIndicate)
            {
                base.ReadOnly = true;
                base.TabStop = false;
                BackColor = SystemColors.Info;
                ForeColor = SystemColors.WindowText;
            }
            else
            {
                base.ReadOnly = false;
                base.TabStop = true;
                BackColor = SystemColors.Window;
                ForeColor = SystemColors.WindowText;
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 32:
                case 513:
                case 516:
                    if (!base.ReadOnly)
                    {
                        base.WndProc(ref m);
                    }

                    break;
                case 258:
                    {
                        KeyPressEventArgs keyPressEventArgs = new KeyPressEventArgs(Strings.ChrW(m.WParam.ToInt32()));
                        if (blnEnterFlag)
                        {
                            if (Strings.ChrW(m.WParam.ToInt32()) != '\n')
                            {
                                bool multiline = Multiline;
                                Multiline = false;
                                base.WndProc(ref m);
                                Multiline = multiline;
                            }
                            else
                            {
                                base.WndProc(ref m);
                            }
                        }
                        else if (_AllowSpace)
                        {
                            base.WndProc(ref m);
                        }
                        else if (!char.IsWhiteSpace(keyPressEventArgs.KeyChar))
                        {
                            base.WndProc(ref m);
                        }

                        keyPressEventArgs = null;
                        blnEnterFlag = false;
                        break;
                    }
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
}
