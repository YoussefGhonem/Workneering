using System.Xml.Linq;
using Workneering.Base.Domain.Common;

namespace Workneering.Settings.Domain.Entities.Refrences
{
    public record Category : RefrenceEntity
    {
        public Category(string name) : base(name) { }

        private List<SubCategory> _subCategories = new();

        public List<SubCategory> SubCategories => _subCategories;

        public void UpdateSubCategory(Guid id, SubCategory field)
        {
            var skill = _subCategories.FirstOrDefault(x => x.Id == id);
            skill.UpdateName(field.Name);
            skill.UpdateDescription(field.Description);
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
