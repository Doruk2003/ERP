using Admin.Application.Abstractions.Persistence;
using Admin.Domain.Users;
using Admin.Infrastructure.Persistence.Documents;
using MongoDB.Driver;

namespace Admin.Infrastructure.Persistence.Repositories;

public sealed class UserRepository : IUserRepository
{
    private const string CollectionName = "Admin_User";
    private readonly IMongoCollection<UserDocument> _collection;

    public UserRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<UserDocument>(CollectionName);
    }

    public async Task<bool> EmailExistsAsync(
        string email,
        CancellationToken cancellationToken = default)
    {
        var filter = Builders<UserDocument>.Filter.And(
            Builders<UserDocument>.Filter.Eq(x => x.Email, email),
            Builders<UserDocument>.Filter.Eq(x => x.IsDeleted, false));

        return await _collection
            .Find(filter)
            .AnyAsync(cancellationToken);
    }

    public async Task AddAsync(
        User user,
        CancellationToken cancellationToken = default)
    {
        var document = new UserDocument
        {
            Id = user.Id.ToString(),
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            IsDeleted = false
        };

        await _collection.InsertOneAsync(document, cancellationToken: cancellationToken);
    }
}
