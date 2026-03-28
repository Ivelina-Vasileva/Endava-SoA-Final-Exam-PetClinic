using Bogus;

namespace SeleniumFramework.Models.Builders
{
    public class VisitModelBuilder
    {
        private VisitModel _visitModel;

        public VisitModelBuilder()
        {
            _visitModel = new VisitModel();
        }

        public VisitModelBuilder WithDefaultValues()
        {
            _visitModel.Description = "Tooth cleaning";
            _visitModel.Date = "2026-09-07";

            return this;
        }

        public VisitModelBuilder WithRandomValues()
        {
            var faker = new Faker();

            _visitModel.Description = "Routine Checkup";
            _visitModel.Date = faker.Date.Soon(0).ToString("yyyy/MM/dd");

            return this;
        }

        public VisitModel Build()
        {
            return _visitModel;
        }
    }
}
