using ATDS.Business.Info.Validate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Info.Common
{
    public class BaseFilterInfo
    {
        [DisplayName("số thứ tự trang muốn get")]
        [MinValidate(1)]
        public virtual int Page { get; set; } = 1;


        [DisplayName("kích thước trang")]
        [RangeValidate(1.0, 1000.0)]
        public virtual int Size { get; set; } = 10;

        [Description("Sắp xếp")]
        public virtual string? OrderBy { get; set; } = "STATUS";
    }
}
