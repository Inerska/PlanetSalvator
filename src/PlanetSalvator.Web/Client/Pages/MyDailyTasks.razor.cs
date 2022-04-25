// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Client.Pages;

using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using PlanetSalvator.Web.Shared;

public partial class MyDailyTasks
{
    [Inject]
    public HttpClient HttpClient { get; set; }

    [Inject]
    public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    
    [Inject]
    public ILogger<MyDailyTasks> Logger { get; set; }

    private IEnumerable<DailyTask>? _dailyTasks;

    /// <inheritdoc/>
    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userEmail = authState.User.Identity.Name;

        try
        {
            _dailyTasks =
                await HttpClient.GetFromJsonAsync<IEnumerable<DailyTask>>($"api/DailyPublicUserTask/byEmail?email={userEmail}");
        }
        catch (AccessTokenNotAvailableException accessTokenNotAvailableException)
        {
            accessTokenNotAvailableException.Redirect();
        }
    }

    public async Task DeleteTaskAsync(DailyTask task)
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userEmail = authState.User.Identity.Name;

        await HttpClient.DeleteAsync($"/api/DailyPublicUserTask?email={userEmail}&guid={task.Guid}");

        _dailyTasks =
            await HttpClient.GetFromJsonAsync<IEnumerable<DailyTask>>($"/api/DailyPublicUserTask/byEmail?email={userEmail}");
    }

    private async Task CompleteTask(DailyTask task)
    {
        await DeleteTaskAsync(task);
    }

    private async Task FillDailyTasksAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userEmail = authState.User.Identity.Name;
        
        await HttpClient.PostAsJsonAsync("/api/DailyPublicUserTask", new Temp(userEmail));
        
        _dailyTasks =
            await HttpClient.GetFromJsonAsync<IEnumerable<DailyTask>>($"/api/DailyPublicUserTask/byEmail?email={userEmail}");
    }
}