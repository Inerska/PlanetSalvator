using Newtonsoft.Json;

namespace PlanetSalvator.BusinessLayer.Services;

public abstract class FetcherBaseService
{
    public async Task<Optional<Stream?>> FetchFromWebRequestAsync(Uri requestUri)
    {
        var client = new HttpClient();
        var response = await client.GetAsync(requestUri);
        var stream = await response.Content.ReadAsStreamAsync();
        
        return new Optional<Stream?>(stream);
    }

    public async Task<TType> FetchFromWebRequestWithRapidHeadersAsync<TType>(
        Uri requestUri,
        string rapidApiHost,
        string rapidApiKey)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(requestUri.AbsoluteUri),
            Headers =
            {
                { "x-rapidapi-host", rapidApiHost },
                { "x-rapidapi-key", rapidApiKey},
            },
        };

        using var response = await client.SendAsync(request);
        var body = await response.Content.ReadAsStringAsync();

        var data = JsonConvert.DeserializeObject<TType>(body);

        return data;
    }
}