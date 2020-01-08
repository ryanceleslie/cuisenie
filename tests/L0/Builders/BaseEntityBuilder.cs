using Core.Entities;
using Core.Specifications;

namespace L0.Builders
{
    public class BaseEntityBuilder
    {
        private BaseEntity _entity;

        public int TestId => 1;
        public string TestCreatedBy => "createdByUser";
        public string TestModifiedBy => "modifiedByUser";

        public BaseEntityBuilder()
        {
            _entity = WithDefaultValues();
        }

        public BaseEntity WithDefaultValues()
        {
            _entity = new BaseEntity()
            {
                Id = TestId,
                CreatedBy = TestCreatedBy,
                ModifiedBy = TestModifiedBy
            };

            return _entity;
        }
    }

    public class BaseEntitySpecificationBuilder : BaseSpecification<BaseEntity>
    {
        public BaseEntitySpecificationBuilder(int id) : base(x => x.Id == id)
        {

        }
    }
}
