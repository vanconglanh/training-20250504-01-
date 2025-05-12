using ATDS.UI.Control.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.UI.Control.Grid
{
    public class BaseNumberColumn : DataGridViewColumn
    {
        private decimal _MaxValue;

        private decimal _MinValue;

        private decimal _Value;

        private Color _MinusColor;

        private Round _RoundType;

        private string _DisplayFormat;

        private int _InputIntDigit;

        private int _InputDecDigit;

        private decimal _BeforeValue;

        private decimal _DefaultValue;

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

        public string DisplayFormat
        {
            get
            {
                return _DisplayFormat;
            }
            set
            {
                _DisplayFormat = value;
            }
        }

        public int InputIntDigit
        {
            get
            {
                return _InputIntDigit;
            }
            set
            {
                _InputIntDigit = value;
            }
        }

        public int InputDecDigit
        {
            get
            {
                return _InputDecDigit;
            }
            set
            {
                _InputDecDigit = value;
            }
        }

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

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (!(value is DataGridViewBaseNumberCell))
                {
                    throw new InvalidCastException("DataGridViewBaseNumberCellオブジェクトを指定してください。");
                }

                base.CellTemplate = value;
            }
        }

        public BaseNumberColumn()
            : base(new DataGridViewBaseNumberCell())
        {
            _MaxValue = 99999m;
            _MinValue = -99999m;
            _Value = default;
            _MinusColor = Color.Red;
            _RoundType = Round.Off;
            _DisplayFormat = "####0";
            _InputIntDigit = 5;
            _InputDecDigit = 0;
            _BeforeValue = default;
            _DefaultValue = default;
        }

        public override object Clone()
        {
            BaseNumberColumn baseNumberColumn = (BaseNumberColumn)base.Clone();
            baseNumberColumn.MaxValue = MaxValue;
            baseNumberColumn.MinValue = MinValue;
            baseNumberColumn.MinusColor = MinusColor;
            baseNumberColumn.RoundType = RoundType;
            baseNumberColumn.DisplayFormat = DisplayFormat;
            baseNumberColumn.InputIntDigit = InputIntDigit;
            baseNumberColumn.InputDecDigit = InputDecDigit;
            baseNumberColumn.DefaultValue = DefaultValue;
            return baseNumberColumn;
        }
    }
}
