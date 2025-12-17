namespace Admin.Domain.Roles;

public sealed class Permission
{
    public string Code { get; } = null!;
    public string Description { get; } = null!;

    private Permission() { }

    public Permission(string code, string description)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("Permission code is required.");

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Permission description is required.");

        Code = code.Trim().ToUpperInvariant();
        Description = description.Trim();
    }
}
