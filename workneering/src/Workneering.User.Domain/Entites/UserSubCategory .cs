using Workneering.Base.Domain.Common;

namespace Workneering.User.Domain.Entites
{
    public record UserSubCategory : BaseEntity
    {
        private Guid _subCategoryId;

        public UserSubCategory()
        {

        }
        public UserSubCategory(Guid subCategoryId)
        {
            _subCategoryId = subCategoryId;
        }

        public Guid SubCategoryId { get => _subCategoryId; private set => _subCategoryId = value; }

        public void UpdateSubCategoryId(Guid field)
        {
            _subCategoryId = field;
        }

    }
}
