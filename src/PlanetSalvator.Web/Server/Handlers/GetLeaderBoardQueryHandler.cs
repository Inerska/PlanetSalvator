// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Server.Handlers;

using LinqToDB;
using MediatR;
using PlanetSalvator.Web.Server.Data;
using PlanetSalvator.Web.Server.Queries;
using PlanetSalvator.Web.Shared;

public record GetLeaderBoardQueryHandler(ApplicationDbContext _context) : IRequestHandler<GetLeaderBoardQuery, ICollection<ApplicationUser>>
{
    private readonly ApplicationDbContext _context = _context;

    public async Task<ICollection<ApplicationUser>> Handle(GetLeaderBoardQuery request, CancellationToken cancellationToken)
    {
        return await _context.Users.Take(request.topCount).ToListAsync(cancellationToken);
    }
}