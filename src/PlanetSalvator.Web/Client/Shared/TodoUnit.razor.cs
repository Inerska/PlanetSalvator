// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Client.Shared;

using Microsoft.AspNetCore.Components;
using PlanetSalvator.Web.Shared;

public partial class TodoUnit
{
    [Parameter]
    public DailyTask DailyTask { get; set; }

    [Parameter]
    public bool? IsDone { get; set; } = false;

    [Parameter]
    public EventCallback<DailyTask> CompleteTask { get; set; }

    private async Task Confirm()
    {
        _message.Success($"Bien joué ! + {DailyTask.Points} points !");
        
        await CompleteTask.InvokeAsync(DailyTask);
    }
}