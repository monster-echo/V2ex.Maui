using System.Net;
using System.Runtime.Versioning;

namespace V2ex.Blazor.Services;

public class NetworkProxyService(IPreferences preferences)
{
    private const string NetworkProxySettingsKey = "network-proxy-settings";
    public Task<NetworkProxySettings> GetAsync()
    {
        return Task.FromResult(preferences.Get(NetworkProxySettingsKey, new NetworkProxySettings()));
    }

    public Task SaveAsync(NetworkProxySettings settings)
    {
        preferences.Set(NetworkProxySettingsKey, settings);
        return Task.CompletedTask;
    }

    [UnsupportedOSPlatform("browser")]
    public async Task<bool> TestAsync(NetworkProxySettings settings)
    {
        try
        {
            var proxyUrl = settings.GetProxyUrl();
            var httpClient = proxyUrl == null
                ? new HttpClient()
                : new HttpClient(new HttpClientHandler
                {
                    Proxy = new WebProxy(proxyUrl)
                });
            var response = await httpClient.GetAsync("http://www.v2ex.com");
            return response.StatusCode == HttpStatusCode.OK;
        }
        catch (Exception)
        {
            return false;
        }
    }
}