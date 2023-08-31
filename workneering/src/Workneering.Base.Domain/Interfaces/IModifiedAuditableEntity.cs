namespace Workneering.Base.Domain.Interfaces;

public interface IModifiedAuditableEntity
{
    public DateTimeOffset? LastModifiedDate { get; }
    public Guid? LastModifiedBy { get; }
    public void MarkAsModified(Guid? userId);
}