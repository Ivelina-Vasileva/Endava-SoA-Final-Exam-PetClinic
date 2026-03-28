using NUnit.Framework;
using Reqnroll;
using RestSharp;
using SeleniumFramework.ApiTests.Apis;
using SeleniumFramework.ApiTests.Models.Builders;
using SeleniumFramework.ApiTests.Models.Dtos;
using SeleniumFramework.ApiTests.Utils.Constants;

namespace SeleniumFramework.ApiTests.Steps
{
    [Binding]
    public class PetApiSteps
    {
        private RestResponse <PetDto> _createPetResponse;
        private readonly PetsApi _petsApi;
        private ScenarioContext _scenarioContext;
        private readonly OwnersApi _ownersApi;


        public PetApiSteps(PetsApi petsApi, ScenarioContext scenarioContext, OwnersApi ownersApi)
        {
            _petsApi = petsApi;
            _scenarioContext = scenarioContext;
            _ownersApi = ownersApi;
        }

        [Given("I make a post request to pets endpoint with the following data:")]
        public void GivenIMakeAPostRequestToPetsEndpointWithTheFollowingData(Table table)
        {
            var row = table.Rows[0];

            if (OwnersApiSteps.SavedOwnerId <= 0)
            {
                var tempOwner = new OwnerBuilder().WithRandomValues().Build();
                var ownerResponse = _ownersApi.CreateOwner(tempOwner);
                OwnersApiSteps.SavedOwnerId = ownerResponse.Data.Id;
            }
                int savedOwnerId = OwnersApiSteps.SavedOwnerId;
                int typeId = int.Parse(row["typeId"]);

                var petPayload = new PetDto
                {
                    Name = row["name"],
                    BirthDate = row["birthDate"],
                    Type = new PetDto.PetType
                    {
                        Id = typeId,
                        Name = row["typeName"]
                    }
                };

                _createPetResponse = _petsApi.CreatePet(savedOwnerId, petPayload);
                _scenarioContext[ContextKeys.StatusCode] = (int)_createPetResponse.StatusCode;

                if (_createPetResponse.IsSuccessful && _createPetResponse.Data != null)
                {
                    _scenarioContext[ContextKeys.CreatedPetId] = _createPetResponse.Data.Id;
                }
            
        }

        [Then("created pet response should contain the following data:")]
        public void ThenCreatedPetResponseShouldContainTheFollowingData(Table table)
        {
            var expected = table.Rows[0];

            int savedOwnerId = OwnersApiSteps.SavedOwnerId;

            var createdPet = Newtonsoft.Json.JsonConvert.DeserializeObject<PetDto>(_createPetResponse.Content);

            Assert.Multiple(() =>
            {
                Assert.That(createdPet.Id, Is.GreaterThan(0), "Generated Pet ID should be a positive number!");
                Assert.That(createdPet.Name.ToString(), Is.EqualTo(expected["name"]));
                Assert.That(createdPet.OwnerId, Is.EqualTo(savedOwnerId));

                Assert.That(createdPet.Type.Name.ToString(), Is.EqualTo(expected["typeName"]));
                Assert.That(createdPet.Type.Id.ToString(), Is.EqualTo(expected["typeId"]));
            });
        }

    }
}

