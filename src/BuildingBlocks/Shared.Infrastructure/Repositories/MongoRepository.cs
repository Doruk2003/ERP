using MongoDB.Driver;
using Shared.Domain.Common;

namespace Shared.Infrastructure.Repositories;

public abstract class MongoRepository<T>
    where T : AuditableEntity
{
    protected readonly IMongoCollection<T> Collection;

    protected MongoRepository(IMongoDatabase database, string collectionName)
    {
        Collection = database.GetCollection<T>(collectionName);
    }

    public virtual async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
    }

    public virtual async Task UpdateAsync(
        FilterDefinition<T> filter,
        T entity,
        CancellationToken cancellationToken = default)
    {
        await Collection.ReplaceOneAsync(
            filter,
            entity,
            new ReplaceOptions { IsUpsert = false },
            cancellationToken);
    }

    public virtual async Task SoftDeleteAsync(
        FilterDefinition<T> filter,
        CancellationToken cancellationToken = default)
    {
        var update = Builders<T>.Update.Set(x => x.IsDeleted, true);
        await Collection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
    }

    public virtual async Task<T?> GetAsync(
        FilterDefinition<T> filter,
        CancellationToken cancellationToken = default)
    {
        return await Collection
            .Find(filter)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public virtual async Task<IReadOnlyList<T>> GetListAsync(
        FilterDefinition<T> filter,
        CancellationToken cancellationToken = default)
    {
        return await Collection
            .Find(filter)
            .ToListAsync(cancellationToken);
    }
}
