// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Client.Pages;

using System.Net.Http.Json;
using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using PlanetSalvator.Web.Shared.Dtos;

public class EssentialTipsBase
    : ComponentBase
{
    internal readonly ListGridType GridType = new()
    {
        Gutter = 10,
        Xs = 1,
        Sm = 2,
        Md = 4,
        Lg = 4,
        Xl = 4,
        Xxl = 3,
    };

    internal IEnumerable<PracticalTip>? EssentialTips;

    [Inject] protected HttpClient HttpClient { get; set; }

    /// <inheritdoc />
    protected override async Task OnInitializedAsync()
    {
        try
        {
            EssentialTips =
                await HttpClient.GetFromJsonAsync<IEnumerable<PracticalTip>>("/api/PracticalTip");
        }
        catch (AccessTokenNotAvailableException accessTokenNotAvailableException)
        {
            accessTokenNotAvailableException.Redirect();
        }
    }

    internal RenderFragment GetCoverTemplate(string? imageUri)
    {
        return builder =>
        {
            builder.OpenElement(0, "img");
            builder.AddAttribute(1, "src", imageUri);
            builder.AddAttribute(2, "alt", "Cover");
            builder.AddAttribute(3, "class", "cover");
            builder.CloseElement();
        };
    }

    internal string GetShortedDescription(string? essentialTipDescription, int contentLengthLimit = 99)
    {
        if (string.IsNullOrEmpty(essentialTipDescription))
        {
            return string.Empty;
        }

        return essentialTipDescription.Length <= contentLengthLimit
            ? essentialTipDescription
            : string.Concat(essentialTipDescription.AsSpan(0, contentLengthLimit + 1), "...");
    }
}