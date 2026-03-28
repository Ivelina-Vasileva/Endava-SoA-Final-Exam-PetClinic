using Reqnroll;
using SeleniumFramework.Models;
using SeleniumFramework.Models.Factories;
using SeleniumFramework.Pages;
using SeleniumFramework.Utilities.Constants;

namespace SeleniumFramework.Steps
{
    [Binding]
    public class PetSteps
    {
        private readonly AddPetPage _addPetPage;
        private readonly OwnerInformationPage _ownerInfoPage;
        private readonly ScenarioContext _scenarioContext;
        private readonly PetModelFactory _petModelFactory;

        public PetSteps(AddPetPage addPetPage, ScenarioContext scenarioContext, OwnerInformationPage ownerInfoPage, PetModelFactory petModelFactory)
        {
            _addPetPage = addPetPage;
            _scenarioContext = scenarioContext;
            _ownerInfoPage = ownerInfoPage;
            _petModelFactory = petModelFactory;
        }

        [When("I fill in valid pet details")]
        public void WhenIFillInValidPetDetails()
        {
            PetModel newPet = _petModelFactory.CreateRandomPet();

            _addPetPage.FillPetDetails(newPet);

            _scenarioContext[ContextKeys.NewPet] = newPet;
        }

        [Then("I should see the details of the newly created pet in the profile table")]
        public void ThenIShouldSeeTheDetailsOfTheNewlyCreatedPet()
        {
            var newPet = _scenarioContext.Get<PetModel>(ContextKeys.NewPet);
            bool exists = _ownerInfoPage.IsPetPresent(newPet);

            Assert.That(exists, Is.True,
                $"Could not find a pet record matching Name: {newPet.Name}, " +
                $"Birth Date: {newPet.Birthdate}, Type: {newPet.Type}");
        }

        [When(@"I enter ""(.*)"" into the pet ""(.*)"" field")]
        public void WhenIEnterValueIntoPetField(string value, string fieldName)
        {
            _addPetPage.FillField(fieldName, value);
        }

        [Then(@"I should see a warning message for the pet ""(.*)"" field")]
        public void ThenIShouldSeePetWarning(string fieldName)
        {
            Assert.That(_addPetPage.HasErrorForField(fieldName), Is.True,
                $"Expected a validation error for pet field '{fieldName}' but none was found.");
        }
    }
}
