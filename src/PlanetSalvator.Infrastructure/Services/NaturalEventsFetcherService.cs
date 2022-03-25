// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Newtonsoft.Json;
using PlanetSalvator.Infrastructure.Models.NaturalEvent;

namespace PlanetSalvator.Infrastructure.Services;

public class NaturalEventsFetcherService
    : IWebDataFetcher<NaturalEvent>
{
    public async Task<Optional<IEnumerable<NaturalEvent>?>> TryFetchDataAsync()
    {
        var client = new HttpClient();
        var response = await client.GetAsync("https://eonet.sci.gsfc.nasa.gov/api/v2.1/events");
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<IEnumerable<NaturalEvent>>(content);

        return await Task.FromResult(Optional<IEnumerable<NaturalEvent>>.Of(result ?? Array.Empty<NaturalEvent>()));
    }
}