using Shared.Domain.Common;

namespace Admin.Domain.Users.Events;

public sealed class UserCreatedDomainEvent : DomainEvent
{
    public UserId UserId { get; }
    public string Email { get; }

    public UserCreatedDomainEvent(UserId userId, string email)
    {
        UserId = userId;
        Email = email;
    }
}
