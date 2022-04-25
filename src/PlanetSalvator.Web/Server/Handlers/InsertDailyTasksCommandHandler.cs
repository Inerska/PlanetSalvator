// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using AntDesign;
using LinqToDB;

namespace PlanetSalvator.Web.Server.Handlers;

using MediatR;
using Microsoft.EntityFrameworkCore;
using PlanetSalvator.Infrastructure.Extensions;
using PlanetSalvator.Web.Server.Commands;
using PlanetSalvator.Web.Server.Data;
using PlanetSalvator.Web.Server.Queries;
using PlanetSalvator.Web.Shared;

public record InsertDailyTasksCommandHandler
    (ApplicationDbContext Context, IMediator Mediator) : IRequestHandler<InsertDailyTasksCommandByEmail>
{
    private readonly IMediator _mediator = Mediator;
    private readonly ApplicationDbContext _context = Context;

    /// <inheritdoc/>
    public async Task<Unit> Handle(InsertDailyTasksCommandByEmail request, CancellationToken cancellationToken)
    {
        var tasks = await _mediator.Send(new GetDailyTasksQuery(), cancellationToken);
        var user = await _context.Users.FirstOrDefaultAsync(user => string.Equals(user.Email, request.Email.Email), cancellationToken);

        if (user is null)
        {
            throw new KeyNotFoundException($"User with email {request.Email.Email} not found.");
        }

        await ResetUserDailyTaskAsync(user);

        user.DailyTasks.AddRange(tasks);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    private async Task ResetUserDailyTaskAsync(ApplicationUser? applicationUser)
    {
        if (applicationUser is null)
        {
            return;
        }

        var table = await _context.DailyTasks.ToListAsync();

        _context.DailyTasks.RemoveRange(table);

        await _context.SaveChangesAsync();
    }
}
