using Workneering.Base.Domain.Common;

namespace Workneering.Settings.Domain.Entities.Refrences
{
    public record SubCategory : BaseEntity
    {
        private string _name;
        private List<Skill> _skills = new();
        public SubCategory(string name, List<Skill> _skills)
        {
            _name = name;
            _skills.AddRange(Skills);
        }
        public SubCategory()
        {

        }
        public string Name { get => _name; private set => _name = value; }
        public List<Skill> Skills => _skills;

        #region Skills
        public void UpdateSkills(Guid id, Skill field)
        {
            var skill = _skills.FirstOrDefault(x => x.Id == id);
            skill.UpdateName(field.Name);
        }
        public void RemoveSkills(Guid id)
        {
            var skill = _skills.FirstOrDefault(x => x.Id == id);
            skill.MarkAsDeleted(null);
        }

        public void UpdateName(string field)
        {
            Name = field;
        }
        #endregion
    }
}
