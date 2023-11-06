using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using Workneering.Base.Domain.Interfaces;
using Workneering.Identity.Domain.Entities.Claims;
using Workneering.Identity.Domain.Entities.ValueObjects;
using Workneering.Shared.Core.Enums;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Identity.Domain.Entities
{
    public class User : IdentityUser<Guid>, ISoftDelete, ICreatedAuditableEntity, IModifiedAuditableEntity
    {
        #region Backing Fields 
        private UserStatusEnum? _status;
        private string? _name;
        private string? _imageAmazonKey;
        private string? _phoneNumber;
        private UserAddress? _address;
        private string? _provider;
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
        public User(string name, string email)
        {
            _name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Email = Guard.Against.NullOrWhiteSpace(email, nameof(email));
            UserName = Email;

            MarkAsCreated(CurrentUser.Id);
        }
        public User(string name, string email, string provider, string userName)
        {
            _name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Email = Guard.Against.NullOrWhiteSpace(email, nameof(email));
            Provider = Guard.Against.NullOrWhiteSpace(provider, nameof(provider));
            UserName = userName;
            MarkAsCreated(CurrentUser.Id);
        }

        #region public Fields

        public UserStatusEnum? Status
        {
            get => _status;
            private set => _status = value;
        }

        public string Name
        {
            get => _name;
            private set => _name = value;
        }
        public UserAddress Address
        {
            get => _address;
            private set => _address = value;
        }
        public string? PhoneNumber
        {
            get => _phoneNumber;
            private set => _phoneNumber = value;
        }
        public string? ImageKey
        {
            get => _imageAmazonKey;
            private set => _imageAmazonKey = value;
        }
        public string? Provider
        {
            get => _provider;
            private set => _provider = value;
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
        public void AddMessagesSent(string content)
        {
            //var message = new Message(content);
            //_messagesSent.Add(message);
        }
        public void AddMessagesReceived(string content)
        {
            //var message = new Message(content);
            //_messagesSent.Add(message);
        }
        public void MarkAsCreated(Guid? userId)
        {
            _createdDate = DateTimeOffset.UtcNow;
            _createdBy = userId;
        }
        public void UpdateAddress(UserAddress? field)
        {
            _address = field;
        }

        public void UpdatePhoneNumber(string phoneNumber)
        {
            _phoneNumber = phoneNumber;
        }
        public void UpdateName(string name)
        {
            _name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
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

        public void SetName(string? firstName)
        {
            if (string.IsNullOrEmpty(firstName) ||
                string.Equals(_name, firstName, StringComparison.CurrentCultureIgnoreCase)) return;
            _name = Guard.Against.NullOrWhiteSpace(firstName, nameof(firstName));
        }

        public void MarkAsNotDeleted()
        {
            IsDeleted = false;
            DeletedBy = null;

        }
        #endregion
    }
}
