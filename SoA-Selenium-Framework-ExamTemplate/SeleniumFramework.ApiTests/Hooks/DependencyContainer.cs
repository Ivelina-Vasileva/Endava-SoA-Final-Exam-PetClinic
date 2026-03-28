using Microsoft.Extensions.DependencyInjection;
using Reqnroll;
using Reqnroll.Microsoft.Extensions.DependencyInjection;
using RestSharp;
using SeleniumFramework.ApiTests.Apis;
using SeleniumFramework.ApiTests.Utils;
using SeleniumFramework.Models;

namespace SeleniumFramework.ApiTests.Hooks;

public class DependencyContainer
{
    [ScenarioDependencies]
    public static IServiceCollection RegisterDependencies()
    {
        var services = new ServiceCollection();
        services.AddSingleton(sp =>
        {
            return ConfigurationManager.Instance.SettingsModel;
        });

        services.AddSingleton(sp =>
        {
            var settings = sp.GetRequiredService<SettingsModel>();
            var options = new RestClientOptions(settings.ApiUrl);
            var client = new RestClient(options);
            client.AddDefaultHeader("Accept", "application/json");
            return client;
        });

        services.AddScoped<OwnersApi>();
        services.AddScoped<PetsApi>();

        return services;
    }
}