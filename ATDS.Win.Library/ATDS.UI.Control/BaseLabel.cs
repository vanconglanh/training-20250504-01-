using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.UI.Control
{
    public class BaseLabel : Label
    {
        private const bool lcDVIsNeed = false;

        private const bool lcDVAutosize = false;

        private const string lcDSAutoSize = "AutoSizeはFalse";

        private const string lcDSIsNeed = "必須項目かどうかを設定または取得します。";

        private const string lcDSBackColor = "背景色を設定";

        private bool _Autosize;

        private bool _IsNeed;

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
                if (_IsNeed)
                {
                    Font = new Font(Font, FontStyle.Bold);
                }
                else
                {
                    Font = new Font(Font, FontStyle.Regular);
                }
            }
        }

        [DefaultValue(false)]
        [Description("必須項目かどうかを設定または取得します。")]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                if ((_Autosize != value) & !_Autosize)
                {
                    base.AutoSize = false;
                    _Autosize = value;
                }
                else
                {
                    base.AutoSize = value;
                }
            }
        }

        public BaseLabel()
        {
            _IsNeed = false;
        }

        private void Init()
        {
        }
    }
}
