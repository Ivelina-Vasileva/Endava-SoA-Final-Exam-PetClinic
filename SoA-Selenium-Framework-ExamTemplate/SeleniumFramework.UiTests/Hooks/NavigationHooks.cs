using Bogus.DataSets;
using OpenQA.Selenium;
using Reqnroll;
using RestSharp;
using SeleniumFramework.ApiTests.Apis;
using SeleniumFramework.Models;
using System.Xml.Linq;
using SeleniumFramework.Utilities.Constants;


namespace SeleniumFramework.Hooks
{
    [Binding]
    public class NavigationHooks
    {
        private readonly IWebDriver _driver;
        private readonly SettingsModel _settings;

        public NavigationHooks(IWebDriver webDriver, SettingsModel settings)
        {
            this._driver = webDriver;
            this._settings = settings;
        }

        [BeforeScenario("@FindOwnersPage")]
        public void FindOwnersPage()
        {
            _driver.Navigate().GoToUrl(_settings.FindOwnersPageUrl);
        }

        [BeforeScenario(@"OwnerInformationPage")]
        public void OwnerInformationPage()
        {
            _driver.Navigate().GoToUrl(_settings.OwnersInformationPageUrl);
        }

        [BeforeScenario(@"DefaultOwnerInformationPageUrl")]
        public void DefaultOwnerInformationPageUrl()
        {
            _driver.Navigate().GoToUrl(_settings.DefaultOwnerInformationPageUrl);
        }
       
        [AfterScenario]
        public void CloseBrowser()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
