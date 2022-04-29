// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using PlanetSalvator.Web.Shared;

namespace PlanetSalvator.Web.Server.Data;

using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public DbSet<DailyTask> DailyTasks { get; set; }

    public DbSet<Quiz> Quizzes { get; set; }

    public ApplicationDbContext(
        DbContextOptions options,
        IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {
    }
}