using MongoDB.Driver;
using Shared.Application.Abstractions;
using Shared.Domain.Common;
using Shared.Infrastructure.Mongo;

namespace Shared.Infrastructure.Repositories;

public abstract class MongoRepository<T>
    where T : AuditableEntity
{
    protected readonly IMongoCollection<T> Collection;
    private readonly IDomainEventDispatcher _domainEventDispatcher;

    protected MongoRepository(
        MongoContext context,
        IDomainEventDispatcher domainEventDispatcher,
        string moduleName
    )
    {
        _domainEventDispatcher = domainEventDispatcher;
        Collection = context.GetCollection<T>(moduleName);
    }

    protected async Task InsertAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
        await DispatchDomainEventsAsync(entity, cancellationToken);
    }

    protected async Task ReplaceAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Collection.ReplaceOneAsync(
            x => x.Id == entity.Id,
            entity,
            cancellationToken: cancellationToken
        );

        await DispatchDomainEventsAsync(entity, cancellationToken);
    }

    protected IQueryable<T> Query()
    {
        return Collection.AsQueryable().Where(x => !x.IsDeleted);
    }

    private async Task DispatchDomainEventsAsync(T entity, CancellationToken cancellationToken)
    {
        if (!entity.DomainEvents.Any())
            return;

        await _domainEventDispatcher.DispatchAsync(entity.DomainEvents, cancellationToken);
        entity.ClearDomainEvents();
    }
}
