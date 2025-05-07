using ATDS.UI.Control.Utils;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ATDS.UI.Control.Grid
{
    public class BaseDataGrid : DataGridView
    {
        private const int lcRowIndex_All = -1;

        private const int lcDefaultMaxLen_Text = 128;

        private const int lcDefaultMaximum_Number = 9999999;

        private Color lcBackColor_Label;

        private string lSkinFile_Path;

        private string lSkinFile_Normal;

        private string lSkinFile_Display;

        private string lSkinFile_Note;

        private int _DefaultActiveColLeft;

        private int _DefaultActiveColRight;

        private int _DefaultActiveRowTop;

        private int _DefaultActiveRowBottom;

        private bool _IsNextCell_EnterKey;

        private SheetMode _SheetMode;

        private Color _SelectionBackColor;

        [Bindable(false)]
        public virtual string SkinXml_Dir
        {
            get
            {
                return lSkinFile_Path;
            }
            set
            {
                lSkinFile_Path = value;
            }
        }

        [Bindable(false)]
        public int DefaultActiveColLeft
        {
            get
            {
                if (_DefaultActiveColLeft >= 0)
                {
                    return _DefaultActiveColLeft;
                }

                return 0;
            }
            set
            {
                _DefaultActiveColLeft = value;
            }
        }

        [Bindable(false)]
        public int DefaultActiveColRight
        {
            get
            {
                if (_DefaultActiveColRight >= 0)
                {
                    return _DefaultActiveColRight;
                }

                if (ColumnCount > 0)
                {
                    return checked(ColumnCount - 1);
                }

                return 0;
            }
            set
            {
                _DefaultActiveColRight = value;
            }
        }

        [Bindable(false)]
        public int DefaultActiveRowTop
        {
            get
            {
                if (_DefaultActiveRowTop >= 0)
                {
                    return _DefaultActiveRowTop;
                }

                return 0;
            }
            set
            {
                _DefaultActiveRowTop = value;
            }
        }

        [Bindable(false)]
        public int DefaultActiveRowBottom
        {
            get
            {
                if (_DefaultActiveRowBottom >= 0)
                {
                    return _DefaultActiveRowBottom;
                }

                if (RowCount > 0)
                {
                    return checked(RowCount - 1);
                }

                return 0;
            }
            set
            {
                _DefaultActiveRowBottom = value;
            }
        }

        [Browsable(false)]
        [DefaultValue(true)]
        public bool IsNextCell_EnterKey
        {
            get
            {
                return _IsNextCell_EnterKey;
            }
            set
            {
                _IsNextCell_EnterKey = value;
            }
        }

        [Bindable(false)]
        public SheetMode SheetMode
        {
            get
            {
                return _SheetMode;
            }
            set
            {
                _SheetMode = value;
            }
        }

        public BaseDataGrid()
        {
            CellPainting += grdList_CellPainting;
            lcBackColor_Label = SystemColors.Info;
            lSkinFile_Path = ATDS.AppAdmin.AppSetting.XmlDir;
            lSkinFile_Normal = "InitSkin_Normal.xml";
            lSkinFile_Display = "InitSkin_Display.xml";
            lSkinFile_Note = "InitSkin_Note.xml";
            _DefaultActiveColLeft = -1;
            _DefaultActiveColRight = -1;
            _DefaultActiveRowTop = -1;
            _DefaultActiveRowBottom = -1;
            _IsNextCell_EnterKey = true;
            _SheetMode = SheetMode.Normal;
            _SelectionBackColor = Color.AliceBlue;
        }

        protected virtual bool ShouldSerializeSkinXml_Dir()
        {
            return !SkinXml_Dir.Equals(lSkinFile_Path);
        }

        protected virtual bool ShouldSerializeDefaultActiveColLeft()
        {
            return !DefaultActiveColLeft.Equals(-1);
        }

        protected virtual bool ShouldSerializeDefaultActiveColRight()
        {
            return !DefaultActiveColRight.Equals(-1);
        }

        protected virtual bool ShouldSerializeDefaultActiveRowTop()
        {
            return !DefaultActiveRowTop.Equals(-1);
        }

        protected virtual bool ShouldSerializeDefaultActiveRowBottom()
        {
            return !DefaultActiveRowBottom.Equals(-1);
        }

        protected virtual bool ShouldSerializeSheetMode()
        {
            return !SheetMode.Equals(SheetMode.Normal);
        }

        public void Init(SheetMode InitSheetMode)
        {
            SheetMode = InitSheetMode;
            Init();
        }

        public void Init()
        {
            InitGrid();
        }

        public void InitGrid()
        {
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToOrderColumns = false;
            AllowUserToResizeRows = false;
            MultiSelect = false;
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            switch (SheetMode)
            {
                case SheetMode.Normal:
                    ReadOnly = false;
                    SelectionMode = DataGridViewSelectionMode.CellSelect;
                    break;
                case SheetMode.Display:
                    ReadOnly = true;
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    break;
                case SheetMode.Note:
                    ReadOnly = true;
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    break;
            }

            InitSheet();
        }

        public void InitSheet()
        {
            string text = "";
            ColumnHeadersHeight = 25;
            RowHeadersWidth = 35;
            switch (SheetMode)
            {
                case SheetMode.Normal:
                    text = lSkinFile_Normal;
                    break;
                case SheetMode.Display:
                    text = lSkinFile_Display;
                    break;
                case SheetMode.Note:
                    text = lSkinFile_Note;
                    RowCount = 100;
                    ColumnCount = 1;
                    Columns[0].Width = 730;
                    break;
            }

            SkinLoad(SkinXml_Dir + text);
        }

        public void ClearSheet()
        {
            ClearSheet(0);
        }

        public void ClearSheet(int vRowCount)
        {
            Rows.Clear();
            checked
            {
                if (RowCount > 0)
                {
                    int num = RowCount - 1;
                    for (int i = 0; i <= num; i++)
                    {
                        Rows[i].Tag = null;
                    }
                }

                if (SheetMode != SheetMode.Note)
                {
                    RowCount = vRowCount;
                }
            }
        }

        public void SetFocus(int RowIndex)
        {
            if (SheetMode == SheetMode.Display && RowCount > RowIndex)
            {
                Focus();
                SelectedRows[RowIndex].Selected = true;
            }
        }

        public void CellType_Label(int ColumIndex, string HeaderTitle, int Width)
        {
            try
            {
                using DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn dataGridViewTextBoxColumn2 = dataGridViewTextBoxColumn;
                dataGridViewTextBoxColumn2.HeaderCell.Value = HeaderTitle;
                dataGridViewTextBoxColumn2.ReadOnly = true;
                dataGridViewTextBoxColumn2.Width = Width;
                dataGridViewTextBoxColumn2 = null;
                if (ColumnCount > ColumIndex)
                {
                    Columns.Insert(ColumIndex, dataGridViewTextBoxColumn);
                }
                else
                {
                    Columns.Add(dataGridViewTextBoxColumn);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                //ErrLog.Write(ref ex2);
                throw ex2;
            }
        }

        public void CellType_Number(int ColumIndex, string HeaderTitle, int Width)
        {
            try
            {
                CellType_Number(ColumIndex, HeaderTitle, Width, 0m, 0m, Color.Red, Round.Off, "0", 0, 0);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                //ErrLog.Write(ref ex2);
                throw ex2;
            }
        }

        public void CellType_Number(int ColumIndex, string HeaderTitle, int Width, decimal MaxValue, decimal MinValue, Color MinusColor, Round RoundType, string DisplayFormat, int InputIntDigit, int InputDecDigit)
        {
            try
            {
                using BaseNumberColumn baseNumberColumn = new BaseNumberColumn();
                BaseNumberColumn baseNumberColumn2 = baseNumberColumn;
                baseNumberColumn2.HeaderCell.Value = HeaderTitle;
                baseNumberColumn2.Width = Width;
                baseNumberColumn2.MaxValue = MaxValue;
                baseNumberColumn2.MinValue = MinValue;
                baseNumberColumn2.MinusColor = MinusColor;
                baseNumberColumn2.RoundType = RoundType;
                baseNumberColumn2.DisplayFormat = DisplayFormat;
                baseNumberColumn2.InputIntDigit = InputIntDigit;
                baseNumberColumn2.InputDecDigit = InputDecDigit;
                baseNumberColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                baseNumberColumn2 = null;
                if (ColumnCount > ColumIndex)
                {
                    Columns.Insert(ColumIndex, baseNumberColumn);
                }
                else
                {
                    Columns.Add(baseNumberColumn);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                //ErrLog.Write(ref ex2);
                throw ex2;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private void SkinLoad(string XmlPath)
        {
            XmlDocument xmlDocument = new XmlDocument();
            if (Operators.CompareString(FileSystem.Dir(XmlPath), "", TextCompare: false) == 0)
            {
                return;
            }

            EnableHeadersVisualStyles = false;
            xmlDocument.Load(XmlPath);
            XmlNode xmlNode = xmlDocument.SelectSingleNode("SheetSkin/CellForeColor");
            if (Operators.CompareString(xmlNode.InnerText, "", TextCompare: false) != 0)
            {
                DefaultCellStyle.ForeColor = ColorTranslator.FromHtml(xmlNode.InnerText);
            }

            xmlNode = xmlDocument.SelectSingleNode("SheetSkin/GridLines");
            if (Operators.CompareString(xmlNode.InnerText, "", TextCompare: false) != 0)
            {
                switch (xmlNode.InnerText)
                {
                    case "None":
                        CellBorderStyle = DataGridViewCellBorderStyle.None;
                        break;
                    case "Horizontal":
                        CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                        break;
                    case "Vertical":
                        CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
                        break;
                    default:
                        CellBorderStyle = DataGridViewCellBorderStyle.Single;
                        break;
                }
            }

            xmlNode = xmlDocument.SelectSingleNode("SheetSkin/GridLineColor");
            if (Operators.CompareString(xmlNode.InnerText, "", TextCompare: false) != 0)
            {
                GridColor = ColorTranslator.FromHtml(xmlNode.InnerText);
            }

            xmlNode = xmlDocument.SelectSingleNode("SheetSkin/HeaderBackColor");
            if (Operators.CompareString(xmlNode.InnerText, "", TextCompare: false) != 0)
            {
                ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml(xmlNode.InnerText);
                RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml(xmlNode.InnerText);
            }

            xmlNode = xmlDocument.SelectSingleNode("SheetSkin/HeaderForeColor");
            if (Operators.CompareString(xmlNode.InnerText, "", TextCompare: false) != 0)
            {
                ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml(xmlNode.InnerText);
                RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml(xmlNode.InnerText);
            }

            xmlNode = xmlDocument.SelectSingleNode("SheetSkin/HeaderFontBold");
            if (Conversions.ToBoolean(xmlNode.InnerText))
            {
                ColumnHeadersDefaultCellStyle.Font = new Font(ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                RowHeadersDefaultCellStyle.Font = new Font(RowHeadersDefaultCellStyle.Font, FontStyle.Bold);
            }

            xmlNode = xmlDocument.SelectSingleNode("SheetSkin/SelectionBackColor");
            if (Operators.CompareString(xmlNode.InnerText, "", TextCompare: false) != 0)
            {
                RowsDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml(xmlNode.InnerText);
            }

            xmlNode = xmlDocument.SelectSingleNode("SheetSkin/SelectionForeColor");
            if (Operators.CompareString(xmlNode.InnerText, "", TextCompare: false) != 0)
            {
                RowsDefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml(xmlNode.InnerText);
            }

            xmlNode = xmlDocument.SelectSingleNode("SheetSkin/EvenRowBackColor");
            if (Operators.CompareString(xmlNode.InnerText, "", TextCompare: false) != 0)
            {
                RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml(xmlNode.InnerText);
            }

            xmlNode = xmlDocument.SelectSingleNode("SheetSkin/OddRowBackColor");
            if (Operators.CompareString(xmlNode.InnerText, "", TextCompare: false) != 0)
            {
                AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml(xmlNode.InnerText);
            }
        }

        private void grdList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle cellBounds = e.CellBounds;
                cellBounds.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, GetRowNo(e.RowIndex).ToString(), e.CellStyle.Font, cellBounds, e.CellStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                e.Handled = true;
            }
        }

        private int GetRowNo(int vRow)
        {
            int num = 0;
            checked
            {
                for (int i = 0; i <= vRow; i++)
                {
                    if (Rows[i].Visible)
                    {
                        num++;
                    }
                }

                if (num == 0)
                {
                    num = 1;
                }

                return num;
            }
        }
    }
}
