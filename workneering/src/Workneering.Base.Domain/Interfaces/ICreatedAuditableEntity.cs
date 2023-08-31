namespace Workneering.Base.Domain.Interfaces;

public interface ICreatedAuditableEntity
{
    public DateTimeOffset CreatedDate { get; }
    public Guid? CreatedBy { get; }
    public void MarkAsCreated(Guid? userId);
}