using Reqnroll;
using SeleniumFramework.Models;
using SeleniumFramework.Models.Factories;
using SeleniumFramework.Pages;
using SeleniumFramework.Utilities.Constants;

namespace SeleniumFramework.Steps
{
    [Binding]
    public class OwnerSteps
    {
        private readonly AddOwnerPage _addOwnerPage;
        private readonly ScenarioContext _scenarioContext;
        private readonly OwnerModelFactory _ownerModelFactory;

        public OwnerSteps(AddOwnerPage addOwnerPage, ScenarioContext scenarioContext, OwnerModelFactory ownerModelFactory)
        {

            _addOwnerPage = addOwnerPage;
            _scenarioContext = scenarioContext;
            _ownerModelFactory = ownerModelFactory;
        }

        [When("I fill in the owner valid data.")]
        public void WhenIFillInTheOwnerValidData()
        {
            OwnerModel newOwner = _ownerModelFactory.CreateRandomOwner();

            _addOwnerPage.FillOwnerForm(newOwner);

            _scenarioContext[ContextKeys.NewOwner] = newOwner;

        }

        [When(@"I enter ""(.*)"" into the ""(.*)"" owner form field")]
        public void WhenIEnterValueIntoField(string value, string fieldName)
        {
            _addOwnerPage.FillField(fieldName, value);
        }

        [Then(@"I should see a warning message for the owner ""(.*)"" field")]
        public void ThenIShouldSeeWarning(string fieldName)
        {
            Assert.That(_addOwnerPage.HasErrorForField(fieldName), Is.True,
                $"Expected a validation error for the '{fieldName}' field but it was not found.");
        }
    }
}
