using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WindowsCredWpfApp.Validators
{
    public class PasswordValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult(false, "Password cannot be null or white space");
            }
            else
            {
                if (value.ToString().Length < 8)
                {
                    return new ValidationResult(false, "Password cannot be less than 8 characters.");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
