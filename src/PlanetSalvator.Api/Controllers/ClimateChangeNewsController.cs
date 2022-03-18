using Microsoft.AspNetCore.Mvc;
using PlanetSalvator.BusinessLayer.Services;

namespace PlanetSalvator.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ClimateChangeNewsController
    : ControllerBase
{

    private readonly ClimateChangeNewsFetcherService _fetcherService;

    public ClimateChangeNewsController(ClimateChangeNewsFetcherService fetcherService)
    {
        _fetcherService = fetcherService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        //TODO
        // _fetcherService.FetchFromWebRequestWithRapidHeadersAsync<>();
        
        return Ok();
    }
}