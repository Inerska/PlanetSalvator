// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;

namespace PlanetSalvator.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WaterTemperatureControler
    : ControllerBase
{
    private readonly ILogger _logger;

    public WaterTemperatureControler(ILogger logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}