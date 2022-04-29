// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Server.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanetSalvator.Web.Server.Queries;

[ApiController]
[Route("/api/[controller]")]
public class QuizController
    : Controller
{
    private readonly IMediator _mediator;

    /// <summary>
    ///     Initializes a new instance of the <see cref="QuizController" /> class.
    /// </summary>
    /// <param name="mediator"></param>
    public QuizController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetQuizzes(int count)
    {
        return Ok(await _mediator.Send(new GetQuizQuery(count)));
    }
}