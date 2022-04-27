using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Model.Monetary
{
    public class CurrencyExchangeData
    {
        public Dictionary<string, Currency> Rates { get; set; } = new();
    }
}
