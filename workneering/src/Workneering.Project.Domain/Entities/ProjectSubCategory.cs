using Workneering.Base.Domain.Common;

namespace Workneering.Project.Domain.Entities
{
    public record ProjectSubCategory : BaseEntity
    {
        private Guid _subCategoryId;
        private string _name;

        public ProjectSubCategory()
        {

        }
        public ProjectSubCategory(Guid subCategoryId, string name)
        {
            _subCategoryId = subCategoryId;
            _name = name;
        }

        public Guid SubCategoryId { get => _subCategoryId; private set => _subCategoryId = value; }
        public string Name { get => _name; private set => _name = value; }

        public void UpdateSubCategoryId(Guid field)
        {
            _subCategoryId = field;
        }

    }
}
