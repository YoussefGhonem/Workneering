using Workneering.Base.Domain.Common;

namespace Workneering.Project.Domain.Entities
{
    public record ProjectCategory : BaseEntity
    {
        private Guid _categoryId;
        private string _name;

        public ProjectCategory()
        {

        }
        public ProjectCategory(Guid categoryId, string name)
        {
            _categoryId = categoryId;
            _name = name;
        }

        public Guid CategoryId { get => _categoryId; private set => _categoryId = value; }
        public string Name { get => _name; private set => _name = value; }

        public void UpdateCategoryId(Guid field)
        {
            _categoryId = field;
        }
        public void UpdateName(string field)
        {
            _name = field;
        }

    }
}
