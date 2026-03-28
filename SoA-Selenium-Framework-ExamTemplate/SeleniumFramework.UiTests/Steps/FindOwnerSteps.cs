using Reqnroll;
using SeleniumFramework.Pages;

namespace SeleniumFramework.Steps
{
    [Binding]
    
    public class FindOwnerSteps
    {
        private readonly FindOwnersPage _findOwnersPage;

        public FindOwnerSteps(FindOwnersPage findOwnersPage)
        {
            _findOwnersPage = findOwnersPage;
        }

        [When("I select an owner from the list")]
        public void WhenISelectAnOwnerFromTheList()
        {
            _findOwnersPage.SelectFirstOwner();
        }

        [When(@"I enter ""(.*)"" into the search form ""(.*)"" field")]
        public void WhenIEnterValueIntoTheSearchFormField(string value, string fieldName)
        {
            _findOwnersPage.ClickSearchOwnerForm();
            _findOwnersPage.FillSearchField(value);


        }
        [Then(@"I should see a warning message for the owner search ""(.*)"" field")]
        public void ThenIShouldSeeWarningForSearchField(string fieldName)
        {

            bool isErrorDisplayed = _findOwnersPage.IsSearchErrorDisplayed();

            Assert.That(isErrorDisplayed, Is.True,
                $"Expected a validation error for the '{fieldName}' field during search, but none was found.");
        }


    }
}
