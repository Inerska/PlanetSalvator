// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Infrastructure.Services;

public class FileDataFetcherService
    : IDataFetcherService
{
    public async Task<Optional<Stream?>> TryFetchAsync()
    {
        const string endpoint = "https://hubeau.eaufrance.fr/api/v1/temperature/chronique.csv";
        var client = new HttpClient();
        var response = await client.GetAsync(endpoint);
        var stream = await response.Content.ReadAsStreamAsync();
        
        return new Optional<Stream?>(stream);
    }
}
