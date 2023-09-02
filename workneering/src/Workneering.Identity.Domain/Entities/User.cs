using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using Workneering.Base.Domain.Interfaces;
using Workneering.Base.Helpers.Models;
using Workneering.Identity.Domain.Entities.Claims;
using Workneering.Shared.Core.Enums;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Identity.Domain.Entities
{
    public class User : IdentityUser<Guid>, ISoftDelete, ICreatedAuditableEntity, IModifiedAuditableEntity
    {
        #region Backing Fields 
        private UserStatusEnum? _status;
        private string? _firstName;
        private string? _lastName;
        private Guid? _countryId;
        private string? _phoneNumber;
        private FileDto? _Image;
        // Audit
        private DateTimeOffset _createdDate;
        private Guid? _createdBy;
        private DateTimeOffset? _lastModifiedDate;
        private Guid? _lastModifiedBy;
        // Collections
        private readonly HashSet<UserRole> _userRoles = new();
        private readonly HashSet<UserClaim> _claims = new();
        private readonly HashSet<UserLogin> _logins = new();
        private readonly HashSet<UserToken> _tokens = new();

        #endregion
        public User(string firstName, string lastName, string email, Guid? countryId = null)
        {
            _firstName = Guard.Against.NullOrWhiteSpace(firstName, nameof(firstName));
            _lastName = Guard.Against.NullOrWhiteSpace(lastName, nameof(lastName));
            _countryId = countryId;
            Email = Guard.Against.NullOrWhiteSpace(email, nameof(email));
            UserName = Email;

            MarkAsCreated(CurrentUser.Id);
        }

        #region public Fields
        public FileDto? Image
        {
            get => _Image;
            private set => _Image = value;
        }

        public UserStatusEnum? Status
        {
            get => _status;
            private set => _status = value;
        }
        public Guid? CountryId
        {
            get => _countryId;
            private set => _countryId = value;
        }
        public string? FirstName
        {
            get => _firstName;
            private set => _firstName = value;
        }
        public string? PhoneNumber
        {
            get => _phoneNumber;
            private set => _phoneNumber = value;
        }
        public string? LastName
        {
            get => _lastName;
            private set => _lastName = value;
        }
        public bool IsDeleted { get; private set; }
        public DateTimeOffset? DeletedDate { get; private set; }
        public Guid? DeletedBy { get; private set; }
        // Audit
        public Guid? CreatedBy
        {
            get => _createdBy;
            private set => _createdBy = value;
        }

        public DateTimeOffset CreatedDate
        {
            get => _createdDate;
            private set => _createdDate = value;
        }

        public Guid? LastModifiedBy
        {
            get => _lastModifiedBy;
            private set => _lastModifiedBy = value;
        }

        public DateTimeOffset? LastModifiedDate
        {
            get => _lastModifiedDate;
            private set => _lastModifiedDate = value;
        }

        public virtual IReadOnlyCollection<UserRole> UserRoles => _userRoles;
        public virtual IReadOnlyCollection<UserClaim> Claims => _claims;
        public virtual IReadOnlyCollection<UserLogin> Logins => _logins;
        public virtual IReadOnlyCollection<UserToken> Tokens => _tokens;
        #endregion

        #region Public Methods
        public void MarkAsCreated(Guid? userId)
        {
            _createdDate = DateTimeOffset.UtcNow;
            _createdBy = userId;
        }

        public void MarkAsModified(Guid? userId)
        {
            _lastModifiedDate = DateTimeOffset.UtcNow;
            _lastModifiedBy = userId;
        }
        public void MarkAsDeleted(Guid? userId)
        {
            IsDeleted = true;
            DeletedDate = DateTimeOffset.UtcNow;
            DeletedBy = userId;
        }

        public void AddUserRole(UserRole userRole)
        {
            if (_userRoles.Select(x => x.RoleId).Contains(userRole.RoleId)) return;
            _userRoles.Add(userRole);
        }

        public void SetFirstName(string? firstName)
        {
            if (string.IsNullOrEmpty(firstName) ||
                string.Equals(_firstName, firstName, StringComparison.CurrentCultureIgnoreCase)) return;



            _firstName = Guard.Against.NullOrWhiteSpace(firstName, nameof(firstName));
        }
        public void SetCountryId(Guid? field)
        {
            _countryId = field;
        }

        public void SetLastName(string? lastName)
        {
            if (string.IsNullOrEmpty(lastName) ||
                string.Equals(_lastName, lastName, StringComparison.CurrentCultureIgnoreCase)) return;
            _lastName = Guard.Against.NullOrWhiteSpace(lastName, nameof(lastName));
        }
        public void MarkAsNotDeleted()
        {
            IsDeleted = false;
            DeletedBy = null;

        }
        #endregion

    }
}
