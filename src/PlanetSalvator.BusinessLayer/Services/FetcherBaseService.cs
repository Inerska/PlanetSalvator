using PlanetSalvator.BusinessLayer;

public abstract class FetcherBaseService
{
    public async Task<Optional<Stream?>> FetchFromWebRequestAsync(Uri requestUri)
    {
        var client = new HttpClient();
        var response = await client.GetAsync(requestUri);
        var stream = await response.Content.ReadAsStreamAsync();
        
        return new Optional<Stream?>(stream);

    }
}
