using SeleniumFramework.ApiTests.Models.Dtos;
using Bogus;

namespace SeleniumFramework.ApiTests.Models.Builders
{
    public class OwnerBuilder
    {
        private OwnerDto _ownerDto;
        public OwnerBuilder()
        {
            _ownerDto = new OwnerDto();
        }
        public OwnerBuilder WithRandomValues()
        {
            var faker = new Faker("en");

            _ownerDto.FirstName = faker.Name.FirstName();
            _ownerDto.LastName = faker.Name.LastName();
            _ownerDto.Address = faker.Address.StreetAddress();
            _ownerDto.City = faker.Address.City();
            _ownerDto.Telephone = faker.Phone.PhoneNumber("0#########");

            return this;
        }

        public OwnerDto Build()
        {
            return _ownerDto;
        }
    }
}
