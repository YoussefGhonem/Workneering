using Workneering.Base.Domain.Common;

namespace Workneering.User.Domain.Entites
{
    public record ClientCategory : BaseEntity
    {
        private Guid _categoryId;

        public ClientCategory()
        {

        }
        public ClientCategory(Guid categoryId)
        {
            _categoryId = categoryId;
        }

        public Guid CategoryId { get => _categoryId; private set => _categoryId = value; }

        public void UpdateCategoryId(Guid field)
        {
            _categoryId = field;
        }

    }
}
