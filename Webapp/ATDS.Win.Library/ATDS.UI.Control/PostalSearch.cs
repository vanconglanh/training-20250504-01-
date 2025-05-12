using ATDS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ATDS.UI.Control
{
    public class PostalSearch : Form
    {
        private enum LC_COL : byte
        {
            POSTAL,
            ADDRESS,
            MAX
        }

        private struct ltypPostalEx
        {
            public string strKey;

            public Postal objPostal;
        }

        public enum StartStateType : byte
        {
            PostalMode,
            AddressMode
        }

        private IContainer components;

        [CompilerGenerated]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [AccessedThroughProperty("btnSelect")]
        private BaseButton _btnSelect;

        [CompilerGenerated]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [AccessedThroughProperty("btnCancel")]
        private BaseButton _btnCancel;

        [CompilerGenerated]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [AccessedThroughProperty("lstList")]
        private ListBox _lstList;

        private const string lcTitle = "住所検索";

        private bool lIsFormLoad;

        private Postal[] _DefaultList;

        private bool _IsSelected;

        private bool _IsShow_Jigyosho_Name;

        private StartStateType _StartState;

        private Postal _SelectedItem;

        private List<ltypPostalEx> lSetList;

        internal virtual BaseButton btnSelect
        {
            [CompilerGenerated]
            get
            {
                return _btnSelect;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            [CompilerGenerated]
            set
            {
                EventHandler value2 = btnSelect_Click;
                BaseButton baseButton = _btnSelect;
                if (baseButton != null)
                {
                    baseButton.Click -= value2;
                }

                _btnSelect = value;
                baseButton = _btnSelect;
                if (baseButton != null)
                {
                    baseButton.Click += value2;
                }
            }
        }

        internal virtual BaseButton btnCancel
        {
            [CompilerGenerated]
            get
            {
                return _btnCancel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            [CompilerGenerated]
            set
            {
                EventHandler value2 = btnCancel_Click;
                BaseButton baseButton = _btnCancel;
                if (baseButton != null)
                {
                    baseButton.Click -= value2;
                }

                _btnCancel = value;
                baseButton = _btnCancel;
                if (baseButton != null)
                {
                    baseButton.Click += value2;
                }
            }
        }

        internal virtual ListBox lstList
        {
            [CompilerGenerated]
            get
            {
                return _lstList;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            [CompilerGenerated]
            set
            {
                EventHandler value2 = lstList_DoubleClick;
                KeyPressEventHandler value3 = lstList_KeyPress;
                ListBox listBox = _lstList;
                if (listBox != null)
                {
                    listBox.DoubleClick -= value2;
                    listBox.KeyPress -= value3;
                }

                _lstList = value;
                listBox = _lstList;
                if (listBox != null)
                {
                    listBox.DoubleClick += value2;
                    listBox.KeyPress += value3;
                }
            }
        }

        public Postal[] DefaultList
        {
            get
            {
                return _DefaultList;
            }
            set
            {
                _DefaultList = value;
            }
        }

        public bool IsSelected
        {
            get
            {
                return _IsSelected;
            }
            set
            {
                _IsSelected = value;
            }
        }

        public bool IsShow_Jigyosho_Name
        {
            get
            {
                return _IsShow_Jigyosho_Name;
            }
            set
            {
                _IsShow_Jigyosho_Name = value;
            }
        }

        public Postal SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                _SelectedItem = value;
                IsSelected = true;
            }
        }

        public StartStateType StartState
        {
            get
            {
                return _StartState;
            }
            set
            {
                _StartState = value;
            }
        }

        public PostalSearch()
        {
            base.Load += Form_Load;
            lIsFormLoad = true;
            _IsSelected = false;
            _IsShow_Jigyosho_Name = false;
            _StartState = StartStateType.PostalMode;
            lSetList = new List<ltypPostalEx>();
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        [System.Diagnostics.DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.btnSelect = new BaseButton();
            this.btnCancel = new BaseButton();
            this.lstList = new System.Windows.Forms.ListBox();
            base.SuspendLayout();
            this.btnSelect.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelect.Location = new System.Drawing.Point(76, 232);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(92, 32);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "選択";
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(400, 232);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "ｷｬﾝｾﾙ";
            this.lstList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.lstList.ItemHeight = 12;
            this.lstList.Location = new System.Drawing.Point(16, 8);
            this.lstList.Name = "lstList";
            this.lstList.Size = new System.Drawing.Size(524, 208);
            this.lstList.TabIndex = 0;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            base.ClientSize = new System.Drawing.Size(556, 274);
            base.Controls.Add(this.lstList);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnSelect);
            base.Name = "PostalSearch";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            base.ResumeLayout(false);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                base.Visible = false;
                SuspendLayout();
                lIsFormLoad = true;
                InitFormDesign();
                InitForm();
                if (!Information.IsNothing(DefaultList) && DefaultList.Length != 0)
                {
                    SetSpread(DefaultList);
                    base.ActiveControl = lstList;
                }

                lIsFormLoad = false;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                MessageBox.Show(ex2.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ProjectData.ClearProjectError();
            }
            finally
            {
                ResumeLayout(performLayout: false);
                base.Visible = true;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectRow();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lstList_DoubleClick(object sender, EventArgs e)
        {
            SelectRow();
        }

        private void lstList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SelectRow();
            }
        }

        private void InitFormDesign()
        {
            base.ControlBox = false;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            Text = "住所検索";
            InitListBox();
        }

        private void InitForm()
        {
            lstList.Items.Clear();
        }

        private void InitListBox()
        {
            ListBox listBox = lstList;
            listBox.SuspendLayout();
            listBox.Items.Clear();
            listBox.ScrollAlwaysVisible = false;
            listBox.ResumeLayout(performLayout: true);
            listBox = null;
        }

        private void SelectRow()
        {
            ListBox listBox = lstList;
            if (listBox.SelectedIndex != -1)
            {
                foreach (ltypPostalEx lSet in lSetList)
                {
                    if (Operators.CompareString(lSet.strKey, Conversions.ToString(listBox.SelectedItem), TextCompare: false) == 0)
                    {
                        SelectedItem = lSet.objPostal;
                        break;
                    }
                }

                Close();
            }

            listBox = null;
        }

        private void SetSpread(Postal[] objList)
        {
            string text = "";
            string text2 = "";
            try
            {
                lstList.SuspendLayout();
                lSetList = null;
                lSetList = new List<ltypPostalEx>();
                ListBox listBox = lstList;
                listBox.Items.Clear();
                foreach (Postal postal in objList)
                {
                    text = string.Concat(str3: (!_IsShow_Jigyosho_Name || Operators.CompareString(Strings.Trim(postal.Jigyosho_Name), "", TextCompare: false) == 0) ? "" : ("  ◆" + postal.Jigyosho_Name), str0: Conversions.ToInteger(postal.PostalString).ToString("000-0000"), str1: "  ", str2: postal.GetFullAddress());
                    listBox.Items.Add(text);
                    ltypPostalEx ltypPostalEx = default(ltypPostalEx);
                    ltypPostalEx = default(ltypPostalEx);
                    ltypPostalEx.strKey = text;
                    ltypPostalEx.objPostal = postal;
                    lSetList.Add(ltypPostalEx);
                }

                if (_StartState == StartStateType.PostalMode)
                {
                    listBox.Sorted = true;
                }

                listBox = null;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
            finally
            {
                lstList.ResumeLayout(performLayout: true);
                ltypPostalEx ltypPostalEx = default(ltypPostalEx);
            }
        }
    }
}
