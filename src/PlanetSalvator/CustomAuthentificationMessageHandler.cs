using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

public class CustomAuthentificationMessageHandler
    : AuthorizationMessageHandler
{
    public CustomAuthentificationMessageHandler(
        IAccessTokenProvider provider,
        NavigationManager navigation)
        : base(provider, navigation)
    {
        ConfigureHandler(new[] {"https://demo.identityserver.io/api/"});
    }
}