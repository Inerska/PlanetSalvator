﻿// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;

namespace PlanetSalvator.Web.Server.Handlers;

using MediatR;
using Microsoft.EntityFrameworkCore;
using PlanetSalvator.Web.Server.Data;
using PlanetSalvator.Web.Server.Queries;
using PlanetSalvator.Web.Shared;

public record GetDailyTasksByEmailHandler(ApplicationDbContext Context) : IRequestHandler<GetDailyTasksByEmailQuery, IEnumerable<DailyTask>>
{
    private readonly ApplicationDbContext _context = Context;

    /// <inheritdoc/>
    public async Task<IEnumerable<DailyTask>> Handle(GetDailyTasksByEmailQuery request, CancellationToken cancellationToken)
    {
        /*var tasks = _context.DailyTasks
            .Include(d => d.ApplicationUser.DailyTasks)
            .Where(d => d.ApplicationUser.Email == request.Email);*/
        var tasks = _context.DailyTasks.Where(x => x.ApplicationUser.Email == request.Email);
        var t = (await tasks.ToListAsync());
        var t2 = t.Take(3);
        return await tasks.ToListAsync(cancellationToken);
    }
}
