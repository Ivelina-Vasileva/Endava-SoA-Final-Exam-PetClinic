using Bogus;

namespace SeleniumFramework.Models.Builders
{
    public class OwnerModelBuilder
    {
        private OwnerModel _ownerModel;

        public OwnerModelBuilder()
        {
            _ownerModel = new OwnerModel();
        }

        public OwnerModelBuilder WithDefaultValues()
        {
            _ownerModel.Id = 1;
            _ownerModel.FirstName = "George";
            _ownerModel.LastName = "Franklin";
            _ownerModel.Address = "110 W. Liberty St.";
            _ownerModel.City = "Madison";
            _ownerModel.Telephone = "6085551023";

            return this;
        }

        public OwnerModelBuilder WithRandomValues()
        {
            var faker = new Faker("en");

            _ownerModel.FirstName = faker.Name.FirstName();
            _ownerModel.LastName = faker.Name.LastName();
            _ownerModel.Address = faker.Address.StreetAddress();
            _ownerModel.City = faker.Address.City();
            _ownerModel.Telephone = faker.Phone.PhoneNumber("0#########");

            return this;
        }

        public OwnerModel Build()
        {
            return _ownerModel;
        }
    }
}
