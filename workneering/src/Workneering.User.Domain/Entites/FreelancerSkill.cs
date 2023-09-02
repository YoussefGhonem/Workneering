using Workneering.Base.Domain.Common;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.User.Domain.Entites;
public record FreelancerSkill : BaseEntity
{
    private string _name;
    private string _description;
    private bool _isSystemAdded;

    public FreelancerSkill(string name)
    {
        _name = name;
        _isSystemAdded = CurrentUser.Roles.Contains(Shared.Core.Identity.Enums.RolesEnum.SuperAdmin) ? true : false;
    }
    public FreelancerSkill()
    {

    }
    public string Name { get => _name; private set => _name = value; }
    public string Description { get => _description; private set => _description = value; }
    public bool IsSystemAdded { get => _isSystemAdded; private set => _isSystemAdded = value; }


    public void UpdateName(string field)
    {
        _name = field;
    }
    public void UpdateDescription(string field)
    {
        _description = field;
    }

}
