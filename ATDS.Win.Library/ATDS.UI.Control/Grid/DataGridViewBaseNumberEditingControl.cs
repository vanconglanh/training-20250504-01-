using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ATDS.UI.Control.Grid
{
    public class DataGridViewBaseNumberEditingControl : BaseNumber, IDataGridViewEditingControl
    {
        private DataGridView dataGridView;

        private int rowIndex;

        private bool valueChanged;

        public object EditingControlFormattedValue
        {
            get
            {
                return GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting);
            }
            set
            {
                base.Value = Conversions.ToDecimal(value);
            }
        }

        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        public Cursor EditingPanelCursor => base.Cursor;

        public bool RepositionEditingControlOnValueChange => false;

        public DataGridViewBaseNumberEditingControl()
        {
            base.TabStop = false;
        }

        protected override void OnCreateControl()
        {
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return base.Text;
        }

        object IDataGridViewEditingControl.GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            //ILSpy generated this explicit interface implementation from .override directive in GetEditingControlFormattedValue
            return this.GetEditingControlFormattedValue(context);
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
            ForeColor = dataGridViewCellStyle.ForeColor;
            BackColor = dataGridViewCellStyle.BackColor;
            switch (dataGridViewCellStyle.Alignment)
            {
                case DataGridViewContentAlignment.TopCenter:
                case DataGridViewContentAlignment.MiddleCenter:
                case DataGridViewContentAlignment.BottomCenter:
                    base.TextAlign = HorizontalAlignment.Center;
                    break;
                case DataGridViewContentAlignment.TopRight:
                case DataGridViewContentAlignment.MiddleRight:
                case DataGridViewContentAlignment.BottomRight:
                    base.TextAlign = HorizontalAlignment.Right;
                    break;
                default:
                    base.TextAlign = HorizontalAlignment.Left;
                    break;
            }
        }

        void IDataGridViewEditingControl.ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            //ILSpy generated this explicit interface implementation from .override directive in ApplyCellStyleToEditingControl
            this.ApplyCellStyleToEditingControl(dataGridViewCellStyle);
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.End:
                case Keys.Home:
                case Keys.Left:
                case Keys.Right:
                    return true;
                case Keys.Decimal:
                case Keys.OemPeriod:
                    return true;
                default:
                    return false;
            }
        }

        bool IDataGridViewEditingControl.EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            //ILSpy generated this explicit interface implementation from .override directive in EditingControlWantsInputKey
            return this.EditingControlWantsInputKey(keyData, dataGridViewWantsInputKey);
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            if (selectAll)
            {
                SelectAll();
            }
            else
            {
                base.SelectionStart = TextLength;
            }
        }

        void IDataGridViewEditingControl.PrepareEditingControlForEdit(bool selectAll)
        {
            //ILSpy generated this explicit interface implementation from .override directive in PrepareEditingControlForEdit
            this.PrepareEditingControlForEdit(selectAll);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            valueChanged = true;
            dataGridView.NotifyCurrentCellDirty(dirty: true);
        }
    }
}
