using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CurrencyExchange.View.Helpers
{
    internal static class BrushExtensions
    {
        public static SolidColorBrush BrushFromHex(this SolidColorBrush brush, string hex)
        {
            brush.Color = new Color().ColorFromHex(hex);
            return brush;
        }

        public static Color ColorFromHex(this Color color, string hex)
        {
            return (Color)ColorConverter.ConvertFromString(hex.ToUpper());
        }
    }
}
