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
builder.Services.AddAuthentication()
    .AddOpenIdConnect(options =>
    {
        options.ClientId = "PlanetSalvator.Api";
        options.Authority = "https://localhost:44300/";
        options.RequireHttpsMetadata = false;
        options.ResponseType = OpenIdConnectResponseType.Code;
        options.GetClaimsFromUserInfoEndpoint = true;
        options.SaveTokens = true;
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("email");
        options.Scope.Add("roles");
        options.Events.OnRedirectToIdentityProvider = async context =>
        {
            context.ProtocolMessage.SetParameter("audience", "https://localhost:44300/");
        };
        options.Events.OnRemoteFailure = async context =>
        {
            context.HandleResponse();
            context.Response.Redirect("/");
        };
    });
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