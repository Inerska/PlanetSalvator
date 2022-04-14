// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Client.Pages;

using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

public partial class MyDailyTasks
{
    [Inject]
    public HttpClient? HttpClient { get; set; }

    private IEnumerable<string>? _dailyTasks;

    /// <inheritdoc/>
    protected override async Task OnInitializedAsync()
    {
        try
        {
            _dailyTasks =
                await HttpClient.GetFromJsonAsync<IEnumerable<string>>("/api/DailyPublicUserTask");
        }
        catch (AccessTokenNotAvailableException accessTokenNotAvailableException)
        {
            accessTokenNotAvailableException.Redirect();
        }
    }
}