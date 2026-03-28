using RestSharp;
using SeleniumFramework.ApiTests.Models.Dtos;

namespace SeleniumFramework.ApiTests.Apis;

public class OwnersApi(RestClient restClient)
{
    private readonly RestClient _client = restClient;
    private readonly string _uri = "owners";

    public RestResponse<List<OwnerDto>> GetAllOwners()
    {
        var request = new RestRequest(_uri, Method.Get);
        return _client.Execute<List<OwnerDto>>(request);
    }
    public RestResponse<OwnerDto> CreateOwner(OwnerDto owner)
    {
        var request = new RestRequest(_uri, Method.Post);
        request.AddJsonBody(owner);
        return _client.Execute<OwnerDto>(request);
    }
}