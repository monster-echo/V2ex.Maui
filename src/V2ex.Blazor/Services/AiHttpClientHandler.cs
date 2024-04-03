using Microsoft.Extensions.Options;
using System.Net;
using System.Runtime.Versioning;

namespace V2ex.Blazor.Services;

public class ApiHttpClientHandler: HttpClientHandler
{
    [UnsupportedOSPlatform("browser")]
    public ApiHttpClientHandler(
        CookieContainerService cookieContainerService,
        NetworkProxyService networkProxyService)
    {
        this.CookieContainer = cookieContainerService.Container;
        this.NetworkProxyService = networkProxyService;
        this.UseCookies = true;
        this.UseDefaultCredentials = false;
        this.AllowAutoRedirect = false;
        this.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

#if WINDOWS
        var networkSettings = this.NetworkProxyService.GetAsync().Result;
        var proxyUrl = networkSettings.GetProxyUrl();
        if (proxyUrl == null)
        {
            this.Proxy = null;
        }
        else
        {
            this.Proxy = new WebProxy(proxyUrl);
        }
#endif
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);
        return response;
    }

    private NetworkProxyService NetworkProxyService { get; }
}

public class AiHttpClientHandler : HttpClientHandler
{
    public AiHttpClientHandler(CookieContainerService cookieContainerService, IOptions<ChatGPTOptions> options)
    {
        this.CookieContainer = new CookieContainer();
        this.UseCookies = true;
        this.UseDefaultCredentials = false;
        this.AllowAutoRedirect = false;
        this.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

        var endpoint = options.Value.Endpoint;
        var host = new Uri(endpoint).Host;

        foreach (Cookie cookie in cookieContainerService.Container.GetAllCookies())
        {
            cookie.Domain = host;
            this.CookieContainer.Add(cookie);
        }
    }
}
