using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Info.Validate
{
    public class MinValidateAttribute : ValidationAttribute
    {
        private readonly int minValue;

        public MinValidateAttribute(int value)
        {
            minValue = value;
            base.ErrorMessage = $"giá trị của {{0}} không được nhỏ hơn {minValue}";
        }

        public override bool IsValid(object value)
        {
            return value == null || (int)value >= minValue;
        }
    }
}
