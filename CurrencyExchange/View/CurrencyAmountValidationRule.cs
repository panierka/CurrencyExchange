using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CurrencyExchange.View
{
    class CurrencyAmountValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string text = value as string;

            if(!decimal.TryParse(text, NumberStyles.AllowDecimalPoint, cultureInfo, out decimal x))
            {
                return new ValidationResult(false, "Invalid characters");
            }

            if (x < 0)
            {
                return new ValidationResult(false, "Amount of currency must not be lesser than 0");
            }

            if (x % 0.01m != 0)
            {
                return new ValidationResult(false, "...");
            }

            if (text.Last() == '.')
            {
                return new ValidationResult(false, "...");
            }

            return ValidationResult.ValidResult;
        }
    }
}
