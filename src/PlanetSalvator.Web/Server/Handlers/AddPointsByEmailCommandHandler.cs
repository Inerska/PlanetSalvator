// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore;
using PlanetSalvator.Web.Server.Data;

namespace PlanetSalvator.Web.Server.Handlers;

using MediatR;
using PlanetSalvator.Web.Server.Commands;

public class AddPointsByEmailCommandHandler : AsyncRequestHandler<AddPointsQueryCommandByEmail>
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddPointsByEmailCommandHandler"/> class.
    /// </summary>
    /// <param name="context"></param>
    public AddPointsByEmailCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    protected override async Task Handle(AddPointsQueryCommandByEmail request, CancellationToken cancellationToken)
    {
        var (email, points) = request;
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

        user.Points += points;

        await _context.SaveChangesAsync(cancellationToken);
    }
};