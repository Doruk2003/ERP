using MediatR;
using Shared.Application.Abstractions;
using Shared.Domain.Common;

namespace Shared.Application.Behaviors;

public sealed class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IMediator _mediator;

    public DomainEventDispatcher(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task DispatchAsync(
        IEnumerable<DomainEvent> domainEvents,
        CancellationToken cancellationToken = default
    )
    {
        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent, cancellationToken);
        }
    }
}
