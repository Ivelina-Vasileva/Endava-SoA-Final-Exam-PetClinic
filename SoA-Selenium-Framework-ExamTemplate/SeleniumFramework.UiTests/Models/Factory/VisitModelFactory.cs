namespace SeleniumFramework.Models.Factories
{
    using SeleniumFramework.Models.Builders;

    public class VisitModelFactory
    {
        public VisitModel CreateRandomVisit()
        {
            return new VisitModelBuilder()
                .WithRandomValues()
                .Build();
        }
    }
}