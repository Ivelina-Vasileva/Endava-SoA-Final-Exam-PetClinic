using Reqnroll;
using SeleniumFramework.Models;
using SeleniumFramework.Models.Factories;
using SeleniumFramework.Pages;
using SeleniumFramework.Utilities.Extensions;

namespace SeleniumFramework.Steps
{
    [Binding]
    public class VisitSteps
    {
        private readonly AddVisitPage _addVisitPage;
        private readonly ScenarioContext _scenarioContext;
        private readonly OwnerInformationPage _ownerInfoPage;
        private readonly PetModel _defaultPet;
        private readonly OwnerModel _defaultOwner;
        private readonly OwnerModelFactory _ownerModelFactory;
        private readonly PetModelFactory _petModelFactory;
        private readonly VisitModelFactory _visitModelFactory;

        public VisitSteps(AddVisitPage addVisitPage, ScenarioContext scenarioContext, OwnerInformationPage ownerInfoPage, PetModelFactory petModelFactory, OwnerModelFactory ownerModelFactory, VisitModelFactory visitModelFactory)
        {
            _addVisitPage = addVisitPage;
            _scenarioContext = scenarioContext;
            _ownerInfoPage = ownerInfoPage;

            _petModelFactory = petModelFactory;
            _ownerModelFactory = ownerModelFactory;
            _visitModelFactory = visitModelFactory;

            _defaultPet = _petModelFactory.CreateDefaultPet();
            _defaultOwner = _ownerModelFactory.CreateDefaultOwner();
        }

        [When("I click the \"Add Visit\" link next to the pet's name")]
        public void WhenIClickTheAddVisitLink()
        {
            var owner = _scenarioContext.ContainsKey("CreatedOwner")
                ? _scenarioContext.Get<OwnerModel>("CreatedOwner")
                : _defaultOwner;
            var pet = _scenarioContext.ContainsKey("CreatedPet")
              ? _scenarioContext.Get<PetModel>("CreatedPet")
              : _defaultPet;

            _addVisitPage.ClickAddVisitForPet((int)_defaultOwner.Id, (int)_defaultPet.Id);
        }

        [When("The visit page displays correct pet information")]
        public void WhenTheVisitPageDisplaysCorrectPetInformation()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_addVisitPage.GetPetNameText(), Is.EqualTo(_defaultPet.Name), "Pet name mismatch on form!");
                Assert.That(
                    _addVisitPage.GetPetBirthDateText(),
                    Is.EqualTo(_defaultPet.Birthdate.Replace("-", "/")),
                    "Pet birth date mismatch on form!"
                ); Assert.That(_addVisitPage.GetPetTypeText(), Is.EqualTo(_defaultPet.Type), "Pet type mismatch on form!");
                Assert.That(_addVisitPage.GetOwnerNameText(), Is.EqualTo($"{_defaultOwner.FirstName} {_defaultOwner.LastName}"), "Owner name mismatch on form!");
            });
        }

        [When("I fill in valid visit details")]
        public void WhenIFillInValidVisitDetails()
        {
            var randomVisit = _visitModelFactory.CreateRandomVisit();

            _scenarioContext["VisitDescription"] = randomVisit.Description;
            _addVisitPage.FillVisitDetails(randomVisit);
        }

        [Then("I should see the visit description in the pet's visits table")]
        public void ThenIShouldSeeTheVisitDescriptionInTheTable()
        {
            var expectedDescription = _scenarioContext.Get<string>("VisitDescription");

            bool visitExists = _ownerInfoPage.IsVisitPresentForPet(_defaultPet, expectedDescription);

            Assert.That(visitExists, Is.True,
                $"Could not find visit with description '{expectedDescription}' " +
                $"for pet matching Name: {_defaultPet.Name}, Birth Date: {_defaultPet.Birthdate}");
        }

        [When(@"I enter ""(.*)"" into the visit ""(.*)"" field")]
        public void WhenIEnterValueIntoVisitField(string value, string fieldName)
        {
            _addVisitPage.FillField(fieldName, value);
        }

        [Then(@"I should see a warning message for the visit ""(.*)"" field")]
        public void ThenIShouldSeeVisitWarning(string fieldName)
        {
            Assert.That(_addVisitPage.HasErrorForField(fieldName), Is.True,
                $"Validation Criteria Failed: Expected a visible error for visit field '{fieldName}'.");
        }
    }
}