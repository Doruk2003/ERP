using Admin.Domain.Users.Events;
using Shared.Domain.Common;

namespace Admin.Domain.Users;

public sealed class User : AuditableEntity, IAggregateRoot
{
    public UserId Id { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;

    private User() { }

    private User(UserId id, string email, string firstName, string lastName)
    {
        Id = id;
        SetEmail(email);
        FirstName = firstName;
        LastName = lastName;

        SetCreated(null);

        AddDomainEvent(new UserCreatedDomainEvent(Id, Email));
    }

    public static User Create(string email, string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required.");

        if (!email.Contains('@'))
            throw new ArgumentException("Email format is invalid.");

        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("FirstName is required.");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("LastName is required.");

        return new User(UserId.New(), email.Trim().ToLowerInvariant(), firstName, lastName);
    }

    public void ChangeEmail(string email)
    {
        SetEmail(email);
        SetModified(null);
    }

    private void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required.");

        if (!email.Contains('@'))
            throw new ArgumentException("Email format is invalid.");

        Email = email.Trim().ToLowerInvariant();
    }
}
