// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Abstractions;
using PlanetSalvator.BusinessLayer.Services;
using PlanetSalvator.Infrastructure.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(optionsBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    ArgumentNullException.ThrowIfNull(connectionString, nameof(connectionString));

    optionsBuilder.UseNpgsql(
        connectionString,
        x => x.MigrationsAssembly("PlanetSalvator.Domain"));
    optionsBuilder.UseOpenIddict<string>();
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.ClaimsIdentity.UserIdClaimType = OpenIddictConstants.Claims.Name;
    options.ClaimsIdentity.UserIdClaimType = OpenIddictConstants.Claims.Subject;
    options.ClaimsIdentity.RoleClaimType = OpenIddictConstants.Claims.Role;
});

builder.Services.AddOpenIddict()
    .AddCore(coreBuilder => coreBuilder.UseEntityFrameworkCore().UseDbContext<ApplicationDbContext>())
    .AddServer(serverBuilder =>
    {
        serverBuilder.SetTokenEndpointUris("/connect/token");
        serverBuilder.SetUserinfoEndpointUris("/connect/userinfo");

        serverBuilder.AllowPasswordFlow();
        serverBuilder.AllowRefreshTokenFlow();

        serverBuilder.AllowCustomFlow("custom_flow_name");

        serverBuilder.UseReferenceAccessTokens();
        serverBuilder.UseReferenceRefreshTokens();

        serverBuilder.RegisterScopes(
            OpenIddictConstants.Permissions.Scopes.Email,
            OpenIddictConstants.Permissions.Scopes.Profile,
            OpenIddictConstants.Permissions.Scopes.Roles);

        serverBuilder.SetAccessTokenLifetime(TimeSpan.FromMinutes(30));
        serverBuilder.SetRefreshTokenLifetime(TimeSpan.FromDays(7));

        serverBuilder.AddDevelopmentEncryptionCertificate()
            .AddDevelopmentSigningCertificate();

        serverBuilder.UseAspNetCore().EnableTokenEndpointPassthrough();
    })
    .AddValidation(validationBuilder =>
    {
        validationBuilder.UseLocalServer();
        validationBuilder.UseAspNetCore();
    });

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = OpenIddictConstants.Schemes.Bearer;
    options.DefaultChallengeScheme = OpenIddictConstants.Schemes.Bearer;
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IDataFetcherService, ClimateChangeNewsFetcherService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();