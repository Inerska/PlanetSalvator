// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanetSalvator.Web.Server.Queries;
using PlanetSalvator.Web.Shared.Dtos;

namespace PlanetSalvator.Web.Server.Controllers;

/// <inheritdoc />
[ApiController]
[Route("/api/[controller]")]
public class PracticalTipController
    : Controller
{
    private readonly IMediator _mediator;
    private readonly ILogger<PracticalTipController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="PracticalTipController"/> class.
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="logger"></param>
    public PracticalTipController(
        IMediator mediator,
        ILogger<PracticalTipController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="count"></param>
    /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
    [HttpGet]
    public async Task<IActionResult> GetPracticalTips([FromQuery] int count = 8)
    {
        return Ok(await _mediator.Send(new GetPracticalTipsQuery(count)));
    }
}