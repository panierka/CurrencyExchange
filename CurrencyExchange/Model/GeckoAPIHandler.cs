using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CurrencyExchange.Model.Monetary;

namespace CurrencyExchange.Model
{
    internal class GeckoAPIHandler
    {
        private static readonly HttpClient client = new();

        public static async Task<CurrencyExchangeData> GetCurrencyData(bool includeCrypto = false)
        {
            var url = "https://api.coingecko.com/api/v3/exchange_rates";
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Nie udało się uzyskać odpowiedzi");
            }

            var json = await response.Content.ReadAsStringAsync();
            var currencyData = JsonConvert.DeserializeObject<CurrencyExchangeData>(json);
            NormalizeToPLN(currencyData);

            if (!includeCrypto)
            {
                currencyData.Rates = new(currencyData.Rates.Where(x => x.Value.Type == "fiat"));
            }

            FillInCodes(currencyData);

            return currencyData;

            static void NormalizeToPLN(CurrencyExchangeData currencyData)
            {
                decimal btcValueInPLN = currencyData.Rates["pln"].Value;

                foreach (var currency in currencyData.Rates.Values)
                {
                    currency.Value /= btcValueInPLN;
                }
            }

            static void FillInCodes(CurrencyExchangeData currencyData)
            {
                foreach (var pair in currencyData.Rates)
                {
                    pair.Value.Code = pair.Key.ToUpper();
                }
            }
        }
    }
}
