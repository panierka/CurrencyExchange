using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Model.Monetary
{
    public class Currency
    {
        public string Name { get; set; }

        public string Unit { get; set; }

        public decimal Value { get; set; }

        public string Type { get; set; }

        public string Code { get; set; }

        public string Display => $"({Code}) {Name}";

        public override string ToString()
        {
            return $"{Name}: {Value} [{Unit}]";
        }
    }
}
