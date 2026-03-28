namespace SeleniumFramework.Models.Factories
{
    using SeleniumFramework.Models.Builders;

    public class PetModelFactory
    {
        public PetModel CreateDefaultPet()
        {
            return new PetModelBuilder()
                .WithDefaultValues()
                .Build();
        }

        public PetModel CreateRandomPet()
        {
            return new PetModelBuilder()
                .WithRandomValues()
                .Build();
        }
    }
}