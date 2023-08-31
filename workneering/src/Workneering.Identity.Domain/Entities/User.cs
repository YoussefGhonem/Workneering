using Workneering.Base.Domain.Common;
using Workneering.Base.Domain.Interfaces;
using Workneering.Shared.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Workneering.Identity.Domain.Entities
{
    public class User : IdentityUser<Guid>, ISoftDelete, ICreatedAuditableEntity, IModifiedAuditableEntity
    {
        #region Backing Fields 
        private UserStatusEnum? _status;
        private string? _firstName;
        private string? _lastName;
        // Audit
        private DateTimeOffset _createdDate;
        private Guid? _createdBy;
        private DateTimeOffset? _lastModifiedDate;
        private Guid? _lastModifiedBy;
        #endregion 

        #region public Fields
        public UserStatusEnum? Status
        {
            get => _status;
            private set => _status = value;
        }
        public string? FirstName
        {
            get => _firstName;
            private set => _firstName = value;
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

        public void MarkAsNotDeleted()
        {
            IsDeleted = false;
            DeletedBy = null;

        }
        #endregion

    }
}
