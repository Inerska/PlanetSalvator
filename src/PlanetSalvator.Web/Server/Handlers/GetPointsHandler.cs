// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Server.Handlers;

using MediatR;
using Microsoft.EntityFrameworkCore;
using PlanetSalvator.Web.Server.Data;
using PlanetSalvator.Web.Server.Queries;

public record GetPointsHandler(ApplicationDbContext _dbContext, ILogger<GetPointsHandler> logger) : IRequestHandler<GetPointsQueryByEmail, int>
{

    private readonly ApplicationDbContext _dbContext = _dbContext;
    private readonly ILogger<GetPointsHandler> _logger;

    public async Task<int> Handle(GetPointsQueryByEmail request, CancellationToken cancellationToken)
    {
        var email = request.Email;
        var user = await _dbContext.Users.FirstOrDefaultAsync(user => string.Equals(user.Email, email), cancellationToken);

        ArgumentNullException.ThrowIfNull(user);

        return user?.Points ?? -1;
    }
}