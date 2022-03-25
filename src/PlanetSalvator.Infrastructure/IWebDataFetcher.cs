// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using PlanetSalvator.Infrastructure.Models.NaturalEvent;

namespace PlanetSalvator.Infrastructure;

public interface IWebDataFetcher<TTYpe> where TTYpe : FetchableData
{
    Task<Optional<IEnumerable<NaturalEvent>?>> TryFetchDataAsync();
}