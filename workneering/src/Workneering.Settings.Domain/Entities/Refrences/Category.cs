using Workneering.Base.Domain.Common;

namespace Workneering.Settings.Domain.Entities.Refrences
{
    public record Category : BaseEntity
    {
        private string _name;
        private List<SubCategory> _subCategories = new();

        public Category()
        {

        }
        public Category(string name, List<SubCategory> subCategories)
        {
            _name = name;
            _subCategories.AddRange(subCategories);
        }
        public string Name { get => _name; private set => _name = value; }

        public List<SubCategory> SubCategories => _subCategories;

        public void UpdateName(string field)
        {
            Name = field;
        }

        public void UpdateSubCategory(Guid id, SubCategory field)
        {
            var skill = _subCategories.FirstOrDefault(x => x.Id == id);
            skill.UpdateName(field.Name);
        }
        public void AddSubCategory(SubCategory field)
        {
            _subCategories.Add(field);
        }
        public void RemoveSubCategory(Guid id)
        {
            var skill = _subCategories.FirstOrDefault(x => x.Id == id);
            if (skill != null)
                skill.MarkAsDeleted(null);
        }

    }
}
