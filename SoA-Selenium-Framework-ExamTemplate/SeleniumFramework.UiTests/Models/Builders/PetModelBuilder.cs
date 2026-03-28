using Bogus;

namespace SeleniumFramework.Models.Builders
{
    public class PetModelBuilder
    {
        private PetModel _petModel;

        public PetModelBuilder()
        {
            _petModel = new PetModel();
        }

        public PetModelBuilder WithDefaultValues()
        {
            _petModel.Id = 1;
            _petModel.Name = "Leo";
            _petModel.Birthdate = "2010-09-07";
            _petModel.Type = "cat";

            return this;
        }

        public PetModelBuilder WithRandomValues()
        {
            var faker = new Faker();

            _petModel.Name = $"{faker.Name.FirstName()}{faker.UniqueIndex}";
            _petModel.Birthdate = faker.Date.Past(2).ToString("yyyy-MM-dd");
            _petModel.Type = "dog";

            return this;
        }

        public PetModel Build()
        {
            return _petModel;
        }
    }
}
