using System.Xml.Linq;
using Workneering.Base.Domain.Common;

namespace Workneering.Settings.Domain.Entities.Refrences
{
    public record Category : RefrenceEntity
    {
        public Category(string name) : base(name) { }

        private List<Skill> _skills = new();
        private bool _isMain;

        public bool IsMain { get => _isMain; private set => _isMain = value; }
        public List<Skill> Skills => _skills;


        public void UpdateIsMain(bool field)
        {
            _isMain = field;
        }

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
