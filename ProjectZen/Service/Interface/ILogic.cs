using Microsoft.AspNetCore.Mvc;
using ProjectZen.Service.Model;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectZen.Service.Interface
{
    public interface ILogic
    {
        Task<CurrencyDataResult> GetHistoricalAsync([FromServices] IHttpClientFactory factory, string date, string @base, string target);
    }
}
