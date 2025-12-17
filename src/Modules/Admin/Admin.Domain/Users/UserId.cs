using Shared.Domain.Common;

namespace Admin.Domain.Users;

public sealed class UserId : ValueObject
{
    public Guid Value { get; }

    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId New()
        => new(Guid.NewGuid());

    public static UserId From(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("UserId cannot be empty.");

        return new UserId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();
}
