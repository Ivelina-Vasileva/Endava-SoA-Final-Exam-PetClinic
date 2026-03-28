using Reqnroll;
using SeleniumFramework.Pages;

namespace SeleniumFramework.Steps
{
    [Binding]
    public class SharedSteps
    {
        private readonly FindOwnersPage _findOwnersPage;
        private readonly AddOwnerPage _addOwnerPage;
        private readonly OwnerInformationPage _ownerInfoPage;
        private readonly AddPetPage _addPetPage;
        private readonly AddVisitPage _addVisitPage;

        public SharedSteps(
            FindOwnersPage findOwnersPage,
            AddOwnerPage addOwnerPage,
            OwnerInformationPage ownerInfoPage,
            AddPetPage addPetPage,
            AddVisitPage addVisitPage
        )
        {
            _findOwnersPage = findOwnersPage;
            _addOwnerPage = addOwnerPage;
            _ownerInfoPage = ownerInfoPage;
            _addPetPage = addPetPage;
            _addVisitPage = addVisitPage;
        }

        [When("I click the {string} button")]
        [When("I click the {string} button.")]
        [When(@"I click the {string} Link.")]
        [When("I click the {string} button on the form.")]
        [When("I click the {string} submit button on the form.")]
        public void WhenIClickTheButton(string buttonName)
        {
            switch (buttonName)
            {
                case "Find Owner":
                    _findOwnersPage.ClickFindOwnersButton();
                    break;
                case "Add Owner Submit":
                    _addOwnerPage.ClickAddOwnerSubmitButton();
                    break;
                case "Add New Pet":
                    _ownerInfoPage.ClickAddNewPetButton();
                    break;
                case "Add Pet":
                    _addPetPage.ClickAddPetButton();
                    break;
                case "Add Owner":
                    _addOwnerPage.ClickAddOwnerLink();
                    break;
                case "Add Visit":
                    _addVisitPage.ClickAddVisitButton();
                    break;
                default:
                    throw new System.ArgumentException($"The button '{buttonName}' is not defined in SharedSteps!");
            }
        }
    }
}
