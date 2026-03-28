using OpenQA.Selenium;
using Reqnroll;
using SeleniumFramework.Models;
using SeleniumFramework.Pages;
using SeleniumFramework.Utilities.Constants;

namespace SeleniumFramework.Steps
{
    [Binding]
    public class OwnerInformationSteps
    {
        private readonly IWebDriver _driver;
        private readonly OwnerInformationPage _ownerInfoPage;
        private readonly SettingsModel _settingsModel;
        private readonly ScenarioContext _scenarioContext;

        public OwnerInformationSteps(IWebDriver driver, OwnerInformationPage ownerInfoPage, SettingsModel settingsModel, ScenarioContext scenarioContext)
        {
            _driver = driver;

            _ownerInfoPage = ownerInfoPage;
            _settingsModel = settingsModel;
            _scenarioContext = scenarioContext;
        }

        [Then("I should be redirected to the Owner Information page.")]
        public void ThenIShouldBeRedirectedToThePage()
        {
            var expectedUrlPart = _settingsModel.OwnersInformationPageUrl;
            Assert.That(_driver.Url, Does.Contain(expectedUrlPart), "Redirect to Owner Information page failed!");
        }

        [Then(@"I should see the details of the newly created owner.")]
        public void IShouldSeeTheDetailsOfTheNewlyCreatedOwner()
        {
            Assert.Multiple(() =>
            {
                var newlyCreatedOwner = _scenarioContext.Get<OwnerModel>(ContextKeys.NewOwner);

                var actualFullName = _ownerInfoPage.GetOwnerName();
                var expectedFullName = $"{newlyCreatedOwner.FirstName} {newlyCreatedOwner.LastName}";
                var actualAddress = _ownerInfoPage.GetOwnerAddress();
                var expectedAddress = newlyCreatedOwner.Address;

                Assert.That(actualFullName, Is.EqualTo(expectedFullName),
                    $"Expected name: {expectedFullName}, but on the screen we see: {actualFullName}");


                Assert.That(actualAddress, Is.EqualTo(newlyCreatedOwner.Address),
                    $"Expected address: {newlyCreatedOwner.Address}, but on the screen we see: {actualAddress}");
            });
        }
    }
}
