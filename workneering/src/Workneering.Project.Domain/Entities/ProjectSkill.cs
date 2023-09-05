using Workneering.Base.Domain.Common;

namespace Workneering.Project.Domain.Entities;
public record ProjectSkill : BaseEntity
{
    private Guid _skillId;
    private string _name;

    public ProjectSkill(Guid skillId, string name)
    {
        _skillId = skillId;
        _name = name;
    }
    public ProjectSkill()
    {
    }
    public Guid SkillId { get => _skillId; private set => _skillId = value; }
    public string Name { get => _name; private set => _name = value; }

    public void UpdateSkillId(Guid field)
    {
        _skillId = field;
    }

}
