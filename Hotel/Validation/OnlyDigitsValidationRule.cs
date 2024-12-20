﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hotel.Validation
{
    class OnlyDigitsValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            if (value==null||!value.ToString()!.All(c => char.IsDigit(c))) 
            return new ValidationResult(false,"Please enter only digits");

            return new ValidationResult(true, null);
        }
    }
}
