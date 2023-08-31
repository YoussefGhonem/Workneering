using Microsoft.AspNetCore.Identity;

namespace Workneering.Identity.Domain.Entities
{
    // This class represents the class that defines the authentication tokens associated with a user.
    //  These tokens are used for various purposes like password reset tokens,
    //  email confirmation tokens, two-factor authentication tokens, etc.
    public class UserToken : IdentityUserToken<Guid>
    {
        public virtual User User { get; set; }
    }
}
