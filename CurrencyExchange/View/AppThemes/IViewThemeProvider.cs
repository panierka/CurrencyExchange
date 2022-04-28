using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CurrencyExchange.View.AppThemes
{
    internal interface IViewThemeProvider
    {
        public void ChangeViewTheme();

        public string ThemeName { get; }
        public Brush BackgroundBrush { get; }
        public Brush BoxBrush { get; }
        public Brush FontBrush { get; }
        public Color Gradient1Brush { get; }
        public Color Gradient2Brush { get; }
    }
}
