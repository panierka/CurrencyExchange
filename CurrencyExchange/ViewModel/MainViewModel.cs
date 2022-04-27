using CurrencyExchange.Model;
using CurrencyExchange.Model.Monetary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurrencyExchange.ViewModel
{
    internal class MainViewModel : Base.ViewModel
    {
        private CurrencyExchangeData _currencyData;
        private Currency _currentCurrency;
        private Currency _currentTargetCurrency;
        private decimal _amountOfCurrency;


        public CurrencyExchangeData CurrencyData 
        { 
            get => _currencyData;
            set
            {
                _currencyData = value;
                OnPropertyChanged(nameof(CurrencyData), nameof(AmountOfCurrency));
            }
        }

        public Currency CurrentCurrency
        {
            get => _currentCurrency;
            set
            {
                _currentCurrency = value;
                OnPropertyChanged(nameof(CurrentCurrency), nameof(AmountOfTargetCurrency));
            }
        }

        public Currency CurrentTargetCurrency
        {
            get => _currentTargetCurrency;
            set
            {
                _currentTargetCurrency = value;
                OnPropertyChanged(nameof(CurrentTargetCurrency), nameof(AmountOfTargetCurrency));
            }
        }

        public decimal AmountOfCurrency
        {
            get => _amountOfCurrency;
            set
            {
                _amountOfCurrency = value;
                OnPropertyChanged(nameof(AmountOfCurrency), nameof(AmountOfTargetCurrency));
            }
        }

        public decimal AmountOfTargetCurrency
        {
            get
            {
                if (CurrentCurrency is null || CurrentTargetCurrency is null)
                {
                    return 0;
                }

                return decimal.Round(AmountOfCurrency * CurrentTargetCurrency.Value / CurrentCurrency.Value, 2, MidpointRounding.ToNegativeInfinity);
            }
        }

        public MainViewModel()
        {
            try
            {
                Task.Run(async () => CurrencyData = await GeckoAPIHandler.GetCurrencyData()).Wait();
            }
            catch (Exception)
            {
                MessageBox.Show($"Błąd przy łączeniu z API CoinGecko.");
                Application.Current.Shutdown();
            }
        }
    }
}
