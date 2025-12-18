using MongoDB.Driver;

namespace Admin.Infrastructure.Persistence;

public sealed class AdminMongoContext
{
    private readonly IMongoDatabase _database;

    public AdminMongoContext(IMongoDatabase database)
    {
        _database = database;
    }

    public IMongoCollection<T> GetCollection<T>(string name)
        => _database.GetCollection<T>(name);
}
