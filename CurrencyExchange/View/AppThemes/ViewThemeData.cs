using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CurrencyExchange.View.AppThemes
{
    internal record ViewThemeData(
        string Name,
        Brush BackgroundBrush, 
        Brush BoxBrush, 
        Brush FontBrush, 
        Color Gradient1, 
        Color Gradient2);
}
