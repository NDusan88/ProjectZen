using Microsoft.AspNetCore.Mvc;
using ProjectZen.Service.Interface;
using ProjectZen.Service.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using static ProjectZen.Model.ExchangeData;

namespace ProjectZen.Service
{
    public class Logic : ILogic
    {
        private CurrencyDataResult result = new CurrencyDataResult();
        private ExchangeRoot exchangeData = new ExchangeRoot();
        private readonly List<ExchangeRoot> exchangeRoots = new List<ExchangeRoot>();
        private readonly List<GetCurrencyData> getCurrencies = new List<GetCurrencyData>();

        public async Task<CurrencyDataResult> GetHistoricalAsync([FromServices] IHttpClientFactory factory, string date, string @base, string target)
        {
            var clinet = factory.CreateClient("simple");

            string[] dates = date.Split(',').ToArray();

            for (int i = 0; i < dates.Length; i++)
            {
                try
                {
                    var resonse = clinet.GetAsync(dates[i] + "?base=" + @base + "&symbols=" + target).Result;
                    string jsonData = await resonse.Content.ReadAsStringAsync();
                    exchangeData = JsonSerializer.Deserialize<ExchangeRoot>(jsonData);
                }
                catch (JsonException msg)
                {
                    throw msg;
                }
                finally
                {
                    exchangeRoots.Add(exchangeData);
                }
            }

            for (int i = 0; i < exchangeRoots.Count; i++)
            {
                if (exchangeRoots[i]?.rates?.GetType()?.GetProperty(target)?.Name == target)
                {
                    GetCurrencyData getCurrencyData = new GetCurrencyData();

                    getCurrencyData.Rates = (float)exchangeRoots[i].rates.GetType().GetProperty(target).GetValue(exchangeRoots[i].rates, null);
                    getCurrencyData.Date = exchangeRoots[i].date;

                    getCurrencies.Add(getCurrencyData);
                }
            }

            Max max = new Max()
            {
                date = getCurrencies?.FirstOrDefault(x => x.Rates == getCurrencies.Max(x => x.Rates))?.Date,
                max = getCurrencies.Max(x => x.Rates)
            };
            Min min = new Min()
            {
                date = getCurrencies?.FirstOrDefault(x => x.Rates == getCurrencies.Min(x => x.Rates))?.Date,
                min = getCurrencies.Min(x => x.Rates)
            };
            Avrage avrage = new Avrage
            {
                avrage = getCurrencies.Average(x => x.Rates)
            };

            System.Console.Clear();
            System.Console.WriteLine("A min rate of " + min.min+" on " + min.date +"");
            System.Console.WriteLine("A max rate of " + max.max + " on " + max.date + "");
            System.Console.WriteLine("A avrage rate of " + avrage.avrage);
            return result = new CurrencyDataResult()
            {
                GetMax = max,
                GetMin = min,
                GetAvrage = avrage
            };
        }
    }
}