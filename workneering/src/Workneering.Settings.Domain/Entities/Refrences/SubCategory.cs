using Workneering.Base.Domain.Common;

namespace Workneering.Settings.Domain.Entities.Refrences
{
    public record SubCategory : RefrenceEntity
    {
        public SubCategory(string name) : base(name) { }

        private List<Skill> _skills = new();

        public List<Skill> Skills => _skills;

        #region Skills
        public void UpdateSkills(Guid id, Skill field)
        {
            var skill = _skills.FirstOrDefault(x => x.Id == id);
            skill.UpdateName(field.Name);
            skill.UpdateDescription(field.Description);
        }
        public void RemoveSkills(Guid id)
        {
            var skill = _skills.FirstOrDefault(x => x.Id == id);
            skill.MarkAsDeleted(null);
        }
        #endregion
    }
}
