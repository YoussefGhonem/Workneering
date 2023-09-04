using Workneering.Base.Domain.Common;

namespace Workneering.Project.Domain.Entities
{
    public record ProjectSkill : BaseEntity
    {
        private string _name;
        private Guid? _skillId;

        public ProjectSkill(string name, Guid? skillId)
        {
            _name = name;
            _skillId = skillId ?? Id;
        }
        public ProjectSkill()
        {
        }
        public string Name { get => _name; private set => _name = value; }
        public Guid? SkillId { get => _skillId; private set => _skillId = value; }

        public void UpdateName(string field)
        {
            _name = field;
        }
        public void UpdateSkillId(Guid field)
        {
            _skillId = field;
        }
    }
}
