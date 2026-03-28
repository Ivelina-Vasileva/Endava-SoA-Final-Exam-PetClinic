namespace SeleniumFramework.Models.Factories
{
    using SeleniumFramework.Models.Builders;

    public class OwnerModelFactory
    {
        public OwnerModel CreateDefaultOwner()
        {
            return new OwnerModelBuilder()
                .WithDefaultValues()
                .Build();
        }

        public OwnerModel CreateRandomOwner()
        {
            return new OwnerModelBuilder()
                .WithRandomValues()
                .Build();
        }
    }
}