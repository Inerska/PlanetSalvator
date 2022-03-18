using PlanetSalvator.BusinessLayer;
using PlanetSalvator.BusinessLayer.Services;

class ClimateChangeNewsFetcherService
      : FetcherBaseService, IDataFetcherService
{
    public async Task<Optional<Stream?>> TryFetchAsync()
    {
        throw new NotImplementedException();
    }
}
