using Workneering.Base.Domain.Common;

namespace Workneering.User.Domain.Entites;
public record FreelancerSkill : BaseEntity
{
    private string _name;
    private Guid? _skillId;

    public FreelancerSkill(string name, Guid? skillId)
    {
        _name = name;
        _skillId = skillId ?? Id;
    }
    public FreelancerSkill()
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
