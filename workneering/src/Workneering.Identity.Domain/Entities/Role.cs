using Microsoft.AspNetCore.Identity;
using Workneering.Identity.Domain.Entities.Claims;

namespace Workneering.Identity.Domain.Entities
{
    public class Role : IdentityRole<Guid>
    {
        private string _displayName;
        private readonly ICollection<RoleClaim> _roleClaims;

        public Role(string name, string displayName)
        {
            Name = name;
            _displayName = displayName;
            NormalizedName = name.ToUpper();
        }

        public string DisplayName
        {
            get => _displayName;
            private set => _displayName = value;
        }

        public virtual ICollection<RoleClaim> RoleClaims => _roleClaims;
    }
}
