using Reqnroll;
using SeleniumFramework.ApiTests.Apis;
using SeleniumFramework.ApiTests.Models.Builders;
using SeleniumFramework.ApiTests.Models.Dtos;
using SeleniumFramework.ApiTests.Steps;
using SeleniumFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumFramework.ApiTests.Utils.Constants;

namespace SeleniumFramework.ApiTests.Hooks
{
    [Binding]
    public class CreationHooks
    {
        private readonly SettingsModel _settings;
        private readonly ScenarioContext _scenarioContext;
        private readonly PetsApi _petsApi;
        private readonly OwnersApi _ownersApi;

        public CreationHooks(SettingsModel settings, ScenarioContext scenarioContext, PetsApi petsApi, OwnersApi ownersApi)
        {
            this._settings = settings;
            _scenarioContext = scenarioContext;
            _petsApi = petsApi;
            _ownersApi = ownersApi;
        }

        [BeforeScenario("@CreateOwner")]
        public void EnsureOwnerExists()
        {
            if (OwnersApiSteps.SavedOwnerId <= 0)
            {
                var tempOwner = new OwnerBuilder().WithRandomValues().Build();

                var response = _ownersApi.CreateOwner(tempOwner);
                OwnersApiSteps.SavedOwnerId = response.Data.Id;
            }
        }

        [BeforeScenario("@CreatePet")]
        public void SetupPetData()
        {
            PetDto petToCreate = new PetDto();
            petToCreate.Name = "ApiTestPet";
            petToCreate.BirthDate = "2024-01-01";
            petToCreate.Type = new PetDto.PetType { Id = 1, Name = "dog" };

            int testOwnerId = 1;
            var response = _petsApi.CreatePet(testOwnerId, petToCreate);

            if (response.IsSuccessful && response.Data != null)
            {
                _scenarioContext[ContextKeys.CreatedPetId] = response.Data.Id;
                _scenarioContext[ContextKeys.NewPet] = response.Data;
                Console.WriteLine($"Created pet with ID: {response.Data.Id}");
            }
        }

        [AfterScenario("@DeletePet")]
        public void DeletePet()
        {
            if (_scenarioContext.ContainsKey("CreatedPetId"))
            {
                int id = _scenarioContext.Get<int>(ContextKeys.CreatedPetId);
                var response = _petsApi.DeletePet(id);
                if (response.IsSuccessful)
                {
                    Console.WriteLine($"Successfully deleted API pet with ID: {id}");
                }
            }
        }

    }
}
