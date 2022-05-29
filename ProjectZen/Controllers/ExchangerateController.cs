using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectZen.Service;
using ProjectZen.Service.Interface;
using ProjectZen.Service.Model;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectZen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangerateController : ControllerBase
    {
        private readonly ILogger<ExchangerateController> _logger;
        private readonly ILogic logic = new Logic();
        public ExchangerateController(ILogger<ExchangerateController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{date}/{base}/{target}")]
        public async Task<CurrencyDataResult> GetHisteoricalAsync([FromServices] IHttpClientFactory factory, string date, string @base, string target)
        {
            return await logic.GetHistoricalAsync(factory, date, @base.ToUpper(), target.ToUpper());
        }

    }
}
