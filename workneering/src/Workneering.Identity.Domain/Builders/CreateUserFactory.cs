using Workneering.Identity.Domain.Entities;
using Workneering.Shared.Core.Identity.Enums;

namespace Workneering.Identity.Domain.Builders;

public class CreateUserFactory
{
    #region Private members

    // Basic Info
    private readonly string _name;
    private readonly Guid? _countryId;
    private readonly string _email;
    private string? _phoneNumber;
    private bool _changePassword;
    private string? _provider;
    private string? _userName;
    private string? ImageUrl;

    // Business
    private HashSet<UserRole> _newUserRoles = new();

    #endregion

    public CreateUserFactory(
        string name,
        string email)
    {
        _name = name;
        _email = email;
    }

    public CreateUserFactory WithPhoneNumber(string? phoneNumber)
    {
        _phoneNumber = phoneNumber;
        return this;
    }
    public CreateUserFactory WithProvider(string? provider)
    {
        _provider = provider;
        return this;
    }
    public CreateUserFactory UserName(string? userName)
    {
        _userName = userName;
        return this;
    }


    public CreateUserFactory MustChangePasswordAtFirstLogin()
    {
        _changePassword = true;
        return this;
    }

    public CreateUserFactory WithRoles(List<Role> rolesFromDatabase, params RolesEnum[] roles)
    {
        foreach (var roleName in roles)
        {
            var role = rolesFromDatabase.FirstOrDefault(x => x.Name == roleName.ToString());
            var userRole = new UserRole()
            {
                Role = role,
                RoleId = role.Id
            };
            _newUserRoles.Add(userRole);
        }

        return this;
    }

    public User Build()
    {
        // User Aggregate
        var user = new User(
            _name,
            _email
     );

        // Roles
        foreach (var userRole in _newUserRoles)
        {
            user.AddUserRole(userRole);
        }

        return user;
    }
    public User BuildProvider()
    {
        // User Aggregate
        var user = new User(
            _name,
        _email,
        _provider,
        _userName
     );

        // Roles
        foreach (var userRole in _newUserRoles)
        {
            user.AddUserRole(userRole);
        }

        return user;
    }
}