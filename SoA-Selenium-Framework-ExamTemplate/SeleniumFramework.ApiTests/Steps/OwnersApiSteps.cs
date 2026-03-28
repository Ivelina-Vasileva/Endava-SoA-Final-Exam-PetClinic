using Newtonsoft.Json;
using NUnit.Framework;
using Reqnroll;
using RestSharp;
using SeleniumFramework.ApiTests.Apis;
using SeleniumFramework.ApiTests.Models.Dtos;
using SeleniumFramework.ApiTests.Utils.Constants;

namespace SeleniumFramework.ApiTests.Steps
{
    [Binding]
    public class OwnersApiSteps
    {
        public static int SavedOwnerId;
        private readonly OwnersApi _ownersApi;
        private RestResponse _response;
        private ScenarioContext _scenarioContext;

        public OwnersApiSteps(OwnersApi ownersApi, ScenarioContext scenarioContext)
        {
            _ownersApi = ownersApi;
            _scenarioContext = scenarioContext;
        }

        [When("I send a GET request to the owners API")]
        public void WhenISendAGetRequestToOwnersApi()
        {
            _response = _ownersApi.GetAllOwners();

            _scenarioContext[ContextKeys.StatusCode] = (int)_response.StatusCode;
            _scenarioContext[ContextKeys.RawResponse] = _response.Content;

            Assert.That(_response.ContentType, Does.Contain("application/json"));
        }

        [Then("the response should contain a list of owners")]
        public void ThenTheResponseShouldContainAListOfOwners()
        {
            var owners = JsonConvert.DeserializeObject<List<OwnerDto>>(_response.Content);
            Assert.That(owners, Is.Not.Null, "Owners list is null!");
            Assert.That(owners.Count, Is.GreaterThan(0), "Owners list is empty!");

            var firstOwner = owners[0];

            Assert.Multiple(() =>
            {
                Assert.That(firstOwner.Id, Is.GreaterThan(0), "ID should be a positive number");
                Assert.That(firstOwner.FirstName, Is.Not.Null.And.Not.Empty, "FirstName is empty");
                Assert.That(firstOwner.LastName, Is.Not.Null.And.Not.Empty, "LastName is empty");
                Assert.That(firstOwner.Address, Is.Not.Null.And.Not.Empty, "Address is empty");
                Assert.That(firstOwner.City, Is.Not.Null.And.Not.Empty, "City is empty");
                Assert.That(firstOwner.Telephone, Is.Not.Null.And.Not.Empty, "Telephone is empty");
            });

            SavedOwnerId = owners[0].Id;
        }
    }

}

