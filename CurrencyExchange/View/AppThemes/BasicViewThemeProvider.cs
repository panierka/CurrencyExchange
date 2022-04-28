using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using CurrencyExchange.View.Helpers;

namespace CurrencyExchange.View.AppThemes
{
    internal sealed class BasicViewThemeProvider : IViewThemeProvider, INotifyPropertyChanged
    {
        private readonly List<ViewThemeData> viewThemes = new();
        private int currentThemeIndex = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public BasicViewThemeProvider()
        {
            ViewThemeData lightTheme = new(
                "Light Theme",
                BackgroundBrush: Brushes.White,
                BoxBrush: new SolidColorBrush().BrushFromHex("#ECF0F1"),
                FontBrush: new SolidColorBrush().BrushFromHex("#2C3E50"),
                Gradient1: Colors.WhiteSmoke,
                Gradient2: Colors.HotPink
            );

            ViewThemeData darkTheme = new(
                "Dark Theme",
                BackgroundBrush: new SolidColorBrush().BrushFromHex("#212529"),
                BoxBrush: new SolidColorBrush().BrushFromHex("#343a40"),
                FontBrush: new SolidColorBrush().BrushFromHex("#e9d8a6"),
                Gradient1: new Color().ColorFromHex("#005f73"),
                Gradient2: new Color().ColorFromHex("#9b2226")
            );

            viewThemes.Add(lightTheme);
            viewThemes.Add(darkTheme);

            CurrentViewTheme = lightTheme;
        }

        private ViewThemeData CurrentViewTheme { get; set; } = new("", Brushes.White, Brushes.White, Brushes.White, Colors.White, Colors.White);

        public string ThemeName => CurrentViewTheme.Name;
        public Brush BackgroundBrush => CurrentViewTheme.BackgroundBrush;
        public Brush BoxBrush => CurrentViewTheme.BoxBrush;
        public Brush FontBrush => CurrentViewTheme.FontBrush;
        public Color Gradient1Brush => CurrentViewTheme.Gradient1;
        public Color Gradient2Brush => CurrentViewTheme.Gradient2;

        public void ChangeViewTheme()
        {
            currentThemeIndex = (currentThemeIndex + 1) % viewThemes.Count;
            CurrentViewTheme = viewThemes[currentThemeIndex];

            NotifyPropertyChanged(
                nameof(ThemeName),
                nameof(BackgroundBrush),
                nameof(BoxBrush),
                nameof(FontBrush),
                nameof(Gradient1Brush),
                nameof(Gradient2Brush));
        }

        private void NotifyPropertyChanged(params string[] names)
        {
            foreach(string name in names)
            {
                PropertyChanged?.Invoke(this, new(name));
            }
        }
    }
}
