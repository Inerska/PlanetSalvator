// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using PlanetSalvator.Web.Server.Commands;
using PlanetSalvator.Web.Server.Handlers;

namespace PlanetSalvator.Web.Server.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanetSalvator.Web.Server.Queries;

[ApiController]
[Route("api/[controller]")]
public class UserPointsController
    : Controller
{
    private readonly ILogger<UserPointsController> _logger;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserPointsController"/> class.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    public UserPointsController(
        ILogger<UserPointsController> logger,
        IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="Email"></param>
    /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
    [HttpGet]
    public async Task<IActionResult> GetPointsByEmail([FromQuery] string Email)
    {
        var result = await _mediator.Send(new GetPointsQueryByEmail(Email));

        if (result == -1)
        {
            return NotFound();
        }

        return Ok(result);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="Email"></param>
    /// <param name="Points"></param>
    /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
    [HttpPost]
    public async Task<IActionResult> AddPointsByEmail([FromQuery] string Email, [FromQuery] int Points)
    {
        var result = await _mediator.Send(new AddPointsQueryCommandByEmail(Email, Points));

        return Ok(result);
    }
}