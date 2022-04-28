// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Server.Handlers;

using MediatR;
using Microsoft.EntityFrameworkCore;
using PlanetSalvator.Web.Server.Data;
using PlanetSalvator.Web.Server.Queries;
using PlanetSalvator.Web.Shared;

public record GetDailyTasksByEmailHandler
    (ApplicationDbContext Context) : IRequestHandler<GetDailyTasksByEmailQuery, IEnumerable<DailyTask>>
{
    private readonly ApplicationDbContext _context = Context;

    /// <inheritdoc />
    public async Task<IEnumerable<DailyTask>> Handle(
        GetDailyTasksByEmailQuery request,
        CancellationToken cancellationToken)
    {
        var tasks = _context.DailyTasks.Where(x => x.ApplicationUser.Email == request.Email);

        return await tasks.ToListAsync(cancellationToken);
    }
}