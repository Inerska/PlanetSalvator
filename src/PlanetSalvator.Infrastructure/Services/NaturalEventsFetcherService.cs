// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using System.Net.Http.Json;
using PlanetSalvator.Infrastructure.Models.NaturalEvent;

namespace PlanetSalvator.Infrastructure.Services;

public class Root
{
    public string hey { get; set; }
}

public class NaturalEventsFetcherService
    : IWebDataFetcher<NaturalEvent>
{
    private readonly HttpClient _httpClient;

    public NaturalEventsFetcherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Optional<Root>> TryFetchDataAsync()
    {
        var result =
            await _httpClient.GetFromJsonAsync<Root>(
                "https://mocki.io/v1/cde63136-cec5-4ab5-9f88-fe4ed071331a");

        return Optional<Root>.Of(result);
    }
}