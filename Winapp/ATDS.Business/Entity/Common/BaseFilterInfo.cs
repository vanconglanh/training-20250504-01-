using ATDS.Business.Entity.Validate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Entity.Common
{
    public class BaseFilterInfo
    {
        [DisplayName("số thứ tự trang muốn get")]
        [MinValidate(1)]
        public virtual int PageIndex { get; set; } = 1;


        [DisplayName("kích thước trang")]
        [RangeValidate(1.0, 1000.0)]
        public virtual int PageSize { get; set; } = 10;

        [Description("Sắp xếp")]
        public virtual string? OrderBy { get; set; } = "YUKO_FLAG";
    }
}
