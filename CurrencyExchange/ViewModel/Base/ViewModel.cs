using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.ViewModel.Base
{
    internal class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(params string[] names)
        {
            foreach(var name in names)
            {
                PropertyChanged?.Invoke(this, new(name));
            }
        }
    }
}
