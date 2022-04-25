// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Server.Handlers;

using MediatR;
using Microsoft.EntityFrameworkCore;
using PlanetSalvator.Web.Server.Commands;
using PlanetSalvator.Web.Server.Data;

public record DeleteDailyTaskByGuidCommandHandler(ApplicationDbContext Context) : IRequestHandler<DeleteDailyTaskCommandByGuid>
{
    private readonly ApplicationDbContext _context = Context;

    public async Task<Unit> Handle(DeleteDailyTaskCommandByGuid request, CancellationToken cancellationToken)
    {
        var (email, guid) = request;
        var user = await _context.Users.FirstOrDefaultAsync(
            u =>
            string.Equals(u.Email, email), cancellationToken);

        // Retrieve daily tasks from user with includes
        var dailyTasks = _context.DailyTasks
            .Include(d => d.ApplicationUser.DailyTasks)
            .ToList();

        var taskToDelete = dailyTasks.Find(task => task.Guid.Equals(guid));

        if (taskToDelete == null)
        {
            throw new KeyNotFoundException();
        }

        user.DailyTasks.Remove(taskToDelete);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
