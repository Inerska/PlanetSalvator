// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Client.Shared;

using Microsoft.AspNetCore.Components;
using PlanetSalvator.Web.Shared;

public partial class QuizUnit
{
    [Parameter]
    public Quiz QuizProp { get; set; }

    [Parameter]
    public EventCallback<Quiz> QuizSubmit { get; set; }

    public async Task Submit()
    {
        await QuizSubmit.InvokeAsync(QuizProp);
    }
}