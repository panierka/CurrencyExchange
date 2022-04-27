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
                return new ValidationResult(false, "Niepoprawne znaki");
            }

            if (x < 0)
            {
                return new ValidationResult(false, "Wartość nie może być ujemna");
            }

            if (x % 0.01m != 0)
            {
                return new ValidationResult(false, "Nie istnieją aż takie grosze");
            }

            if (text.Last() == '.')
            {
                return new ValidationResult(false, "Nie możesz zakończyć liczby przecinkiem");
            }

            return ValidationResult.ValidResult;
        }
    }
}
