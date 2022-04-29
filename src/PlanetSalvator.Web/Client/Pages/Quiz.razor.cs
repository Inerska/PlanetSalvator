// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Client.Pages;

using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

public partial class Quiz
{
    [Inject]
    private HttpClient Http { get; set; }

    public IEnumerable<PlanetSalvator.Web.Shared.Quiz> Quizzes { get; set; }

    /// <inheritdoc/>
    protected override async Task OnInitializedAsync()
    {
        var quizzes = await Http.GetFromJsonAsync<IEnumerable<PlanetSalvator.Web.Shared.Quiz>>("api/quiz");

        Quizzes = quizzes ?? new List<PlanetSalvator.Web.Shared.Quiz>();
    }
}