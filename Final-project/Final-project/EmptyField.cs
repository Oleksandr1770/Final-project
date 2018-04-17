using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Final_project
{
    class EmptyField : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;
            if ((str == "") || (value == null))
            {
                return new ValidationResult(false, "Value cannot be empty");
            }
            else return ValidationResult.ValidResult;
        }
    }
}
