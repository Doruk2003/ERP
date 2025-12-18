using Shared.Domain.Common;

namespace Admin.Domain.Roles;

public sealed class Role : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; } = default!;

    private readonly List<Permission> _permissions = new();
    public IReadOnlyCollection<Permission> Permissions => _permissions.AsReadOnly();

    private Role() { }

    public Role(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Role name is required.");

        Name = name.Trim();
        SetCreated(null);
    }

    public void AddPermission(Permission permission)
    {
        if (_permissions.Any(p => p.Code == permission.Code))
            return;

        _permissions.Add(permission);
        SetModified(null);
    }
}
