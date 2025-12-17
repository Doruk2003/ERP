namespace Shared.Domain.Common;

public abstract class AuditableEntity : BaseEntity
{
    public DateTime CreatedAt { get; protected set; }
    public string? CreatedBy { get; protected set; }

    public DateTime? ModifiedAt { get; protected set; }
    public string? ModifiedBy { get; protected set; }

    public bool IsDeleted { get; private set; }

    protected void SetCreated(string? createdBy)
    {
        CreatedAt = DateTime.UtcNow;
        CreatedBy = createdBy;
    }

    protected void SetModified(string? modifiedBy)
    {
        ModifiedAt = DateTime.UtcNow;
        ModifiedBy = modifiedBy;
    }

    public void MarkAsDeleted()
    {
        IsDeleted = true;
        SetModified(null);
    }
}
