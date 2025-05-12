using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ATDS.UI.Control.Grid
{
    public class DataGridViewBaseNumberCell : DataGridViewTextBoxCell
    {
        public override Type EditType => typeof(DataGridViewBaseNumberEditingControl);

        public override Type ValueType => typeof(object);

        public override object DefaultNewRowValue => base.DefaultNewRowValue;

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, RuntimeHelpers.GetObjectValue(initialFormattedValue), dataGridViewCellStyle);
            DataGridViewBaseNumberEditingControl dataGridViewBaseNumberEditingControl = (DataGridViewBaseNumberEditingControl)base.DataGridView.EditingControl;
            if (dataGridViewBaseNumberEditingControl != null)
            {
                BaseNumberColumn baseNumberColumn = (BaseNumberColumn)base.OwningColumn;
                if (baseNumberColumn != null)
                {
                    dataGridViewBaseNumberEditingControl.MaxValue = baseNumberColumn.MaxValue;
                    dataGridViewBaseNumberEditingControl.MinValue = baseNumberColumn.MinValue;
                    dataGridViewBaseNumberEditingControl.MinusColor = baseNumberColumn.MinusColor;
                    dataGridViewBaseNumberEditingControl.RoundType = baseNumberColumn.RoundType;
                    dataGridViewBaseNumberEditingControl.DisplayFormat = baseNumberColumn.DisplayFormat;
                    dataGridViewBaseNumberEditingControl.InputIntDigit = baseNumberColumn.InputIntDigit;
                    dataGridViewBaseNumberEditingControl.InputDecDigit = baseNumberColumn.InputDecDigit;
                    dataGridViewBaseNumberEditingControl.DefaultValue = baseNumberColumn.DefaultValue;
                }
            }
        }
    }
}
