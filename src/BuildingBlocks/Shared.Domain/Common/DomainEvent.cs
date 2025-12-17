namespace Shared.Domain.Common;

public abstract class DomainEvent
{
    protected DomainEvent()
    {
        OccurredOn = DateTime.UtcNow;
    }

    public DateTime OccurredOn { get; }
}
