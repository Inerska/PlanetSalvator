using Microsoft.AspNetCore.Mvc;
using PlanetSalvator.Infrastructure.Services;

namespace PlanetSalvator.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ClimateChangeNewsController
    : ControllerBase
{

    private readonly ClimateChangeNewsFetcherService _fetcherService;
    private readonly ILogger<ClimateChangeNewsController> _logger;

    public ClimateChangeNewsController(
        ClimateChangeNewsFetcherService fetcherService,
        ILogger<ClimateChangeNewsController> logger)
    {
        _fetcherService = fetcherService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        //TODO
        // _fetcherService.FetchFromWebRequestWithRapidHeadersAsync<>();
        _logger.LogDebug("Get()");
        return Ok();
    }
}