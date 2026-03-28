using RestSharp;
using SeleniumFramework.ApiTests.Models.Dtos;

namespace SeleniumFramework.ApiTests.Apis
{
    public class PetsApi
    {
        private readonly RestClient _client;
        private readonly string _uri;

        public PetsApi(RestClient restClient)
        {
            _client = restClient;
            _uri = "pettypes";
        }
        public RestResponse<List<PetDto>> GetPetTypes()
        {
            var request = new RestRequest(_uri, Method.Get);
            return _client.Execute<List<PetDto>>(request);
        }

        public RestResponse<PetDto> CreatePet(int ownerId, PetDto pet)
        {
            var request = new RestRequest($"owners/{ownerId}/pets", Method.Post);
            request.AddJsonBody(pet);

            return _client.Execute<PetDto>(request);
        }
        public RestResponse<PetDto> GetPetById(int ownerId, int petId)
        {
            var request = new RestRequest($"/owners/{ownerId}/pets/{petId}", Method.Get);
            return _client.Execute<PetDto>(request);
        }
        public RestResponse DeletePet(int petId)
        {
            var request = new RestRequest($"pets/{petId}", Method.Delete);
            return _client.Execute(request);
        }
    }
}