// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using OpenIddict.Abstractions;

public static class OpenIdConnectRegistration
{
    public static async Task RegisterApplicationAsync(IServiceProvider serviceProvider)
    {
        var manager = serviceProvider.GetRequiredService<IOpenIddictApplicationManager>();

        if (await manager.FindByClientIdAsync("planet-salvator-client") is null)
            await manager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ClientId = "planet-salvator-client",
                DisplayName = "Planet Salvator",
                RedirectUris = {new Uri("https://localhost:44300/signin-oidc")},
                Permissions =
                {
                    OpenIddictConstants.Permissions.Endpoints.Authorization,
                    OpenIddictConstants.Permissions.Endpoints.Logout,
                    OpenIddictConstants.Permissions.Endpoints.Token,
                    OpenIddictConstants.Permissions.GrantTypes.AuthorizationCode,
                    OpenIddictConstants.Permissions.GrantTypes.RefreshToken,
                    OpenIddictConstants.Permissions.GrantTypes.Password,
                    OpenIddictConstants.Permissions.GrantTypes.ClientCredentials
                }
            });
    }
}