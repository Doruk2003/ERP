using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Admin.Infrastructure.Persistence.Documents;

public sealed class UserDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; } = null!;

    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public bool IsDeleted { get; set; }
}
