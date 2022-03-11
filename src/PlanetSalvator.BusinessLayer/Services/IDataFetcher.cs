// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.BusinessLayer.Services;

public interface IDataFetcher
{
    Task<Optional<Stream?>> TryFetchAsync();
}