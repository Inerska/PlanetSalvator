// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanetSalvator.Infrastructure.Extensions;
using PlanetSalvator.Web.Server.Queries;
using PlanetSalvator.Web.Shared.Comparers;

namespace PlanetSalvator.Web.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaderBoardController
    : Controller
{
    private readonly IMediator _mediator;

    public LeaderBoardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="leaderCount"></param>
    /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
    [HttpGet]
    public async Task<IActionResult> GetLeaderBoard([FromQuery] int leaderCount = 20)
    {
        var leaderBoard = await _mediator.Send(new GetLeaderBoardQuery(leaderCount));

        // return leaderboard sorted by points using the class comparer ascending
        return Ok(leaderBoard.Sort(new ApplicationUserComparer()));
    }

}