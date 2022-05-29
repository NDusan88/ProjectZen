using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using static ProjectZen.Model.ExchangeData;

namespace ProjectZen
{
    public class Test
    {
        public List<ExchangeRoot> GetHistorical([FromServices] IHttpClientFactory factory, string date)
        {
            List<ExchangeRoot> exchangeRoots = new List<ExchangeRoot>();
            var clinet = factory.CreateClient("simple");
            string[] nums = date.Split(',').ToArray();

            foreach (var param in nums)
            {
                var resonse = clinet.GetAsync(param).Result;

                string jsonData = resonse.Content.ReadAsStringAsync().Result;
                var data = JsonSerializer.Deserialize<ExchangeRoot>(jsonData);

                exchangeRoots.Add(data);
            }
            //exchangeRoots.Clear();

            return exchangeRoots;
        }
    }
}
