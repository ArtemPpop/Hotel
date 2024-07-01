using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hotel.Validation
{
    internal class PhoneValidationRule:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string pattern = "((\\+?7|8)[ \\-] ?)?((\\(\\d{3}\\))|(\\d{3}))?([ \\-])?(\\d{3}[\\- ]?\\d{2}[\\- ]?\\d{2})$";
            if (value == null) return new ValidationResult(false, "Не пустое");
            if (Regex.IsMatch(value.ToString()!, pattern)) return new ValidationResult(true, null);
            return new ValidationResult(false, "Please enter only digits");
        }
    }
}
