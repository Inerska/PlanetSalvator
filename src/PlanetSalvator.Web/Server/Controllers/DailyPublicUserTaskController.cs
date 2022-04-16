// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Server.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanetSalvator.Infrastructure.Extensions;
using PlanetSalvator.Web.Server.Queries;

[ApiController]
[Route("/api/[controller]")]
public class DailyPublicUserTaskController
    : Controller
{
    private readonly ILogger<DailyPublicUserTaskController> _logger;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="DailyPublicUserTaskController"/> class.
    /// </summary>
    /// <param name="logger"></param>
    public DailyPublicUserTaskController(
        ILogger<DailyPublicUserTaskController> logger,
        IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    /// <summary>
    /// Simulate an extern api call to get the daily task.
    /// </summary>
    /// <param name="tasksCount">The count of daily tasks to retrieve.</param>
    /// <returns>The tasksCount daily tasks retrieved.</returns>
    [HttpGet]
    public async Task<IActionResult> GetDailyPublicUserTask([FromQuery] int tasksCount = 3)
    {
        var tasks = (await _mediator.Send(new GetDailyTasksQuery(tasksCount))).ToList();

        if (tasks.IsNullOrEmpty())
        {
            return NotFound();
        }

        return Ok(tasks.Shuffle().Take(tasksCount));
    }
}