// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Client.Shared;

using Microsoft.AspNetCore.Components;

public partial class TodoUnit
{
    [Parameter]
    public string? Content { get; set; }

    [Parameter] public bool? IsDone { get; set; } = false;
}