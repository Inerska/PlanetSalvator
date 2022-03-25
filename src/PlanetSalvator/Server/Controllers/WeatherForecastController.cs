using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanetSalvator.Infrastructure.Models.NaturalEvent;
using PlanetSalvator.Infrastructure.Services;
using PlanetSalvator.Shared;

namespace PlanetSalvator.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly NaturalEventsFetcherService _service;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            NaturalEventsFetcherService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<NaturalEvent>?> Get()
        {
            var data = await _service.TryFetchDataAsync();

            _logger.LogDebug($"Get() - Failed: {data.HasValue}");

            return data.HasValue
                ? data.Value
                : Enumerable.Empty<NaturalEvent>();
        }
    }
}