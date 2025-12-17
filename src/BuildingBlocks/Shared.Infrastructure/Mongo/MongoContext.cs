using MongoDB.Driver;
using Shared.Domain.Common;

namespace Shared.Infrastructure.Mongo;

public sealed class MongoContext
{
    private readonly IMongoDatabase _database;

    public MongoContext(MongoSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        _database = client.GetDatabase(settings.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string moduleName)
        where T : BaseEntity
    {
        var collectionName = CollectionNameResolver.Resolve<T>(moduleName);
        return _database.GetCollection<T>(collectionName);
    }
}
