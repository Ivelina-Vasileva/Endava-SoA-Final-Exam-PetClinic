using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll.Microsoft.Extensions.DependencyInjection;
using SeleniumFramework.Models;
using SeleniumFramework.Models.Builders;
using SeleniumFramework.Models.Factories;
using SeleniumFramework.Pages;
using SeleniumFramework.Utilities;

namespace SeleniumFramework.Hooks
{
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

            services.AddScoped<IWebDriver>(sp =>
            {
                var driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                return driver;
            });

            RegisterPages(services);
            RegisterCommonServices(services);
            return services;
        }

        private static void RegisterPages(IServiceCollection services)
        {
            services.AddScoped<AddOwnerPage>();
            services.AddScoped<OwnerInformationPage>();
            services.AddScoped<FindOwnersPage>();
            services.AddScoped<OwnerModel>();
            services.AddScoped<PetModel>();
            services.AddScoped<AddPetPage>();
            services.AddScoped<AddVisitPage>();
            services.AddScoped<VisitModel>();

        }

        private static void RegisterCommonServices(IServiceCollection services)
        {
            services.AddScoped<PetModelBuilder>();
            services.AddScoped<PetModelFactory>();
            services.AddScoped<OwnerModelBuilder>();
            services.AddScoped<OwnerModelFactory>();
            services.AddScoped<VisitModelBuilder>();
            services.AddScoped<VisitModelFactory>();
        }

    }
}
