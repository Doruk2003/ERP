using Shared.Domain.Common;

namespace Shared.Application.Abstractions;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(
        IEnumerable<DomainEvent> domainEvents,
        CancellationToken cancellationToken = default
    );
}
