using Admin.Application.Common;
using MediatR;

namespace Admin.Application.Users.Create;

public sealed record CreateUserCommand(
    string Email,
    string FirstName,
    string LastName
) : IRequest<Result>;
