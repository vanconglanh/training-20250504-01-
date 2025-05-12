using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Entity.Validate
{
    public class RangeValidateAttribute : RangeAttribute
    {
        public RangeValidateAttribute(double minimum, double maximum)
            : base(minimum, maximum)
        {
            base.ErrorMessage = "giá trị của {0} phải nằm trong khoảng {1} - {2}";
        }
    }
}
