using Core.Entities.RecipeAggregate;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Builders
{
    public class RecipeBuilder
    {
        private Recipe _recipe;

        public int TestId => 1;
        public string TestCreatedBy => "createdByUser";
        public string TestModifiedBy => "modifiedByUser";
        public string TestName => "Test Recipe";
        public int TestServings => 5;
        public TimeSpan TestPrep => TimeSpan.FromMinutes(15);
        public TimeSpan TestCook => TimeSpan.FromMinutes(30);
        public TimeSpan TestReady => TimeSpan.FromMinutes(60);
        public string TestExternalUrl => "https://www.google.com";

        public RecipeBuilder()
        {
            _recipe = WithDefaultValues();
        }

        public Recipe WithDefaultValues()
        {
            _recipe = new Recipe()
            {
                Id = TestId,
                CreatedBy = TestCreatedBy,
                ModifiedBy = TestModifiedBy,
                Name = TestName,
                Servings = TestServings,
                Prep = TestPrep,
                Cook = TestCook,
                Ready = TestReady,
                ExternalUrl = TestExternalUrl
            };

            return _recipe;
        }
    }

    public class RecipeSpecificationBuilder : BaseSpecification<Recipe>
    {
        public RecipeSpecificationBuilder(int id) : base(x => x.Id == id) {}
    }
}
