// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PlanetSalvator;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
builder.Services.AddHttpClient("api", client => client.BaseAddress = new Uri("https://demo.indentityserver.io"));
builder.Services.AddScoped(services => services.GetRequiredService<IHttpClientFactory>()
    .CreateClient("api"));

builder.Services.AddOidcAuthentication(options =>
{
    options.ProviderOptions.Authority = "https://demo.identityserver.io";
    options.ProviderOptions.ClientId = "interactive.confidential.short";
    options.ProviderOptions.ResponseType = "code";
    options.ProviderOptions.DefaultScopes.Add("api");
    options.ProviderOptions.DefaultScopes.Add("email");
    options.ProviderOptions.DefaultScopes.Add("profile");
});

await builder.Build().RunAsync();