// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Server.Handlers;

using LinqToDB;
using MediatR;
using PlanetSalvator.Web.Server.Data;
using PlanetSalvator.Web.Server.Queries;
using PlanetSalvator.Web.Shared;

public record GetQuizHandler(ApplicationDbContext ApplicationDbContext) : IRequestHandler<GetQuizQuery, ICollection<Quiz>>
{
    private readonly ApplicationDbContext _applicationDbContext = ApplicationDbContext;

    public async Task<ICollection<Quiz>> Handle(GetQuizQuery request, CancellationToken cancellationToken)
    {
        var quizzes = await _applicationDbContext.Quizzes.ToListAsync();

        return quizzes;
    }
}