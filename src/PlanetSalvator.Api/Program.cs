// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using OpenIddict.Abstractions;
using PlanetSalvator.BusinessLayer.Services;
using PlanetSalvator.Infrastructure.Persistence.Contexts;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(optionsBuilder =>
{
    var connectionString = Environment.GetEnvironmentVariable("DefaultConnectionString");
    ArgumentNullException.ThrowIfNull(connectionString, nameof(connectionString));    
    
    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    optionsBuilder.UseOpenIddict();
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

builder.Services.AddScoped<IDataFetcherService, ClimateChangeNewsFetcherService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();