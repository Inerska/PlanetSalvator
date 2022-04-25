// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using PlanetSalvator.Web.Server.Handlers;
using PlanetSalvator.Web.Shared;

namespace PlanetSalvator.Web.Server.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanetSalvator.Web.Server.Commands;
using PlanetSalvator.Web.Server.Queries;

[ApiController]
[Route("/api/[controller]")]
public class DailyPublicUserTaskController
    : Controller
{
    private readonly ILogger<DailyPublicUserTaskController> _logger;
    private readonly IMediator _mediator;

    /// <summary>
    ///     Initializes a new instance of the <see cref="DailyPublicUserTaskController" /> class.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    public DailyPublicUserTaskController(
        ILogger<DailyPublicUserTaskController> logger,
        IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    /// <summary>
    ///     Simulate an extern api call to get the daily task.
    /// </summary>
    /// <param name="tasksCount">The count of daily tasks to retrieve.</param>
    /// <returns>The tasksCount daily tasks retrieved.</returns>
    [HttpGet]
    public async Task<IActionResult> GetDailyPublicUserTask([FromQuery] int tasksCount = 3)
    {
        return Ok(await _mediator.Send(new GetDailyTasksQuery(tasksCount)));
    }

    [HttpGet]
    [Route("/api/[controller]/byEmail")]
    public async Task<IActionResult> GetDailyPublicUserTaskByEmail([FromQuery] string email)
    {
        return Ok(await _mediator.Send(new GetDailyTasksByEmailQuery(email)));
    }

    /// <summary>
    ///     Set the daily tasks for the current user.
    /// </summary>
    /// <param name="email">The user's email.</param>
    /// <returns>A <see cref="Task{TResult}" /> representing the result of the asynchronous operation.</returns>
    [Consumes("application/json")]
    [HttpPost]
    public async Task<IActionResult> SetDailyPublicUserTask([FromBody] Temp email)
    {
        // If the mediator return an exception then returns NotFound.
        try
        {
            await _mediator.Send(new InsertDailyTasksCommandByEmail(email));
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return Ok();
    }

    /// <summary>
    ///     Delete a daily task for the current user.
    /// </summary>
    /// <param name="email">The user's email.</param>
    /// <param name="task">The task content.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
    [HttpDelete]
    public async Task<IActionResult> DeleteDailyPublicUserTask([FromQuery] string email, Guid guid)
    {
        await _mediator.Send(new DeleteDailyTaskCommandByGuid(email, guid));
        return Ok();
    }
}