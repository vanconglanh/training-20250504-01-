using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ATDS.UI.Control
{
    public class BaseCombo : ComboBox
    {
        private const string lcCategory = "オリジナル";

        private const bool lcDVAutoDropDown = false;

        private const bool lcDVListArrayView = false;

        private const int lcDVRightColByteLength = 4;

        private const bool lcDVIsNextControl = false;

        private const bool lcDVNumKeyConnection = false;

        private const string lcDVFormatStr = "{0,4:#}";

        private const string lcDVErrMessage_Need = "必須です。";

        private const string lcDVErrMessage_Length = "文字数オーバーです。";

        private const bool lcDVIsIndicate = false;

        private const bool lcDVIsEnterKey = false;

        private const bool lcDVIsNeed = false;

        private const bool lcDVIsSelectOnly = true;

        private const bool lcDVIsSetItem = true;

        private const int lcDVMaxLength = 0;

        private const string lcDVMsgTitle = "コンボ";

        private const string lcDSAutoDropDown = "フォーカス取得時に自動DropDownするかを設定します。";

        private const string lcDSListArrayView = "リストを複数行表示するかを設定します。";

        private const string lcDSRightColByteLength = "2列目データを表示するバイト数を設定します。";

        private const string lcDSIsNextControl = "Enterキーで次の項目に移動するかを設定します。";

        private const string lcDSNumKeyConnection = "数字キーとコントロールを関連付けるかを設定します。";

        private const string lcDSFormatStr = "コンボボックス設定用書式を取得します。";

        private const string lcDSErrMessage_Need = "必須チェックエラー時に表示するメッセージを設定または取得します。";

        private const string lcDSErrMessage_Length = "桁数チェックエラー時に表示するメッセージを設定または取得します。";

        private const string lcDSIsIndicate = "編集可否を設定または取得します。";

        private const string lcDSIsEnterKey = "Enterキーが押されたかどうかを取得します。";

        private const string lcDSIsNeed = "必須項目かどうかを設定または取得します。";

        private const string lcDSIsSelectOnly = "コンボボックスのスタイルを選択のみにするかどうかを設定または取得します。";

        private const string lcDSIsSetItem = "連動するテキストのセットをするかどうかを設定または取得します。";

        private const string lcDSMaxLength = "最大入力文字数をバイト単位で設定または取得します。";

        private const string lcDSMsgTitle = "メッセージボックスのタイトルを設定または取得します。";

        private const string lcDSSetText = "連動させるテキストボックスを設定または取得します。";

        private const int WndProc_LButtonDown = 513;

        private const int WndProc_LButtonUp = 514;

        private const int WndProc_LButtonDblClk = 515;

        private const int WndProc_SetCursor = 32;

        private const int EncodeType = 932;

        private bool _AutoDropDown;

        private bool _ListArrayView;

        private int _RightColByteLength;

        private bool _IsNextControl;

        private string _FormatStr;

        private string _ErrMessage_Need;

        private string _ErrMessage_Length;

        private bool _IsIndicate;

        private bool _IsEnterKey;

        private bool _IsNeed;

        private bool _IsSelectOnly;

        private bool _IsSetItem;

        private int _Maxlength;

        private string _MsgTitle;

        private BaseEdit _SetText;

        [Category("オリジナル")]
        [DefaultValue(false)]
        [Description("フォーカス取得時に自動DropDownするかを設定します。")]
        public bool AutoDropDown
        {
            get
            {
                return _AutoDropDown;
            }
            set
            {
                _AutoDropDown = value;
            }
        }

        [Category("オリジナル")]
        [DefaultValue(false)]
        [Description("リストを複数行表示するかを設定します。")]
        public bool ListArrayView
        {
            get
            {
                return _ListArrayView;
            }
            set
            {
                _ListArrayView = value;
            }
        }

        [Category("オリジナル")]
        [DefaultValue(4)]
        [Description("2列目データを表示するバイト数を設定します。")]
        public int RightColByteLength
        {
            get
            {
                return _RightColByteLength;
            }
            set
            {
                _RightColByteLength = value;
                _FormatStr = "{0," + Conversions.ToString(value) + ":#}";
            }
        }

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

        [Category("オリジナル")]
        [DefaultValue("必須です。")]
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
        [DefaultValue("文字数オーバーです。")]
        [Description("桁数チェックエラー時に表示するメッセージを設定または取得します。")]
        public string ErrMessage_Length
        {
            get
            {
                return _ErrMessage_Length;
            }
            set
            {
                _ErrMessage_Length = value;
            }
        }

        [Category("オリジナル")]
        [DefaultValue("{0,4:#}")]
        [Description("コンボボックス設定用書式を取得します。")]
        [Browsable(false)]
        public string FormatStr => _FormatStr;

        [Category("オリジナル")]
        [DefaultValue(false)]
        [Description("編集可否を設定または取得します。")]
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
        [DefaultValue(false)]
        [Description("Enterキーが押されたかどうかを取得します。")]
        [Browsable(false)]
        public bool IsEnterKey => _IsEnterKey;

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
        [DefaultValue(true)]
        [Description("連動するテキストのセットをするかどうかを設定または取得します。")]
        public bool IsSetItem
        {
            get
            {
                return _IsSetItem;
            }
            set
            {
                _IsSetItem = value;
            }
        }

        [Category("オリジナル")]
        [DefaultValue("コンボ")]
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

        [Category("オリジナル")]
        [Description("連動させるテキストボックスを設定または取得します。")]
        public BaseEdit SetText
        {
            get
            {
                return _SetText;
            }
            set
            {
                _SetText = value;
            }
        }

        [Category("オリジナル")]
        [DefaultValue(true)]
        [Description("コンボボックスのスタイルを選択のみにするかどうかを設定または取得します。")]
        public bool IsSelectOnly
        {
            get
            {
                return _IsSelectOnly;
            }
            set
            {
                _IsSelectOnly = value;
                if (_IsSelectOnly)
                {
                    base.DropDownStyle = ComboBoxStyle.DropDownList;
                    base.ImeMode = ImeMode.Disable;
                }
                else
                {
                    base.DropDownStyle = ComboBoxStyle.DropDown;
                    base.ImeMode = ImeMode.Hiragana;
                    ListArrayView = false;
                }
            }
        }

        public BaseCombo()
        {
            base.Enter += BaseCombo_Enter;
            base.Leave += BaseCombo_Leave;
            base.DrawItem += BaseCombo_DrawItem;
            base.KeyDown += BaseCombo_KeyDown;
            base.SelectedIndexChanged += cmbBumon_SelectedIndexChanged;
            base.Validated += BaseCombo_Validated;
            _AutoDropDown = false;
            _ListArrayView = false;
            _RightColByteLength = 4;
            _IsNextControl = false;
            _FormatStr = "{0,4:#}";
            _ErrMessage_Need = "必須です。";
            _ErrMessage_Length = "文字数オーバーです。";
            _IsIndicate = false;
            _IsEnterKey = false;
            _IsNeed = false;
            _IsSelectOnly = true;
            _IsSetItem = true;
            _Maxlength = 0;
            _MsgTitle = "コンボ";
        }

        private bool ShouldSerializeSetText()
        {
            return SetText != null;
        }

        private void BaseCombo_Enter(object sender, EventArgs e)
        {
            try
            {
                if (_AutoDropDown && base.Items.Count != 0)
                {
                    base.DroppedDown = true;
                }

                BackColor = Color.MistyRose;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                MessageBox.Show(ex2.Message, _MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ProjectData.ClearProjectError();
            }
        }

        public virtual void BaseCombo_Leave(object sender, EventArgs e)
        {
            BackColor = SystemColors.Window;
        }

        private void BaseCombo_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboItem comboItem = new ComboItem();
            Pen pen = new Pen(Color.Black);
            try
            {
                if (e.Index == -1)
                {
                    e.DrawBackground();
                    e.DrawFocusRectangle();
                    return;
                }

                e.DrawBackground();
                comboItem = (ComboItem)base.Items[e.Index];
                Brush brush = new SolidBrush(e.ForeColor);
                Graphics graphics = e.Graphics;
                graphics.DrawString(comboItem.Name, e.Font, brush, 5f, e.Bounds.Y);
                if (_ListArrayView & base.DroppedDown)
                {
                    float num = base.Width;
                    graphics.DrawString(string.Format(FormatStr, comboItem.Code), e.Font, brush, num + 5f, e.Bounds.Y);
                    graphics.DrawLine(pen, num, e.Bounds.Top, num, e.Bounds.Bottom);
                }

                graphics = null;
                e.DrawFocusRectangle();
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
                comboItem = null;
                pen = null;
                float num = 0f;
                Brush brush = null;
            }
        }

        private void BaseCombo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Keys keyCode = e.KeyCode;
                if (keyCode == Keys.Return)
                {
                    _IsEnterKey = true;
                    if (_IsNextControl)
                    {
                        e.Handled = true;
                        SendKeys.SendWait("\t");
                    }
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

        private void cmbBumon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_IsSetItem && SelectedIndex != -1)
                {
                    SetTextItem(SelectedIndex);
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
                _IsSetItem = true;
            }
        }

        private void BaseCombo_Validated(object sender, EventArgs e)
        {
            if (_IsEnterKey)
            {
                CheckValue();
            }

            _IsEnterKey = false;
        }

        public virtual bool CheckValue()
        {
            if (IsNeed)
            {
                if (IsSelectOnly)
                {
                    if (SelectedIndex == -1)
                    {
                        MessageBox.Show(_ErrMessage_Need, _MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Focus();
                        return false;
                    }

                    if (Information.IsNothing(RuntimeHelpers.GetObjectValue(base.SelectedItem)))
                    {
                        MessageBox.Show(_ErrMessage_Need, _MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Focus();
                        return false;
                    }
                }
                else if (Operators.CompareString(Strings.Trim(Text), "", TextCompare: false) == 0)
                {
                    MessageBox.Show(_ErrMessage_Need, _MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Focus();
                    return false;
                }
            }

            if (!IsSelectOnly && Operators.CompareString(Text, "", TextCompare: false) != 0 && ((base.MaxLength != 0) & (BaseModule.LenB(Text) > base.MaxLength)))
            {
                MessageBox.Show(_ErrMessage_Length, _MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Focus();
                return false;
            }

            return true;
        }

        public bool SelectComboItem(int Code)
        {
            bool result = false;
            if (base.Items.Count == 0)
            {
                return result;
            }

            int num = FindObject(string.Format(FormatStr, Code));
            if (num != -1)
            {
                result = true;
            }

            if (!IsNeed && num == -1)
            {
                num = 0;
            }

            SelectedIndex = num;
            return result;
        }

        public bool SelectComboItem(string Code)
        {
            bool result = false;
            if (base.Items.Count == 0)
            {
                return result;
            }

            int num = FindObject(Code);
            if (num != -1)
            {
                result = true;
            }

            if (!IsNeed && num == -1)
            {
                num = 0;
            }

            SelectedIndex = num;
            return result;
        }

        public bool SelectComboItem_Name(string Text)
        {
            bool result = false;
            if (base.Items.Count == 0)
            {
                return result;
            }

            int num = FindObject_Name(Text);
            if (num != -1)
            {
                result = true;
            }

            if (!IsNeed && num == -1)
            {
                num = 0;
            }

            SelectedIndex = num;
            return result;
        }

        public virtual void SetComboItem()
        {
        }

        public virtual object GetSelectedItem()
        {
            object result = null;
            try
            {
                if (SelectedIndex >= 0 && base.SelectedItem != null)
                {
                    result = RuntimeHelpers.GetObjectValue(((ComboItem)base.SelectedItem).Value);
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

        public void InitComboItem()
        {
            base.DataSource = null;
            base.DisplayMember = "";
            base.ValueMember = "";
            base.Items.Clear();
            InitComboStyle();
        }

        protected override void WndProc(ref Message m)
        {
            int msg = m.Msg;
            if (msg == 32 || (uint)(msg - 513) <= 2u)
            {
                if (!_IsIndicate)
                {
                    base.WndProc(ref m);
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        public void AddEmptyItem()
        {
            if (!IsNeed)
            {
                base.Items.Add(new ComboItem("", "", null));
            }
        }

        public void AddItem(string Code, string Name, object Value)
        {
            base.Items.Add(new ComboItem(Code, Name, RuntimeHelpers.GetObjectValue(Value)));
        }

        protected void SetSelectedIndex()
        {
            if (IsNeed)
            {
                SelectedIndex = -1;
            }
            else
            {
                SelectedIndex = 0;
            }
        }

        protected void SetTextItem(int SelectedIndex)
        {
            int num = 0;
            if (Information.IsNothing(SetText))
            {
                return;
            }

            if (this.SelectedIndex != -1)
            {
                if (GetID() != 0)
                {
                    SetText.Text = ((ComboItem)base.SelectedItem).Code;
                }
                else
                {
                    SetText.Text = "";
                }
            }
            else
            {
                SetText.Text = "";
            }
        }

        protected virtual int GetID()
        {
            return Conversions.ToInteger(((ComboItem)base.SelectedItem).Code);
        }

        public void InitIndicate()
        {
            if (IsIndicate)
            {
                base.TabStop = false;
                BackColor = SystemColors.Info;
                ForeColor = SystemColors.WindowText;
            }
            else
            {
                base.TabStop = true;
                BackColor = SystemColors.Window;
                ForeColor = SystemColors.WindowText;
            }
        }

        private void Init()
        {
            base.MaxDropDownItems = 10;
            base.DrawMode = DrawMode.OwnerDrawFixed;
            base.DropDownStyle = ComboBoxStyle.DropDownList;
            base.ValueMember = "NAME";
        }

        private int FindObject(string Code)
        {
            int num = -1;
            checked
            {
                int result = default(int);
                try
                {
                    int num2 = base.Items.Count - 1;
                    for (int i = 0; i <= num2; i++)
                    {
                        if (Operators.CompareString(((ComboItem)base.Items[i]).Code, Code, TextCompare: false) == 0)
                        {
                            num = i;
                            break;
                        }
                    }

                    result = num;
                    return result;
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception ex2 = ex;
                    MessageBox.Show(ex2.Message, _MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    ProjectData.ClearProjectError();
                }

                return result;
            }
        }

        private int FindObject_Name(string Name)
        {
            int num = -1;
            checked
            {
                int result = default(int);
                try
                {
                    int num2 = base.Items.Count - 1;
                    for (int i = 0; i <= num2; i++)
                    {
                        if (Operators.CompareString(((ComboItem)base.Items[i]).Name, Name, TextCompare: false) == 0)
                        {
                            num = i;
                            break;
                        }
                    }

                    result = num;
                    return result;
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception ex2 = ex;
                    MessageBox.Show(ex2.Message, _MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    ProjectData.ClearProjectError();
                }

                return result;
            }
        }

        private void InitComboStyle()
        {
            string text = "";
            checked
            {
                try
                {
                    if (_ListArrayView)
                    {
                        int num = _RightColByteLength - 1;
                        for (int i = 0; i <= num; i++)
                        {
                            text += "X";
                        }

                        SizeF sizeF = CreateGraphics().MeasureString(text, Font);
                        base.DropDownWidth = base.Width + (int)Math.Round(sizeF.Width) + 25;
                    }
                    else
                    {
                        base.DropDownWidth = base.Width;
                    }
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception ex2 = ex;
                    throw;
                }
                finally
                {
                    SizeF sizeF = default(SizeF);
                }
            }
        }
    }
}
