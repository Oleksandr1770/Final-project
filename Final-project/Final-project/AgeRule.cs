using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Final_project
{
    class AgeRule : ValidationRule
    {
        private int min;
        private int max;

        public int Min { get => min; set => min = value; }
        public int Max { get => max; set => max = value; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int year = 0;
            if (!int.TryParse((string)value, out year))
            {
                return new ValidationResult(false, "Invalid data type");
            }
            if (year < min || year > max)
            {
                return new ValidationResult(false, string.Format("Year is out of range {0}-{1}", min, max));
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
