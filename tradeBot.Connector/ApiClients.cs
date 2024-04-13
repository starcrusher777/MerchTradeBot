using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using tradeBot.Connector.API;
using Refit;

namespace tradeBot.Connector;

public class ApiClients
{

    private IHost _host;
#if DEBUG
    private string _baseUrl = "https://localhost:4242/";
#else
    private string _baseUrl = "";
#endif

    public ApiClients(List<(string, string)> authHeaders)
    {
        this._host = Host.CreateDefaultBuilder().ConfigureServices((_, services) =>
        {
            services
                .AddRefitClient<IUserApi>()
                .ConfigureHttpClient(x =>
                {
                    x.BaseAddress = new Uri(_baseUrl + "user");
                    authHeaders.ForEach(h => x.DefaultRequestHeaders.Add(h.Item1, h.Item2));
                });

            services
                .AddRefitClient<IOfferApi>()
                .ConfigureHttpClient(x =>
                {
                    x.BaseAddress = new Uri(_baseUrl + "offer");
                    authHeaders.ForEach(h => x.DefaultRequestHeaders.Add(h.Item1, h.Item2));
                });

            services
                .AddRefitClient<ITelegramApi>()
                .ConfigureHttpClient(x =>
                {
                    x.BaseAddress = new Uri(_baseUrl + "telegram");
                    authHeaders.ForEach(h => x.DefaultRequestHeaders.Add(h.Item1, h.Item2));
                });
        }).Build();
    }

    public IUserApi Users => _host.Services.GetRequiredService<IUserApi>();
    public IOfferApi Offers => _host.Services.GetRequiredService<IOfferApi>();
    public ITelegramApi Telegram => _host.Services.GetRequiredService<ITelegramApi>();
}

